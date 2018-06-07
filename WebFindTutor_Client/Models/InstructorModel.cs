using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFindTutor_Client.Models
{
    public class InstructorModel
    {
        public int Instructor_ID { get; set; }
        public string Instructor_FirstName { get; set; }
        public string Instructor_LastName { get; set; }
        public byte[] Instructor_Email { get; set; }
        public string Instructor_TelNumber { get; set; }
        public string Instructor_location { get; set; }
        public string Instructor_Pic { get; set; }
        public string Instructor_University { get; set; }
        public byte[] Teaching_History { get; set; }
        public Nullable<int> Course_ID { get; set; }
        public Nullable<int> Subject_ID { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Confirmation { get; set; }
    }
}