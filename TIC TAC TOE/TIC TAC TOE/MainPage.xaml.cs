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
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : UserControl
    {
        MainWindow mainWindow;

        public MainPage()
        {
            InitializeComponent();
            mainWindow = MainWindow.getInstance();
        }

        private void btn2Player_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gameStartSubPage.setMode(1);
            MainWindow.setVisibility(3);
        }

        private void btnPlayerCom_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gameStartSubPage.setMode(2);
            MainWindow.setVisibility(3);
        }

        private void btnRec_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.setVisibility(4);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.exit();
        }

        



    }
}
