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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace CSA
{
    /// <summary>
    /// Interaction logic for CreateSession.xaml
    /// </summary>
    public partial class SettingsPass : MetroWindow
    {
        MainWindow main = null;
        public SettingsPass(MainWindow m)
        {
            InitializeComponent();
            main=m;
        }
        private void SetPassBtn_Click(object sender, RoutedEventArgs e)
        {
            if (main.s.Password == passbox.Password)
            {
                DialogResult = true;
                this.Close();
            }
            this.Close();
        }

        private void SetPassBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                if (main.s.Password == passbox.Password)
                {
                    DialogResult = true;
                    this.Close();
                }
            }
        }
    }
}
