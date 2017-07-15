using DomainLayer.Models;
using System;
using System.Data;

namespace Repository.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);
        string ReturnBook(int ID, string remarks);
        string AddBook(BookModel bookObj);
        string RemoveBook(int bookID);
        DataTable GetLog();
        DataTable GetBooks(string choice);
        string AddUser(UserModel userModel);
        DataTable GetStudentLog(int studID);
        string RemoveUser(int removeID);
        DataTable GetIssueLogByDate(DateTime dtlog);
        DataTable GetReturnLogByDate(DateTime dtlog);
    }
}
