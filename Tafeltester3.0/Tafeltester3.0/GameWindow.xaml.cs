using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window

    {

        public GameWindow()
        {
            InitializeComponent();
            generateSom();
        }
        public int awnser;
        public int userinput;
        public int score;
        public int Diff;
        private void generateSom()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();


            int numOfOperand = r.Next(1, 3); // it is just a test so I just want to have up to 20 operands.
            int randomNumber;
            string Difficulty = Settings.Default["Diffilculty"].ToString();
            Diff = Int32.Parse(Difficulty);
            switch (Diff)
            {
                case 0:
                    randomNumber = r.Next(1, 100);
                    numOfOperand = r.Next(1, 3);
                    break;
                case 1:
                    randomNumber = r.Next(1, 200);
                    numOfOperand = r.Next(1, 4);
                    break;
                case 2:
                    randomNumber = r.Next(1, 1000);
                    numOfOperand = r.Next(1, 5);
                    break;
                default:
                    randomNumber = r.Next(1, 100);
                    numOfOperand = r.Next(1, 3);
                    break;
            }
            for (int i = 0; i < numOfOperand; i++)
            {

                randomNumber = r.Next(1, 100);
                builder.Append(randomNumber);


                int randomOperand = r.Next(1, 2);

                string operand = null;

                switch (randomOperand)
                {
                    case 1:
                        operand = "+";
                        break;
                    case 2:
                        operand = "*";
                        break;
                    case 3:
                        operand = "-";
                        break;
                    case 4:
                        operand = "/";
                        break;
                }
                builder.Append(operand);
            }
            randomNumber = r.Next(1, 100);
            builder.Append(randomNumber);
            DataTable dt = new DataTable();
            var v = dt.Compute(builder.ToString(), "").ToString();
            awnser = Int32.Parse(v);
            SomLabel.Content = builder.ToString();
        }
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void awnserbox_GotFocus(object sender, RoutedEventArgs e)
        {
            awnserbox.Text = null;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (awnserbox.Text != "")
            {
                userinput = Int32.Parse(awnserbox.Text);
                CheckAwnser();
            }
            
                
        }

        private void CheckAwnser()
        {
            if (awnser == userinput)
            {
                score++;
                naamscore.Content = score.ToString();
                awnserbox.Text = null;
                MessageBox.Show("Dat is goed. ");
                generateSom();

            }
            else{
                MessageBox.Show("Dat is fout! Het goie antwoord was " + awnser.ToString());
                Settings.Default["score"] = score;
                ScoreWindow main = new ScoreWindow();
                main.Show();
                this.Close();
            }
        }

       
    }
}
