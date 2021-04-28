using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        
        public string MemberName { get; set; }
        public string MemberDOB { get; set; }
        public string MemberJobTitle { get; set; }
  
    }
}
