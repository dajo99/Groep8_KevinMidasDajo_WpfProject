using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbanNet;

namespace Artmin_DAL
{
    public partial class Artist : BaseClass
    {
        public Artist(Artist a)
        {
            this.Name = a.Name;
            this.Email = a.Email;
            this.Phone = a.Phone;
            this.EventID = a.EventID;
            this.BankAccountNo = a.BankAccountNo;
            this.ArtistID = a.ArtistID;
        }

        public Artist()
        {

        }

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
                    return "Telefoonnumer is niet correct ingevuld!";
                }
                /*if (columnName == "Email" && !new EmailAddressAttribute().IsValid(Email))
                {
                    return "Email is niet correct!";
                }*/
                if (columnName == "Email")
                {
                    var task = ValidateMail.MailIsValidAsync(Email);
                    task.Wait();

                    if (!task.Result)
                    {
                        return "Email is niet correct ingevuld!";
                    }          
                }
                if (columnName == "BankAccountNo")
                {
                    IIbanValidator validator = new IbanValidator();
                    IbanNet.ValidationResult validationResult = validator.Validate(BankAccountNo);
                    if (!validationResult.IsValid)
                    {
                        return "De opgegeven IBAN-nummer bestaat niet!";
                    }           
                }
                return "";
            }
        }
        public override string ToString()
        {           
            return this.Name.ToUpper() + Environment.NewLine +
                this.Email + Environment.NewLine +
                this.Phone.Insert(3," ").Insert(6," ");
        }

        public void copyFrom(Artist a)
        {
            this.Name = a.Name;
            this.Phone = a.Phone;
            this.Email = a.Email;
            this.ArtistID = a.ArtistID;
            this.EventID = a.EventID;
            this.BankAccountNo = a.BankAccountNo;
        }
    }
}
