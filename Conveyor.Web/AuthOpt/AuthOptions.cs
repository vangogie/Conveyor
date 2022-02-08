using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Conveyor.Web.AuthOpt
{
    public class AuthOptions
    {
        public const string ISSUER = "CalculateConveyor"; // издатель токена, любое значение
        public const string AUDIENCE = "AngularCalculateConveyor"; // потребитель токена, любое значение
        const string KEY = "ivan_1991_le!_znak";   // ключ для шифрации
        public const int LIFETIME = 60; // время жизни токена, в минутах
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
