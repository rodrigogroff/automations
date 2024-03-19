using System;

namespace Master.Entity.Dto.Domain.Auth
{
    public class DtoRegisterInformation
    {
        public Guid id { get; set; }

        public bool? IsFinished { get; set; }

        public bool? IsWorkRequired { get; set; }
    }
}
