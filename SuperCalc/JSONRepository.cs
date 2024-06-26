﻿using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Text.Json;

namespace SuperCalc
{
    /// <summary>
    /// Класс репозиторий с таблицей.
    /// </summary>
    public class JSONRepository
    {
        public string PathName => _pathName;
        private string _pathName;

        /// <summary>
        /// Метод для чтения файла.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string[,] GetData()
        {
            if (string.IsNullOrEmpty(PathName)) throw new ArgumentException("Не указан путь до файла");

            string json = File.ReadAllText(PathName);
            string[][]? deserializedData = JsonConvert.DeserializeObject<string[][]>(json);

            if (deserializedData is null) throw new ArgumentException("Пустой файл");

            string[,] data = new string[deserializedData.Length, deserializedData[0].Length];

            for (int i = 0; i < deserializedData.Length; i++)
            {
                for (int j = 0; j < deserializedData[i].Length; j++)
                {
                    data[i, j] = deserializedData[i][j];
                }
            }

            return data;
        }

        /// <summary>
        /// Метод для сохранения в файл.
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Save(string[,] data)
        {
            if (string.IsNullOrEmpty(PathName)) throw new ArgumentException("Не указан путь до файла");

            File.Delete(PathName);

            string[][] buffer = new string[data.GetLength(0)][];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                buffer[i] = new string[data.GetLength(1)];
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    buffer[i][j] = data[i, j];
                }
            }

            string jsonData = JsonConvert.SerializeObject(buffer, Formatting.Indented);

            File.WriteAllText(PathName, jsonData);
        }

        /// <summary>
        /// Метод для изменения пути к файлу.
        /// </summary>
        /// <param name="path"></param>
        public void OnPathChanged(string path)
        {
            _pathName = path;
        }
    }
}
