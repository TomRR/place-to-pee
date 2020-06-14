using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IToiletsBerlinData
    {
        Task<List<ToiletsBerlinModel>> GetAllToiletsBerlin();
    }
}