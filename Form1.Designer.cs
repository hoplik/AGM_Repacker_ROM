namespace Code_Decode_ROM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_ROM_Path = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_Orig = new System.Windows.Forms.TextBox();
            this.textBox_After_Decode = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Decode = new System.Windows.Forms.TabPage();
            this.richTextBox_Parse = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Unpack = new System.Windows.Forms.Button();
            this.button_Unpack_Dir = new System.Windows.Forms.Button();
            this.tabPage_Control = new System.Windows.Forms.TabPage();
            this.button_Analise = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_Decode_Only = new System.Windows.Forms.RadioButton();
            this.radioButton_Dec_Unpack = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Char_Tostring = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_Code_Free = new System.Windows.Forms.RadioButton();
            this.textBox_Decode = new System.Windows.Forms.TextBox();
            this.radioButton_Code = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Files_St_Adr = new System.Windows.Forms.TextBox();
            this.radioButton_FileStAdr_Man = new System.Windows.Forms.RadioButton();
            this.radioButton_FileStAdr_Auto = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Set_Set = new System.Windows.Forms.Button();
            this.textBox_Bin_Header_Len = new System.Windows.Forms.TextBox();
            this.textBox_Start_Adress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_About = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton_Cancel = new System.Windows.Forms.ToolStripSplitButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip_Dir = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_Analyse = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker_Unpacker = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage_Decode.SuspendLayout();
            this.tabPage_Control.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_About.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ROM_Path
            // 
            this.button_ROM_Path.Location = new System.Drawing.Point(15, 6);
            this.button_ROM_Path.Name = "button_ROM_Path";
            this.button_ROM_Path.Size = new System.Drawing.Size(478, 37);
            this.button_ROM_Path.TabIndex = 0;
            this.button_ROM_Path.Text = "Путь к файлу прошивки";
            this.button_ROM_Path.UseVisualStyleBackColor = true;
            this.button_ROM_Path.Click += new System.EventHandler(this.Button_ROM_Path_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Бинарный файл прошивки(*.bin)|*.bin|Все файлы(*.*)|*.*";
            // 
            // textBox_Orig
            // 
            this.textBox_Orig.AcceptsReturn = true;
            this.textBox_Orig.AcceptsTab = true;
            this.textBox_Orig.Location = new System.Drawing.Point(15, 76);
            this.textBox_Orig.Multiline = true;
            this.textBox_Orig.Name = "textBox_Orig";
            this.textBox_Orig.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Orig.Size = new System.Drawing.Size(655, 363);
            this.textBox_Orig.TabIndex = 5;
            // 
            // textBox_After_Decode
            // 
            this.textBox_After_Decode.AcceptsReturn = true;
            this.textBox_After_Decode.AcceptsTab = true;
            this.textBox_After_Decode.Location = new System.Drawing.Point(676, 76);
            this.textBox_After_Decode.Multiline = true;
            this.textBox_After_Decode.Name = "textBox_After_Decode";
            this.textBox_After_Decode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_After_Decode.Size = new System.Drawing.Size(616, 167);
            this.textBox_After_Decode.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Decode);
            this.tabControl1.Controls.Add(this.tabPage_Control);
            this.tabControl1.Controls.Add(this.tabPage_About);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1317, 501);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_Decode
            // 
            this.tabPage_Decode.Controls.Add(this.richTextBox_Parse);
            this.tabPage_Decode.Controls.Add(this.label6);
            this.tabPage_Decode.Controls.Add(this.label5);
            this.tabPage_Decode.Controls.Add(this.label3);
            this.tabPage_Decode.Controls.Add(this.button_Unpack);
            this.tabPage_Decode.Controls.Add(this.button_Unpack_Dir);
            this.tabPage_Decode.Controls.Add(this.textBox_After_Decode);
            this.tabPage_Decode.Controls.Add(this.button_ROM_Path);
            this.tabPage_Decode.Controls.Add(this.textBox_Orig);
            this.tabPage_Decode.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Decode.Name = "tabPage_Decode";
            this.tabPage_Decode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Decode.Size = new System.Drawing.Size(1309, 472);
            this.tabPage_Decode.TabIndex = 0;
            this.tabPage_Decode.Text = "Разбираем";
            this.tabPage_Decode.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Parse
            // 
            this.richTextBox_Parse.AcceptsTab = true;
            this.richTextBox_Parse.Location = new System.Drawing.Point(676, 273);
            this.richTextBox_Parse.Name = "richTextBox_Parse";
            this.richTextBox_Parse.Size = new System.Drawing.Size(616, 166);
            this.richTextBox_Parse.TabIndex = 13;
            this.richTextBox_Parse.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(679, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Парсинг декодированного сегмента";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(679, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Декодированный сегмент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Оригинальный сегмент файла";
            // 
            // button_Unpack
            // 
            this.button_Unpack.Location = new System.Drawing.Point(984, 6);
            this.button_Unpack.Name = "button_Unpack";
            this.button_Unpack.Size = new System.Drawing.Size(317, 37);
            this.button_Unpack.TabIndex = 8;
            this.button_Unpack.Text = "Распаковать";
            this.button_Unpack.UseVisualStyleBackColor = true;
            this.button_Unpack.Visible = false;
            this.button_Unpack.Click += new System.EventHandler(this.Button_Unpack_Click);
            // 
            // button_Unpack_Dir
            // 
            this.button_Unpack_Dir.Location = new System.Drawing.Point(500, 6);
            this.button_Unpack_Dir.Name = "button_Unpack_Dir";
            this.button_Unpack_Dir.Size = new System.Drawing.Size(478, 37);
            this.button_Unpack_Dir.TabIndex = 7;
            this.button_Unpack_Dir.Text = "Директория распаковки";
            this.button_Unpack_Dir.UseVisualStyleBackColor = true;
            this.button_Unpack_Dir.Click += new System.EventHandler(this.Button_Unpack_Dir_Click);
            // 
            // tabPage_Control
            // 
            this.tabPage_Control.Controls.Add(this.button_Analise);
            this.tabPage_Control.Controls.Add(this.richTextBox1);
            this.tabPage_Control.Controls.Add(this.groupBox3);
            this.tabPage_Control.Controls.Add(this.groupBox2);
            this.tabPage_Control.Controls.Add(this.groupBox1);
            this.tabPage_Control.Controls.Add(this.label7);
            this.tabPage_Control.Controls.Add(this.button_Set_Set);
            this.tabPage_Control.Controls.Add(this.textBox_Bin_Header_Len);
            this.tabPage_Control.Controls.Add(this.textBox_Start_Adress);
            this.tabPage_Control.Controls.Add(this.label1);
            this.tabPage_Control.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Control.Name = "tabPage_Control";
            this.tabPage_Control.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Control.Size = new System.Drawing.Size(1309, 472);
            this.tabPage_Control.TabIndex = 1;
            this.tabPage_Control.Text = "Настройки";
            this.tabPage_Control.UseVisualStyleBackColor = true;
            // 
            // button_Analise
            // 
            this.button_Analise.Location = new System.Drawing.Point(11, 117);
            this.button_Analise.Name = "button_Analise";
            this.button_Analise.Size = new System.Drawing.Size(355, 29);
            this.button_Analise.TabIndex = 33;
            this.button_Analise.Text = "Игнорировать нулевые байты в конце";
            this.button_Analise.UseVisualStyleBackColor = true;
            this.button_Analise.Click += new System.EventHandler(this.Button_Analise_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(5, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(834, 105);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_Decode_Only);
            this.groupBox3.Controls.Add(this.radioButton_Dec_Unpack);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBox_Char_Tostring);
            this.groupBox3.Location = new System.Drawing.Point(845, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 100);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Опции распаковки";
            // 
            // radioButton_Decode_Only
            // 
            this.radioButton_Decode_Only.AutoSize = true;
            this.radioButton_Decode_Only.Checked = true;
            this.radioButton_Decode_Only.Location = new System.Drawing.Point(6, 48);
            this.radioButton_Decode_Only.Name = "radioButton_Decode_Only";
            this.radioButton_Decode_Only.Size = new System.Drawing.Size(172, 21);
            this.radioButton_Decode_Only.TabIndex = 23;
            this.radioButton_Decode_Only.TabStop = true;
            this.radioButton_Decode_Only.Text = "Только декодировать";
            this.radioButton_Decode_Only.UseVisualStyleBackColor = true;
            // 
            // radioButton_Dec_Unpack
            // 
            this.radioButton_Dec_Unpack.AutoSize = true;
            this.radioButton_Dec_Unpack.Location = new System.Drawing.Point(6, 21);
            this.radioButton_Dec_Unpack.Name = "radioButton_Dec_Unpack";
            this.radioButton_Dec_Unpack.Size = new System.Drawing.Size(223, 21);
            this.radioButton_Dec_Unpack.TabIndex = 22;
            this.radioButton_Dec_Unpack.Text = "Декодировать и распаковать";
            this.radioButton_Dec_Unpack.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Символов в строке";
            // 
            // comboBox_Char_Tostring
            // 
            this.comboBox_Char_Tostring.FormattingEnabled = true;
            this.comboBox_Char_Tostring.Items.AddRange(new object[] {
            "8",
            "10",
            "16"});
            this.comboBox_Char_Tostring.Location = new System.Drawing.Point(188, 69);
            this.comboBox_Char_Tostring.Name = "comboBox_Char_Tostring";
            this.comboBox_Char_Tostring.Size = new System.Drawing.Size(46, 24);
            this.comboBox_Char_Tostring.TabIndex = 20;
            this.comboBox_Char_Tostring.Text = "16";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_Code_Free);
            this.groupBox2.Controls.Add(this.textBox_Decode);
            this.groupBox2.Controls.Add(this.radioButton_Code);
            this.groupBox2.Location = new System.Drawing.Point(530, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 77);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Код декодирования";
            // 
            // radioButton_Code_Free
            // 
            this.radioButton_Code_Free.AutoSize = true;
            this.radioButton_Code_Free.Location = new System.Drawing.Point(6, 22);
            this.radioButton_Code_Free.Name = "radioButton_Code_Free";
            this.radioButton_Code_Free.Size = new System.Drawing.Size(103, 21);
            this.radioButton_Code_Free.TabIndex = 31;
            this.radioButton_Code_Free.Text = "Без шифра";
            this.radioButton_Code_Free.UseVisualStyleBackColor = true;
            this.radioButton_Code_Free.CheckedChanged += new System.EventHandler(this.RadioButton_Code_Free_CheckedChanged);
            // 
            // textBox_Decode
            // 
            this.textBox_Decode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_Decode.Location = new System.Drawing.Point(155, 21);
            this.textBox_Decode.MaxLength = 16;
            this.textBox_Decode.Name = "textBox_Decode";
            this.textBox_Decode.Size = new System.Drawing.Size(144, 22);
            this.textBox_Decode.TabIndex = 9;
            this.textBox_Decode.Text = "0123456789ABCDEF";
            // 
            // radioButton_Code
            // 
            this.radioButton_Code.AutoSize = true;
            this.radioButton_Code.Checked = true;
            this.radioButton_Code.Location = new System.Drawing.Point(6, 49);
            this.radioButton_Code.Name = "radioButton_Code";
            this.radioButton_Code.Size = new System.Drawing.Size(293, 21);
            this.radioButton_Code.TabIndex = 23;
            this.radioButton_Code.TabStop = true;
            this.radioButton_Code.Text = "Алгоритм шифрования DES-ECB (64 bit)";
            this.radioButton_Code.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Files_St_Adr);
            this.groupBox1.Controls.Add(this.radioButton_FileStAdr_Man);
            this.groupBox1.Controls.Add(this.radioButton_FileStAdr_Auto);
            this.groupBox1.Location = new System.Drawing.Point(5, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 76);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Адрес начала списка файлов";
            // 
            // textBox_Files_St_Adr
            // 
            this.textBox_Files_St_Adr.Enabled = false;
            this.textBox_Files_St_Adr.Location = new System.Drawing.Point(239, 21);
            this.textBox_Files_St_Adr.MaxLength = 10;
            this.textBox_Files_St_Adr.Name = "textBox_Files_St_Adr";
            this.textBox_Files_St_Adr.Size = new System.Drawing.Size(114, 22);
            this.textBox_Files_St_Adr.TabIndex = 26;
            this.textBox_Files_St_Adr.Text = "0x2800";
            this.textBox_Files_St_Adr.TextChanged += new System.EventHandler(this.TextBox_NumString_TextChanged);
            // 
            // radioButton_FileStAdr_Man
            // 
            this.radioButton_FileStAdr_Man.AutoSize = true;
            this.radioButton_FileStAdr_Man.Location = new System.Drawing.Point(6, 49);
            this.radioButton_FileStAdr_Man.Name = "radioButton_FileStAdr_Man";
            this.radioButton_FileStAdr_Man.Size = new System.Drawing.Size(134, 21);
            this.radioButton_FileStAdr_Man.TabIndex = 25;
            this.radioButton_FileStAdr_Man.Text = "Ввести вручную";
            this.radioButton_FileStAdr_Man.UseVisualStyleBackColor = true;
            // 
            // radioButton_FileStAdr_Auto
            // 
            this.radioButton_FileStAdr_Auto.AutoSize = true;
            this.radioButton_FileStAdr_Auto.Checked = true;
            this.radioButton_FileStAdr_Auto.Location = new System.Drawing.Point(6, 22);
            this.radioButton_FileStAdr_Auto.Name = "radioButton_FileStAdr_Auto";
            this.radioButton_FileStAdr_Auto.Size = new System.Drawing.Size(203, 21);
            this.radioButton_FileStAdr_Auto.TabIndex = 24;
            this.radioButton_FileStAdr_Auto.TabStop = true;
            this.radioButton_FileStAdr_Auto.Text = "Посчитать автоматически";
            this.radioButton_FileStAdr_Auto.UseVisualStyleBackColor = true;
            this.radioButton_FileStAdr_Auto.CheckedChanged += new System.EventHandler(this.RadioButton_FileStAdr_Auto_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Количество символов для чтения";
            // 
            // button_Set_Set
            // 
            this.button_Set_Set.Location = new System.Drawing.Point(445, 117);
            this.button_Set_Set.Name = "button_Set_Set";
            this.button_Set_Set.Size = new System.Drawing.Size(394, 31);
            this.button_Set_Set.TabIndex = 19;
            this.button_Set_Set.Text = "Применить настройки";
            this.button_Set_Set.UseVisualStyleBackColor = true;
            this.button_Set_Set.Click += new System.EventHandler(this.Button_Set_Set_Click);
            // 
            // textBox_Bin_Header_Len
            // 
            this.textBox_Bin_Header_Len.Location = new System.Drawing.Point(244, 179);
            this.textBox_Bin_Header_Len.MaxLength = 10;
            this.textBox_Bin_Header_Len.Name = "textBox_Bin_Header_Len";
            this.textBox_Bin_Header_Len.Size = new System.Drawing.Size(114, 22);
            this.textBox_Bin_Header_Len.TabIndex = 18;
            this.textBox_Bin_Header_Len.Text = "0x5000";
            this.textBox_Bin_Header_Len.TextChanged += new System.EventHandler(this.TextBox_NumString_TextChanged);
            // 
            // textBox_Start_Adress
            // 
            this.textBox_Start_Adress.Location = new System.Drawing.Point(244, 152);
            this.textBox_Start_Adress.MaxLength = 10;
            this.textBox_Start_Adress.Name = "textBox_Start_Adress";
            this.textBox_Start_Adress.Size = new System.Drawing.Size(114, 22);
            this.textBox_Start_Adress.TabIndex = 8;
            this.textBox_Start_Adress.Text = "0";
            this.textBox_Start_Adress.TextChanged += new System.EventHandler(this.TextBox_NumString_TextChanged);
            this.textBox_Start_Adress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox_Start_Adress_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Адрес начала прошивки";
            // 
            // tabPage_About
            // 
            this.tabPage_About.Controls.Add(this.linkLabel1);
            this.tabPage_About.Controls.Add(this.label9);
            this.tabPage_About.Location = new System.Drawing.Point(4, 25);
            this.tabPage_About.Name = "tabPage_About";
            this.tabPage_About.Size = new System.Drawing.Size(1309, 472);
            this.tabPage_About.TabIndex = 3;
            this.tabPage_About.Text = "О программе";
            this.tabPage_About.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(50, 59);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 17);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(558, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Вопросы, замечания, пожелания можете оставлять на странице проекта в ГитХаб";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripSplitButton_Cancel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1317, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 18);
            this.toolStripProgressBar1.Step = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(272, 20);
            this.toolStripStatusLabel1.Text = "Выберите директорию и путь к файлу";
            // 
            // toolStripSplitButton_Cancel
            // 
            this.toolStripSplitButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_Cancel.DropDownButtonWidth = 0;
            this.toolStripSplitButton_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Cancel.Image")));
            this.toolStripSplitButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_Cancel.Name = "toolStripSplitButton_Cancel";
            this.toolStripSplitButton_Cancel.Size = new System.Drawing.Size(269, 24);
            this.toolStripSplitButton_Cancel.Text = "Эта операция может быть отменена";
            this.toolStripSplitButton_Cancel.Visible = false;
            this.toolStripSplitButton_Cancel.ButtonClick += new System.EventHandler(this.ToolStripSplitButton_Cancel_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker_Analyse
            // 
            this.backgroundWorker_Analyse.WorkerReportsProgress = true;
            this.backgroundWorker_Analyse.WorkerSupportsCancellation = true;
            this.backgroundWorker_Analyse.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_Analyse_DoWork);
            this.backgroundWorker_Analyse.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_Analyse_ProgressChanged);
            this.backgroundWorker_Analyse.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_Analyse_RunWorkerCompleted);
            // 
            // backgroundWorker_Unpacker
            // 
            this.backgroundWorker_Unpacker.WorkerReportsProgress = true;
            this.backgroundWorker_Unpacker.WorkerSupportsCancellation = true;
            this.backgroundWorker_Unpacker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_Unpacker_DoWork);
            this.backgroundWorker_Unpacker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_Unpacker_ProgressChanged);
            this.backgroundWorker_Unpacker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_Unpacker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 501);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Repacker ROM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Decode.ResumeLayout(false);
            this.tabPage_Decode.PerformLayout();
            this.tabPage_Control.ResumeLayout(false);
            this.tabPage_Control.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_About.ResumeLayout(false);
            this.tabPage_About.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_ROM_Path;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_Orig;
        private System.Windows.Forms.TextBox textBox_After_Decode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Decode;
        private System.Windows.Forms.TabPage tabPage_Control;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button_Unpack_Dir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_Unpack;
        private System.Windows.Forms.ToolTip toolTip_Dir;
        private System.Windows.Forms.TextBox textBox_Decode;
        private System.Windows.Forms.TextBox textBox_Start_Adress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Bin_Header_Len;
        private System.Windows.Forms.Button button_Set_Set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Char_Tostring;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox_Parse;
        private System.Windows.Forms.TabPage tabPage_About;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton radioButton_Code;
        private System.Windows.Forms.TextBox textBox_Files_St_Adr;
        private System.Windows.Forms.RadioButton radioButton_FileStAdr_Man;
        private System.Windows.Forms.RadioButton radioButton_FileStAdr_Auto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_Decode_Only;
        private System.Windows.Forms.RadioButton radioButton_Dec_Unpack;
        private System.Windows.Forms.RadioButton radioButton_Code_Free;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_Cancel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_Analise;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Analyse;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Unpacker;
    }
}

