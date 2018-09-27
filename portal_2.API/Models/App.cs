using System;

namespace portal_2.API.Models
{
    public class App
    {
        public int Id { get; set; }
        public string PolNo { get; set; }
        public string Apftnm { get; set; }
        public string Apltnm { get; set; }
        public DateTime Submittd { get; set; }
        public DateTime? Placed { get; set; }
   
    }
}