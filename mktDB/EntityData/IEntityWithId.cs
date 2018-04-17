using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mktDB.EntityData
{
    public interface IEntityWithId
    {
        int Id { get; set; }
    }
}
