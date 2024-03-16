using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.MVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.MVC.Infra.Data.Context
{
    //herda o dbcontext que contém todos os recursos para usar o EF
    public class ApplicationDbContext : DbContext
    {
        //construtor da classe, passando para a classe base as opções do DBContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        //Representações das tabelas que serão criadas no banco, mapeamento orm
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //Definição das configuração das entidades
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}