using CPW219_eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_eCommerceSite.Models
{
    public static class UserDb
    {
        public static User Add(User p, UserContext db)
        {
            //Add User to context
            db.Users.Add(p);
            return p;
        }

        public static List<User> GetUsers(UserContext context)
        {
            return (from s in context.Users
                    select s).ToList(); // need to fix, cannot access database
        }

        public static User GetUser(UserContext context, string id)
        {
            User p2 = context
                            .Users
                            .Where(s => s.Email == id)
                            .Single();
            return p2;
        }

        public static void Delete(UserContext context, User p)
        {
            context.Users.Update(p);
        }

        public static void Update(UserContext context, User p)
        {
            //Mark the object as deleted
            context.Users.Remove(p);

            //Send delete query to database
            context.SaveChanges();
        }
    }
}
