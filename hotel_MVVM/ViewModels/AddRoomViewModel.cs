using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.ViewModels.Base;
using hotel_MVVM.Views;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace hotel_MVVM.ViewModels
{
    public class AddRoomViewModel : ViewModel
    {
        private IRoomService _roomService;
        private AddAdminWindow _wnd;

        private ICommand _addImageCommand;
        private ICommand _addRoomCommand;
        private string _nameImage;
        private string _imagePath;

        private string _roomName;
        private string _roomPrice;
        private string _roomDescription;
        private int _roomCapacity;

        public AddRoomViewModel(AddAdminWindow window, IRoomService roomService)
        {
            _wnd = window;
            _roomService = roomService;
        }

        public string RoomName
        {
            get => _roomName;
            set
            {
                if (!Set(ref _roomName, value)) return;
            }
        }
        public string RoomPrice
        {
            get => _roomPrice;
            set
            {
                if (!Set(ref _roomPrice, value)) return;
            }
        }
        public string RoomDesc
        {
            get => _roomDescription;
            set
            {
                if (!Set(ref _roomDescription, value)) return;
            }
        }
        public int RoomCapacity
        {
            get => _roomCapacity;
            set
            {
                if (!Set(ref _roomCapacity, value)) return;
            }
        }

        public ICommand AddImageCommand
        {
            get
            {
                if (_addImageCommand == null)
                {
                    _addImageCommand = new RelayCommand(AddImage);
                }
                return _addImageCommand;
            }
        }

        public ICommand AddRoomCommand
        {
            get
            {
                if (_addRoomCommand == null)
                {
                    _addRoomCommand = new RelayCommand(SaveData);
                }
                return _addRoomCommand;
            }
        }

        private void AddImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Отображаем выбранное изображение в Image элементе
                _imagePath = openFileDialog.FileName;
                _nameImage = Path.GetFileName(_imagePath);
                BitmapImage bitmapImage = new BitmapImage(new System.Uri(_imagePath));
                SelectedImageSource = bitmapImage;

            }
        }

        private void SaveImage()
        {
            string projectFolder = Directory.GetCurrentDirectory();
            string destinationPath = Path.Combine(projectFolder, "Images", Path.GetFileName(_imagePath));

            // Если папка Images не существует, создаем ее
            string imagesFolder = Path.Combine(projectFolder, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
          
            if (!File.Exists(destinationPath))
            {
                File.Copy(_imagePath, destinationPath, true);
            }
        }

        private void SaveData(object parametr)
        {
            //int roomPlace = Convert.ToInt32(RoomPlace.SelectedItem);
            if (!int.TryParse(RoomPrice, out int roomPrice))
            {
                MessageBox.Show("Заполните стоимость", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (SelectedImageSource != null)
                SaveImage();
            if (string.IsNullOrWhiteSpace(RoomName) || roomPrice<=0 ||
                 string.IsNullOrWhiteSpace(RoomDesc) || RoomCapacity <= 0)
            {
                MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Прерываем сохранение данных
            }
            RoomDTO roomDTO = new RoomDTO();
            roomDTO.RoomName = RoomName;
            roomDTO.PhotoName = _nameImage;
            roomDTO.Capacity = RoomCapacity;
            roomDTO.Price = roomPrice;
            roomDTO.Description = RoomDesc;
            _roomService.CreateRoom(roomDTO);

            _wnd.Close();
        }

        private BitmapImage _selectedImageSource;

        public BitmapImage SelectedImageSource
        {
            get => _selectedImageSource;
            set
            {
                if (!Set(ref _selectedImageSource, value)) return;
            }
        }

    }
}
