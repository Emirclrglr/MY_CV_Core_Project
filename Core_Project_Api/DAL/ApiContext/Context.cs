using Core_Project_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Project_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=CANAS_EVRAD\\SQLEXPRESS;database=CoreProjectApiDB; integrated security=true");
        }

        public DbSet<Category>? Categories { get; set; }

    }
}
