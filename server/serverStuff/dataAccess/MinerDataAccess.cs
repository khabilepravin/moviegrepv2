using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace dataAccess
{
    public class MinerDataAccess : DbContext
    {
        public MinerDataAccess() : base("Name=DbConnectString") { }

        public DbSet<main> datas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<main>().ToTable("dbo.main");

            Database.SetInitializer<MinerDataAccess>(null);
        }

        public IQueryable<main> GetFirst()
        {
            var records = from m in datas
                      where m.Id == 1
                      select m;

            return records;
        }

        public void Add(main entity)
        {
            datas.Add(entity);
            //this.Entry(entity).State = EntityState.Added;
            
            this.SaveChanges();
        }
    }
}
