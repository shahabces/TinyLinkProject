using System;
using TinyLink.Core.Contracts;
using TinyLink.Core.Contracts.Dtos;
using TinyLink.Core.Contracts.Repositories;
using TinyLink.Core.Entities;

namespace TinyLink.Core.ApplicationServices
{
    public class TinyLinkApplicationService:ITinyLinkApplicationService
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
                var hash = _tinyLinkRepository.Add(tinyLinkEntity);
                return hash;
            }

            return tinyLink.Hash;

        }

        public string VisitLink(string hash)
        {
            var tinyLink = _tinyLinkRepository.Get(hash);
            if (tinyLink == null)
            {
                return string.Empty;
            }
            _tinyLinkRepository.AddVisit(hash);
            return tinyLink.Link;
        }

    }
}
