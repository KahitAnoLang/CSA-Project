using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Threading;
using MahApps.Metro.Controls.Dialogs;

namespace CSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatch = new DispatcherTimer();
            dispatch.Interval = new TimeSpan(0, 0, 0, 0, 100);
            dispatch.Tick += dispatch_Tick;
            dispatch.Start();
        }

        private void dispatch_Tick(object sender, EventArgs e)
        {
            Dtime.Content = DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToLongTimeString();
        }


        private void button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Animation.DropShadowOpacity(button, 0.0, TimeSpan.FromMilliseconds(0));
        }
        private void button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            flyoutAdList.IsOpen = true;
            Animation.DropShadowOpacity(button, 0.3, TimeSpan.FromMilliseconds(0));
        }

        private void Generic_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            Animation.TranslateX(s, 30.0, TimeSpan.FromMilliseconds(100));
        }

        private void Generic_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            if(s.Uid=="0")
            Animation.TranslateX(s, 0.0, TimeSpan.FromMilliseconds(50));
        }

        private static Point p = new Point(30, 0);
        private void MenuBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            s.RenderTransform.Transform(p);
            TimeGrid.Uid = "0";
            SessionGrid.Uid = "0";
            CareGrid.Uid = "0";
            AdviserGrid.Uid = "0";
            MasterListGrid.Uid = "0";
            ReportsGrid.Uid = "0";
            SettingGrid.Uid = "0";
            Animation.TranslateX(TimeGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(SessionGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(CareGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(AdviserGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(MasterListGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(ReportsGrid, 0.0, TimeSpan.FromMilliseconds(100));
            Animation.TranslateX(SettingGrid, 0.0, TimeSpan.FromMilliseconds(100));
            s.Uid="1";
            Animation.TranslateX(s, 30.0, TimeSpan.FromMilliseconds(0));
            TInOutGrid.Visibility = Visibility.Collapsed;
            SessionsGrid.Visibility = Visibility.Collapsed;
            CareMainGrid.Visibility = Visibility.Collapsed;
            AvailabilityGrid.Visibility = Visibility.Collapsed;
            MLGrid.Visibility = Visibility.Collapsed;
            RepGrid.Visibility = Visibility.Collapsed;
            SetGrid.Visibility = Visibility.Collapsed;
            switch (s.Name)
            {
                case "TimeGrid":
                    TInOutGrid.Visibility = Visibility.Visible;
                    break;
                case "SessionGrid":
                    SessionsGrid.Visibility = Visibility.Visible;
                    break;
                case "CareGrid":
                    CareMainGrid.Visibility = Visibility.Visible;
                    break;
                case "AdviserGrid":
                    AvailabilityGrid.Visibility = Visibility.Visible;
                    break;
                case "MasterListGrid":
                    MLGrid.Visibility = Visibility.Visible;
                    break;
                case "ReportsGrid":
                    RepGrid.Visibility = Visibility.Visible;
                    break;
                case "SettingGrid":
                    SetGrid.Visibility = Visibility.Visible;
                    break;
            }
            
        }
        private void Sessions_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            Animation.DropShadowOpacity(s, 0.0, TimeSpan.FromMilliseconds(0));
        }
        private void Sessions_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement s = sender as FrameworkElement;
            Animation.DropShadowOpacity(s, 0.3, TimeSpan.FromMilliseconds(0));
            CreateSessionGrid.Visibility = Visibility.Collapsed;
            ViewSessionGrid.Visibility = Visibility.Collapsed;
            SchedSessionGrid.Visibility = Visibility.Collapsed;
            CreateSessionBtn.Background = new SolidColorBrush(Color.FromRgb(154, 175, 220));
            ViewSessionBtn.Background = new SolidColorBrush(Color.FromRgb(154, 175, 220));
            SchedSessionBtn.Background = new SolidColorBrush(Color.FromRgb(154, 175, 220));

            switch (s.Name)
            {
                case "CreateSessionBtn":
                    CreateSessionGrid.Visibility = Visibility.Visible;
                    CreateSessionBtn.Background = new SolidColorBrush(Color.FromRgb(11, 153, 170));
                    break;
                case "ViewSessionBtn":
                    ViewSessionGrid.Visibility = Visibility.Visible;
                    ViewSessionBtn.Background = new SolidColorBrush(Color.FromRgb(11, 153, 170));
                    break;
                case "SchedSessionBtn":
                    SchedSessionGrid.Visibility = Visibility.Visible;
                    SchedSessionBtn.Background = new SolidColorBrush(Color.FromRgb(11, 153, 170));
                    break;
            }
        }

        private async void adminLogin_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //AdminLogin al = new AdminLogin();
            //al.ShowDialog();
          
            LoginDialogData s= await this.ShowLoginAsync("Admin Login", "Enter Username and Password \t\t\t(ESC to cancel)");
            
            CareGrid.Visibility = Visibility.Visible;
            AdviserGrid.Visibility = Visibility.Visible;
            MasterListGrid.Visibility = Visibility.Visible;
            ReportsGrid.Visibility = Visibility.Visible;
            SettingGrid.Visibility = Visibility.Visible;
            yurLbl.Visibility = Visibility.Visible;
            UsernameViewLbl.Visibility = Visibility.Visible;
            adminLogout.Visibility = Visibility.Visible;
            loginLbl.Visibility = Visibility.Collapsed;
            adminLogin.Visibility = Visibility.Collapsed;
            AnimationSet.Add(CareGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Add(CareGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
            AnimationSet.Add(AdviserGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(100)));
            AnimationSet.Add(AdviserGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100)));
            AnimationSet.Add(MasterListGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(200)));
            AnimationSet.Add(MasterListGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(200)));
            AnimationSet.Add(ReportsGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(300)));
            AnimationSet.Add(ReportsGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(300)));
            AnimationSet.Add(SettingGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 100.0, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(400)));
            AnimationSet.Add(SettingGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(400)));
            AnimationSet.Run();

        }

        private void adminLogout_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (r == MessageBoxResult.Yes)
            {
                AnimationSet.Add(SettingGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(SettingGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 30.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(0)));
                AnimationSet.Add(ReportsGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100)));
                AnimationSet.Add(ReportsGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 30.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100)));
                AnimationSet.Add(MasterListGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(200)));
                AnimationSet.Add(MasterListGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 30.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(200)));
                AnimationSet.Add(AdviserGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(300)));
                AnimationSet.Add(AdviserGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 30.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(300)));
                AnimationSet.Add(CareGrid, AnimationKind.Opacity, AnimationFactory.Create(AnimationType.DoubleAnimation, 0.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(400)));
                AnimationSet.Add(CareGrid, AnimationKind.TranslateX, AnimationFactory.Create(AnimationType.DoubleAnimation, 30.0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(400)));
                AnimationSet.Run();
                CareGrid.Visibility = Visibility.Collapsed;
                AdviserGrid.Visibility = Visibility.Collapsed;
                MasterListGrid.Visibility = Visibility.Collapsed;
                ReportsGrid.Visibility = Visibility.Collapsed;
                SettingGrid.Visibility = Visibility.Collapsed;
                yurLbl.Visibility = Visibility.Collapsed;
                UsernameViewLbl.Visibility = Visibility.Collapsed;
                adminLogout.Visibility = Visibility.Collapsed;
                loginLbl.Visibility = Visibility.Visible;
                adminLogin.Visibility = Visibility.Visible;
            }

        }

        private void TimeInBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            TimeInKey tk = new TimeInKey();
            tk.ShowDialog();
        }

        private void TimeOutBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //test first if there is a selected item in listview before doing this
            MessageBoxResult res = MessageBox.Show("Timing out?", "Time-out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(res==MessageBoxResult.Yes)
            {
                //do shit here
            }
        }

        private void SetSched_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetAdviserSched s = new SetAdviserSched();
            s.ShowDialog();
        }
    }
}
