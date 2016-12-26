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
    /// RecordViewPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecordViewPage : UserControl
    {

        public static List<GameLog> items = new List<GameLog>();
        

        public static void addList(String p1, String p2, String win)
        {
            items.Add(new GameLog() { P1 = p1, P2 = p2, Win = win, Time = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString() });    
        }

        public void setListView()
        {
            listView1.ItemsSource = null;
            listView1.ItemsSource = items;
        }

        public RecordViewPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.setVisibility(1);
        }
    }
}
