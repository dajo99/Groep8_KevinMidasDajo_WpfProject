using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public partial class EventType
    {
        private static readonly Dictionary<string, string> EventColors = new Dictionary<string, string>
        {
            { "Fuif",       "Green" },
            { "Trouwfeest", "Yellow" },
            { "VAT",        "Red" },
            { "DJ SET",     "Blue" }
        };
        public string ColorName
        {
            get
            {
                return EventColors.TryGetValue(Name, out string colorName) ? colorName : "Grey";
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
