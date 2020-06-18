using DnsClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public static class ValidateMail
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
                LookupClientOptions options = new LookupClientOptions { Timeout = TimeSpan.FromSeconds(5) };
                var lookup = new LookupClient(options);

                //Performs a DNS lookup for the given question.
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
    }
}

