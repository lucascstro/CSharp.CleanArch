using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.MVC.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateService(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result =  await _signInManager.PasswordSignInAsync(email, password, false, false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser { UserName = email, Email = email };

            var result = await _userManager.CreateAsync(applicationUser);
            if (result.Succeeded)
                await _signInManager.SignInAsync(applicationUser, false);

            return result.Succeeded;

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}