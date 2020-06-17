using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public static class ValidateInputs
    {
        public static Task<bool> MailIsValidAsync(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                var host = mailAddress.Host;
                return CheckDnsEntriesAsync(host);
            }
            catch (FormatException)
            {
                return Task.FromResult(false);
            }
        }

        private static async Task<bool> CheckDnsEntriesAsync(string domain)
        {
            try
            {
                var lookup = new LookupClient();
                lookup.Timeout = TimeSpan.FromSeconds(5);
                var result = await lookup.QueryAsync(domain, QueryType.ANY).ConfigureAwait(false);

                var records = result.Answers.Where(record => record.RecordType == DnsClient.Protocol.ResourceRecordType.A ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.AAAA ||
                                                             record.RecordType == DnsClient.Protocol.ResourceRecordType.MX);
                return records.Any();
            }
            catch (DnsResponseException)
            {
                return false;
            }
        }

        public static bool CheckIban(string iban)
        {
            if (String.IsNullOrEmpty(iban))
            {
                return false;
            }

            //Spaties verwijderen + iban in uppercase zetten
            iban = iban.Replace(" ", String.Empty).ToUpper();

            //Volledige iban controleren of deze volledig overeenkomt met gemaakte reguliere expressie 
            if (Regex.IsMatch(iban, @"^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,27}$"))

            {
                //Eerste 4 characters van iban verschuiven naar het einde
                iban = iban.Substring(4) + iban.Substring(0, 4);
                int checksum = 0;
                foreach (char c in iban)
                {
                    if (Char.IsLetter(c))
                    {
                        checksum = ((100 * checksum) + (c - 55)) % 97;
                    }
                    else
                    {
                        checksum = ((10 * checksum) + (c - 48)) % 97;
                    }
                }

                return checksum == 1;
            }
            else
            {
                return false;
            }
        }
    }
}

