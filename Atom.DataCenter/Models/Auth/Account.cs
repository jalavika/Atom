using System;
using System.Collections.Generic;

namespace Atom.DataCenter.Models.Auth
{
    [Serializable]
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }

        public byte CommunityId { get; set; }
        public double AccountCreation { get; set; }
        public double SubscriptionEndDate { get; set; }

        public short[] ServersIds { get; set; }
        public long[] CharactersIds { get; set; }

        public List<string> LastIps { get; set; }
    }
}