using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Text.Json;

namespace SuperCalc
{
    public class JSONRepository
    {
        public string PathName => _pathName;
        private string _pathName;

        public string[,] GetData()
        {
            if (string.IsNullOrEmpty(PathName)) throw new Exception("Не указан путь до файла");

            string json = File.ReadAllText(PathName);
            string[][]? deserializedData = JsonConvert.DeserializeObject<string[][]>(json);

            if (deserializedData is null) throw new Exception("Пустой файл");

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

        public void Save(string[,] data)
        {
            if (string.IsNullOrEmpty(PathName)) throw new Exception("Не указан путь до файла");

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

        public void OnPathChanged(string path)
        {
            _pathName = path;
        }
    }
}
