using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingList.Domain
{
    public class ListTypeModel : SystemDictionaryDomain
    {
        public List<ToDoListDomain> ToDoList { get; set; }
    }
}