using Master.Entity.Dto.Domain.Auth;
using System.Collections.Generic;

namespace Master.Entity
{
    public class LocalNetwork
    {
        public const string Secret = "ciOiJIUzI1NiIsInR5cCI6IeyJ1bmlxdxxxWVfbmFtZSI6IjEiLCJuYmYiOjE1NTc5Mjk4ODcsImV4cCI6MTU1fhdsjhfeuyrejhdfj7333001";
        public string _emailSmtp { get; set; }
        public string _passwordSmtp { get; set; }
        public string _hostSmtp { get; set; }
        public int _smtpPort { get; set; }
        public string database { get; set; }
        public string filesDirectory { get; set; }
        public int maxUsers { get; set; }
        public int hour { get; set; }
        public int min { get; set; }

        public List<DtoRandomUser> userDB { get; set; }
    }
}


