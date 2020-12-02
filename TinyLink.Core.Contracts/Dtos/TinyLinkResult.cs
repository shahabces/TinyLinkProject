using System;
using System.Collections.Generic;
using System.Text;

namespace TinyLink.Core.Contracts.Dtos
{
    public class TinyLinkResult
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Hash { get; set; }
    }
}
