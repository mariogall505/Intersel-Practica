using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Intersel_Practica.Dto
{
    public class CallDetailDto
    {
        public Nullable<int> CallDetailId { get; set; }
        public Nullable<double> MobileLine { get; set; }
        public string CalledPartyNumber { get; set; }
        public string CalledPartyDescription { get; set; }
        public string DateTime { get; set; }
        public string Hour { get; set; }
        public Nullable<short> Duration { get; set; }
        public Nullable<double> TotalCost { get; set; }
        public int Id { get; set; }
        //Details
        public string DescError { get; set; }
        public int Error { get; set; }
        public string Description { get; set; }
    }
}