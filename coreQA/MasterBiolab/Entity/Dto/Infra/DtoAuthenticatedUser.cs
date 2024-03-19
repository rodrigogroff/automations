namespace Master.Entity.Dto.Infra
{
    public class DtoAuthenticatedUser
    {
        public long id { get; set; }
        public long fkCompany { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public bool admin { get; set; }
        public bool manager { get; set; }
    }
}
