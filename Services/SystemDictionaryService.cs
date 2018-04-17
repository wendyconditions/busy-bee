using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestingList.Domain;
using TestingList.Extensions;
using TestingList.Interfaces;

namespace TestingList.Services
{
    public class SystemDictionaryService : ISystemDictionaryService
    {
        private IDataProvider _dataProvider;

        public SystemDictionaryService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public List<ListTypeModel> GetAll()
        {
            List<ListTypeModel> list = null;

            _dataProvider.ExecuteCmd("dbo.SystemDictionary_SelectAll"
                , inputParamMapper: null
                , singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    ListTypeModel singleItem = new ListTypeModel();
                    
                    int startingIndex = 0; //startingOrdinal

                    singleItem.Id = reader.GetSafeInt32(startingIndex++);
                    singleItem.ItemValue = reader.GetSafeString(startingIndex++);
                    singleItem.CreatedUserID = reader.GetSafeInt32(startingIndex++);
                    singleItem.CreatedTime = reader.GetSafeDateTime(startingIndex++);
                    //not going to create list if there's no data / lazy load / if statement
                    if (list == null)
                    {
                        list = new List<ListTypeModel>();
                    }

                    list.Add(singleItem);
                });

            return list;
        }

        public int Insert(SystemDictionaryDomain model)
        {
            int Id = 0;

            _dataProvider.ExecuteNonQuery("dbo.SystemDictionary_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ItemValue", model.ItemValue);

                   SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   idParameter.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(idParameter);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   Int32.TryParse(param["@Id"].Value.ToString(), out Id);
               });

            return Id;
        }
    }
}