using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core
{
    public class ITLifeBlogDbContext : DbContext,IUnitOfWork
    {
        public ITLifeBlogDbContext():base("name=ITLifeBlog")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Article> Articles { get; set; }

        //public DbSet<ArticleComment> ArticleComments { get; set; }

        //public DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        //public DbSet<Message> Messages { get; set; }

        //public DbSet<Mood> Moods { get; set; }

        //public DbSet<MoodComment> MoodComments { get; set; }
            
        public virtual DbSet<Role> Roles { get; set; }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await this.SaveChangesAsync();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Account>()
            //.HasRequired<Role>(a => a.Role)
            //.WithMany(r => r.Accounts)
            //.HasForeignKey<int>(a => a.RoleId);
        }
    }
}
