using System;

namespace portal_2.API.Dtos
{
    public class BrokerForListDto
    {
        public int BrokerId { get; set; }
        public int EntityId { get; set; }
        public string Username { get; set; }
        public string Fstname { get; set; }
        public string Lstname { get; set; }
        public int BranchId { get; set; }
        public int RbmId { get; set; }
        public int AffiliateId { get; set; }
        public int StateId { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }  
        public int Phone { get; set; }
        public int PhoneExt { get; set; }
        public bool IsContracted { get; set; }
        public DateTime ModifyWhen { get; set; }
        public DateTime LastActive { get; set; }
    }
}