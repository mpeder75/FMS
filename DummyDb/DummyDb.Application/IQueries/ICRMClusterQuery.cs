using DummyDb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDb.Application.IQueries
{
    public interface ICRMClusterQuery
    {
        IEnumerable<RoomDto> GetCluster();
    }
}
