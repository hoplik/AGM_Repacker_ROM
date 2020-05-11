
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code_Decode_ROM
{
    public partial class Form1 : Form
    {
        readonly Functions fn = new Functions();
        internal string ROM_File_Path = string.Empty;   // Полный путь к файлу прошивки для распаковки
        internal string Decode_ROM_Path = string.Empty; // Полный путь к директории, в которую будет распакована прошивка
        internal List<byte> bin_head_bytes = new List<byte>(8); // Байты, считанные с прошивки
        internal List<byte> decode_head_bytes = new List<byte>(8); // Декодированные байты прошивки
        internal int last_byte = 1048576; // Последний ненулевой байт шапки прошивки заканчивая адресом 0х100000 (1 048 576)
        byte[] key_decode = new byte[8]; // Ключ расшифровки
        Header_Info H_I = new Header_Info();
        File_info_bytes[] F_I_B = Array.Empty<File_info_bytes>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_ROM_Path_Click(object sender, EventArgs e)
        {
            textBox_Orig.Text = string.Empty;
            textBox_After_Decode.Text = string.Empty;
            richTextBox_Parse.Text = string.Empty;
            ROM_File_Path = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ROM_File_Path = openFileDialog1.FileName;
                button_ROM_Path.Text = ROM_File_Path;
                Parse_Bin_Head();
            }
            else
            {
                if (bin_head_bytes != null) bin_head_bytes.Clear();
                button_ROM_Path.Text = "Путь к файлу прошивки";
                toolStripStatusLabel1.Text = "Выберите директорию и путь к файлу";
            }
        }

        private void Button_Unpack_Dir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Decode_ROM_Path = folderBrowserDialog1.SelectedPath;
                button_Unpack_Dir.Text = Decode_ROM_Path;
            }
            else
            {
                button_Unpack_Dir.Text = "Директория распаковки";
                toolStripStatusLabel1.Text = "Выберите директорию и путь к файлу";
                Decode_ROM_Path = string.Empty;
            }
            if (!string.IsNullOrEmpty(ROM_File_Path) && !string.IsNullOrEmpty(Decode_ROM_Path) && !backgroundWorker1.IsBusy)
            {
                button_Unpack.Visible = true;
                if (radioButton_Decode_Only.Checked) button_Unpack.Text = radioButton_Decode_Only.Text;
                else button_Unpack.Text = radioButton_Dec_Unpack.Text;
                toolStripStatusLabel1.Text = "Теперь можно распаковать прошивку";
            }
            else button_Unpack.Visible = false;
        }

        private void Button_Unpack_Click(object sender, EventArgs e)
        {
            StringBuilder key_string = new StringBuilder(textBox_Decode.Text);
            while (key_string.Length < 16) key_string.Insert(0, '0');
            int Start_Adress = Adress_to_Int(textBox_Start_Adress.Text);
            if (decode_head_bytes != null) decode_head_bytes.Clear();
            byte[] res_bytes = new byte[bin_head_bytes.Count];
            byte[] send_bytes = new byte[bin_head_bytes.Count];
            button_Unpack.Visible = false;
            for (int i = 0; i < key_string.Length / 2; i++) key_decode[i] = (byte)Convert.ToInt32(key_string.ToString().Substring(i * 2, 2), 16);
            if (bin_head_bytes.Count > 0) // Отправляем на декодировку стандарт DES-ECB)
            {
                for (int i = 0; i < bin_head_bytes.Count; i++) send_bytes[i] = bin_head_bytes[i];
                if (radioButton_Code.Checked) res_bytes = fn.Decoder(send_bytes, key_decode);
                if (radioButton_Code_Free.Checked) res_bytes = send_bytes;
                if (res_bytes != null)
                {
                    for (int i = 0; i < res_bytes.Length; i++) decode_head_bytes.Add(res_bytes[i]);
                    textBox_After_Decode.Text = fn.ByEight(res_bytes, Convert.ToInt32(comboBox_Char_Tostring.Text));
                }
            }
            else toolStripStatusLabel1.Text = "В буфере обмена нет данных о шапке прошивки. Выберите другой файл прошивки!";
            richTextBox_Parse.Text = "<-=Параметры прошивки=->" + Environment.NewLine + Environment.NewLine;
            H_I.Bin_Nym = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Bin_Number - Start_Adress);
            try
            {
                if (H_I.Bin_Nym == 1)
                {
                    H_I.Conf_Files = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Config_Files - Start_Adress);
                    H_I.Bin_Files = BitConverter.ToUInt32(res_bytes, (int)Functions.Parsing_Header_Four_Bytes.Bin_Files - Start_Adress);
                    richTextBox_Parse.Text += $"Количество bin файлов прошивки - {H_I.Bin_Nym}" + Environment.NewLine +
                        $"Количество bin файлов внутри прошивки - {H_I.Bin_Files}" + Environment.NewLine +
                        $"Количество конфигурационных файлов внутри прошивки - {H_I.Conf_Files}" + Environment.NewLine;
                    try
                    {
                        char[] trim_char = { '\0' };
                        H_I.Header_Len = BitConverter.ToString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Header_Len, 4).Replace("-", "");
                        H_I.Author = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Author - Start_Adress, (int)Functions.Parsing_Bytes.Long_number).TrimEnd(trim_char);
                        H_I.Packer_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Packer_Version - Start_Adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        H_I.Phone_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Phone_Version - Start_Adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        H_I.Image_Ver = new ASCIIEncoding().GetString(res_bytes, (int)Functions.Parsing_Header_String_Bytes.Image_Version, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_char);
                        richTextBox_Parse.Text += $"Что-то непонятное - {H_I.Header_Len}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Подписант прошивки - {H_I.Author}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия упаковщика - {H_I.Packer_Ver}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия телефона - {H_I.Phone_Ver}" + Environment.NewLine;
                        richTextBox_Parse.Text += $"Версия прошивки - {H_I.Image_Ver}" + Environment.NewLine;
                        toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился удачно.";
                    }
                    catch (ArgumentOutOfRangeException Ex)
                    {
                        richTextBox_Parse.Text += "Парсинг оставшейся части шапки прошивки завершился неудачно, вероятно, из-за указания ненулевого стартового адреса. " +
                                "Прошивка будет распакована, но возможны ошибки. Стоит проверить параметры в настройках!";
                        toolStripStatusLabel1.Text = Ex.Message;
                    }
                }
                else
                {
                    richTextBox_Parse.Text = "Данная прошивка не может быть распакована, так как состоит не из одного файла, либо некорректно декодирована!";
                    toolStripStatusLabel1.Text = "Парсинг шапки прошивки завершился с ошибками.";
                    return;
                }
            }
            catch (ArgumentOutOfRangeException Ex)
            {
                richTextBox_Parse.Text = "Парсинг шапки прошивки завершился неудачно, вероятно, из-за указания ненулевого стартового адреса или маленького размера считываемых данных. " +
                    "Прошивка не может быть распакована с такими параметрами в настройках!";
                toolStripStatusLabel1.Text = Ex.Message;
                return;
            }
            richTextBox_Parse.SelectionStart = richTextBox_Parse.Text.Length;
            if (radioButton_Dec_Unpack.Checked) backgroundWorker_Unpacker.RunWorkerAsync(openFileDialog1.FileName);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip_Dir.SetToolTip(button_ROM_Path, "Для сброса нажмите кнопку и выберите \"Отмена\"");
            toolTip_Dir.SetToolTip(button_Unpack_Dir, "Для сброса нажмите кнопку и выберите \"Отмена\"");
            toolTip_Dir.SetToolTip(comboBox_Char_Tostring, "Выберите из списка или введите вручную");
            toolTip_Dir.SetToolTip(textBox_Decode, "Система дешифровки - только DES. Количество знаков в ключе меньше 16 будет дополнено '0' в начале.");
        }
        private int Adress_to_Int(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    if (value.StartsWith("0x")) return Convert.ToInt32(value.Substring(2), 16);
                    else return Convert.ToInt32(value);
                }
                catch (OverflowException Ex)
                {
                    toolStripStatusLabel1.Text = Ex.Message;
                    return 0;
                }
                catch (ArgumentOutOfRangeException Ex)
                {
                    toolStripStatusLabel1.Text = Ex.Message;
                    return 0;
                }
            }
            return 0;
        }
        /// <summary>
        /// Проверка на корректность ввода символов в строку числовых значений
        /// </summary>
        /// <param name="sender">Объект ввода (текстовое поле)</param>
        /// <param name="e">Событие</param>
        private void TextBox_NumString_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                if ((sender as TextBox).Text.Contains("0x"))
                {
                    int input = (sender as TextBox).Text.IndexOf("0x");
                    if ((sender as TextBox).Text.Length > input + 2)
                    {
                        (sender as TextBox).Text = "0x" + fn.DelUnknownChars((sender as TextBox).Text.Remove(0, input + 2), Functions.System_Count.hex);
                    }
                }
                else (sender as TextBox).Text = fn.DelUnknownChars((sender as TextBox).Text, Functions.System_Count.dex);
            }
            else (sender as TextBox).Text = "0";
            (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            (sender as TextBox).Focus();
        }
        /// <summary>
        /// Начальная страница при загрузке формы с выбором текстового поля для установки курсора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Control;
            textBox_Start_Adress.Focus();
            richTextBox1.Text = "Чтобы уменьшить время выполнения операций и не обрабатывать нулевые байты из конца шапки прошивки (для процессоров ARM Cortex-a53 это адрес 0x100000), можно сначала провести анализ шапки и, игнорируя все последние нулевые байты, найти последний ненулевой." + Environment.NewLine +
                "Для запуска анализа нажмите кнопку \"Игнорировать нулевые байты в конце\". Результатом анализа станет число декодированных с использованием выбранного алгоритма ненулевых байт, которые необходимо считать из шапки." + Environment.NewLine +
                "Поле\"Количество символов для чтения\" заполнится автоматически при успешном выполнении операции.";
        }

        private void Button_Set_Set_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Decode;
            button_ROM_Path.Focus();
        }
        /// <summary>
        /// Разборка шапки прошивки с её раскодировкой
        /// </summary>
        private void Parse_Bin_Head()
        {
            FileInfo fi = new FileInfo(ROM_File_Path);
            long fl = fi.Length;
            if (fl < Convert.ToInt64(Adress_to_Int(textBox_Start_Adress.Text))) // Проверяем на соответствие размера и стартового адреса
            {
                toolStripStatusLabel1.Text = $"Этот файл слишком мал для прошивки - {fl} байт";
                ROM_File_Path = string.Empty;
            }
            // Поблочно считываем шапку прошивки с начального адреса в отдельном потоке.
            else
            {
                if (Adress_to_Int(textBox_Bin_Header_Len.Text) > 50000) textBox_Orig.Text = "Вами запрошена длительная по выполнению опреция. " +
                            "При желании, она может быть отменена кнопкой внизу формы. Кнопка появится после выполнения хотя бы 1% операции.";
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            }
        }

        private void TextBox_Start_Adress_KeyUp(object sender, KeyEventArgs e)
        {
            if (radioButton_FileStAdr_Auto.Checked)
            {
                int FSA = 10240 - Adress_to_Int(textBox_Start_Adress.Text);
                if (FSA > 0) textBox_Files_St_Adr.BackColor = Color.White;
                else
                {
                    FSA = 0;
                    textBox_Files_St_Adr.BackColor = Color.Red;
                }
                textBox_Files_St_Adr.Text = $"{FSA}";
            }
        }

        private void RadioButton_FileStAdr_Auto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_FileStAdr_Man.Checked) textBox_Files_St_Adr.Enabled = true;
            else textBox_Files_St_Adr.Enabled = false;
        }

        private void RadioButton_Code_Free_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Code_Free.Checked) textBox_Decode.Enabled = false;
            else textBox_Decode.Enabled = true;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int st_adr = Adress_to_Int(textBox_Start_Adress.Text);
            int bytes_len = Adress_to_Int(textBox_Bin_Header_Len.Text);
            if (bin_head_bytes != null) bin_head_bytes.Clear();
            while (bytes_len % 8 != 0)
            {
                bytes_len++;
            }
            using (FileStream fs = new FileStream(ROM_File_Path, FileMode.Open, FileAccess.Read))
            {
                fs.Position = Convert.ToInt64(st_adr); // Смещение позиции чтения на начальный адрес
                using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    for (int i = st_adr; i < st_adr + bytes_len; i++)
                    {
                        bin_head_bytes.Add(br.ReadByte());
                        worker.ReportProgress(i * 100 / (st_adr + bytes_len));
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                        if (bytes_len > 30000) Thread.Sleep(1);
                    }
                }
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = $"Обработка запроса завершена на {e.ProgressPercentage} %";
            if (e.ProgressPercentage > 1) toolStripSplitButton_Cancel.Visible = true;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripSplitButton_Cancel.Visible = false;
            toolStripProgressBar1.Value = 0;
            if (e.Cancelled)
            {
                textBox_Orig.Text = "Операция обработки запроса отменена пользователем";
                ROM_File_Path = string.Empty;
                if (bin_head_bytes != null) bin_head_bytes.Clear();
                toolStripStatusLabel1.Text = "Операция обработки запроса отменена пользователем";
            }
            else
            {
                if (e.Error != null)
                {
                    textBox_Orig.Text = "Обработка запроса завершилась с ошибками!";
                    toolStripStatusLabel1.Text = "Обработка запроса завершилась с ошибками!";
                }
                else
                {
                    byte[] send_bytes = new byte[bin_head_bytes.Count];
                    for (int i = 0; i < bin_head_bytes.Count; i++) send_bytes[i] = bin_head_bytes[i];
                    textBox_Orig.Text = fn.ByEight(send_bytes, Convert.ToInt32(comboBox_Char_Tostring.Text));
                    toolStripStatusLabel1.Text = "Обработка запроса завершена";
                    if (!string.IsNullOrEmpty(ROM_File_Path) && !string.IsNullOrEmpty(Decode_ROM_Path))
                    {
                        button_Unpack.Visible = true;
                        if (radioButton_Decode_Only.Checked) button_Unpack.Text = radioButton_Decode_Only.Text;
                        else button_Unpack.Text = radioButton_Dec_Unpack.Text;
                        toolStripStatusLabel1.Text = "Теперь можно распаковать прошивку";
                    }
                    else button_Unpack.Visible = false;
                }
            }
        }

        private void ToolStripSplitButton_Cancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();
            if (backgroundWorker_Analyse.IsBusy) backgroundWorker_Analyse.CancelAsync();
            if (backgroundWorker_Unpacker.IsBusy) backgroundWorker_Unpacker.CancelAsync();
            if (toolStripSplitButton_Cancel.Text.Contains("Проводник")) Process.Start("explorer.exe", Decode_ROM_Path);
        }

        private void Button_Analise_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && !backgroundWorker_Analyse.IsBusy) backgroundWorker_Analyse.RunWorkerAsync(openFileDialog1.FileName);
        }

        private void BackgroundWorker_Analyse_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker analayser = sender as BackgroundWorker;
            StringBuilder key_string = new StringBuilder(textBox_Decode.Text);
            byte[] key_decode = new byte[key_string.Length / 2];
            byte[] last_byte_block = new byte[8];
            byte[] analyse_block = new byte[8];
            while (key_string.Length < 16) key_string.Insert(0, '0');
            for (int i = 0; i < key_string.Length / 2; i++) key_decode[i] = (byte)Convert.ToInt32(key_string.ToString().Substring(i * 2, 2), 16);
            using (FileStream fs = new FileStream(e.Argument.ToString(), FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    while (last_byte > 8)
                    {
                        fs.Position = Convert.ToInt64(last_byte - 8); // Смещение позиции чтения на начальный адрес
                        if (br.Read(last_byte_block, 0, 8) > 0)
                        {
                            if (radioButton_Code.Checked) analyse_block = fn.Decoder(last_byte_block, key_decode);
                            if (radioButton_Code_Free.Checked) analyse_block = last_byte_block;
                            if (BitConverter.ToInt64(analyse_block, 0) != 0) break;
                        }
                        if (analayser.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                        analayser.ReportProgress(100 - ((1048576 - last_byte) * 100 / 1048576));
                        last_byte -= 8;
                        Thread.Sleep(1);
                    }
                }
            }
        }

        private void BackgroundWorker_Analyse_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = $"До начала файла осталось {e.ProgressPercentage} %";
            if (e.ProgressPercentage < 98) toolStripSplitButton_Cancel.Visible = true;
        }

        private void BackgroundWorker_Analyse_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripSplitButton_Cancel.Visible = false;
            toolStripProgressBar1.Value = 0;
            if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Обработка запроса отменена пользователем";
            }
            else
            {
                if (e.Error != null) toolStripStatusLabel1.Text = $"Обработка запроса завершена с ошибкой. {e.Error.Message}";
                else
                {
                    while (last_byte % 512 != 0) // Добиваем от последнего ненулевого байта до полного блока
                    {
                        last_byte++;
                    }
                    textBox_Bin_Header_Len.Text = last_byte.ToString();
                    toolStripStatusLabel1.Text = "Обработка запроса успешно завершена";
                }
            }
        }
        public struct Header_Info
        {
            public Header_Info(string Packer_Ver, string Phone_Ver, string Image_Ver, string Author, uint Conf_Files, uint Bin_Files, uint Bin_Nym, string Header_Len)
            {
                this.Packer_Ver = Packer_Ver;
                this.Phone_Ver = Phone_Ver;
                this.Image_Ver = Image_Ver;
                this.Author = Author;
                this.Conf_Files = Conf_Files;
                this.Bin_Files = Bin_Files;
                this.Bin_Nym = Bin_Nym;
                this.Header_Len = Header_Len;
            }
            public string Packer_Ver;
            public string Phone_Ver;
            public string Image_Ver;
            public string Author;
            public uint Conf_Files;
            public uint Bin_Files;
            public uint Bin_Nym;
            public string Header_Len;
        }
        public struct File_info_bytes
        {
            public File_info_bytes(string ROM_Name, string File_Name, long Offset, long Size, long CRC, long Res)
            {
                this.ROM_Name = ROM_Name;
                this.File_Name = File_Name;
                this.Offset = Offset;
                this.Size = Size;
                this.CRC = CRC;
                this.Res = Res;
            }
            public string ROM_Name;
            public string File_Name;
            public long Offset;
            public long Size;
            public long CRC;
            public long Res;
        }
        private void BackgroundWorker_Unpacker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker unpacker = sender as BackgroundWorker;
            byte[] decode_arr = new byte[decode_head_bytes.Count];
            int start_adress = Adress_to_Int(textBox_Files_St_Adr.Text);
            for (int i = 0; i < decode_head_bytes.Count; i++) decode_arr[i] = decode_head_bytes[i];
            Array.Resize(ref F_I_B, (int)(H_I.Conf_Files + H_I.Bin_Files));
            char[] trim_chars = { '\0' };
            for (int i = 0; i < H_I.Conf_Files + H_I.Bin_Files; i++) // Первый цикл из всех файлов, запакованных в прошивку
            {
                F_I_B[i].ROM_Name = new ASCIIEncoding().GetString(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + start_adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_chars); // 0х40 (64) Имя файла прошивки
                F_I_B[i].File_Name = new ASCIIEncoding().GetString(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + 64 + start_adress, (int)Functions.Parsing_Bytes.String_parse).TrimEnd(trim_chars);  // 0х40 (64) Имя файла
                F_I_B[i].Offset = BitConverter.ToInt64(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + 128 + start_adress) * 512; // 0х8 (2х4) Начальный адрес блока
                F_I_B[i].Size = BitConverter.ToInt64(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + 136 + start_adress); // 0х8 (2х4) Размер
                F_I_B[i].CRC = BitConverter.ToInt64(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + 144 + start_adress); // 0х8 (2х4) CRC32 Контрольная сумма
                F_I_B[i].Res = BitConverter.ToInt64(decode_arr, i * (int)Functions.Parsing_Bytes.File_info + 152 + start_adress); // 0х8 Резерв
                long size_for_decode = F_I_B[i].Size;
                string path_file = Decode_ROM_Path + "\\" + F_I_B[i].File_Name;
                while (size_for_decode % 512 != 0) // Читаем блоками по 512 байт
                {
                    size_for_decode++;
                }
                byte[] convert_bytes = new byte[size_for_decode];
                using (FileStream fs = new FileStream(e.Argument.ToString(), FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                    {
                        fs.Position = F_I_B[i].Offset; // Смещение позиции чтения на начальный адрес
                        byte[] file_bytes = br.ReadBytes((int)size_for_decode);

                        if (i < H_I.Conf_Files) // Обрабатываем тут конфигурационные файлы, требующие расшифровки (идут в начале)
                        {
                            if (radioButton_Code.Checked) convert_bytes = fn.Decoder(file_bytes, key_decode);
                            if (radioButton_Code_Free.Checked) convert_bytes = file_bytes;
                        }
                        else // За ними бинарные файлы в чистом виде.
                        {
                            convert_bytes = file_bytes;
                        }
                    }
                }
                if (convert_bytes.Length > F_I_B[i].Size) Array.Resize(ref convert_bytes, (int)F_I_B[i].Size);
                if (unpacker.CancellationPending || Convert.ToUInt32(F_I_B[i].CRC) != Crc32.CalculateCrc(convert_bytes)) // Проверяем контрольную сумму
                {
                    e.Cancel = true;
                    break;
                }
                using (BinaryWriter writer = new BinaryWriter(File.Open(path_file, FileMode.Create), new ASCIIEncoding()))
                {
                    writer.Write(convert_bytes);
                }
                unpacker.ReportProgress(i * 100 / (int)(H_I.Conf_Files + H_I.Bin_Files));
                Thread.Sleep(1);
            }

        }
        private void BackgroundWorker_Unpacker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = $"Распаковка файлов прошивки выполнена на {e.ProgressPercentage} %";
            if (e.ProgressPercentage > 1) toolStripSplitButton_Cancel.Visible = true;
        }

        private void BackgroundWorker_Unpacker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Value = 0;
            if (e.Cancelled)
            {
                toolStripStatusLabel1.Text = "Операция распаковки файлов прошивки прервана пользователем или завершилась с ошибкой.";
                toolStripSplitButton_Cancel.Visible = false;
            }
            else
            {
                if (e.Error != null)
                {
                    toolStripStatusLabel1.Text = $"Операция распаковки файлов прошивки завершена с ошибкой {e.Error.Message}";
                    toolStripSplitButton_Cancel.Visible = false;
                }
                else
                {
                    for (int i = 0; i < F_I_B.Length; i++)
                    {
                        richTextBox_Parse.Text += Environment.NewLine + "Файл " + F_I_B[i].File_Name;
                        richTextBox_Parse.Text += $", адрес {F_I_B[i].Offset}, размер {F_I_B[i].Size}, контрольная сумма {F_I_B[i].CRC}";
                    }
                    toolStripStatusLabel1.Text = "Прошивка успешно распакована в указанную директорию.";
                    toolStripSplitButton_Cancel.Text = "Открыть папку в Проводнике";
                    toolStripSplitButton_Cancel.Visible = true;
                }
            }
        }
    }
}
