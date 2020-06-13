using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IToiletsBerlinData
    {
        Task<List<ToiletsBerlinData>> GetAllToiletsBerlin();
    }
}