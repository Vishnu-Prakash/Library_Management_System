using DomainLayer;
using DomainLayer.Models;
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Library
{

    internal class BookModule : IBookModule
    {
        enum Choice {All=1, Active, Available };
        public DBConnection dbcon = new DBConnection();
        public string AddBook(BookModel bookObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddBook");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", bookObj.Name);
                cmd.Parameters.AddWithValue("@AuthorName", bookObj.AuthorName);
                cmd.Parameters.AddWithValue("@Department", bookObj.Department);
                cmd.Parameters.AddWithValue("@IsActive", bookObj.IsActive);
                cmd.Parameters.AddWithValue("@IsAvailable", bookObj.IsAvailable);
                int temp = dbcon.ExeNonQuery(cmd);
                return StringLiterals.BookAddMsg;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetBooks(string choice)
        {
            try
            {
                Choice choices = (Choice)Enum.Parse(typeof(Choice), choice);
                
                switch (choices)
                {
                    case Choice.All:
                        SqlCommand cmd = new SqlCommand("spGetAllBooks");
                        cmd.CommandType = CommandType.StoredProcedure;
                        return dbcon.ExeReader(cmd);
                    case Choice.Active:
                        SqlCommand cmd1 = new SqlCommand("spGetActiveBooks");
                        cmd1.CommandType = CommandType.StoredProcedure;
                        return dbcon.ExeReader(cmd1);
                    case Choice.Available:
                        SqlCommand cmd2 = new SqlCommand("spGetAvailableBooks");
                        cmd2.CommandType = CommandType.StoredProcedure;
                        return dbcon.ExeReader(cmd2);
                    default:
                        return null;
                }
            }
            catch
            {
                throw;
            }
        }
        public string IssueBook(BookHistoryModel obj)
        {
            try
            {
                using (LINQ_to_SQLDataContext dbContext = new LINQ_to_SQLDataContext())
                {
                    if (dbContext.tbl_UserModels.Any(x => x.UserID == obj.UserID&&x.IsAdmin==false) && dbContext.tbl_BookModels.Any(x=>x.BookID==obj.BookID))
                    {
                        if(dbContext.tbl_BookHistoryModels.Any(x=>x.BookID==obj.BookID && x.ReturnedAt == null))
                        {
                            return StringLiterals.BookIsAssignedToUser;
                        }
                        if(dbContext.tbl_BookModels.Any(x=>x.BookID==obj.BookID && (x.IsActive==false || x.IsAvailable == false)))
                        {
                            return StringLiterals.Error;
                        }
                        dbContext.tbl_BookModels.SingleOrDefault(x => x.BookID == obj.BookID).IsAvailable = false;
                        obj.OperationPerofrmedAt = DateTime.Now;
                        SqlCommand cmd = new SqlCommand("spAddHistory");
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BookID", obj.BookID);
                        cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                        cmd.Parameters.AddWithValue("@OperationPerformedAt", obj.OperationPerofrmedAt);
                        cmd.Parameters.AddWithValue("@ReturnedAt", System.Data.SqlTypes.SqlDateTime.MinValue);
                        cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
                        cmd.Parameters.AddWithValue("@PerformedByID", obj.PerformedByID);
                        dbcon.ExeNonQuery(cmd);

                        SqlCommand cmdForLog = new SqlCommand("spAddLog");
                        cmdForLog.CommandType = CommandType.StoredProcedure;
                        cmdForLog.Parameters.AddWithValue("@BookID", obj.BookID);
                        cmdForLog.Parameters.AddWithValue("@UserID", obj.UserID);
                        dbcon.ExeNonQuery(cmdForLog);

                        dbContext.SubmitChanges();
                        return StringLiterals.IssueBookMsg + (obj.OperationPerofrmedAt.AddDays(30));
                    }
                    else
                    {
                        return StringLiterals.Error;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public string ReturnBook(int bookID, string remarks)
        {
            using (LINQ_to_SQLDataContext dbContext = new LINQ_to_SQLDataContext())
            {
                if(dbContext.tbl_BookModels.Any(x=>x.BookID==bookID && x.IsActive && !x.IsAvailable))
                {
                    dbContext.tbl_BookModels.Where(x => x.BookID == bookID).FirstOrDefault().IsAvailable = true;
                    dbContext.tbl_BookHistoryModels.OrderByDescending(x => x.BookID == bookID).FirstOrDefault().ReturnedAt = DateTime.Now;
                    if (dbContext.tbl_BookHistoryModels.Any(x => x.BookID == bookID && (x.Remarks != remarks || (x.ReturnedAt - x.OperationPerformedAt).TotalDays > 30)))
                    {
                        return StringLiterals.FineMsg;
                    }
                    dbContext.SubmitChanges();
                    return StringLiterals.ReturnMsg;
                }
                else
                {
                    return StringLiterals.Error;
                }
            }
            
            }
        public string RemoveBook(int bookID)
        {
            try
            {
                using(LINQ_to_SQLDataContext dbContext = new LINQ_to_SQLDataContext())
                {
                    if (dbContext.tbl_BookModels.Any(x => x.BookID == bookID&&x.IsActive))
                    {
                        dbContext.tbl_BookModels.SingleOrDefault(x => x.BookID==bookID).IsActive=false;
                        dbContext.tbl_BookModels.SingleOrDefault(x => x.BookID == bookID).IsAvailable= false;
                        dbContext.SubmitChanges();
                        return StringLiterals.RemoveBookMsg;
                    }
                    else
                    {
                        return StringLiterals.Error;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetLog()
        {
            SqlCommand cmd = new SqlCommand("spGetLog");
            cmd.CommandType = CommandType.StoredProcedure;
            return dbcon.ExeReader(cmd);
        }
        public string AddUser(UserModel userModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddUser");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", userModel.Name);
                cmd.Parameters.AddWithValue("@Email", userModel.Email);
                cmd.Parameters.AddWithValue("@Password", userModel.Password);
                cmd.Parameters.AddWithValue("@IsActive", userModel.IsActive);
                cmd.Parameters.AddWithValue("@IsAdmin", userModel.IsAdmin);
                int temp = dbcon.ExeNonQuery(cmd);
                return StringLiterals.UserAddMsg;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetStudentLog(int studID)
        {
            SqlCommand cmd = new SqlCommand("spGetStudentLog");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", studID);
            return dbcon.ExeReader(cmd);
            //return StaticDatabase._usersList.Where(m => m.UserID == studID).FirstOrDefault().issues;
        }
        public string RemoveUser(int removeID)
        {
            try
            {
                using (LINQ_to_SQLDataContext dbContext = new LINQ_to_SQLDataContext())
                {
                    if (dbContext.tbl_UserModels.Any(x => x.UserID== removeID))
                    {
                        dbContext.tbl_UserModels.SingleOrDefault(x => x.UserID== removeID).IsActive = false;
                        dbContext.SubmitChanges();
                        return StringLiterals.RemoveUserMsg;
                    }
                    else
                    {
                        return StringLiterals.Error;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetIssueLogByDate(DateTime dtlog)
        {
            SqlCommand cmd = new SqlCommand("spGetIssueLogByDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dat", dtlog);
            return dbcon.ExeReader(cmd);
        }
        public DataTable GetReturnLogByDate(DateTime dtlog)
        {
            SqlCommand cmd = new SqlCommand("spGetReturnLogByDate");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dat", dtlog);
            return dbcon.ExeReader(cmd);
        }
    }
}