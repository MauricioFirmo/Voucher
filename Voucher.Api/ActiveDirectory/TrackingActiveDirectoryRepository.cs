using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using AuthenticationTypes = System.DirectoryServices.AuthenticationTypes;
using DirectoryEntry = System.DirectoryServices.DirectoryEntry;


namespace Voucher.Api
{
    public class TrackingActiveDirectoryRepository : ITrackingActiveDirectoryRepository
    {
 
        //200.185.163.163
        private const string ACTIVE_DIRECTORY_SERVER_DOMAIN = "192.168.1.2/ DC=VOUCHERSP,DC=com,DC=br";
        private const string DOMINIO = "VOUCHERSP";

        public bool LoginColaborador(string username, string password, string culture)
        {
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + ACTIVE_DIRECTORY_SERVER_DOMAIN,
                                                                   DOMINIO + username,
                                                                   password,
                                                                   AuthenticationTypes.Secure);
                
                DirectorySearcher diretorySearcher = new DirectorySearcher(directoryEntry, string.Format("(sAMAccountName={0})", username));
                SearchResult searchResult = diretorySearcher.FindOne();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}