using Player;
using System;

namespace TheFinalBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Skeleton skeleton = new Skeleton();

            GameManager gameManager = new GameManager();

            gameManager.Monsters.Add(skeleton);

            gameManager.Start();
        }
    }
}
