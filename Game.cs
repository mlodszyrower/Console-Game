﻿using System;

namespace Game
{
    public class Game
    {
        static int posX = 1, posY = 1;
        static int enemyX, enemyY;
        static int itemX, itemY;
        static int width = 10, height = 10;
        static char player = '@';
        static char space = '-';
        static char enemy = '$';
        static char item = '#';
        static Random rand = new Random();
        static int score = 0;
        static void Main(string[] args)
        {
            enemyX = width;
            enemyY = height;
            while (true)
            {
                if (CollideWithEnemy()) break;
                if (CollideWithItem()) { 
                    CreateItem(); score++; 
                }
                CreateItem();
                Draw();

                ConsoleKeyInfo info = Console.ReadKey();

                if ((info.Key == ConsoleKey.W && posY != 1) || (info.Key == ConsoleKey.S && posY != height))
                {
                    posY += (info.Key == ConsoleKey.S) ? 1 : -1;
                }
                if ((info.Key == ConsoleKey.A && posX != 1) || (info.Key == ConsoleKey.D && posX != width))
                {
                    posX += (info.Key == ConsoleKey.D) ? 1 : -1;
                }
                Move();
            }
            Console.Clear();
            Console.Write("Game over - thanks for playing!");
        }

        static void Draw()
        {
            Console.Clear();
            Console.Write("Score: " + score + "\n");
            for (int y = 1; y <= height; y++)
            {
                for (int x = 1; x <= width; x++)
                {
                    if (x == posX && y == posY) Console.Write(player);
                    else if (x == enemyX && y == enemyY) Console.Write(enemy);
                    else if (x == itemX && y == itemY) Console.Write(item);
                    else Console.Write(space);
                }
                Console.WriteLine();
            }
        }

        static void Move()
        {
            if (rand.Next(0, 11) < 3) return;
            if ((rand.Next(0, 11) >= 5 && posX != enemyX) || posY == enemyY)
            {
                if (posX < enemyX) enemyX--;
                else if (posX > enemyX) enemyX++;
            }
            else
            {
                if (posY < enemyY) enemyY--;
                else if (posY > enemyY) enemyY++;
            }
        }

        static bool CollideWithEnemy()
        {
            if (posX == enemyX && posY == enemyY) return true;
            return false;
        }

        static bool CollideWithItem()
        {
            if (posX == itemX && posY == itemY) return true;
            return false;
        }

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
