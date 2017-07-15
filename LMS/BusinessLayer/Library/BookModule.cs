using DomainLayer.Models;
using System.Collections.Generic;
using System.Data;

using Repo = Repository.Library;
using System;

namespace BusinessLayer.Library
{
    internal class BookModule : IBookModule
    {
        Repo.IBookModule _bookObj;
        public BookModule()
        {
            _bookObj = Repository.RepoFactory.GetBookModuleObject();
        }
        public string AddBook(BookModel bookObj)
        {
            return _bookObj.AddBook(bookObj);
        }
        public DataTable GetBooks(string choice)
        {
            return _bookObj.GetBooks(choice);
        }
        public string IssueBook(BookHistoryModel obj)
        {
            return _bookObj.IssueBook(obj);
        }
        public string RemoveBook(int bookID)
        {
            return _bookObj.RemoveBook(bookID);
        }
        public string ReturnBook(int ID, string remarks)
        {
            return _bookObj.ReturnBook(ID, remarks);
        }
        public DataTable GetLog()
        {
            return _bookObj.GetLog();
        }
        public string AddUser(UserModel userModel)
        {
            return _bookObj.AddUser(userModel);
        }
        public DataTable GetStudentLog(int studID)
        {
            return _bookObj.GetStudentLog(studID);
        }
        public string RemoveUser(int removeID)
        {
            return _bookObj.RemoveUser(removeID);
        }
        public DataTable GetIssueLogByDate(DateTime dtlog)
        {
            return _bookObj.GetIssueLogByDate(dtlog);
        }
        public DataTable GetReturnLogByDate(DateTime dtlog)
        {
            return _bookObj.GetReturnLogByDate(dtlog);
        }
    }
}
