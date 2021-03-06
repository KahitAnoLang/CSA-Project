﻿using System;
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
using CSAStudentMS.Models;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CSA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ObservableCollection<StudentListViewItem> students = new ObservableCollection<StudentListViewItem>();
        private bool IsPeer = false, IsIn = false;
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
            RefreshActiveAdvisers();    
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
            FrameworkElement g = sender as FrameworkElement;
            g.RenderTransform.Transform(p);
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
            g.Uid="1";
            Animation.TranslateX(g, 30.0, TimeSpan.FromMilliseconds(0));
            TInOutGrid.Visibility = Visibility.Collapsed;
            SessionsGrid.Visibility = Visibility.Collapsed;
            CareMainGrid.Visibility = Visibility.Collapsed;
            AvailabilityGrid.Visibility = Visibility.Collapsed;
            MLGrid.Visibility = Visibility.Collapsed;
            RepGrid.Visibility = Visibility.Collapsed;
            SetGrid.Visibility = Visibility.Collapsed;
            switch (g.Name)
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
                    SettingsPass p = new SettingsPass(this);
                    p.ShowDialog();
                    if (p.DialogResult.Value==true)
                    {
                    SetGrid.Visibility = Visibility.Visible;
                        EditUserNameTb.Text = s.Username;
                        EditPassTb.Text = s.Password.ToString();
                    }
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

        public LoginDialogData s;

        private async void adminLogin_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //AdminLogin al = new AdminLogin();
            //al.ShowDialog();
            
            s= await this.ShowLoginAsync("Admin Login", "Enter Username and Password \t\t\t(ESC to cancel)");

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
                SessionsGrid.Visibility = Visibility.Collapsed;
                CareMainGrid.Visibility = Visibility.Collapsed;
                AvailabilityGrid.Visibility = Visibility.Collapsed;
                MLGrid.Visibility = Visibility.Collapsed;
                RepGrid.Visibility = Visibility.Collapsed;
                SetGrid.Visibility = Visibility.Collapsed;
                TInOutGrid.Visibility = Visibility.Visible;
                loginLbl.Visibility = Visibility.Visible;
                adminLogin.Visibility = Visibility.Visible;
                Animation.TranslateX(TimeGrid, 30.0, TimeSpan.FromMilliseconds(0));
                Animation.TranslateX(SessionGrid, 0.0, TimeSpan.FromMilliseconds(0));
            }

        }

        private void TimeInBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //TimeInKey tk = new TimeInKey();
           // tk.ShowDialog();
            
        }

        private void TimeOutBtn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //test first if there is a selected item in listview before doing this
       
                MessageBoxResult res = MessageBox.Show("Timing out?", "Time-out", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    Student s = new Student(StdNumTimeOut.Text);
                    Attendance a = new Attendance(DateTime.Now);
                    AttendanceDB ADB = new AttendanceDB(s, a);
                    ADB.EditEntry();
                    ADB.DeleteEntry();
                }
        }
        private void SetSched_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetAdviserSched s = new SetAdviserSched();
            s.ShowDialog();
        }

        private void StdNumTimeIn_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsPeerAdviser(StdNumTimeIn.Text))
            {
                UpdateCredentials(StdNumTimeIn.Text);
            }
            
        }

        async private void TimeInBtn_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student(StdNumTimeIn.Text);
            Attendance a = new Attendance(DateTime.Now);
            AttendanceDB ADB = new AttendanceDB(s, a);
            if (IsPeerAdviser(s.IdNum) == true)
            {
                if (IsTimedIn(s.IdNum) == false)
                {
                    ADB.AddEntry();
                    ADB.AddToLogs();
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
                    SqlCommand command = new SqlCommand("SELECT Studno, Name, Program, Year from Students where Studno ='" + s.IdNum + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);          
            DataTable dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
            {
                        AddToActiveAdvisers(Convert.ToString(dr["Name"]));
                        students.Add(new StudentListViewItem()
                        {
                            StudNo = Convert.ToString(dr["StudNo"]),
                            Name = Convert.ToString(dr["Name"]),
                            Year = Convert.ToInt32(dr["Year"]),
                            Program = Convert.ToString(dr["Program"])
                        });
            }

                    AdvListTimeOut.ItemsSource = students;
                }
                else if (IsTimedIn(s.IdNum) == false)
        {
                    await this.ShowMessageAsync("Time In Error", "Adviser is already logged in!");
                }
            }
            else
            {
                await this.ShowMessageAsync("Time In Error", "Invalid ID number!");
            }          
        }
        public void RefreshActiveAdvisers()
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT Studno, Name, Program, Year from Students", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (IsPeerAdviser(Convert.ToString(dr["StudNo"])))
                {
                    if (IsTimedIn(Convert.ToString(dr["StudNo"])))
                    {
                        AddToActiveAdvisers(Convert.ToString(dr["Name"]));
                students.Add(new StudentListViewItem()
                {
                    StudNo = Convert.ToString(dr["StudNo"]),
                            Name = Convert.ToString(dr["Name"]),
                            Year = Convert.ToInt32(dr["Year"]),
                            Program = Convert.ToString(dr["Program"])
                });               
            }
                }
            }
            AdvListTimeOut.ItemsSource = students;
        }

        private void ClearActiveAdvisers()
        {
            
            WrapPanel panel = (WrapPanel)FindName("PeerAdviserStack");
            panel.Children.Clear();
        }

        private void TimeOutBtn_Click(object sender, RoutedEventArgs e)
        {
            

        }

        public void AddToActiveAdvisers(string aname)
        {
            WrapPanel panel = (WrapPanel)FindName("PeerAdviserStack");
            Grid grid = new Grid();
            grid.Height = 30;
            grid.Width = 230;
            grid.Margin = new Thickness(1);
            grid.Background = new SolidColorBrush(Colors.Transparent);

            TextBlock name = new TextBlock();
            name.Text = aname;
            name.FontSize = 14;
            name.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            name.TextWrapping = TextWrapping.Wrap;
            name.Background = new SolidColorBrush(Colors.Transparent);
            name.TextAlignment = TextAlignment.Center;

            ToggleSwitch toggle = new ToggleSwitch();
            toggle.Margin = new Thickness(0, 110, 25, 0);
            toggle.OffSwitchBrush = new SolidColorBrush(Color.FromRgb(17, 158, 218));
            toggle.OnSwitchBrush = new SolidColorBrush(Color.FromRgb(160, 222, 72));
            toggle.Foreground = new SolidColorBrush(Colors.Transparent);
            toggle.HorizontalAlignment = HorizontalAlignment.Center;
            ScaleTransform size = new ScaleTransform(1, 0.5);
            toggle.RenderTransform = size;

            grid.Children.Add(name);
            panel.Children.Insert(0, grid);
        }
       
        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement w = sender as FrameworkElement;
            switch (w.Name)
            {
                case "EditUserBtn":
                    EditUserNameTb.IsEnabled = true;
                    break;
                case "EditPassBtn":
                    EditPassTb.IsEnabled = true;
                    break;
                case "CancelEditBtn":
                    EditUserNameTb.Text = s.Username;
                    EditPassTb.Text = s.Password.ToString();
                    EditPassTb.IsEnabled = false;
                    EditUserNameTb.IsEnabled = false;
                    break;
                case "CancelBtn":
                    AnnounceTitleTb.Clear();
                    AnnounceContentTb.Clear();
                    break;
                case "VeiwAnnouncementBtn":
                    Announcements ann = new Announcements();
                    ann.ShowDialog();
                    break;
            }
        }
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //closing verification
        }
      

        private bool IsTimedIn(string v)
        { 
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * from Attendance where Studno = '" + v + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                IsIn = true;
            }
            else if (dt.Rows.Count == 0)
            {
                IsIn = false;
            }                
            return IsIn;
        }

        private bool IsPeerAdviser(string idno)
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * from PeerAdviser where Studno = '" + idno + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {   
                IsPeer = true;
            }
            else
                IsPeer = false;
            return IsPeer;
        }

        private void UpdateCredentials(string idno)
        {
            SqlConnection conn = new SqlConnection(Settings.ConnectionString);
            SqlCommand command = new SqlCommand("SELECT Name, Program, Year from Students where Studno = '" + idno + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                NameLbl.Content = Convert.ToString(dr[0]);
                ProgLbl.Content = Convert.ToString(dr[1]);
                YearLbl.Content = Convert.ToString(dr[2]);
            }
        }

    }
}
