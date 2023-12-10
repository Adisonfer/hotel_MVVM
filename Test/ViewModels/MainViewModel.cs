using hotel_MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ViewModels;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object mainContent;

        public object MainContent
        {
            get { return mainContent; }
            set
            {
                mainContent = value;
                OnPropertyChanged(nameof(MainContent));
            }
        }

        public MainViewModel()
        {
            // По умолчанию отображаем "Номера"
            ShowNumbers();
        }

        public void ShowNumbers()
        {
            MainContent = new NumbersViewModel();
        }

        public void ShowReservations()
        {
            MainContent = new ReservationsViewModel();
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
