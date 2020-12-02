using System;
using System.Collections.Generic;
using System.Text;
using TinyLink.Core.Contracts.Dtos;

namespace TinyLink.Core.Contracts
{
    public interface ITinyLinkApplicationService
    {
        string AddLink(TinyLinkDto tinyLinkDto);
        string VisitLink(string hash);
    }
}
