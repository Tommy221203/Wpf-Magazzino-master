using System;
using System.Collections.Generic;
using System.IO;
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

namespace Wpf_Magazzino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtnome.Focus();
            if(File.Exists(file_name))
                try
                {
                    using(StreamReader r=new StreamReader(file_name, Encoding.UTF8))
                    {
                        string line;
                        int i=0;
                        while((line=r.ReadLine())!=null)
                        {
                            int index = line.IndexOf(',');
                            string nome = line.Substring(0, index);
                            string prezzo = line.Substring(index + 1);
                            arrayn[i] = nome;
                            arrayp[i++] = prezzo;
                        }
                        c = i;
                            
                    }
                }
                catch { }
        }
        private const string file_name = "txtfile.txt";
        int c = 0;
        string[] arrayn = new string[20];
        string[] arrayp = new string[20];
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (c < 19)
            {
                string nome = (txtnome.Text);
                string prezzo = (txtprezzo.Text);
                arrayn[c] = nome;
                arrayp[c] = prezzo;
                c++;
                txtnome.Clear();
                txtprezzo.Clear();
                txtnome.Focus();
            }
            else
            {
                MessageBox.Show("non puoi inserire più numeri");
                txtnome.IsReadOnly = true;
                txtprezzo.IsReadOnly = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblresult.Clear();
            using (StreamWriter t = new StreamWriter(file_name, false))
            {
                for (int i = 0; i < c; i++)
                {
                    lblresult.Text += $"Nome Prodotto:{arrayn[i]};     Prezzo Prodotto:{arrayp[i]}\n";
                    t.WriteLine($"{arrayn[i]},{arrayp[i]}");
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Vuoi Eliminare Il File?","Sei Sicuro?", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                File.Delete(file_name);
            }
        }
    }
}
