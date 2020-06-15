using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class ToiletsBerlinData : IToiletsBerlinData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public ToiletsBerlinData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<ToiletsBerlinModel>> GetAllToiletsBerlin()
        {
            return _dataAccess.LoadData<ToiletsBerlinModel, dynamic>("dbo.spBerlinToiletLocation_getAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }        
        
        public Task<List<ToiletsBerlinModel>> GetFreeToilets()
        {
            return _dataAccess.LoadData<ToiletsBerlinModel, dynamic>("spToilet_GetFreeToilets",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }        
        public Task<List<ToiletsBerlinModel>> GetToiletsWithChangingTable()
        {
            return _dataAccess.LoadData<ToiletsBerlinModel, dynamic>("spToilet_GetToiletsWithChangingTable",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }        
        public Task<List<ToiletsBerlinModel>> GetToiletsHandicappedAccessible()
        {
            return _dataAccess.LoadData<ToiletsBerlinModel, dynamic>("spToilet_GetIsHandicappedAccessible",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }


        public Task<int> DeleteToilet(int toiletId)
        {
            return _dataAccess.SaveData("dbo.spToilet_Delete",
                                        new
                                        {
                                            Id = toiletId
                                        },
                                        _connectionString.SqlConnectionName);
        }

    }
}

