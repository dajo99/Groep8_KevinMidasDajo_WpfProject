﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbanNet;

/*----------------------------
 * AUTHOR: Kevin Beliën
 * --------------------------*/

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
                    return "Artist name is required!";
                }
                if (columnName == "Phone" && (Phone.Length < 8 || !new PhoneAttribute().IsValid(Phone)))
                {
                    return "the specified phone number is incorrect!";
                }
                if (columnName == "Email")
                {
                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        return "Email is a required field!";
                    }
                    else
                    {
                        var task = ValidateMail.MailIsValidAsync(Email);
                        task.Wait();
                        if (!task.Result)
                        {
                            return "the specified Email is incorrect!";
                        }
                    }
                }
                if (columnName == "BankAccountNo")
                {
                    IIbanValidator validator = new IbanValidator();
                    IbanNet.ValidationResult validationResult = validator.Validate(BankAccountNo);

                    if (string.IsNullOrWhiteSpace(BankAccountNo))
                    {
                        return "IBAN is a required field!";
                    }
                    else if (!validationResult.IsValid)
                    {
                        return "the specified IBAN is incorrect!";
                    }           
                }
                return "";
            }
        }
        public override string ToString()
        {           
            return 
                this.Email + Environment.NewLine +
                this.Phone.Insert(3," ").Insert(6," ");
        }

        public void CopyFrom(Artist a)
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
