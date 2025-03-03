using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
    public class ProjectDetail
    {
        public int ProjectDetailID { get; set; }
       
        public string Description { get; set; }
        public string Title { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Projects { get; set; }
        
    }
}