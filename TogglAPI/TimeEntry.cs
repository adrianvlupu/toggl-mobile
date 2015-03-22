using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public class TimeEntry
    {
        public int id{get;set;}
        public int wid{get;set;}
        public int pid{get;set;}
        public bool billable{get;set;}
        public DateTime start{get;set;}
        public long duration{get;set;}
        public string description{get;set;}
        public DateTime at { get; set; }
    }
}
