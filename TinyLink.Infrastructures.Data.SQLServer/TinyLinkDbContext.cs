using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TinyLink.Core.Entities;

namespace TinyLink.Infrastructures.Data.SQLServer
{
    public class TinyLinkDbContext:DbContext
    {
        public DbSet<TinyLinkEntity> TinyLinkEntities { get; set; }

        public TinyLinkDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

    }
}
