using System;
using System.Collections.Generic;
using System.Text;

namespace TinyLink.Core.Entities
{
    
    public class TinyLinkEntity
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Hash { get; set; }
        public int Count { get; set; }
    }
}
