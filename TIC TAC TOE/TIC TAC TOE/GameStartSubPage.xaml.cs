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

namespace TIC_TAC_TOE
{
    /// <summary>
    /// GameStartSubPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GameStartSubPage : UserControl
    {
        private static int mode=0;//1-pp 2-pc

        public GameStartSubPage()
        {
            InitializeComponent();
          //  btnBack.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 255));
        }


        public void setMode(int m)
        {
            mode = m;
            if (mode == 1)
            {
                //lbl1.Content = "Player1";
                //lbl2.Content = "Player2";
                img1.Visibility = Visibility.Visible;
                img2.Visibility = Visibility.Visible;
                img3.Visibility = Visibility.Hidden;
            }
            else if (mode == 2)
            {
                //lbl1.Content = "Player";
                //lbl2.Content = "Com";
                img1.Visibility = Visibility.Visible;
                img2.Visibility = Visibility.Hidden;
                img3.Visibility = Visibility.Visible;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name == "btnStart1")
            {
                MainWindow.gameStartPage.gameStart(mode, 1);
                //1p 선공
            }
            else if (btn.Name == "btnStart2")
            {
                int p = mode == 1 ? 2 : 3;
                MainWindow.gameStartPage.gameStart(mode, p);
                //2p 선공
            }

                MainWindow.setVisibility(2);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.setVisibility(1);
        }
    }
}
