using System;

namespace portal_2.API.Dtos
{
    public class BrokerForListDto
    {
        public int Id { get; set; }
        public int BrokerTempId { get; set; }
        public int EntityId { get; set; }
        public string Username { get; set; }
        public string Fstname { get; set; }
        public string Lstname { get; set; }
        public string Branch { get; set; }
        public string Rbm { get; set; }
        public string Affiliate { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }  
        public int Phone { get; set; }
        public int PhoneExt { get; set; }
        public bool IsContracted { get; set; }
        public DateTime ModifyWhen { get; set; }
        public DateTime LastActive { get; set; }
    }
}