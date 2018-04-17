using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingList.Domain;

namespace TestingList.Interfaces
{
    public interface ISystemDictionaryService
    {
        List<ListTypeModel> GetAll();
        int Insert(SystemDictionaryDomain model);
        //void Update(ToDoListDomain model);
        //Dictionary<int, DeleteIdsRequest> SoftDelete(DeleteIdsRequest model);
        //Dictionary<int, DeleteIdsRequest> HardDelete(DeleteIdsRequest model);
    }
}