using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<ToiletsBerlinModel> GetToiletById(int toiletId)
        {
            var recs = await _dataAccess.LoadData<ToiletsBerlinModel, dynamic>("dbo.spToilet_GetById",
                                                                       new
                                                                       {
                                                                           Id = toiletId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<int> CreateToilet(ToiletsBerlinModel toiletsBerlinModel)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Street", toiletsBerlinModel.Street);
            p.Add("PostalCode", toiletsBerlinModel.PostalCode);
            p.Add("Price", toiletsBerlinModel.Price);
            p.Add("City", toiletsBerlinModel.City);
            p.Add("hasChangingTable", toiletsBerlinModel.HasChangingTable);
            p.Add("isHandicappedAccessible", toiletsBerlinModel.IsHandycappedAccessible);
            p.Add("Latitude", toiletsBerlinModel.Latitude);
            p.Add("Longitude", toiletsBerlinModel.Longitude);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spToilet_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

    }
}

