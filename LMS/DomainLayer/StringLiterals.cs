using System;

namespace DomainLayer
{
    public static class StringLiterals
    {
        public static string BookIsAssignedToUser { get { return "Book is already assigned to user."; } }
        public static string BookAddMsg { get { return "Book is added."; } }
        public static string IssueBookMsg { get { return "Book is issued. Duedate is "; } }
        public static string RemoveBookMsg { get { return "Book is removed."; } }
        public static string Error { get { return "Invalid operation."; } }
        public static string FineMsg { get { return "Pay Fine. Book is retuned."; } }
        public static string ReturnMsg { get { return "Book is returned."; } }
        public static string UserAddMsg { get { return "User is added."; } }
        public static string RemoveUserMsg { get { return "User is removed"; } }
        public static string ValidationsErrorMsg { get { return "Enter valid input"; } }
        public static string WelcomeMsg { get { return "Welcome to Library Management System"; } }
        public static string UserNameLabel { get { return "Enter Username: "; } }
        public static string PasswordLabel { get { return "Enter Password: "; } }
        public static string LoginSuccessMsg { get { return "Login successful"; } }
        public static string SelectMsg { get { return "Select the option that you wanna perform:\n"; } }
        public static string OptionsMsg { get { return "1. Add a book\n\n2. Display books\n\n3. Make an issue\n\n4. Make a return\n\n5. Remove a book\n\n6. Operations log\n\n7. Books taken by a student\n\n8. Add a user\n\n9. Remove a user\n\n10. Logout\n"; } }
        public static string InvalidCredentialsMsg { get { return "\nInvalid credentials"; } }
        public static string BookNameLabel { get { return "Enter name of book: "; } }
        public static string DeptNameLabel { get { return "Enter name of Department: "; } }
        public static string AuthorNameLabel { get { return "Enter name of Author: "; } }
        public static string nullLabel { get { return ""; } }
        public static string EmailLabel { get { return "Enter email of user: "; } }
        public static string TypeOfUserLabel { get { return "Enter 1 if user is admin\t2 if user is a student: "; } }
        public static object One { get { return "1"; } }
        public static string UserIdLabel { get { return "Enter userid: "; } }
        public static string PressAnyKeyPrompt { get { return "Press any key to go back"; } }
        public static string ChooseLogOptionPrompt { get { return "Choose one option: 1. Display log till date\t2. Display log by date: "; } }
        public static string DisplayLogTillNowMsg { get { return "Displaying log of operations done till now ...\n"; } }
        public static string EnterDatePrompt { get { return "Enter date in mm/dd/yyyy format: "; } }
        public static string DisplayingLogTillDate { get { return "Displaying log of operations performed on "; } }
        public static string IssuesMsg { get { return "Issues\n"; } }
        public static string ReturnsMsg { get { return "\nReturns\n"; } }
        public static string EnterBookIDPrompt { get { return "Enter BookID: "; } }
        public static string EnterStudIDPrompt { get { return "Enter student id: "; } }
        public static string EnterUserIDPrompt { get { return "Enter User id: "; } }
        public static string EnterRemarksPrompt { get { return "Enter remarks of the book: "; } }
        public static string DisplayingAllBooksMsg { get { return "\nDisplaying all books...\n"; } }
        public static string DisplayingEnabledBooksMsg { get { return "\nDisplaying only enabled books...\n"; } }
        public static string DisplayingAvailableBooksMsg { get { return "\nDisplaying only available books...\n"; } }
        public static string SelectBooksMsg { get { return "1. Display all books\n2. Display only enabled books\n3. Display only available books"; } }
        public static string NewLine { get { return "\n"; } }
    }
}
