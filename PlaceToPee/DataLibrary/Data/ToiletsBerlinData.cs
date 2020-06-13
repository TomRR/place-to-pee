using DataLibrary.Db;
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

        public Task<List<ToiletsBerlinData>> GetAllToiletsBerlin()
        {
            return _dataAccess.LoadData<ToiletsBerlinData, dynamic>("dbo.spToiletsBerlin_GetAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

    }
}

