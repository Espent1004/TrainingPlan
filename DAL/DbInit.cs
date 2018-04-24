using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using Model.Database;

namespace DAL
{
    public class DbInit : CreateDatabaseIfNotExists<TpContext>
    {
        protected override void Seed(TpContext context)
        {
            byte[] salt = createSalt();
            byte[] hash = createHash("passord", salt);
            Users user = new Users() { UserId = 1, Email = "espent1004@gmail.com", Phone = "95791134",Password = hash, Salt = salt };


            context.Users.Add(user);

            Status status1 = new Status()
            {
                StatusId = 1,
                StatusText = "Planned"
            };

            Status status2 = new Status()
            {
                StatusId = 2,
                StatusText = "Completed"
            };

            Status status3 = new Status()
            {
                StatusId = 3,
                StatusText = "Cancelled"
            };

            context.Status.Add(status1);
            context.Status.Add(status2);
            context.Status.Add(status3);

            base.Seed(context);
        }

        private static byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static byte[] createHash(string Password, byte[] inSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(Password, inSalt, 1000);
            return pbkdf2.GetBytes(keyLength);
        }
    }


}
