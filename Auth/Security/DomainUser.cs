using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Web;

namespace Auth.Security
{
    public static class DomainUser
    {
        static string YOURDOMAIN;
        // put your own Domains here if you have multiple
        private static List<PrincipalContext> ctxLista = new List<PrincipalContext>()
        {
            new PrincipalContext(ContextType.Domain, YOURDOMAIN),
        };

        public static UserPrincipal FindUser(string username)
        {
            foreach (var ctx in ctxLista)
            {
                var user = UserPrincipal.FindByIdentity(ctx, username);
                if (user != null)
                {
                    return user;
                }
            }

            return null;
        }

        public static bool ValidateUser(string username, string password)
        {
            foreach (var ctx in ctxLista)
            {
                //This will force the connection to the server and validate that the credentials are good
                //If the connection is good but the credentals are bad it will return "false", if the connection is bad it will throw a exception of some form.
                if (ctx.ValidateCredentials(null, null))
                {
                    if (ctx.ValidateCredentials(username, password))
                    {
                        return true;
                    }

                }
            }

            return false;
        }
    }
}