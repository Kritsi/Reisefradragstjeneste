using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reisefradragtjeneste.Models;
using Reisefradragtjeneste.Services;

namespace Reisefradragtjeneste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FradragController : ControllerBase
    {
        readonly IReisefradrag _reisefradrag;

        public FradragController(IReisefradrag reisefradrag)
        {
            _reisefradrag = reisefradrag;
        }

        readonly List<ReiseInfo> reiseInfos = new List<ReiseInfo>()
        {
            new ReiseInfo
            {
                Id = 1,
                Arbeidsreise = new Reise[] {
                    new Reise {
                        Km = 91,
                        Antall = 180
                    },
                    new Reise
                    {
                        Km = 378,
                        Antall = 4
                    }
                },
                Besoksreise = new Reise[]
                {
                    new Reise
                    {
                        Km = 580,
                        Antall = 4
                    }
                },
                UtgifterBomFergeEtc = 4850
            }
        };

        [HttpGet]
        public List<ReiseInfo> Get()
        {
            return reiseInfos;
        }

        [HttpGet("{id}")]
        public ReiseInfo Get(int id)
        {
            return reiseInfos.FirstOrDefault(r => r.Id == id);
        }

        [HttpPost]
        public List<ReiseInfo> Post(ReiseInfo reiseInfo)
        {
            reiseInfos.Add(reiseInfo);
            return reiseInfos;
        }

        [HttpPost("beregn")]
        public ReisefradagBelop PostBeregn(ReiseInfo reiseInfo)
        {
            return _reisefradrag.BeregnReisefradrag(reiseInfo);
        }

        [HttpDelete]
        public List<ReiseInfo> Delete(int id)
        {
            var reiseInfo = reiseInfos.FirstOrDefault(r => r.Id == id);
            reiseInfos.Remove(reiseInfo);
            return reiseInfos;
        }

        [HttpPut]
        public List<ReiseInfo> Put(ReiseInfo reiseInfo)
        {
            var reiseInfoOrginal = reiseInfos.FirstOrDefault(r => r.Id == reiseInfo.Id);
            reiseInfos.Remove(reiseInfoOrginal);
            reiseInfos.Add(reiseInfo);
            return reiseInfos;
        }
    }
}
