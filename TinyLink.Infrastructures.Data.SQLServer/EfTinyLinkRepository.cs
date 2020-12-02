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

        public bool Exist(string hash)
        {
            var exist = _tinyLinkDbContext.TinyLinkEntities.Where(c => c.Hash == hash).FirstOrDefault();
            if (exist==null)
            {
                return false;
            }
            return true;
        }

        public int Get(string hash)
        {
            var tinylink = _tinyLinkDbContext.TinyLinkEntities.Where(c => c.Hash == hash).FirstOrDefault();
            return tinylink.Count;
        }

        TinyLinkEntity ITinyLinkRepository.Get(string hash)
        {
            throw new NotImplementedException();
        }
    }
}
