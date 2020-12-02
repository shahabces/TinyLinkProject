using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyLink.Core.Contracts.Dtos;
using TinyLink.Core.Contracts.Repositories;
using TinyLink.Core.Entities;

namespace TinyLink.Infrastructures.Data.SQLServer
{
    public class EfTinyLinkRepository : ITinyLinkRepository
    {
        private readonly TinyLinkDbContext _tinyLinkDbContext;

        public EfTinyLinkRepository(TinyLinkDbContext tinyLinkDbContext)
        {
            _tinyLinkDbContext = tinyLinkDbContext;
        }

        public string Add(TinyLinkEntity tinyLink)
        {
            _tinyLinkDbContext.TinyLinkEntities.Add(tinyLink);
            _tinyLinkDbContext.SaveChanges();
            return tinyLink.Hash;
        }

        public void AddVisit(string hash)
        {
            var link = _tinyLinkDbContext.TinyLinkEntities.Where(c => c.Hash == hash).FirstOrDefault();
            link.Count++;
            _tinyLinkDbContext.SaveChanges();
        }

        public TinyLinkEntity Get(string hash)
        {
            return _tinyLinkDbContext.TinyLinkEntities.Where(c => c.Hash == hash).FirstOrDefault();
        }
    }
}
