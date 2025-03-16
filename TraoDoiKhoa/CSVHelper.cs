using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TraoDoiKhoa
{
    public class CSVHelper
    {
        private const string Header = "User_Id,Name,p,a,y"; // Tiêu đề của file CSV

        /// <summary>
        /// Ghi dữ liệu vào file CSV, nếu ID đã tồn tại thì ghi đè, nếu không thì thêm mới.
        /// </summary>
        public void WriteOrUpdateById(string filePath, DataModel newData)
        {
            List<DataModel> data = new List<DataModel>();

            // Đọc toàn bộ dữ liệu từ file nếu tồn tại
            if (File.Exists(filePath))
            {
                data = ReadAll(filePath);
            }

            // Kiểm tra và ghi đè theo ID
            bool found = false;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].id_ == newData.id_)
                {
                    data[i] = newData; // Ghi đè dữ liệu
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                data.Add(newData); // Thêm mới nếu ID không tồn tại
            }

            // Ghi toàn bộ dữ liệu lại vào file
            WriteAll(filePath, data);
        }

        /// <summary>
        /// Đọc dữ liệu từ file CSV theo ID.
        /// </summary>
        public DataModel ReadById(string filePath, int id)
        {
            List<DataModel> data = new List<DataModel>();

            // Sử dụng using để tự động đóng file sau khi đọc xong
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                // Đọc toàn bộ dữ liệu từ file
                string line;
                bool skipHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    // Bỏ qua dòng tiêu đề
                    if (skipHeader)
                    {
                        skipHeader = false;
                        continue;
                    }

                    var parts = line.Split(',');

                    if (parts.Length >= 5)
                    {
                        data.Add(new DataModel
                        {
                            id_ = int.Parse(parts[0]),
                            Name = parts[1],
                            p = parts[2],
                            a = parts[3],
                            y = parts[4]
                        });
                    }
                }
            }

            // Tìm dữ liệu theo ID
            foreach (var item in data)
            {
                if (item.id_ == id)
                {
                    return item;
                }
            }

            return null; // Trả về null nếu không tìm thấy
        }

        /// <summary>
        /// Ghi toàn bộ danh sách dữ liệu vào file CSV.
        /// </summary>
        private void WriteAll(string filePath, List<DataModel> data)
        {
            List<string> lines = new List<string>();

            // Ghi tiêu đề
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Ghi tiêu đề
                writer.WriteLine(Header);

                // Ghi dữ liệu
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.id_},{item.Name},{item.p},{item.a},{item.y}");
                }
            }
        }

        /// <summary>
        /// Đọc toàn bộ dữ liệu từ file CSV.
        /// </summary>
        public List<DataModel> ReadAll(string filePath)
        {
            List<DataModel> data = new List<DataModel>();

            var lines = File.ReadAllLines(filePath);

            // Bỏ qua dòng tiêu đề
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');

                if (parts.Length >= 5)
                {
                    data.Add(new DataModel
                    {
                        id_ = int.Parse(parts[0]),
                        Name = parts[1],
                        p = parts[2],
                        a = parts[3],
                        y = parts[4]
                    });
                }
            }

            return data;
        }
    }

    /// <summary>
    /// Mô hình dữ liệu cho file CSV.
    /// </summary>
    public class DataModel
    {
        public int id_ { get; set; }
        public string Name { get; set; }
        public string p { get; set; }
        public string a { get; set; }
        public string y { get; set; }
    }
}
