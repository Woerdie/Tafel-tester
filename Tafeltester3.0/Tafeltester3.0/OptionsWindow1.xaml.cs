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
using Tafeltester3._0.Properties;

namespace Tafeltester3._0
{
    /// <summary>
    /// Interaction logic for OptionsWindow1.xaml
    /// </summary>
    public partial class OptionsWindow1 : Window
    {

        public OptionsWindow1()
        {
            InitializeComponent();
            Naam.Text = Settings.Default["username"].ToString();
            label();
        }


        private void label()
        {
            switch (Settings.Default["Diffilculty"])
            {
                case 0:
                    nee.Content = "de geselceteerde moelijkheidsgraad is easy";
                    break;
                case 1:
                    nee.Content = "de geselceteerde moelijkheidsgraad is normaal";
                    break;
                        case 2:
                    nee.Content = "de geselceteerde moelijkheidsgraad is hard";
                    break;
            }
            
                }

        //easy
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Diffilculty"] = 0;
            Settings.Default.Save();
            label();
            
        }
        //normaal
        private void normal_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Diffilculty"] = 1;
            Settings.Default.Save();
            label();
        }
        //hurd
        private void hard_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Diffilculty"] = 2;
            Settings.Default.Save();
            label();
        }

        private void Naam_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow game = new MainWindow();
            game.Show();
            this.Close();
        }

        private void Naam_KeyUp(object sender, KeyEventArgs e)
        {
            Settings.Default["username"] = Naam.Text;
            Settings.Default.Save();
        }
    }
}
