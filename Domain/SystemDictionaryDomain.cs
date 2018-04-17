using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingList.Domain
{
    public class SystemDictionaryDomain
    {
        public int Id { get; set; }
        public string ItemValue { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}