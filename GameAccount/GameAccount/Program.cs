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
            Account account = new Account();
            Account account2 = new Account();
            Account account3 = new Account();
            account.Name = "Name";
            account.Name = "Yo";
            Console.WriteLine(account.id);
            Console.WriteLine(account2.id);
            Console.WriteLine(account3.id);


        }

    }


}