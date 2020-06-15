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
    public class StandorteData : IStandorteData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public StandorteData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<StandorteModel>> GetStandorte()
        {
            return _dataAccess.LoadData<StandorteModel, dynamic>("dbo.spStandorte_GetAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

    }
}
