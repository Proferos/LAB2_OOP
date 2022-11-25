using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameAccount

{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameAccount prem = PremiumAccount.Create("prem");
            GameAccount admin = AdminAccount.Create("admin");
            GameAccount user = Account.Create("user");
            GameAccount user2 = Account.Create("user2");


            Training game1 = new Training(user, admin);
            game1.Play();


            CoinFlipSolo game2 = new CoinFlipSolo(user, user2, 50);
            game2.Play();
            CoinFlipSolo game3 = new CoinFlipSolo(user, user2, 70);
            game3.Play();
            CoinFlipSolo game4 = new CoinFlipSolo(user, user2, 900);
            game4.Play();

            CoinFlip game5 = new CoinFlip(prem, admin, 2);
            game5.Play();
            CoinFlip game6 = new CoinFlip(prem, admin, 70);
            game6.Play();


            GameAccount.GetStats("prem");
            GameAccount.GetStats("admin");
            GameAccount.GetStats("user");
            GameAccount.GetStats("user2");


        }

    }


}