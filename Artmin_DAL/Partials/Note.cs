using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    //AUTHOR Dajo Vandoninck
    public partial class Note : BaseClass
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
