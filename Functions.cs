using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Code_Decode_ROM
{
    class Functions
    {
        internal enum Parsing_Header_String_Bytes // Строка из 0x40 символов (64 байт)
        {
            Packer_Version = 0, // 0х0 Версия упаковщика
            Phone_Version = 64, // 0x40 Версия телефона
            Image_Version = 576, // 0x240 Версия прошивки
            Author = 1096, // 0x448 Автор прошивки (8 байт)
            Header_Len = 1612 // 0x64c Размер шапки (2 байта)
        }
        internal enum Parsing_Header_Four_Bytes // Четыре байта на цифру
        {
            Config_Files = 1088, // 0x440 Количество конфигурационных файлов внутри прошивки в хекс (кодируются)
            Bin_Files = 1092, // 0x444 Количество bin файлов внутри прошивки в хекс (не кодируются)
            Bin_Number = 1608 // 0x648 Количество bin файлов прошивки (должен быть 1, иначе аварийное завершение)
        }
        internal enum Parsing_Bytes // Количество байт для чтения при разных режимах
        {
            String_parse = 64, // 0x40 Количество знаков для строковых значений
            Long_number = 8, // Количество знаков для длинных цифр в информации о файле
            File_info = 160 // Суммарное количество знаков для описания файла
        }
        /// <summary>
        /// Система исчисления, применяемая к строке знаков
        /// </summary>
        internal enum System_Count
        {
            dex,
            hex
        }
        /// <summary>
        /// Расшифровываем из потока памяти массив байт синхронно ключом и выводим результат массивом байт.
        /// </summary>
        /// <param name="value">Массив зашифрованных байт</param>
        /// <param name="key">Код шифрования в виде массива байт</param>
        /// <returns>Массив байт в расшифрованном виде</returns>
        internal byte[] Decoder(byte[] value, byte[] key)
        {
            MemoryStream mStream = new MemoryStream(value);
            DES DESalg = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Key = key,
                Padding = PaddingMode.None
            };
            ICryptoTransform transform = DESalg.CreateDecryptor();
            byte[] decode_bytes = new byte[value.Length];
            CryptoStream cStream = new CryptoStream(mStream, transform, CryptoStreamMode.Read);
            try
            {
                int db = cStream.Read(decode_bytes, 0, decode_bytes.Length);
                if (db > 0) return decode_bytes;
                else return null;
            }
            catch (CryptographicException Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Удаляем некорректные символы из строки в зависимости от системы исчисления
        /// </summary>
        /// <param name="value">Исходное значение анализируемой строки</param>
        /// <param name="sys_count">Система исчисления (10, 16)</param>
        /// <returns>Возвращаем строку с изменёнными или удалёнными некорректными символами</returns>
        internal string DelUnknownChars(string value, System_Count sys_count)
        {
            StringBuilder GoodStr = new StringBuilder(value);
            string[] Dex_str = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < GoodStr.Length; i++)
            {
                if (sys_count == System_Count.dex)
                {
                    if (!Dex_str.Contains(GoodStr[i].ToString())) GoodStr.Remove(i, 1);
                }
                else
                {
                    switch (GoodStr[i].ToString())
                    {
                        case "0": break;
                        case "1": break;
                        case "2": break;
                        case "3": break;
                        case "4": break;
                        case "5": break;
                        case "6": break;
                        case "7": break;
                        case "8": break;
                        case "9": break;
                        case "A": break;
                        case "B": break;
                        case "C": break;
                        case "D": break;
                        case "E": break;
                        case "F": break;
                        case "a":
                            GoodStr.Replace("a", "A");
                            break;
                        case "b":
                            GoodStr.Replace("b", "B");
                            break;
                        case "c":
                            GoodStr.Replace("c", "C");
                            break;
                        case "d":
                            GoodStr.Replace("d", "D");
                            break;
                        case "e":
                            GoodStr.Replace("e", "E");
                            break;
                        case "f":
                            GoodStr.Replace("f", "F");
                            break;
                        default:
                            GoodStr.Remove(i, 1);
                            break;
                    }
                }
            }
            return GoodStr.ToString();
        }
        /// <summary>
        /// Преобразовываем строку байт в список символов в байтах и ASCII
        /// </summary>
        /// <param name="charbyte">Массив байт, считанных из шапки прошивки</param>
        /// <param name="all_read_chars">Количество байт для анализа</param>
        /// <param name="chars_to_string">Количество символов в строке для разбора массива</param>
        /// <returns></returns>
        internal string ByEight(byte[] charbyte, int chars_to_string)
        {
            int all_read_chars = charbyte.Length;
            int full_str = ((all_read_chars / chars_to_string) * (chars_to_string * 5 + 2)) + ((chars_to_string * 5) + 2);
            StringBuilder str_by_eight = new StringBuilder(full_str);
            int count_char_place = 0;
            int count_full_char_string = 0;
            for (int i = 0; i < all_read_chars; i++)
            {
                if (str_by_eight.Length < (count_char_place * 3) + count_full_char_string)
                {
                    str_by_eight.Append(string.Format("{0:X2} ", charbyte[i]));
                }
                else
                {
                    str_by_eight.Insert((count_char_place * 3) + count_full_char_string, string.Format("{0:X2} ", charbyte[i]));
                }
                char prt_char = (char)charbyte[i];
                if (Char.IsWhiteSpace(prt_char) || Char.IsControl(prt_char))
                {
                    prt_char = '.'; // Заменяем нечитаемые символы точкой
                }
                str_by_eight.Append(string.Format(" {0}", prt_char));
                count_char_place++;
                if (count_char_place == chars_to_string) // Достигли конца полной строки
                {
                    str_by_eight.Insert(count_char_place * 3 + count_full_char_string, "\t|");
                    count_char_place = 0;
                    count_full_char_string += chars_to_string * 5 + 2; // 24 - hex+" ", 2 - "tab|", 16 - " "+ascii - это для 8 знаков в строке
                }
            }
            if (count_char_place > 0) // Последняя неполная строка. Добиваем пробелами до полной.
            {
                for (int i = count_char_place; i < chars_to_string; i++)
                {
                    str_by_eight.Insert(i * 3 + count_full_char_string, "   ");
                }
                str_by_eight.Insert(chars_to_string * 3 + count_full_char_string, "\t|");
            }
            while ((count_full_char_string / chars_to_string * 5 + 2) > 1) // Расставляем переносы для удобства чтения
            {
                str_by_eight.Insert(count_full_char_string, Environment.NewLine);
                count_full_char_string -= chars_to_string * 5 + 2;
            }
            return str_by_eight.ToString();
        }
    }
}
