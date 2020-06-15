using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IToiletsBerlinData
    {
        Task<List<ToiletsBerlinModel>> GetAllToiletsBerlin();

        Task<List<ToiletsBerlinModel>> GetFreeToilets();
        Task<int> DeleteToilet(int toiletId);
        Task<List<ToiletsBerlinModel>> GetToiletsWithChangingTable();
        Task<List<ToiletsBerlinModel>> GetToiletsHandicappedAccessible();
    }
}