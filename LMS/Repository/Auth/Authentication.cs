using DomainLayer.Models;
using System.Linq;

namespace Repository.Auth
{
    internal class Authentication : IAuthentication
    {
        public bool Authenticate(AuthModel obj)
        {
            using(LINQ_to_SQLDataContext dataContext = new LINQ_to_SQLDataContext())
            {
                return dataContext.tbl_UserModels.Any(m => m.Email == obj.Email && m.Password == obj.Password && m.IsAdmin == true && m.IsActive == true);
            }
        }
    }
}