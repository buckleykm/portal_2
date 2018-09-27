using System;
using System.Collections.Generic;

namespace portal_2.API.Models
{
    public class Broker
    {
        public int BrokerId { get; set; }
        public int EntityId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Fstname { get; set; }
        public string Lstname { get; set; }
        public int BranchId { get; set; }
        public int RbmId { get; set; }
        public int AffiliateId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }   
        public int StateId { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }  
        public string AltEmail { get; set; }
        public int Phone { get; set; }
        public int PhoneExt { get; set; }
        public string AltPhone { get; set; }
        public bool IsContracted { get; set; }
        public int NpnId { get; set; }
        public DateTime ModifyWhen { get; set; }
        public DateTime LastActive { get; set; }
        public ICollection<App> Apps { get; set; }
    }
}