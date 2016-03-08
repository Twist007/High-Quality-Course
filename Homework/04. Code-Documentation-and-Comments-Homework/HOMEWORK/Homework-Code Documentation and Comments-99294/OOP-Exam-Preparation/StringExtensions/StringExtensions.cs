namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A static class holding extension methods to the String class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Computes the MD5 hash value of a string 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the hash as a 32-character, hexadecimal-formatted string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Check if a string is equal to one of the following: "true", "ok", "yes", "1", "да".
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a string to a short numeric type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a short if conversion was successful and false if not.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a string to an integer numeric type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns an integer if conversion was successful and false if not.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a string to long numeric type
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns an integer if conversion was successful and false if not.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a string to DateTime
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns DateTime if conversion was successful and false if not.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts the input string to title case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return
                input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Retrieves a substring between the startString and endString from the input string. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startString"></param>
        /// <param name="endString"></param>
        /// <param name="startFrom"></param>
        /// <returns></returns>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition =
                input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts a string from cyrillic to latin
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the latin representation of the input cyrillic string in upper case.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
            var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts a string from latin to cyrillic
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns the cyrillic representation of the input latin string in upper case.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

            var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Validates an username containing cyrillic letters. 
        /// Converts all cyrillic letters into latin ones and removes all symbols 
        /// other than letters, digits, underscore and dot.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Validates a file name. 
        /// Converts all cyrillic letters into latin ones, replaces all whitespaces with a hyphen symbol
        /// and removes all symbols other than letters, digits, underscore, hyphen and dot.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extracts a substring with a specified length out of the input string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="charsCount"></param>
        /// <returns></returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the extension of the specified file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of a file according to its extension.
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string into an array of bytes.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }

}
