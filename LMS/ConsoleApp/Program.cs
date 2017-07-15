using BusinessLayer;
using BusinessLayer.Auth;
using BusinessLayer.Library;
using DomainLayer.Models;
using DomainLayer;
using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; true;)
            {
                Console.SetCursorPosition((Console.WindowWidth - StringLiterals.WelcomeMsg.Length) / 2, Console.CursorTop);
                Console.WriteLine(StringLiterals.WelcomeMsg);
                Console.Write(StringLiterals.UserNameLabel);
                string username = Console.ReadLine();
                Console.Write(StringLiterals.PasswordLabel);
                string password = Console.ReadLine();
                IAuthentication obj = BALFactory.GetAuthenticationObject();
                if (obj.Authenticate(new AuthModel() { Email = username, Password = password }))
                {
                    Console.WriteLine(StringLiterals.LoginSuccessMsg);
                    IBookModule bookOp = BALFactory.GetBookModuleObject();
                    OperationsUI driveUI = new OperationsUI();
                    driveUI.StartPoint(bookOp, username);
                }
                else
                {
                    Console.WriteLine(StringLiterals.InvalidCredentialsMsg);
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
