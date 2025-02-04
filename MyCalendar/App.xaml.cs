namespace MyCalendar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Set tab bar appearance
            var navigationPage = Application.Current.MainPage as NavigationPage;
            Microsoft.Maui.Handlers.NavigationViewHandler.Mapper.AppendToMapping("CustomNavigationPage", (handler, view) =>
            {
#if ANDROID
            if (handler.PlatformView is Android.Widget.LinearLayout layout)
            {
                layout.ShowDividers = Android.Widget.ShowDividers.None;
                layout.DividerPadding = 0;
            }
#endif
            });
        }
    }
}
