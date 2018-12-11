using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestProject2.Models;

namespace TestProject2.AuthProvider
{
    public class AuthRepository : IDisposable
    {
        private ApplicationDbContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new ApplicationDbContext();
           _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
         
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email,
                Email = userModel.Email,
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            try
            {
                IdentityUser user = await _userManager.FindAsync(userName, password);
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
       
          
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}