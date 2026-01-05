using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int r;
        int g;
        int b;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            r = (int)scrollR.Value;
            g = (int)scrollG.Value;
            b = (int)scrollB.Value;

            labelR.Content = r.ToString();
            labelG.Content = g.ToString();
            labelB.Content = b.ToString();

            textR.Text = r.ToString();
            textG.Text = g.ToString();
            textB.Text = b.ToString();

            UpdateColor();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
       // {
        //    pozdrav.Content = "Ahoj";
       //     if (textik.Text == "")
       //     {
       //         MessageBox.Show("Pole je prázdné");
        //    }
        //    else
           // {
         //       pozdrav.Content = textik.Text;
        //    }
//
         //   }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    //    private void pozdrav_MouseEnter(object sender, MouseEventArgs e)
    //    {
    //        Random rnd = new Random();
    //        byte r = (byte)rnd.Next(0, 255);
    //        byte g = (byte)rnd.Next(0, 255);
    //        byte b = (byte)rnd.Next(0, 255);
//
  //          pozdrav.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
   //     }

        private void scrollR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            r = (int)e.NewValue;
            labelR.Content = r.ToString();
            if (textR.Text != r.ToString())
                textR.Text = r.ToString();

            UpdateColor();
        }


        private void scrollB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            b = (int)e.NewValue;
            labelB.Content = b.ToString();
            if (textB.Text != b.ToString())
                textB.Text = b.ToString();

            UpdateColor();
        }

        private void scrollG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            g = (int)e.NewValue;
            labelG.Content = g.ToString();
            if (textG.Text != g.ToString())
                textG.Text = g.ToString();

            UpdateColor();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textR.Text))
                return;

            if (!int.TryParse(textR.Text, out int hodnota) || hodnota < 0 || hodnota > 255)
            {
                MessageBox.Show(
                    "Zadej celé číslo v rozsahu 0–255.",
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                textR.TextChanged -= TextBox_TextChanged_1; 
                textR.Text = "0";
                textR.CaretIndex = textR.Text.Length;
                textR.TextChanged += TextBox_TextChanged_1;
                return;
            }
            else
            {
                labelR.Content = hodnota.ToString();
                scrollR.Value = hodnota;
            } 
        }


        private void textG_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textG.Text))
                return;

            if (!int.TryParse(textG.Text, out int hodnota) || hodnota < 0 || hodnota > 255)
            {
                MessageBox.Show(
                    "Zadej celé číslo v rozsahu 0–255.",
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                textG.TextChanged -= TextBox_TextChanged_1;
                textG.Text = "0";
                textG.CaretIndex = textG.Text.Length;
                textG.TextChanged += TextBox_TextChanged_1;
                return;
            }
            else
            {
                labelG.Content = hodnota.ToString();
                scrollG.Value = hodnota;
            }
        }

        private void textB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textB.Text))
                return;

            if (!int.TryParse(textB.Text, out int hodnota) || hodnota < 0 || hodnota > 255)
            {
                MessageBox.Show(
                    "Zadej celé číslo v rozsahu 0–255.",
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                textB.TextChanged -= TextBox_TextChanged_1;
                textB.Text = "0";
                textB.CaretIndex = textB.Text.Length;
                textB.TextChanged += TextBox_TextChanged_1;
                return;
            }
            else
            {
                labelB.Content = hodnota.ToString();
                scrollB.Value = hodnota;
            }
        }
        private void UpdateColor()
        {
            colors.Background = new SolidColorBrush(
                Color.FromRgb((byte)r, (byte)g, (byte)b)
            );
            UpdateHexLabel();
        }
        private void UpdateHexLabel()
        {
            string hex = $"#{r:X2}{g:X2}{b:X2}";
            hexLabel.Content = hex;
        }
        private void colors_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}