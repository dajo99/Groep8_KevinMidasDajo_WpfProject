using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public partial class Note : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Title" && string.IsNullOrWhiteSpace(Title))
                {
                    return "Title is een verplicht veld!";
                }
                if (columnName == "Description" && string.IsNullOrWhiteSpace(Description))
                {
                    return "Description is een verplicht veld!";
                }
                return "";
            }
        }

        
    }
}
