using System;

namespace Game
{
    public class Item : Game
    {
        public static void CreateItem()
        {
            int x = rand.Next(1, width), y = posY;

            while (y > posY - 2 && y < posY + 2)
            {
                y = rand.Next(1, height);
            }

            itemX = x;
            itemY = y;
        }
    }
}
