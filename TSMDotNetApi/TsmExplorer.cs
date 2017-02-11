using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Models;

namespace TSMDotNetApi
{
    public class TsmExplorer : ITsmExplorer, IDisposable
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://api.tradeskillmaster.com/v1/item/";

        public TsmExplorer(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public TsmItemGlobalData GetItemGlobalData(int itemId)
        {
            return GetItemGlobalDataAsync(itemId).GetAwaiter().GetResult();
        }

        public async Task<TsmItemGlobalData> GetItemGlobalDataAsync(int itemId)
        {
            var uri = $"{itemId}";
            return await GetDataFromTsm<TsmItemGlobalData>(uri);
        }

        public IEnumerable<TsmItemRegionData> GetRegionalData(TsmRegion region)
        {
            return GetRegionalDataAsync(region).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<TsmItemRegionData>> GetRegionalDataAsync(TsmRegion region)
        {
            var uri = $"region/{region}";
            return await GetDataFromTsm<IEnumerable<TsmItemRegionData>>(uri);
        }

        public IEnumerable<TsmItemRealmData> GetRealmData(TsmRegion region, string realm)
        {
            return GetRealmDataAsync(region, realm).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<TsmItemRealmData>> GetRealmDataAsync(TsmRegion region, string realm)
        {
            var uri = $"{region}/{realm}";
            return await GetDataFromTsm<IEnumerable<TsmItemRealmData>>(uri);
        }

        public TsmItemRealmData GetItemRealmData(TsmRegion region, string realm, int itemId)
        {
            return GetItemRealmDataAsync(region, realm, itemId).GetAwaiter().GetResult();
        }

        public async Task<TsmItemRealmData> GetItemRealmDataAsync(TsmRegion region, string realm, int itemId)
        {
            var uri = $"{region}/{realm}/{itemId}";
            return await GetDataFromTsm<TsmItemRealmData>(uri);
        }

        private async Task<T> GetDataFromTsm<T>(string uriPart)
        {
            var uri = CreateUri(uriPart);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private string CreateUri(string uri)
        {
            return $"{BaseUrl}{uri}?format=json&apiKey={_apiKey}";
        }
    }
}
