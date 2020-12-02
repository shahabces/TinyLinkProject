using System;
using TinyLink.Core.Contracts.Dtos;
using TinyLink.Core.Contracts.Repositories;
using TinyLink.Core.Entities;

namespace TinyLink.Core.ApplicationServices
{
    public class TinyLinkApplicationService
    {
        private readonly ITinyLinkRepository _tinyLinkRepository;

        public TinyLinkApplicationService(ITinyLinkRepository tinyLinkRepository)
        {
            _tinyLinkRepository = tinyLinkRepository;
        }

        public string AddLink(TinyLinkDto tinyLinkDto)
        {
            var tinyLink = _tinyLinkRepository.Get(tinyLinkDto.Hash);
            if (tinyLink == null)
            {
                TinyLinkEntity tinyLinkEntity = new TinyLinkEntity
                {
                    Link = tinyLinkDto.Link,
                    Hash = tinyLinkDto.Hash,
                    Count = 0
                };
                return _tinyLinkRepository.Add(tinyLinkEntity);
            }

            tinyLink.Count++;
            return tinyLink.Hash;

        }

        public string VisitLink(string hash)
        {
            var tinyLink = _tinyLinkRepository.Get(hash);
            if (tinyLink==null)
            {
                return string.Empty;
            }
            tinyLink.Count++;
            return tinyLink.Link;
        }
        
    }
}
