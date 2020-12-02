using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TinyLink.Core.Entities;

namespace TinyLink.Infrastructures.Data.SQLServer
{
    public class TinyLinkDbContext:DbContext
    {
        public DbSet<TinyLinkEntity> TinyLinkEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=TinyLinkDb;integrated security=true");
        }
    }
}
