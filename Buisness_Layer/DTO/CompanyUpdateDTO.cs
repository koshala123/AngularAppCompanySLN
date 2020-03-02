using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Buisness_Layer.DTO
{
    public class CompanyUpdateDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string SystemName { get; set; }
        public string IssueType { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string RequestDate { get; set; }
        public int RequestNumber { get; set; }
        public int RequestName { get; set; }
        public int Status { get; set; } 
        public string Comment { get; set; }
        public string Error { get; set; }
        public bool Active { get; set; }

        

        
    }
    
}
