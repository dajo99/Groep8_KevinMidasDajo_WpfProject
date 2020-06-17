using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public partial class Artist : BaseClass
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Gelieve de artiestennaam in te vullen!";
                }
                if (columnName == "Phone" && !new PhoneAttribute().IsValid(Phone))
                {
                    return "Gelieve het telefoonnummer in te vullen!";
                }
                /*if (columnName == "Email" && !new EmailAddressAttribute().IsValid(Email))
                {
                    return "Email is niet correct!";
                }*/
                if (columnName == "Email")
                {
                    var task = ValidateInputs.MailIsValidAsync(Email);
                    task.Wait();

                    if (task.Result == false)
                    {
                        return "Email is niet correct!";
                    }          
                }
                if (columnName == "BankAccountNo" && ValidateInputs.CheckIban(BankAccountNo))
                {
                    return "De opgegeven IBAN-nummer bestaat niet!";
                }
                return "";
            }
        }
        public override string ToString()
        {
            return this.Name.ToUpper() + Environment.NewLine +
                this.Email + Environment.NewLine +
                this.Phone;
        }
    }
}
