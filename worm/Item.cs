using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worm
{
    internal class Item
    {
        
        
        Random random;
        public Item (int seed)
        {
            random = new Random(seed);
        }

        int item_x, item_y;
        public int Getitem_x()
        { return item_x; }
        public int Getitem_y()
        { return item_y; }

        //새로나오는 아이템의 위치를 랜덤하게 만들어주는 함수
        public void Refreshitem()
        {
            
            
            item_x = random.Next(2, 58);
            if (item_x % 2 == 1)
            {
                ++item_x;
            }
            item_y = random.Next(1, 30);
        }
        

        //출력
        public void Render()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow; // 글씨 색상변경
            Console.SetCursorPosition(item_x, item_y);
            Console.Write('●');

        }
    }
}
