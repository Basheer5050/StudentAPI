using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studbApi.Models
{
    public class StudentsModel
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}