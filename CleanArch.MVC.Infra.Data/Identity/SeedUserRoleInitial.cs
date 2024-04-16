using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.MVC.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        //o ISeedUserRoleInitial faz uma pré-configuração na primeira vez que a aplicação for executada.
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //criacao de perfis de usuário
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "User";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "Admin";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
        //criacao de usuário alocado ao seu tipo de perfil(role)
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario2@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario2@localhost";
                user.Email = "usuario2@localhost";
                user.NormalizedUserName = "usuario2@localhost";
                user.NormalizedEmail = "usuario2@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

               IdentityResult result = _userManager.CreateAsync(user, "abc12345").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin3@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin3@localhost";
                user.Email = "admin3@localhost";
                user.NormalizedUserName = "admin3@localhost";
                user.NormalizedEmail = "admin3@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "abc12345").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}