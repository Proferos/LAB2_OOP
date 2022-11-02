using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameAccount
{
    public class Account{
        static int idGenerator = 1000;
        public int id = ++idGenerator;
        private string name;
        private int rating;
        private int gamesCount;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int GamesCount
        {
            get { return rating; }
            set { rating = value; }
        }

    }


    public class GameAccount
    {
        public string UserName;
        int CurrentRating;
        int GamesCount;

        public List<Game> gamesHistory = new List<Game>();
        public static List<GameAccount> AccountList = new List<GameAccount>();


        public GameAccount(string UserName)
        {
            this.UserName = UserName;
            CurrentRating = 1000;
            GamesCount = 0;
        }


        public void addToList(GameAccount account)
        {
            AccountList.Add(account);
        }


        public static GameAccount Create(string UserName)
        {
            GameAccount account = new GameAccount(UserName);
            AccountList.Add(account);
            return account;
        }

        public void WinGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating += Rating;
            Console.WriteLine("\n{0} just won {1} rating from {2}\n", UserName, Rating, FindByName(opponentName).UserName);
        }


        public void LoseGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating -= Rating;
            if (CurrentRating <= 0)
            {
                CurrentRating = 1;
            }
        }


        public static void GetStats(string user)
        {
            GameAccount us = FindByName(user);
            Console.WriteLine("\nUsername: {0}; Rating: {1}, Games count: {2}", us.UserName, us.CurrentRating, us.GamesCount);


            int a;
            string enemy;
            string result;
            int rating;

            foreach (Game game in us.gamesHistory)
            {
                a = game.Number;
                if (game.player1 == us)
                {
                    enemy = game.player2.UserName;
                }
                else
                {
                    enemy = game.player1.UserName;
                }

                if (game.winner == us)
                {
                    result = "won";
                }
                else
                {
                    result = "lost";
                }
                rating = game.Rating;
                Console.WriteLine("\nStats for player {0}", user);
                Console.WriteLine("Game {0}: against {1} {2} {3} rating\n", a, enemy, result, rating);
                Thread.Sleep(100);
            }


        }


        public static GameAccount FindByName(string AccountName)
        {
            int i = 0;
            GameAccount cur = AccountList[0];
            while (cur.UserName != AccountName)
            {
                cur = AccountList[i];
                i++;
            }
            return cur;
        }
    }
}