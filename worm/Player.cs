using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worm
{
    internal class Player
    {
        int player_x = 0;
        int player_y = 0;
        int tael_count = 0;

        int[] tael_x = new int[1000];
        int[] tael_y = new int[1000];

        //나는 클래스 플레이어 2 변수를 가져옴
        public Player2 player2;

        public void Settael_count(int num = 1)
        { tael_count += num; }

        public int Getplayer_x()
        { return player_x; }
        public int Getplayer_y()
        { return player_y; }

        bool Alive = true;
        public bool GetAlive()
        { return Alive; }

        public void SetAlive(bool alive)
        {
            Alive = alive;
        }
        //public int Count;

        bool Up = true;
        bool Down = true;
        bool Right = true;
        bool Left = false;





        int dir = 0;

        public void Awake()
        {

        }

        public void Start()
        {
            player_x = gameloop.BOARD_WIDTH / 2;
            player_y = gameloop.BOARD_HEIGHT / 2;
        }
        //계산



        public void Move_Left()
        {
            dir = 2;
            Up = true;
            Down = true;
            Right = false;
            Left = true;
        }
        public void Move_Right()
        {
            dir = 0;
            Up = true;
            Down = true;
            Right = true;
            Left = false;
        }
        public void Move_Up()
        {
            dir = 1;
            Up = true;
            Down = false;
            Right = true;
            Left = true;
        }
        public void Move_Down()
        {
            dir = 3;
            Up = false;
            Down = true;
            Right = true;
            Left = true;
        }

        public bool GetLeft()
        { return Left; }
        public bool GetRight()
        { return Right; }
        public bool GetUp()
        { return Up; }
        public bool GetDown()
        { return Down; }




        public void Update()
        {


            tael_x[0] = player_x;
            tael_y[0] = player_y;

            for (int i = tael_count; i > 0; --i)
            {

                tael_x[i] = tael_x[i - 1];
                tael_y[i] = tael_y[i - 1];

                if (tael_x[i + 1] == player_x && tael_y[i + 1] == player_y)
                {
                    Alive = false;
                }

                if (tael_x[i + 1] == player2.Getplayer2_x() && tael_y[i + 1] == player2.Getplayer2_y())
                {
                    player2.SetAlive(false);
                }

                if (tael_count == 2)
                {
                    ++tael_count;
                }
            }






            switch (dir)
            {
                case 0:
                    {
                        Console.Clear();
                        if (player_x >= 58)
                        {
                            player_x = 58;
                            Alive = false;
                        }
                        else
                        {
                            player_x += 2;
                        }
                    }
                    break;
                case 1:
                    {
                        Console.Clear();
                        if (--player_y < 1)
                        {
                            player_y = 1;
                            Alive = false;
                        }
                    }

                    break;
                case 2:
                    {
                        Console.Clear();
                        if (player_x < 2)
                        {
                            
                            player_x = 2;
                            Alive = false;
                        }
                        else
                        {
                        player_x -= 2;
                         
                        }
                    }

                    break;
                case 3:
                    {
                        Console.Clear();
                        if (++player_y >= gameloop.BOARD_HEIGHT)
                        {
                            player_y = gameloop.BOARD_HEIGHT;
                            Alive = false;
                        }
                    }

                    break;

            }




        }
        //출력
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan; // 글씨 색상변경
            if (Alive)
            {
                if (tael_count > 0)
                {

                    for (int i = 0; i < tael_count; ++i)
                    {

                        Console.SetCursorPosition(tael_x[i], tael_y[i]);
                        Console.Write('▣');

                    }
                }

                Console.SetCursorPosition(player_x, player_y);
                Console.Write('■');
                Console.ResetColor();//글씨색상 초기화
            }



        }

    }
}
