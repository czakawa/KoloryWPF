using System;
using System.Windows;
using System.Windows.Media;

namespace KoloryWPF
{
    
    internal static class Ustawienia
    {
        
        public static Color Czytaj()
        {
            var ustawienia = Properties.Settings.Default;

            return new Color()
            {
                A = 255,
                R = ustawienia.R,
                G = ustawienia.G,
                B = ustawienia.B
            };
        }

        
        public static void Zapisz(Color kolor)
        {
            var ustawienia = Properties.Settings.Default;

            ustawienia.R = kolor.R;
            ustawienia.G = kolor.G;
            ustawienia.B = kolor.B;

            ustawienia.Save();
        }

       
        public static void ZapiszOkno(Window okno)
        {
            var ustawienia = Properties.Settings.Default;

            ustawienia.Maximized = okno.WindowState == WindowState.Maximized;

            if (ustawienia.Maximized)
            {
             
                ustawienia.Top = okno.RestoreBounds.Top;
                ustawienia.Left = okno.RestoreBounds.Left;
                ustawienia.Width = okno.RestoreBounds.Width;
                ustawienia.Height = okno.RestoreBounds.Height;
            }
            else
            {
                ustawienia.Top = okno.Top;
                ustawienia.Left = okno.Left;
                ustawienia.Width = okno.Width;
                ustawienia.Height = okno.Height;
            }
        }

        
        public static void CzytajOkno(Window okno)
        {
            var ustawienia = Properties.Settings.Default;

            double top = ustawienia.Top;
            double left = ustawienia.Left;
            double width = ustawienia.Width;
            double height = ustawienia.Height;

            bool mieściSięNaEkranie =
                left >= SystemParameters.VirtualScreenLeft &&
                top >= SystemParameters.VirtualScreenTop &&
                left + width <= SystemParameters.VirtualScreenLeft + SystemParameters.VirtualScreenWidth &&
                top + height <= SystemParameters.VirtualScreenTop + SystemParameters.VirtualScreenHeight;

            if (mieściSięNaEkranie)
            {
                okno.Top = top;
                okno.Left = left;
                okno.Width = width;
                okno.Height = height;
            }
            

            if (ustawienia.Maximized)
                okno.WindowState = WindowState.Maximized;
        }
    }
}
