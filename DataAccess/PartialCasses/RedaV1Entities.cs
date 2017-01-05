using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class RedaV1Entities //: DbContext
    {
        public RedaV1Entities(string connString)
            : base(connString)
        {
        }
    }
}
