using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DefectDetectionApp
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;
        private string imagePath = "";

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        // метод загрузки изображения пользователя
        private void fileDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    Bitmap image = new Bitmap(imagePath);

                    pictureBox.Image = image;
                }
            }
        }

        // метод получения результата детекции
        private void btnRunInference_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Сначала выберите изображение");
                return;
            }

            // делаем прогресс бар видимым
            progressBar.Visible = true;
            label2.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            // получаем результат детекции
            var detectionJson = RunInference(imagePath);

            var detections = JsonConvert.DeserializeObject<List<Detection>>(detectionJson);
            progressBar.Value = 75;

            // сохраняем в базу данных
            dbHelper.SaveResult(imagePath, detections.Count, detections.ToArray());
            progressBar.Value = 100;
            MessageBox.Show("Результат сохранен");

            // рисуем на изображении ограничивающие прямоугольники
            DrawBoundingBoxes(new Bitmap(imagePath), detections);
            label2.Visible = false;
            progressBar.Visible = false;
        }

        // метод запуска python скрипта, где yolo выполняет детекцию
        private string RunInference(string imagePath)
        { 
            var psi = new ProcessStartInfo
            {
                FileName = "myenv\\Scripts\\python.exe",
                Arguments = $"yolo_inference.py \"{imagePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            progressBar.Value = 25;
            string detectionJson = "";

            using (var process = Process.Start(psi))
            {
                // получаем выход модели
                using (var reader = process.StandardOutput)
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        /* помимо координат yolo также пишет информацию об объектах,
                         она здесь не нужна, поэтому сохраняем только координаты,
                         которые содержатся в массиве */
                        if (line.StartsWith("["))
                        {
                            detectionJson += line;
                            break;
                        }
                    }
                }
            }

            progressBar.Value = 50;

            return detectionJson;
        }

        // метод рисования ограничивающих прямоугольников на изображении пользователя
        private void DrawBoundingBoxes(Bitmap originalImage, List<Detection> detections)
        {
            using (Graphics g = Graphics.FromImage(originalImage))
            {
                foreach (var detection in detections)
                {
                    float width = detection.X2 - detection.X1;
                    float height = detection.Y2 - detection.Y1;

                    g.DrawRectangle(Pens.Red, detection.X1, detection.Y1, width, height);
                }
            }
            pictureBox.Image = originalImage;
        }

        // метод показа всех сохраненных детекций в базе данных
        private void showDatabase_Click(object sender, EventArgs e)
        {
            List<DataShowFormat> database = dbHelper.GetAllResults();
            Form2 dbForm = new Form2(database, dbHelper);
            dbForm.Show();
        }

        // метод удаления данных из базы
        private void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите удалить все данные?",
                                     "Подтвердите удаление",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                dbHelper.ClearDatabase();
                MessageBox.Show("Данные удалены");
            }
        }
    }
}
