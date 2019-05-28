using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Auth.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserRoleName { get; set; }

        public override string UserName { get; }

        public CustomMembershipUser(User user)
            : base("CustomMembershipProvider", user.Username, user.Id, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserName = user.Username;
            FirstName = user.Firstname;
            LastName = user.Lastname;
            UserRoleName = user.Role;
        }
    }
}