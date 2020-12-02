using System;
using System.Collections.Generic;
using System.Text;
using TinyLink.Core.Contracts.Dtos;
using TinyLink.Core.Entities;

namespace TinyLink.Core.Contracts.Repositories
{
    public interface ITinyLinkRepository
    {
        string Add(TinyLinkEntity tinyLink);
        TinyLinkEntity Get(string hash);
        void AddVisit(string hash);
    }
}
