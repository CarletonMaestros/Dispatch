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
using System.Windows.Shapes;

namespace Orchestra
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SongSelectWindow : Window
    {
        public string songFile;

        public SongSelectWindow()
        {
            InitializeComponent();
        }

        public void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            ParaAnd.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            //newIm.UriSource = new Uri(@"C:\Users\Rachel\Documents\GitHub\VirtualOrchestra\GUI\Resources\Radiohead.jpg");
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Radiohead.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\r.mid";
            //songFile = @"C:\Users\Rachel\Documents\GitHub\VirtualOrchestra\Sample MIDIs\r.mid";
        }

        private void ParaAndLoop(object sender, RoutedEventArgs e)
        {
            ParaAnd.Position = TimeSpan.Zero;
            ParaAnd.Play();
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            Prayer.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Madonna.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\prayer.mid";
        }

        private void PrayerLoop(object sender, RoutedEventArgs e)
        {
            Prayer.Position = TimeSpan.Zero;
            Prayer.Play();
        }

        private void ListBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            ScarMon.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Skrillex.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\s.mid";
        }

        private void ScarMonLoop(object sender, RoutedEventArgs e)
        {
            ScarMon.Position = TimeSpan.Zero;
            ScarMon.Play();
        }

        private void ListBoxItem_Selected_4(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            Sym5.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Beethoven.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\sym5.mid";
        }

        private void Sym5Loop(object sender, RoutedEventArgs e)
        {
            Sym5.Position = TimeSpan.Zero;
            Sym5.Play();
        }

        private void ListBoxItem_Selected_5(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            MtKing.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\MountainKing.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\mtking.mid";
        }

        private void MtKingLoop(object sender, RoutedEventArgs e)
        {
            MtKing.Position = TimeSpan.Zero;
            MtKing.Play();
        }

        private void ListBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            GetLucky.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Daftpunk.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\daft.mid";
        }

        private void GetLuckyLoop(object sender, RoutedEventArgs e)
        {
            GetLucky.Position = TimeSpan.Zero;
            GetLucky.Play();
        }

        private void ListBoxItem_Selected_7(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            HardDay.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Beatles.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\h.mid";
        }

        private void HardDayLoop(object sender, RoutedEventArgs e)
        {
            HardDay.Position = TimeSpan.Zero;
            HardDay.Play();
        }

        private void ListBoxItem_Selected_8(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            NewWorld.Play();
            BitmapImage newIm = new BitmapImage();
            newIm.BeginInit();
            newIm.UriSource = new Uri(@"C:\Users\admin\Desktop\VirtualOrchestra\GUI\Resources\Dvorak.jpg");
            newIm.EndInit();
            PreviewImage.Source = newIm;
            songFile = @"C:\Users\admin\Desktop\VirtualOrchestra\Sample MIDIs\newworld.mid";
        }

        private void NewWorldLoop(object sender, RoutedEventArgs e)
        {
            NewWorld.Position = TimeSpan.Zero;
            NewWorld.Play();
        }

        private void StopAllMusic()
        {
            bool parAndPause = ParaAnd.CanPause;
            if (parAndPause == true)
            {
                ParaAnd.Stop();
            }
            bool scarMonPause = ScarMon.CanPause;
            if (scarMonPause == true)
            {
                ScarMon.Stop();
            }
            bool prayerPause = Prayer.CanPause;
            if (prayerPause == true)
            {
                Prayer.Stop();
            }
            bool hardDayPause = HardDay.CanPause;
            if (hardDayPause == true)
            {
                HardDay.Stop();
            }
            bool sym5Pause = Sym5.CanPause;
            if (sym5Pause == true)
            {
                Sym5.Stop();
            }
            bool newWorldPause = NewWorld.CanPause;
            if (newWorldPause == true)
            {
                NewWorld.Stop();
            }
            bool getLuckyPause = GetLucky.CanPause;
            if (getLuckyPause == true)
            {
                GetLucky.Stop();
            }
            bool mtKingPause = MtKing.CanPause;
            if (mtKingPause == true)
            {
                MtKing.Stop();
            }

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            StopAllMusic();
            this.Close();
            Dispatch.TriggerSongSelected(songFile);
            
            
            
        }
    }
}
