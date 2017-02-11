using System.Collections.Generic;
using System.Threading.Tasks;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Models;

namespace TSMDotNetApi
{
    /// <summary>
    /// A client interface to use the TradeSkillMaster API
    /// </summary>
    public interface ITsmExplorer
    {
        /// <summary>
        /// Get information about an item, including auction and sale stats for both US and EU regions.
        /// <c>This endpoint may be called a maximum of 500 times per day.</c>
        /// </summary>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        TsmItemGlobalData GetItemGlobalData(int itemId);

        /// <summary>
        /// Get information about an item, including auction and sale stats for both US and EU regions.
        /// <c>This endpoint may be called a maximum of 500 times per day.</c>
        /// </summary>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        Task<TsmItemGlobalData> GetItemGlobalDataAsync(int itemId);


        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified region.
        /// This endpoint may be called a maximum of 5 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <returns></returns>
        IEnumerable<TsmItemRegionData> GetRegionalData(TsmRegion region);

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified region.
        /// This endpoint may be called a maximum of 5 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <returns></returns>
        Task<IEnumerable<TsmItemRegionData>> GetRegionalDataAsync(TsmRegion region);


        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified realm (and its region).
        /// This endpoint may be called a maximum of 10 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <returns></returns>
        IEnumerable<TsmItemRealmData> GetRealmData(TsmRegion region, string realm);

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified realm (and its region).
        /// This endpoint may be called a maximum of 10 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <returns></returns>
        Task<IEnumerable<TsmItemRealmData>> GetRealmDataAsync(TsmRegion region, string realm);


        /// <summary>
        /// Gets information about an item an on a specific realm, including auction and sale stats for the realm and its region.
        /// This endpoint may be called a maximum of 500 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        TsmItemRealmData GetItemRealmData(TsmRegion region, string realm, int itemId);

        /// <summary>
        /// Gets information about an item an on a specific realm, including auction and sale stats for the realm and its region.
        /// This endpoint may be called a maximum of 500 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        Task<TsmItemRealmData> GetItemRealmDataAsync(TsmRegion region, string realm, int itemId);
    }
}
