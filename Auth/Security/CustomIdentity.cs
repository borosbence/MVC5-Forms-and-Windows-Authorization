using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Auth.Security
{
    [Serializable]
    public class CustomIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserRoleName { get; set; }

        public string UserName { get; set; }

        public string Name
        {
            //get { return Identity.Name; }
            get { return UserName; }
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated {
            get { return Identity.IsAuthenticated; }
        }

        public CustomIdentity(IIdentity identity)
        {
            Identity = identity;

            var customMembershipUser = (CustomMembershipUser)Membership.GetUser(identity.Name);
            if (customMembershipUser != null)
            {
                UserName = customMembershipUser.UserName;
                FirstName = customMembershipUser.FirstName;
                LastName = customMembershipUser.LastName;
                Email = customMembershipUser.Email;
                UserRoleName = customMembershipUser.UserRoleName;
            }
        }
    }
}