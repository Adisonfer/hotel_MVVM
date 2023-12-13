using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace hotel_MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        public AddAdminWindow()
        {
            InitializeComponent();
        }
        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;

                // Отображаем выбранное изображение в Image элементе
                BitmapImage bitmapImage = new BitmapImage(new System.Uri(imagePath));
                selectedImage.Source = bitmapImage;

                // Позволяет пользователю указать новое имя файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
                saveFileDialog.FileName = "NewImage"; // Задайте имя файла по умолчанию

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Имя, которое ввел пользователь
                    string newFileName = saveFileDialog.FileName;

                    // Папка проекта, где будем сохранять файл
                    string projectFolder = Directory.GetCurrentDirectory();

                    // Если папка Images не существует, создаем ее
                    string imagesFolder = Path.Combine(projectFolder, "Images");
                    if (!Directory.Exists(imagesFolder))
                    {
                        Directory.CreateDirectory(imagesFolder);
                    }

                    // Конечный путь файла с новым именем
                    string destinationPath = Path.Combine(imagesFolder, Path.GetFileName(newFileName));

                    // Копирование файла в папку с новым именем
                    File.Copy(imagePath, destinationPath, true);

                    MessageBox.Show("Изображение добавлено и сохранено с новым именем.");
                }
            }
        }
    }
}
