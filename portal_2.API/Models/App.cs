using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace portal_2.API.Models
{
    public class App
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string PolNo { get; set; }
        public string Apftnm { get; set; }
        public string Apltnm { get; set; }
        public DateTime? Submittd { get; set; }
        public DateTime? Placed { get; set; }
        public string Status { get; set; }
        public decimal premium { get; set; }
        public int BrokerId { get; set; }
   
    }
}