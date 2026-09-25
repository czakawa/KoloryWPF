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

namespace KoloryWPF
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            Color kolor = Ustawienia.Czytaj();
            rectangle.Fill = new SolidColorBrush(kolor);

            
            sliderR.Value = kolor.R;
            sliderG.Value = kolor.G;
            sliderB.Value = kolor.B;

            
            Ustawienia.CzytajOkno(this);
        }

        
        private Color KolorProstokata
        {
            get => (rectangle.Fill as SolidColorBrush).Color;
            set => (rectangle.Fill as SolidColorBrush).Color = value;
        }

        
        private void sliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            if (rectangle == null || sliderR == null || sliderG == null || sliderB == null)
                return;

            if (!(rectangle.Fill is SolidColorBrush))
                return;

            Color kolor = Color.FromRgb((byte)sliderR.Value, (byte)sliderG.Value, (byte)sliderB.Value);
            KolorProstokata = kolor;
        }

        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        
        private void Window_Closed(object sender, EventArgs e)
        {
            Ustawienia.ZapiszOkno(this);
            Ustawienia.Zapisz(KolorProstokata);
        }
    }
}
