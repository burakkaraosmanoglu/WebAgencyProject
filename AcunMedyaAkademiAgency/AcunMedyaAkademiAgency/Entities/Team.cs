using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
    public class Team
    {
        public int TeamID { get; set; }
        public string NameSurname { get; set; }
        
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
        

    }
}