using System;
using System.Threading;
using DomainLayer;
using DomainLayer.Models;
using BusinessLayer.Library;
using System.Data;

namespace ConsoleApp
{
    enum LogChoice { AllLog=1, DateLog};
    enum Choice { All = 1, Active, Available };

    internal class OperationsUI
    {
        enum Option { AddBook = 1, ShowBooks, Issue, Return, RemoveBook, Log, StudentsBooks, AddUser, RemoveUser, Logout };
        public void StartPoint(IBookModule bookOp, string username)
        {
            for (; true;)
            {
                Console.Clear();
                Console.WriteLine(StringLiterals.SelectMsg);
                Console.WriteLine(StringLiterals.OptionsMsg);
                Option opt = (Option)Enum.Parse(typeof(Option), Console.ReadLine());
                if (opt == Option.Logout)
                {
                    break;
                }
                switch (opt)
                {
                    case Option.AddBook:
                        AddBook(bookOp);
                        Thread.Sleep(2000);
                        break;
                    case Option.ShowBooks:
                        ShowBooks(bookOp);
                        break;
                    case Option.Issue:
                        IssueBook(bookOp, username);
                        break;
                    case Option.Return:
                        ReturnBook(bookOp);
                        break;
                    case Option.RemoveBook:
                        RemoveBook(bookOp);
                        Thread.Sleep(2000);
                        break;
                    case Option.Log:
                        GetLog(bookOp);
                        break;
                    case Option.StudentsBooks:
                        GetStudentLog(bookOp);
                        break;
                    case Option.AddUser:
                        Adduser(bookOp);
                        Thread.Sleep(2000);
                        break;
                    case Option.RemoveUser:
                        RemoveUser(bookOp);
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine(StringLiterals.Error);
                        Thread.Sleep(1000);
                        break;
                }
                Console.Clear();
            }
        }
        public void AddBook(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.BookNameLabel);
            string name = Console.ReadLine();
            Console.Write(StringLiterals.DeptNameLabel);
            string dept = Console.ReadLine();
            Console.Write(StringLiterals.AuthorNameLabel);
            string author = Console.ReadLine();
            if(name== StringLiterals.nullLabel && dept== StringLiterals.nullLabel && author== StringLiterals.nullLabel)
            {
                Console.WriteLine(StringLiterals.ValidationsErrorMsg);
            }
            else
            {
                Console.WriteLine(bookOp.AddBook(new BookModel() { Name = name, Department = dept, AuthorName = author, IsAvailable = true, IsActive = true }));
            }
        }
        public void Adduser(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.UserNameLabel);
            string userName = Console.ReadLine();
            Console.Write(StringLiterals.EmailLabel);
            string email = Console.ReadLine();
            Console.Write(StringLiterals.PasswordLabel);
            string pass = Console.ReadLine();
            Console.Write(StringLiterals.TypeOfUserLabel);
            bool IsAdmin = Console.ReadLine().Equals(StringLiterals.One) ? true : false;
            if (userName == StringLiterals.nullLabel && email == StringLiterals.nullLabel && pass == StringLiterals.nullLabel)
            {
                Console.WriteLine(StringLiterals.ValidationsErrorMsg);
            }
            else
            {
                Console.WriteLine(bookOp.AddUser(new UserModel() { Name = userName, Email = email, IsActive = true, Password = pass, IsAdmin = IsAdmin }));
            }
        }
        public void GetLog(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.ChooseLogOptionPrompt);
            LogChoice logOption = (LogChoice)Enum.Parse(typeof(LogChoice),Console.ReadLine());
            switch (logOption)
            {
                case LogChoice.AllLog:
                    Console.Clear();
                    Console.WriteLine(StringLiterals.DisplayLogTillNowMsg);
                    foreach (DataRow row in bookOp.GetLog().Rows)
                    {
                        if (row["ReturnedAt"].ToString() == default(DateTime).ToString())
                        {
                            Console.WriteLine("BookID: {0}\nTaken by: {1}\nIssued by: {2}\nIssued at: {3}\nReturned at: Need to be returned\nRemarks: {4}\n", row["BookID"].ToString(), row["UserID"].ToString(), row["PerformedByID"].ToString(), row["OperationPerformedAt"].ToString(), row["Remarks"].ToString());
                        }
                        else
                        {
                            Console.WriteLine("BookID: {0}\nTaken by: {1}\nIssued by: {2}\nIssued at: {3}\nReturned at: {4}\nRemarks: {5}\n", row["BookID"].ToString(), row["UserID"].ToString(), row["PerformedByID"].ToString(), row["OperationPerformedAt"].ToString(),row["ReturnedAt"].ToString(), row["Remarks"].ToString());
                        }
                    }
                    break;
                case LogChoice.DateLog:
                    Console.Clear();
                    Console.Write(StringLiterals.EnterDatePrompt);
                    DateTime dtlog = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine(StringLiterals.DisplayingLogTillDate + dtlog);
                    Console.WriteLine(StringLiterals.IssuesMsg);
                    foreach (DataRow row in bookOp.GetIssueLogByDate(dtlog).Rows)
                    {
                        Console.WriteLine("BookID: {0}\nTaken by: {1}\nIssued by: {2}\nIssued at: {3}\nRemarks: {4}\n", row["BookID"].ToString(), row["UserID"].ToString(), row["PerformedByID"].ToString(), row["OperationPerformedAt"].ToString(), row["Remarks"].ToString());
                    }
                    Console.WriteLine(StringLiterals.ReturnsMsg);
                    foreach (DataRow row in bookOp.GetReturnLogByDate(dtlog).Rows)
                    {
                        Console.WriteLine("BookID: {0}\nTaken by: {1}\nIssued by: {2}\nReturned at: {3}\nRemarks: {4}\n", row["BookID"].ToString(), row["UserID"].ToString(), row["PerformedByID"].ToString(), row["OperationPerformedAt"].ToString(), row["Remarks"].ToString());
                    }
                    break;
                default:
                    Console.WriteLine(StringLiterals.Error);
                    break;
            }
            Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
            Console.ReadKey();
        }
        public void GetStudentLog(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.UserIdLabel);
            int studId = Convert.ToInt32(Console.ReadLine());
            foreach (DataRow i in bookOp.GetStudentLog(studId).Rows)
            {
                Console.WriteLine(StringLiterals.NewLine+i["BookID"].ToString() + StringLiterals.NewLine + i["Name"].ToString()+StringLiterals.NewLine);
            }
            Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
            Console.ReadKey();
        }
        public void IssueBook(IBookModule bookOp, string username)
        {
            Console.Clear();
            Console.Write(StringLiterals.EnterBookIDPrompt);
            int bookid = Convert.ToInt32(Console.ReadLine());
            Console.Write(StringLiterals.EnterStudIDPrompt);
            int studid = Convert.ToInt32(Console.ReadLine());
            Console.Write(StringLiterals.EnterRemarksPrompt);
            string remark = Console.ReadLine();
            Console.WriteLine(StringLiterals.NewLine + bookOp.IssueBook(new BookHistoryModel() { BookID = bookid, UserID = studid, OperationPerofrmedAt = DateTime.Today, PerformedByID = username, Remarks = remark }) + StringLiterals.NewLine);
            Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
            Console.ReadKey();
        }
        public void RemoveBook(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.EnterBookIDPrompt);
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(bookOp.RemoveBook(id));
        }
        public void RemoveUser(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.EnterUserIDPrompt);
            int removeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(bookOp.RemoveUser(removeID));
        }
        public void ReturnBook(IBookModule bookOp)
        {
            Console.Clear();
            Console.Write(StringLiterals.EnterBookIDPrompt);
            int studID = Convert.ToInt32(Console.ReadLine());
            Console.Write(StringLiterals.EnterRemarksPrompt);
            string remarks = Console.ReadLine();
            Console.WriteLine(StringLiterals.NewLine+bookOp.ReturnBook(studID, remarks)+StringLiterals.NewLine);
            Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
            Console.ReadKey();
        }
        public void ShowBooks(IBookModule bookOp)
        {
            Console.Clear();
            Console.WriteLine(StringLiterals.SelectMsg);
            Console.WriteLine(StringLiterals.SelectBooksMsg);
            string choice = Console.ReadLine();
            Choice choices =(Choice)Enum.Parse(typeof(Choice),choice);
            switch (choices)
            {
                case Choice.All:
                    Console.WriteLine(StringLiterals.DisplayingAllBooksMsg);
                    foreach (DataRow row in bookOp.GetBooks(choice).Rows)
                    {
                        Console.WriteLine("\nBook Id: {0}\nBook Name: {1}\nDepartment: {2}\nAuthor: {3}\nIs available: {4}\nIs Enabled: {5}\n", row["BookID"].ToString(), row["Name"].ToString(), row["Department"].ToString(), row["AuthorName"].ToString(), row["IsAvailable"].ToString(), row["IsActive"].ToString());
                    }
                    Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
                    Console.ReadKey();
                    break;
                case Choice.Active:
                    Console.WriteLine(StringLiterals.DisplayingEnabledBooksMsg);
                    foreach (DataRow row in bookOp.GetBooks(choice).Rows)
                    {
                        Console.WriteLine("\nBook Id: {0}\nBook Name: {1}\nDepartment: {2}\nAuthor: {3}\nIs available: {4}\n", row["BookID"].ToString(), row["Name"].ToString(), row["Department"].ToString(), row["AuthorName"].ToString(), row["IsAvailable"].ToString());
                    }
                    Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
                    Console.ReadKey();
                    break;
                case Choice.Available:
                    Console.WriteLine(StringLiterals.DisplayingAvailableBooksMsg);
                    foreach (DataRow row in bookOp.GetBooks(choice).Rows)
                    {
                        Console.WriteLine("\nBook Id: {0}\nBook Name: {1}\nDepartment: {2}\nAuthor: {3}\n", row["BookID"].ToString(), row["Name"].ToString(), row["Department"].ToString(), row["AuthorName"].ToString());
                    }
                    Console.WriteLine(StringLiterals.PressAnyKeyPrompt);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine(StringLiterals.NewLine + StringLiterals.ValidationsErrorMsg);
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
