using ControlePenal.Context;
using ControlePenal.Entity.Models;
using ControlePenal.Models;

namespace ControlePenal.Application
{
    public class LoginApp
    {
        private ApiContext _context;

        public LoginApp(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Função responsavel por Logar o Usuario 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UserContext? Login(LoginModel login)
        {
            try
            {
                if (login == null)
                    return null;

                UserContext? vLogin = _context.Users.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();

                if (vLogin == null)
                    return null;

                return vLogin;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
