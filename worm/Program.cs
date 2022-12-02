using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 플레이어 1x1 하나
// 자동으로 한칸씩 움직임

// 맵

// 플레이어

// 오브젝트

// 스코어

// 오브젝트를 먹으면 길어짐
// 오브젝트를 하나라도 먹으면 
// 방향키를 누르면 움직이는 방향이 바뀜
// 벽에 닿으면죽음 
namespace worm
{
    internal class Program
    {

        static void Main(string[] args)
        {

            gameloop gl = new gameloop();
            gl.Awake();
            gl.Start();
            while (true)
            {
                gl.Update();
                gl.Render();

            }
        }
        
    }
}
