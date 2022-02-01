using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityProgect.DataModel;

namespace UniversityProgect.Interfaces
{
    interface IGroupRepository
    {
        IQueryable<Group> Groups { get; }
    }
}
