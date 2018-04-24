using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserServices
    {
        byte[] createSalt();
        byte[] createHash(string password, byte[] inSalt);
        Users GetUser(int userId);
        bool Login(String email, String password);
    }
}
