using Microsoft.AspNetCore.Identity;

namespace CleanArch.MVC.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        //criado a classe com a exntesão(obrigatoria para o Identity) para caso necessário adicionar alguma outra informação ao usuário.

        public ApplicationUser()
        {

        }


    }
}