using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worm
{
    internal class Player2
    {

        int player2_x = 0;
        int player2_y = 0;
        int tael2_count = 0;

        int[] tael2_x = new int[1000];
        int[] tael2_y = new int[1000];
        
        public Player player;

        public void Settael_count(int num = 1)
        { tael2_count += num; }

        public int Getplayer2_x()
        { return player2_x; }
        public int Getplayer2_y()
        { return player2_y; }

        bool Alive = true;
        public bool GetAlive()
        { return Alive; }


        public void SetAlive(bool alive)
        {
            Alive = alive;
        }


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
            player2_x = (gameloop.BOARD_WIDTH / 2) + 2;
            player2_y = (gameloop.BOARD_HEIGHT / 2);
        }
        //계산



        public void Move_Left()
        {
            dir = 0;
            Up = true;
            Down = true;
            Right = false;
            Left = true;
        }
        public void Move_Right()
        {
            dir = 2;
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


            tael2_x[0] = player2_x;
            tael2_y[0] = player2_y;

            for (int i = tael2_count; i > 0; --i)
            {

                tael2_x[i] = tael2_x[i - 1];
                tael2_y[i] = tael2_y[i - 1];

                if (tael2_x[i + 1] == player2_x && tael2_y[i + 1] == player2_y)
                {
                    Alive = false;
                }

                if (tael2_x[i + 1] == player.Getplayer_x() && tael2_y[i + 1] == player.Getplayer_y())
                {
                    player.SetAlive(false);
                }


                if (tael2_count == 2)
                {
                    ++tael2_count;
                }
            }






            switch (dir)
            {
                case 2:
                    {
                        Console.Clear();
                        if (player2_x >= 58 )
                        {
                            player2_x = 58;
                            Alive = false;
                        }
                        player2_x += 2;
                    }
                    break;
                case 1:
                    {
                        Console.Clear();
                        if (--player2_y < 1)
                        {
                            player2_y = 1;
                            Alive = false;
                        }
                    }

                    break;
                case 0:
                    {
                        Console.Clear();
                        if (player2_x < 2)
                        {
                            player2_x = 2;
                            Alive = false;
                        }
                        player2_x -= 2;
                    }

                    break;
                case 3:
                    {
                        Console.Clear();
                        if (++player2_y >= gameloop.BOARD_HEIGHT)
                        {
                            player2_y = gameloop.BOARD_HEIGHT - 1;
                            Alive = false;
                        }
                    }

                    break;

            }




        }
        //출력
        public void Render()
        {



          
          
            Console.ForegroundColor = ConsoleColor.DarkRed; // 글씨 색상변경
            if (Alive)
            {

            if (tael2_count > 0)
            {

                for (int i = 0; i < tael2_count; ++i)
                {

                    Console.SetCursorPosition(tael2_x[i], tael2_y[i]);
                        
                        Console.Write('▣');

                }
            }

            Console.SetCursorPosition(player2_x, player2_y);
            Console.Write('■');
            Console.ResetColor();//글씨색상 초기화
            }




        }

    }


}
