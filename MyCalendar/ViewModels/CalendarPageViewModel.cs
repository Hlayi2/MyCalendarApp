using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;

namespace MyCalendar.ViewModels
{
    public class CalendarPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CalendarDay> _calendarDays;

        public ObservableCollection<CalendarDay> CalendarDays
        {
            get => _calendarDays;
            set
            {
                if (_calendarDays != value)
                {
                    _calendarDays = value;
                    OnPropertyChanged();
                }
            }
        }

        public CalendarPageViewModel()
        {
            _calendarDays = new ObservableCollection<CalendarDay>();
            GenerateCalendarDays();
        }

        private void GenerateCalendarDays()
        {
            CalendarDays.Clear();

            // First, calculate the start day of the month (Thursday is index 4)
            int startDayIndex = 4; // For February 2024, starts on Thursday

            // Add empty cells for days before the 1st
            for (int i = 0; i < startDayIndex; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    DayNumber = "",
                    Background = Color.FromArgb("#2B2B2B"),
                    TextColor = Color.FromArgb("#6B6B6B"),
                    CycleDay = ""
                });
            }

            // Add all days of February
            for (int day = 1; day <= 28; day++)
            {
                bool isToday = day == 3; // Assuming Feb 3 is today
                bool hasPeriod = day == 1 || day == 2 || day == 4 || day == 26 || day == 27 || day == 28;
                bool isFertile = day >= 17 && day <= 21;

                CalendarDays.Add(new CalendarDay
                {
                    DayNumber = day.ToString(),
                    Background = isToday ? Color.FromArgb("#6B4CD3") : Color.FromArgb("#2B2B2B"),
                    TextColor = isToday ? Colors.White : (isFertile ? Color.FromArgb("#FF4B91") : Colors.White),
                    HasPeriod = hasPeriod,
                    CycleDay = (day + 12).ToString() // Example cycle day calculation
                });
            }

            // Add empty cells for remaining days if needed
            int remainingCells = 42 - CalendarDays.Count; // 42 = 6 rows × 7 days
            for (int i = 0; i < remainingCells; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    DayNumber = "",
                    Background = Color.FromArgb("#2B2B2B"),
                    TextColor = Color.FromArgb("#6B6B6B"),
                    CycleDay = ""
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CalendarDay : INotifyPropertyChanged
    {
        private string _dayNumber;
        private Color _background;
        private Color _textColor;
        private bool _hasPeriod;
        private string _cycleDay;

        public string DayNumber
        {
            get => _dayNumber;
            set
            {
                if (_dayNumber != value)
                {
                    _dayNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color Background
        {
            get => _background;
            set
            {
                if (_background != value)
                {
                    _background = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color TextColor
        {
            get => _textColor;
            set
            {
                if (_textColor != value)
                {
                    _textColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool HasPeriod
        {
            get => _hasPeriod;
            set
            {
                if (_hasPeriod != value)
                {
                    _hasPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CycleDay
        {
            get => _cycleDay;
            set
            {
                if (_cycleDay != value)
                {
                    _cycleDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}