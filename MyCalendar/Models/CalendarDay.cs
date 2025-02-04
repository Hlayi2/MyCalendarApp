using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCalendar.Models
{
    public class CalendarDay : INotifyPropertyChanged
    {
        private string dayNumber;
        private Color background;
        private Color textColor;
        private bool hasPeriod;
        private string cycleDay;

        public string DayNumber
        {
            get => dayNumber;
            set
            {
                dayNumber = value;
                OnPropertyChanged();
            }
        }

        public Color Background
        {
            get => background;
            set
            {
                background = value;
                OnPropertyChanged();
            }
        }

        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                OnPropertyChanged();
            }
        }

        public bool HasPeriod
        {
            get => hasPeriod;
            set
            {
                hasPeriod = value;
                OnPropertyChanged();
            }
        }

        public string CycleDay
        {
            get => cycleDay;
            set
            {
                cycleDay = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal static void Add(CalendarDay calendarDay)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
