using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worm
{
    internal class gameloop
    {
        Player player = new Player();
        Player2 player2 = new Player2();
        Item[] item = new Item[2];
        public const int BOARD_WIDTH = 60;
        public const int BOARD_HEIGHT = 30;
        bool player1_GameOver = false;
        bool player2_GameOver = false;
        
        int oldTime = 0;
        bool Needrefresh = false;

        // 점수
        int player1_score = 0;
        int player2_score = 0;


        public void Awake()
        {
            for (int i = 0; i < 2; i++)
            {
            item[i] = new Item(i);
            }

            Console.CursorVisible = false;
            Console.BufferWidth = Console.WindowWidth = BOARD_WIDTH;
            Console.BufferHeight = Console.WindowHeight = BOARD_HEIGHT;

            //플레이어 1에 있는 플레이어 2 변수에 내가 만든 플레이어 2 객체를 넣어줌
            player.player2 = player2;
            player2.player = player;


        }
        public void Start()
        {

            player.Start();
            player2.Start();
            for (int i = 0; i < 2; i++)
            {
                item[i].Refreshitem();
            }
        }
        public void Update()
        {

            for (int i = 0; i < 2; i++)
            {
                if (player.Getplayer_x() == item[i].Getitem_x() && player.Getplayer_y() == item[i].Getitem_y())
                {
                    player.Settael_count();
                    ++player1_score;

                    item[i].Refreshitem();
                }
            }


            if (player.Getplayer_x() == player2.Getplayer2_x() && player.Getplayer_y() == player2.Getplayer2_y())
            {
                player1_GameOver = true;
                player2_GameOver = true;
            }



                for (int i = 0; i < 2; i++)
            {
                if (player2.Getplayer2_x() == item[i].Getitem_x() && player2.Getplayer2_y() == item[i].Getitem_y())
                {
                    player2.Settael_count();
                    ++player2_score;

                    item[i].Refreshitem();
                }
            }

            if (player1_GameOver == true && player2_GameOver == true)
            {
                return;
            }

          

            int curTime = Environment.TickCount & Int32.MaxValue;
            if (curTime - oldTime > 50)
            {
                player.Update();
                player2.Update();

                if (player.GetAlive() == false)
                {
                    player1_GameOver = true;
                }
                if (player2.GetAlive() == false)
                {
                    player2_GameOver = true;
                }
                oldTime = curTime;
                Needrefresh = true;
            }
            //입력키 처리
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    
                    case ConsoleKey.LeftArrow:
                        if (player.GetLeft())
                        {
                            
                            player.Move_Left();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (player.GetRight())
                        {
                         
                            player.Move_Right();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (player.GetUp())
                        {
                            
                            player.Move_Up();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (player.GetDown())
                        {
                            
                            player.Move_Down();
                        }
                        break;
                
                            case ConsoleKey.A:
                                if (player2.GetLeft())
                                {
                            
                            player2.Move_Left();
                                }
                                break;
                            case ConsoleKey.D:
                                if (player2.GetRight())
                                {
                            
                            player2.Move_Right();
                                }
                                break;
                            case ConsoleKey.W:
                                if (player2.GetUp())
                                {
                            
                            player2.Move_Up();
                                }
                                break;
                            case ConsoleKey.S:
                                if (player2.GetDown())
                                {
                            
                            player2.Move_Down();
                                }
                                break;


                        }

            }


        }
        public void Render()
        {

            if (Needrefresh == false)
            {
                return;
            }
            else
            {


                player.Render();
                player2.Render();
                for (int i = 0; i < 2; i++)
                {

                    item[i].Render();
                }
                Console.ForegroundColor = ConsoleColor.Green; // 글씨 색상변경
                Console.SetCursorPosition(0, 0);
                Console.Write($"Player1 Scoer : {player1_score}    ");
                Console.Write($"Player2 Scoer : {player2_score}");



                if (player1_GameOver == true && player2_GameOver == true)
                {
                    Console.SetCursorPosition(25, 15);
                    Console.Write($"GAME OVER!!!\n              Player1 Scoer : {player1_score}  Player2 Scoer : {player2_score}");
                    if (player1_score < player2_score)
                    {
                        Console.SetCursorPosition(25, 17);
                        Console.WriteLine($"Player2 WIN");
                    }
                    if (player1_score > player2_score)
                    {
                        Console.SetCursorPosition(25, 17);
                        Console.WriteLine($"Player1 WIN");
                    }
                    if (player1_score == player2_score)
                    {
                        Console.SetCursorPosition(28, 18);
                        Console.WriteLine($"Drow");
                    }

                   
                    

                }

               
                
            }
        }

    }
}
