using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFindTutor_Client.Models
{
    public class ProvinceModel
    {
        public int PROVINCE_ID { get; set; }
        public string PROVINCE_CODE { get; set; }
        public string PROVINCE_NAME { get; set; }
        public string PROVINCE_NAME_ENG { get; set; }
        public Nullable<int> GEO_ID { get; set; }
    }
}