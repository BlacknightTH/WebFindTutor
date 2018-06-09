using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFindTutor_Client.Models
{
    public class AmphurModel
    {
        public int AMPHUR_ID { get; set; }
        public string AMPHUR_CODE { get; set; }
        public string AMPHUR_NAME { get; set; }
        public string AMPHUR_NAME_ENG { get; set; }
        public Nullable<int> GEO_ID { get; set; }
        public Nullable<int> PROVINCE_ID { get; set; }
    }
}