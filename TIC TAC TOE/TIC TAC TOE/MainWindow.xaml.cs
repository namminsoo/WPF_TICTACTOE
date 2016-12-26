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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow mainWindow;
        public static MainPage mainPage;
        public static GameStartPage gameStartPage;
        public static GameStartSubPage gameStartSubPage;
        public static RecordViewPage recordViewPage;


        public static MainWindow getInstance()
        {
            if (mainWindow == null)
            {
                //객체 생성 하지만 할 필요없음.
            }

            return mainWindow;
        }

        public MainWindow()
        {
            InitializeComponent();

            setGrid();
        }


        void setGrid()
        {
            mainWindow = this;
            mainPage = new MainPage();
            gameStartPage = new GameStartPage();
            gameStartSubPage = new GameStartSubPage();
            recordViewPage = new RecordViewPage();

            MainGrid.Children.Add(mainPage);
            MainGrid.Children.Add(gameStartPage);
            MainGrid.Children.Add(gameStartSubPage);
            MainGrid.Children.Add(recordViewPage);

            setVisibility(1);
        }

        /*
         * 1. 메인화면
         * 2. p1 p2 대결
         * 3. p com 대결
         * 4. 기록
         */
        public static void setVisibility(int n)
        {
            switch (n)
            {
                case 1:
                    mainPage.Visibility = Visibility.Visible;

                    gameStartPage.Visibility = Visibility.Hidden;
                    gameStartSubPage.Visibility = Visibility.Hidden;
                    recordViewPage.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    mainPage.Visibility = Visibility.Hidden;

                    gameStartPage.Visibility = Visibility.Visible;
                    gameStartSubPage.Visibility = Visibility.Hidden;
                    recordViewPage.Visibility = Visibility.Hidden;
                    break;
                case 3:

                    mainPage.Visibility = Visibility.Hidden;

                    gameStartPage.Visibility = Visibility.Hidden;
                    gameStartSubPage.Visibility = Visibility.Visible;
                    recordViewPage.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    mainPage.Visibility = Visibility.Hidden;

                    gameStartPage.Visibility = Visibility.Hidden;
                    gameStartSubPage.Visibility = Visibility.Hidden;
                    recordViewPage.Visibility = Visibility.Visible;
                    recordViewPage.setListView();
                    break;
                default: break;
            }
        }

        public void exit()
        {
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

    }
}
