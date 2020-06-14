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

    }
}

