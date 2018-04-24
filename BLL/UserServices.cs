using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model.Domain;

namespace BLL
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public byte[] createHash(string password, byte[] inSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(password, inSalt, 1000);
            return pbkdf2.GetBytes(keyLength);
        }

        public byte[] createSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        public Users GetUser(int userId)
        {
            return _unitOfWork.UserRepository.GetByID(userId);
        }

        public bool Login(string email, string password)
        {
            Users user = _unitOfWork.UserRepository.Get(u => u.Email == email);

            byte[] passwordTest = createHash(password, user.Salt);

            bool correctLogin = user.PasswordByte.SequenceEqual(passwordTest);

            return correctLogin;
        }
    }
}
