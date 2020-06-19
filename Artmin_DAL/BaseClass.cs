using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{ 
    public abstract class BaseClass : IDataErrorInfo
    {
        public abstract string this[string columnName] { get; }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(Error);
        }
        public string Error
        {
            get
            {
                string errors = "";

                foreach (var item in GetType().GetProperties())
                {
                    string error = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        errors += error + Environment.NewLine;
                    }
                }

                return errors;
            }
        }
    }
}
