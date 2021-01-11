using System.DirectoryServices.AccountManagement;
using System.Net.NetworkInformation;

namespace GetADPath
{
    public class GetAD
    {
        //below values need to pass to the program
        //username-windows username  
        //DOMAIN1-domain1 -LDAP://domain1.test.com/DC=domain1,DC=test,DC=com"
        //DOAMIN2-domain2 -LDAP://domain2.test.com:456/DC=domain2,DC=com
        public string DomainADPath(string username, string DOMAIN1, string DOAMIN2)
        {
            //get current domain
            string[] addomain = IPGlobalProperties.GetIPGlobalProperties().DomainName.ToString().Split('.');
            PrincipalContext ctx; 
            string ADPATH = string.Empty;

            //cheks domain name matched with  domain1
            if (addomain[0].ToUpper() == "domain1")
            {
                ctx = new PrincipalContext(ContextType.Domain, addomain[0].ToUpper());  
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);

                if (user != null)
                {
                    //username matched and authenticated in DOMAIN1
                    return ADPATH = DOMAIN1;
                }
                else
                {
                    //if not matched checked the username in domain2
                    ctx = new PrincipalContext(ContextType.Domain, "domain2");
                    user = UserPrincipal.FindByIdentity(ctx, username);

                    if (user != null)
                    {
                        //username matched and authenticated in DOMAIN2
                        return ADPATH = DOAMIN2;
                    }
                    else
                    {
                        return ADPATH;
                    }
                }
            }
            //cheks domain name matched with  domain2
            else if (addomain[0].ToUpper() == "domain2")
            {
                ctx = new PrincipalContext(ContextType.Domain, addomain[0].ToUpper());
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
                
                if (user != null)
                {
                    //username matched and authenticated in DOMAIN2
                    return ADPATH = DOAMIN2;
                }
                else
                {
                    //if not matched checked the username in domain1
                    ctx = new PrincipalContext(ContextType.Domain, "domain1");
                    user = UserPrincipal.FindByIdentity(ctx, username);

                    if (user != null)
                    {
                        //username matched and authenticated in DOMAIN1
                        return ADPATH = DOMAIN1;
                    }
                    else
                    {
                        return ADPATH;
                    }
                }
            }
            else
            {
                return ADPATH;
            }


        }
    }
}
