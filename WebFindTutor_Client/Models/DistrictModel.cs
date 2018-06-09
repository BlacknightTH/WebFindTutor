using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFindTutor_Client.Models
{
    public class DistrictModel
    {
        public int DISTRICT_ID { get; set; }
        public string DISTRICT_CODE { get; set; }
        public string DISTRICT_NAME { get; set; }
        public string DISTRICT_NAME_ENG { get; set; }
        public Nullable<int> AMPHUR_ID { get; set; }
        public Nullable<int> PROVINCE_ID { get; set; }
        public Nullable<int> GEO_ID { get; set; }
    }
}