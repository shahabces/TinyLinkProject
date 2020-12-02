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
        bool Exist(string hash);
        TinyLinkEntity Get(string hash);
    }
}
