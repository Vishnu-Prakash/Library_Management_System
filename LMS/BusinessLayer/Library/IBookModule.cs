using System;
using DomainLayer.Models;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);
        string AddBook(BookModel bookObj);
        string RemoveBook(int bookID);
        DataTable GetLog();
        DataTable GetBooks(string choice);
        string ReturnBook(int ID, string remarks);
        string AddUser(UserModel userModel);
        DataTable GetStudentLog(int studID);
        DataTable GetIssueLogByDate(DateTime dtlog);
        DataTable GetReturnLogByDate(DateTime dtlog);
        string RemoveUser(int removeID);
    }
}
