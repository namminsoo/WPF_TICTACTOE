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
    /// GameStartPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GameStartPage : UserControl
    {
        int[,] stateArr = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        Button[,] btnArr = new Button[3, 3];
        Image[,] imgArr = new Image[3, 3];

        int mode = 0;
        int turn = 0;
        int turnCount = 0;

        const int p1 = 1;//p1
        const int p2 = 2;//p2
        const int p3 = 3;//com

        ImageSource imgSourceA = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TIC TAC TOE;component/" + SettingConstants.pathA));
        ImageSource imgSourceO = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TIC TAC TOE;component/" + SettingConstants.pathO));
        ImageSource imgSourceX = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"pack://application:,,,/TIC TAC TOE;component/" + SettingConstants.pathX));

        //대결상대가 누구이고 누가 선공인지

        //클릭했을 때 올바른건지 체크
        //이미지 바꿔주는 함수?!



        //state 배열 셋팅해주는 함수
        //초기화 함수
        //결판 함수


        public GameStartPage()
        {
            InitializeComponent();
            init();
        }


        void init()
        {



            btnArr[0, 0] = btn00;
            btnArr[0, 1] = btn01;
            btnArr[0, 2] = btn02;
            btnArr[1, 0] = btn10;
            btnArr[1, 1] = btn11;
            btnArr[1, 2] = btn12;
            btnArr[2, 0] = btn20;
            btnArr[2, 1] = btn21;
            btnArr[2, 2] = btn22;


            imgArr[0, 0] = img00;
            imgArr[0, 1] = img01;
            imgArr[0, 2] = img02;
            imgArr[1, 0] = img10;
            imgArr[1, 1] = img11;
            imgArr[1, 2] = img12;
            imgArr[2, 0] = img20;
            imgArr[2, 1] = img21;
            imgArr[2, 2] = img22;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    stateArr[i, j] = 0;
                    imgArr[i, j].ToolTip = "-";
                    imgArr[i, j].Source = imgSourceA;
                }
            }



            lbl1.Content = "??";
            lbl2.Content = "공격";

            turn = 0;
            mode = 0;
            turnCount = 0;
        }


        public void gameStart(int m, int firstPlayer)
        {
            init();

            mode = m;
            turn = firstPlayer;


            if (mode == 1)
            {
                if (turn == 1)
                {
                    lbl1.Content = "Player1";
                }
                else
                {
                    lbl1.Content = "Player2";
                }

            }
            else if (mode == 2)
            {
                if (turn == 1)
                {
                    lbl1.Content = "Player";
                }
                else
                {
                    lbl1.Content = "AI";
                    //컴퓨터 함수 실행

                    
                    comAttack();
                }
            }
        }
        

        bool checkBinggo(int player)
        {
            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (stateArr[i, j] == player) { count1++; }
                    if (stateArr[j, i] == player) { count2++; }
                }
                if (count1 == 3) { return true; }
                else if (count2 == 3) { return true; }
                else { count1 = 0; count2 = 0; }
            }

            if (stateArr[0, 0] == player && stateArr[1, 1] == player && stateArr[2, 2] == player) { return true; }
            if (stateArr[0, 2] == player && stateArr[1, 1] == player && stateArr[2, 0] == player) { return true; }

            return false;
        }


        void setState()
        {

            stateArr[0, 0] = img00.ToolTip.ToString() == "-" ? 0 : (img00.ToolTip.ToString() == "o" ? 1 : img00.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[0, 1] = img01.ToolTip.ToString() == "-" ? 0 : (img01.ToolTip.ToString() == "o" ? 1 : img01.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[0, 2] = img02.ToolTip.ToString() == "-" ? 0 : (img02.ToolTip.ToString() == "o" ? 1 : img02.ToolTip.ToString() == "x" ? 2 : -1);

            stateArr[1, 0] = img10.ToolTip.ToString() == "-" ? 0 : (img10.ToolTip.ToString() == "o" ? 1 : img10.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[1, 1] = img11.ToolTip.ToString() == "-" ? 0 : (img11.ToolTip.ToString() == "o" ? 1 : img11.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[1, 2] = img12.ToolTip.ToString() == "-" ? 0 : (img12.ToolTip.ToString() == "o" ? 1 : img12.ToolTip.ToString() == "x" ? 2 : -1);

            stateArr[2, 0] = img20.ToolTip.ToString() == "-" ? 0 : (img20.ToolTip.ToString() == "o" ? 1 : img20.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[2, 1] = img21.ToolTip.ToString() == "-" ? 0 : (img21.ToolTip.ToString() == "o" ? 1 : img21.ToolTip.ToString() == "x" ? 2 : -1);
            stateArr[2, 2] = img22.ToolTip.ToString() == "-" ? 0 : (img22.ToolTip.ToString() == "o" ? 1 : img22.ToolTip.ToString() == "x" ? 2 : -1);

            //img00.ToolTip = stateArr[0, 0] == 0 ? "-" : (stateArr[0, 0] == 1 ? "o" : (stateArr[0, 0] == 2 ? "x" : ""));
            //img01.ToolTip = stateArr[0, 1] == 0 ? "-" : (stateArr[0, 1] == 1 ? "o" : (stateArr[0, 1] == 2 ? "x" : ""));
            //img02.ToolTip = stateArr[0, 2] == 0 ? "-" : (stateArr[0, 2] == 1 ? "o" : (stateArr[0, 2] == 2 ? "x" : ""));
            //img10.ToolTip = stateArr[1, 0] == 0 ? "-" : (stateArr[1, 0] == 1 ? "o" : (stateArr[1, 0] == 2 ? "x" : ""));
            //img11.ToolTip = stateArr[1, 1] == 0 ? "-" : (stateArr[1, 1] == 1 ? "o" : (stateArr[1, 1] == 2 ? "x" : ""));
            //img12.ToolTip = stateArr[1, 2] == 0 ? "-" : (stateArr[1, 2] == 1 ? "o" : (stateArr[1, 2] == 2 ? "x" : ""));
            //img20.ToolTip = stateArr[2, 0] == 0 ? "-" : (stateArr[2, 0] == 1 ? "o" : (stateArr[2, 0] == 2 ? "x" : ""));
            //img21.ToolTip = stateArr[2, 1] == 0 ? "-" : (stateArr[2, 1] == 1 ? "o" : (stateArr[2, 1] == 2 ? "x" : ""));
            //img22.ToolTip = stateArr[2, 2] == 0 ? "-" : (stateArr[2, 2] == 1 ? "o" : (stateArr[2, 2] == 2 ? "x" : ""));
        }


        private void comAttack()
        {

            int w = 0, h = 0;
            bool ch = false;

            if (turnCount % 2 == 0)//선공
            {
                if (stateArr[1, 1] == 0)
                {
                    w = 1; h = 1;
                }
                else
                {
                    if (turnCount == 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (stateArr[i, j] == 0)
                                { w = i; h = j; ch = true; break; }
                            }
                            if (ch)
                            { ch = false; break; }
                        }
                    }
                    else
                    {
                        if (stateArr[0, 0] + stateArr[1, 1] + stateArr[2, 2] == 4 && (stateArr[0, 0] == 0 || stateArr[1, 1] == 0 || stateArr[2, 2] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }
                        else if (stateArr[0, 2] + stateArr[1, 1] + stateArr[2, 0] == 4 && (stateArr[0, 2] == 0 || stateArr[1, 1] == 0 || stateArr[2, 0] == 0)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }

                        else if (stateArr[0, 0] + stateArr[0, 1] + stateArr[0, 2] == 4 && (stateArr[0, 0] == 0 || stateArr[0, 1] == 0 || stateArr[0, 2] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[0, 2] == 0) { w = 0; h = 2; } }
                        else if (stateArr[1, 0] + stateArr[1, 1] + stateArr[1, 2] == 4 && (stateArr[1, 0] == 0 || stateArr[1, 1] == 0 || stateArr[1, 2] == 0)) { if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } }
                        else if (stateArr[2, 0] + stateArr[2, 1] + stateArr[2, 2] == 4 && (stateArr[2, 0] == 0 || stateArr[2, 1] == 0 || stateArr[2, 2] == 0)) { if (stateArr[2, 0] == 0) { w = 2; h = 0; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                        else if (stateArr[0, 0] + stateArr[1, 0] + stateArr[2, 0] == 4 && (stateArr[0, 0] == 0 || stateArr[1, 0] == 0 || stateArr[2, 0] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }
                        else if (stateArr[0, 1] + stateArr[1, 1] + stateArr[2, 1] == 4 && (stateArr[0, 1] == 0 || stateArr[1, 1] == 0 || stateArr[2, 1] == 0)) { if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } }
                        else if (stateArr[0, 2] + stateArr[1, 2] + stateArr[2, 2] == 4 && (stateArr[0, 2] == 0 || stateArr[1, 2] == 0 || stateArr[2, 2] == 0)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                        else
                        {
                            //공격지가 없을 때 방어 모드로 이거마저 없으면 이중포문
                            if (stateArr[0, 0] + stateArr[1, 1] + stateArr[2, 2] == 2 && (stateArr[0, 0] == 0 || stateArr[1, 1] == 0 || stateArr[2, 2] == 0) && (stateArr[0, 0] != 2 && stateArr[1, 1] != 2 && stateArr[2, 2] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }
                            else if (stateArr[0, 2] + stateArr[1, 1] + stateArr[2, 0] == 2 && (stateArr[0, 2] == 0 || stateArr[1, 1] == 0 || stateArr[2, 0] == 0) && (stateArr[0, 2] != 2 && stateArr[1, 1] != 2 && stateArr[2, 0] != 2)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }

                            else if (stateArr[0, 0] + stateArr[0, 1] + stateArr[0, 2] == 2 && (stateArr[0, 0] == 0 || stateArr[0, 1] == 0 || stateArr[0, 2] == 0) && (stateArr[0, 0] != 2 && stateArr[0, 1] != 2 && stateArr[0, 2] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[0, 2] == 0) { w = 0; h = 2; } }
                            else if (stateArr[1, 0] + stateArr[1, 1] + stateArr[1, 2] == 2 && (stateArr[1, 0] == 0 || stateArr[1, 1] == 0 || stateArr[1, 2] == 0) && (stateArr[1, 0] != 2 && stateArr[1, 1] != 2 && stateArr[1, 2] != 2)) { if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } }
                            else if (stateArr[2, 0] + stateArr[2, 1] + stateArr[2, 2] == 2 && (stateArr[2, 0] == 0 || stateArr[2, 1] == 0 || stateArr[2, 2] == 0) && (stateArr[2, 0] != 2 && stateArr[2, 1] != 2 && stateArr[2, 2] != 2)) { if (stateArr[2, 0] == 0) { w = 2; h = 0; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                            else if (stateArr[0, 0] + stateArr[1, 0] + stateArr[2, 0] == 2 && (stateArr[0, 0] == 0 || stateArr[1, 0] == 0 || stateArr[2, 0] == 0) && (stateArr[0, 0] != 2 && stateArr[1, 0] != 2 && stateArr[2, 0] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }
                            else if (stateArr[0, 1] + stateArr[1, 1] + stateArr[2, 1] == 2 && (stateArr[0, 1] == 0 || stateArr[1, 1] == 0 || stateArr[2, 1] == 0) && (stateArr[0, 1] != 2 && stateArr[1, 1] != 2 && stateArr[2, 1] != 2)) { if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } }
                            else if (stateArr[0, 2] + stateArr[1, 2] + stateArr[2, 2] == 2 && (stateArr[0, 2] == 0 || stateArr[1, 2] == 0 || stateArr[2, 2] == 0) && (stateArr[0, 2] != 2 && stateArr[1, 2] != 2 && stateArr[2, 2] != 2)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }
                            else
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        if (stateArr[i, j] == 0)
                                        { w = i; h = j; ch = true; break; }
                                    }
                                    if (ch)
                                    { ch = false; break; }
                                }
                            }
                        }
                    }
                }
            }
            else//후공
            {
                if (stateArr[1, 1] == 0)
                {
                    w = 1; h = 1;
                }
                else
                {
                    if (turnCount == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (stateArr[i, j] == 0)
                                { w = i; h = j; ch = true; break; }
                            }
                            if (ch)
                            { ch = false; break; }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (stateArr[i, j] == 0)
                                { w = i; h = j; ch = true; break; }
                            }
                            if (ch)
                            { ch = false; break; }
                        }



                        //방어 찾고 공격으로 이길수 있으면 이기고
                        if (stateArr[0, 0] + stateArr[1, 1] + stateArr[2, 2] == 2 && (stateArr[0, 0] == 0 || stateArr[1, 1] == 0 || stateArr[2, 2] == 0) && (stateArr[0, 0] != 2 && stateArr[1, 1] != 2 && stateArr[2, 2] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }
                        else if (stateArr[0, 2] + stateArr[1, 1] + stateArr[2, 0] == 2 && (stateArr[0, 2] == 0 || stateArr[1, 1] == 0 || stateArr[2, 0] == 0) && (stateArr[0, 2] != 2 && stateArr[1, 1] != 2 && stateArr[2, 0] != 2)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }

                        else if (stateArr[0, 0] + stateArr[0, 1] + stateArr[0, 2] == 2 && (stateArr[0, 0] == 0 || stateArr[0, 1] == 0 || stateArr[0, 2] == 0) && (stateArr[0, 0] != 2 && stateArr[0, 1] != 2 && stateArr[0, 2] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[0, 2] == 0) { w = 0; h = 2; } }
                        else if (stateArr[1, 0] + stateArr[1, 1] + stateArr[1, 2] == 2 && (stateArr[1, 0] == 0 || stateArr[1, 1] == 0 || stateArr[1, 2] == 0) && (stateArr[1, 0] != 2 && stateArr[1, 1] != 2 && stateArr[1, 2] != 2)) { if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } }
                        else if (stateArr[2, 0] + stateArr[2, 1] + stateArr[2, 2] == 2 && (stateArr[2, 0] == 0 || stateArr[2, 1] == 0 || stateArr[2, 2] == 0) && (stateArr[2, 0] != 2 && stateArr[2, 1] != 2 && stateArr[2, 2] != 2)) { if (stateArr[2, 0] == 0) { w = 2; h = 0; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                        else if (stateArr[0, 0] + stateArr[1, 0] + stateArr[2, 0] == 2 && (stateArr[0, 0] == 0 || stateArr[1, 0] == 0 || stateArr[2, 0] == 0) && (stateArr[0, 0] != 2 && stateArr[1, 0] != 2 && stateArr[2, 0] != 2)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }
                        else if (stateArr[0, 1] + stateArr[1, 1] + stateArr[2, 1] == 2 && (stateArr[0, 1] == 0 || stateArr[1, 1] == 0 || stateArr[2, 1] == 0) && (stateArr[0, 1] != 2 && stateArr[1, 1] != 2 && stateArr[2, 1] != 2)) { if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } }
                        else if (stateArr[0, 2] + stateArr[1, 2] + stateArr[2, 2] == 2 && (stateArr[0, 2] == 0 || stateArr[1, 2] == 0 || stateArr[2, 2] == 0) && (stateArr[0, 2] != 2 && stateArr[1, 2] != 2 && stateArr[2, 2] != 2)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                        if (stateArr[0, 0] + stateArr[1, 1] + stateArr[2, 2] == 4 && (stateArr[0, 0] == 0 || stateArr[1, 1] == 0 || stateArr[2, 2] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }
                        else if (stateArr[0, 2] + stateArr[1, 1] + stateArr[2, 0] == 4 && (stateArr[0, 2] == 0 || stateArr[1, 1] == 0 || stateArr[2, 0] == 0)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }

                        else if (stateArr[0, 0] + stateArr[0, 1] + stateArr[0, 2] == 4 && (stateArr[0, 0] == 0 || stateArr[0, 1] == 0 || stateArr[0, 2] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[0, 2] == 0) { w = 0; h = 2; } }
                        else if (stateArr[1, 0] + stateArr[1, 1] + stateArr[1, 2] == 4 && (stateArr[1, 0] == 0 || stateArr[1, 1] == 0 || stateArr[1, 2] == 0)) { if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } }
                        else if (stateArr[2, 0] + stateArr[2, 1] + stateArr[2, 2] == 4 && (stateArr[2, 0] == 0 || stateArr[2, 1] == 0 || stateArr[2, 2] == 0)) { if (stateArr[2, 0] == 0) { w = 2; h = 0; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }

                        else if (stateArr[0, 0] + stateArr[1, 0] + stateArr[2, 0] == 4 && (stateArr[0, 0] == 0 || stateArr[1, 0] == 0 || stateArr[2, 0] == 0)) { if (stateArr[0, 0] == 0) { w = 0; h = 0; } else if (stateArr[1, 0] == 0) { w = 1; h = 0; } else if (stateArr[2, 0] == 0) { w = 2; h = 0; } }
                        else if (stateArr[0, 1] + stateArr[1, 1] + stateArr[2, 1] == 4 && (stateArr[0, 1] == 0 || stateArr[1, 1] == 0 || stateArr[2, 1] == 0)) { if (stateArr[0, 1] == 0) { w = 0; h = 1; } else if (stateArr[1, 1] == 0) { w = 1; h = 1; } else if (stateArr[2, 1] == 0) { w = 2; h = 1; } }
                        else if (stateArr[0, 2] + stateArr[1, 2] + stateArr[2, 2] == 4 && (stateArr[0, 2] == 0 || stateArr[1, 2] == 0 || stateArr[2, 2] == 0)) { if (stateArr[0, 2] == 0) { w = 0; h = 2; } else if (stateArr[1, 2] == 0) { w = 1; h = 2; } else if (stateArr[2, 2] == 0) { w = 2; h = 2; } }


                    }
                }
            }//후공


            imgArr[w, h].Source = imgSourceX;
            imgArr[w, h].ToolTip = "x";
            stateArr[w, h] = p3 - 1;
            turnCount++;

            if (checkBinggo(p3 - 1))
            {
                MessageBox.Show("AI 승리!!");
                MainWindow.setVisibility(1);
                RecordViewPage.addList("Player", "AI", "AI");
                //승리 그리고 홈으로
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("비김");
                MainWindow.setVisibility(1);
                RecordViewPage.addList("Player", "AI", "Draw");
                //비김 그리고 홈으로
            }
            lbl1.Content = "Player";
            turn = p1;
        }


        private void btnTTT_Click(object sender, RoutedEventArgs e)
        {
            int w = 0, h = 0;
            bool ch = false;
            Button btn = (Button)sender;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (btnArr[i, j] == btn)
                    { w = i; h = j; ch = true; break; }
                }
                if (ch)
                { ch = false; break; }
            }

            //모드와 턴에 따라 방식이 바뀐다.
            if (mode == 1)//pp
            {
                if (imgArr[w, h].ToolTip.ToString() == "-")
                {
                    if (turn == p1)
                    {
                        imgArr[w, h].Source = imgSourceO;
                        imgArr[w, h].ToolTip = "o";
                        stateArr[w, h] = p1;
                        turnCount++;

                        if (checkBinggo(p1))
                        {
                            MessageBox.Show("1Player 승리!!");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("1Player", "2Player", "1Player");
                            //승리 그리고 홈으로
                        }
                        else if (turnCount == 9)
                        {
                            MessageBox.Show("비김");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("1Player", "2Player", "Draw");
                            //비김 그리고 홈으로
                        }
                        lbl1.Content = "Player2";
                        turn = p2;
                    }
                    else if (turn == p2)
                    {
                        imgArr[w, h].Source = imgSourceX;
                        imgArr[w, h].ToolTip = "x";
                        stateArr[w, h] = p2;

                        turnCount++;

                        if (checkBinggo(p2))
                        {
                            MessageBox.Show("2Player 승리!!");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("1Player", "2Player", "2Player");
                            //승리 그리고 홈으로
                        }
                        else if (turnCount == 9)
                        {
                            MessageBox.Show("비김");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("1Player", "2Player", "Draw");
                            //비김 그리고 홈으로
                        }
                        lbl1.Content = "Player1";
                        turn = p1;
                    }
                }
                else
                {
                    MessageBox.Show("이상한거 누르지마");
                }
            }

            else if (mode == 2)//pc
            {
                if (imgArr[w, h].ToolTip.ToString() == "-")
                {
                    if (turn == p1)
                    {
                        imgArr[w, h].Source = imgSourceO;
                        imgArr[w, h].ToolTip = "o";
                        stateArr[w, h] = p1;
                        turnCount++;

                        if (checkBinggo(p1))
                        {
                            MessageBox.Show("Player 승리!!");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("Player", "AI", "Player");
                            return;
                            //승리 그리고 홈으로
                        }
                        else if (turnCount == 9)
                        {
                            MessageBox.Show("비김");
                            MainWindow.setVisibility(1);
                            RecordViewPage.addList("Player", "AI", "Draw");
                            //비김 그리고 홈으로
                        }
                        lbl1.Content = "AI";
                        turn = p3;
                        //System.Threading.Thread.Sleep(1000);
                        comAttack();
                    }
                    else if (turn == p3)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("이상한거 누르지마");
                }
            }




        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            //초기화 함수
            init();

            MainWindow.setVisibility(1);
        }
    }
}
