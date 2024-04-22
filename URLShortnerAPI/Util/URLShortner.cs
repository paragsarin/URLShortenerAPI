using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // Import Newtonsoft.Json for JSON serialization

namespace URLShortenerAPI.Util
{
    public class URLShortener
    {
        // Dictionaries to store short-to-long and long-to-short URL mappings
        private static Dictionary<string, string> shortToLong = new Dictionary<string, string>();
        private static Dictionary<string, string> longToShort = new Dictionary<string, string>();
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int shortURLLength = 6;
        private static string dataFilePath = "shortener_data.json"; // File path to store data

        // Static constructor to initialize and load data from file
        static URLShortener()
        {
            // Load data from file if it exists
            LoadDataFromFile();
        }

        // Method to shorten a long URL
        public static string ShortenURL(string longURL)
        {
            if (longToShort.ContainsKey(longURL))
            {
                return longToShort[longURL];
            }
            else
            {
                string shortURL = GenerateShortURL();
                shortToLong.Add(shortURL, longURL);
                longToShort.Add(longURL, shortURL);
                // Save data to file
                SaveDataToFile();
                return shortURL;
            }
        }

        // Method to retrieve the long URL from a short URL
        public static string GetLongURL(string shortURL)
        {
            if (shortToLong.ContainsKey(shortURL))
            {
                return shortToLong[shortURL];
            }
            else
            {
                return null;
            }
        }

        // Method to generate a random short URL
        private static string GenerateShortURL()
        {
            Random random = new Random();
            char[] shortURL = new char[shortURLLength];
            for (int i = 0; i < shortURLLength; i++)
            {
                shortURL[i] = chars[random.Next(chars.Length)];
            }
            return new string(shortURL);
        }

        // Method to save data to file using JSON serialization
        private static void SaveDataToFile()
        {
            string jsonData = JsonConvert.SerializeObject(new { ShortToLong = shortToLong, LongToShort = longToShort });
            File.WriteAllText(dataFilePath, jsonData);
        }

        // Method to load data from file using JSON deserialization
        private static void LoadDataFromFile()
        {
            if (File.Exists(dataFilePath))
            {
                string jsonData = File.ReadAllText(dataFilePath);
                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);
                shortToLong = data.ShortToLong.ToObject<Dictionary<string, string>>();
                longToShort = data.LongToShort.ToObject<Dictionary<string, string>>();
            }
        }
    }

    
}
