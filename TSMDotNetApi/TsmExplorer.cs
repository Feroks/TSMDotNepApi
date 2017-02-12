using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Exceptions;
using TSMDotNetApi.Extensions;
using TSMDotNetApi.Models;

namespace TSMDotNetApi
{
    /// <summary>
    /// A client to use the TradeSkillMaster API
    /// </summary>
    public class TsmExplorer : ITsmExplorer, IDisposable
    {
        private const string BaseUrl = "http://api.tradeskillmaster.com/v1/item/";
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        /// <summary>
        /// Create a new <see cref="TsmExplorer"/> instance.
        /// </summary>
        /// <param name="apiKey">Api key from TSM homepage.</param>
        /// <param name="httpClient">Custom <see cref="HttpClient"/> instance.</param>
        public TsmExplorer(string apiKey, HttpClient httpClient = null)
        {
            _apiKey = apiKey;

            if (httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            }
            else
            {
                _httpClient = httpClient;
            }
        }

        /// <summary>
        /// Get information about an item, including auction and sale stats for both US and EU regions.
        /// <c>This endpoint may be called a maximum of 500 times per day.</c>
        /// </summary>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        public TsmItemGlobalData GetItemGlobalData(int itemId)
        {
            return GetItemGlobalDataAsync(itemId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get information about an item, including auction and sale stats for both US and EU regions.
        /// <c>This endpoint may be called a maximum of 500 times per day.</c>
        /// </summary>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<TsmItemGlobalData> GetItemGlobalDataAsync(int itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{itemId}";
            return await GetDataFromTsm<TsmItemGlobalData>(uri, cancellationToken);
        }

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified region.
        /// This endpoint may be called a maximum of 5 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <returns></returns>
        public IEnumerable<TsmItemRegionData> GetRegionalData(TsmRegion region)
        {
            return GetRegionalDataAsync(region).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified region.
        /// This endpoint may be called a maximum of 5 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TsmItemRegionData>> GetRegionalDataAsync(TsmRegion region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"region/{region}";
            return await GetDataFromTsm<IEnumerable<TsmItemRegionData>>(uri, cancellationToken);
        }

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified realm (and its region).
        /// This endpoint may be called a maximum of 10 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <returns></returns>
        public IEnumerable<TsmItemRealmData> GetRealmData(TsmRegion region, string realm)
        {
            return GetRealmDataAsync(region, realm).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a bulk dump of auction and sale stats for every item for the specified realm (and its region).
        /// This endpoint may be called a maximum of 10 times per day.
        /// </summary>
        /// <param name="region">Region, US or EU</param>
        /// <param name="realm">Realm name</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<IEnumerable<TsmItemRealmData>> GetRealmDataAsync(TsmRegion region, string realm, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{region}/{realm.NormalizeServerName()}";
            return await GetDataFromTsm<IEnumerable<TsmItemRealmData>>(uri, cancellationToken);
        }

        /// <summary>
        /// Gets information about an item an on a specific realm, including auction and sale stats for the realm and its region.
        /// This endpoint may be called a maximum of 500 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <returns></returns>
        public TsmItemRealmData GetItemRealmData(TsmRegion region, string realm, int itemId)
        {
            return GetItemRealmDataAsync(region, realm, itemId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets information about an item an on a specific realm, including auction and sale stats for the realm and its region.
        /// This endpoint may be called a maximum of 500 times per day.
        /// </summary>
        /// <param name="region"><see cref="TsmRegion"/>: EU or US</param>
        /// <param name="realm">Realm name</param>
        /// <param name="itemId">Id of an item. Wowhead is a good place to fin one.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<TsmItemRealmData> GetItemRealmDataAsync(TsmRegion region, string realm, int itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{region}/{realm.NormalizeServerName()}/{itemId}";
            return await GetDataFromTsm<TsmItemRealmData>(uri, cancellationToken);
        }

        private async Task<T> GetDataFromTsm<T>(string uriPart, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = CreateUri(uriPart);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new TsmFailedException("Failed to get data from TSM.", response.StatusCode, content, uri);
            }

            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        /// <summary>
        /// Dispose of <see cref="HttpClient"/> inside
        /// </summary>
        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private Uri CreateUri(string uri)
        {
            return new Uri($"{BaseUrl}{uri}?format=json&apiKey={_apiKey}");
        }
    }
}
