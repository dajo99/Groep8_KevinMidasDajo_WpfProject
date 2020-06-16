using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public partial class Artist
    {
        public override string ToString()
        {
            return this.Name.ToUpper() + Environment.NewLine +
                this.Email + Environment.NewLine +
                this.Phone;
        }
    }
}
