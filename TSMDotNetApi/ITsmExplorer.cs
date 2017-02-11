using System.Collections.Generic;
using System.Threading.Tasks;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Models;

namespace TSMDotNetApi
{
    public interface ITsmExplorer
    {
        TsmItemGlobalData GetItemGlobalData(int itemId);
        Task<TsmItemGlobalData> GetItemGlobalDataAsync(int itemId);

        IEnumerable<TsmItemRegionData> GetRegionalData(TsmRegion region);
        Task<IEnumerable<TsmItemRegionData>> GetRegionalDataAsync(TsmRegion region);

        IEnumerable<TsmItemRealmData> GetRealmData(TsmRegion region, string realm);
        Task<IEnumerable<TsmItemRealmData>> GetRealmDataAsync(TsmRegion region, string realm);

        TsmItemRealmData GetItemRealmData(TsmRegion region, string realm, int itemId);
        Task<TsmItemRealmData> GetItemRealmDataAsync(TsmRegion region, string realm, int itemId);
    }
}
