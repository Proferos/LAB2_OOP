using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAccount
{
    public abstract class Game
    {
        public static List<int> GameList = new List<int>() { 1 };

        public GameAccount player1;
        public GameAccount player2;
        public GameAccount winner;
        public int Rating;
        public int Number;

        public virtual void Play(){ }


        private static void filler()
        {
            GameList[0] = 1000;
            Shuffler shuffler = new Shuffler();
            for (int i = 1001; i < 9999; i++)
            {
                GameList.Add(i);
            }
            shuffler.Shuffle(GameList);
        }

        public static int UniqueRandom() // generates unique random 4-digit numbers
        {
            if (GameList[0] == 1)
            {
                filler();
            }

            int ret = 0;
            int i = 0;
            while (ret == 0)
            {
                ret = GameList[i];
                GameList[i] = 0;
                i++;
            }
            return ret;
        }
    }

    public class Shuffler
    {
        public Shuffler()
        {
            _rng = new Random();
        }


        public void Shuffle<T>(IList<T> array) // A shufller for list of game numbers
        {
            for (int n = array.Count; n > 1;)
            {
                int k = _rng.Next(n);
                --n;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        private System.Random _rng;
    }

    public class CoinFlip : Game {
            public CoinFlip(GameAccount player1, GameAccount player2, int Rating)
            {
                if (Rating < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Rating), "Rating bet must be 0 or higher");
                }
                this.player1 = player1;
                this.player2 = player2;
                this.Rating = Rating;
            Number = UniqueRandom();
            }

        public override void Play()
        {
            try
            {
                CoinFlip game = new CoinFlip(player1, player2, Rating);

                Random rnd = new Random();
                int coinFlip = rnd.Next(0, 2);
                switch (coinFlip)
                {
                    case 0:
                        game.winner = player1;
                        player1.WinGame(player2.UserName, game);
                        player2.LoseGame(player1.UserName, game);
                        break;
                    case 1:
                        game.winner = player2;
                        player2.WinGame(player1.UserName, game);
                        player1.LoseGame(player2.UserName, game);
                        break;
                }
                player1.gamesHistory.Add(game);
                player2.gamesHistory.Add(game);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught you tried to bet negative rating");
                Console.WriteLine(e.ToString());
                return;
            }

        }

    }

    public class Training : Game
    {
        public Training(GameAccount player1, GameAccount player2)
        {

            this.player1 = player1;
            this.player2 = player2;
            Rating = 0;
            Number = UniqueRandom();
        }

        public override void Play()
        {
            try
            {
                CoinFlip game = new CoinFlip(player1, player2, Rating);

                Random rnd = new Random();
                int coinFlip = rnd.Next(0, 2);
                switch (coinFlip)
                {
                    case 0:
                        game.winner = player1;
                        player1.WinGame(player2.UserName, game);
                        player2.LoseGame(player1.UserName, game);
                        break;
                    case 1:
                        game.winner = player2;
                        player2.WinGame(player1.UserName, game);
                        player1.LoseGame(player2.UserName, game);
                        break;
                }
                player1.gamesHistory.Add(game);
                player2.gamesHistory.Add(game);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught you tried to bet negative rating");
                Console.WriteLine(e.ToString());
                return;
            }

        }

    }

    public class CoinFlipSolo : Game
    {
        //Game where only player1 player can lose or win rating
        public CoinFlipSolo(GameAccount player1, GameAccount player2, int Rating)
        {
            if (Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Rating), "Rating bet must be 0 or higher");
            }
            this.player1 = player1;
            this.player2 = player2;
            this.Rating = Rating;
            Number = UniqueRandom();
        }

        public override void Play()
        {
            try
            {
                CoinFlipSolo game = new CoinFlipSolo(player1, player2, Rating);

                Random rnd = new Random();
                int coinFlip = rnd.Next(0, 2);
                switch (coinFlip)
                {
                    case 0:
                        game.winner = player1;
                        player1.WinGame(player2.UserName, game);
                        break;
                    case 1:
                        game.winner = player2;
                        player2.announcement(player1.UserName);
                        player1.LoseGame(player2.UserName, game);
                        break;
                }
                player1.gamesHistory.Add(game);
                player2.gamesHistory.Add(game);

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught you tried to bet negative rating");
                Console.WriteLine(e.ToString());
                return;
            }

        }

    }
}