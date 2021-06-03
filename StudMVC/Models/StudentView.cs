using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudMVC.Models
{
    public class StudentView
    {
        public int rollno { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string st_state { get; set; }
        public string country { get; set; }
    }
}