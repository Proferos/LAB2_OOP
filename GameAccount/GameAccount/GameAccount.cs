using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAccount
{
    
    public abstract class GameAccount
    {
        public string UserName;
        protected int CurrentRating;
        protected int GamesCount;
        public List<Game> gamesHistory = new List<Game>();

        public static List<GameAccount> AccountList = new List<GameAccount>();



        public void addToList(GameAccount account)
        {
            AccountList.Add(account);
        }


        

        public virtual void WinGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating += Rating;
            Console.WriteLine("\n{0} just won {1} rating from {2}\n", UserName, Rating, FindByName(opponentName).UserName);
        }


        public virtual void LoseGame(string opponentName, int Rating)
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

    public class PremiumAccount : GameAccount
    {

        public PremiumAccount(string UserName)
        {
            this.UserName = UserName;
            CurrentRating = 1000;
            GamesCount = 0;
        }

        public static GameAccount Create(string UserName)
        {
            PremiumAccount account = new PremiumAccount(UserName);
            AccountList.Add(account);
            return account;
        }

        public override void WinGame(string opponentName, int Rating)
        {
            GamesCount++;
            Rating *= 2;
            CurrentRating += Rating;
            Console.WriteLine("\n{0} just won {1} rating from {2}\n", UserName, Rating, FindByName(opponentName).UserName);
        }


        public override void LoseGame(string opponentName, int Rating)
        {
            GamesCount++;
            Rating /= 2;
            CurrentRating -= Rating;
            if (CurrentRating <= 0)
            {
                CurrentRating = 1;
            }
        }
    }

    public class AdminAccount : GameAccount
    {

        public AdminAccount(string UserName)
        {
            this.UserName = UserName;
            CurrentRating = 1000;
            GamesCount = 0;
        }

        public static GameAccount Create(string UserName)
        {
            AdminAccount account = new AdminAccount(UserName);
            AccountList.Add(account);
            return account;
        }

        public override void WinGame(string opponentName, int Rating)
        {
            GamesCount++;
            Rating *= 2;
            CurrentRating += Rating;
            Console.WriteLine("\n{0} just won {1} rating from {2}\n", UserName, Rating, FindByName(opponentName).UserName);
        }


        public override void LoseGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating -= 0;
            if (CurrentRating <= 0)
            {
                CurrentRating = 1;
            }
        }
    }

    public class Account : GameAccount
    {

        public Account(string UserName)
        {
            this.UserName = UserName;
            CurrentRating = 1000;
            GamesCount = 0;
        }

        public static GameAccount Create(string UserName)
        {
            Account account = new Account(UserName);
            AccountList.Add(account);
            return account;
        }

        public override void WinGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating += Rating;
            Console.WriteLine("\n{0} just won {1} rating from {2}\n", UserName, Rating, FindByName(opponentName).UserName);
        }


        public override void LoseGame(string opponentName, int Rating)
        {
            GamesCount++;
            CurrentRating -= Rating;
            if (CurrentRating <= 0)
            {
                CurrentRating = 1;
            }
        }
    }
}