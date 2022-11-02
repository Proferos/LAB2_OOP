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
            PremiumAccount.Create("prem");
            AdminAccount.Create("admin");
            Account.Create("user");

            Game.Play("prem", "admin", 30);
            Game.Play("prem", "admin", 700);
            Game.Play("prem", "admin", 300);

            GameAccount.GetStats("prem");
            GameAccount.GetStats("admin");


        }

    }


}