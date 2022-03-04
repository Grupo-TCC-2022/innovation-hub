using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    /*Classe especifica do framework Entity Framework, ela eh responsavel por dizer ao
    Entity quais classes a gente vai querer que seja transformada em tabela no banco, como
    a classe AppUser/Usuario do app que sera transformada na tabela Users/Usuarios (no plural)*/
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
    }
}