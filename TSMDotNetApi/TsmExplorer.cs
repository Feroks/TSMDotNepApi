using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TSMDotNetApi.Enums;
using TSMDotNetApi.Exceptions;
using TSMDotNetApi.Extensions;
using TSMDotNetApi.Models;

namespace TSMDotNetApi
{
    /// <inheritdoc cref="ITsmExplorer" />
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
        /// <param name="apiKey">API key from TSM homepage.</param>
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

        /// <inheritdoc />
        public TsmItemGlobalData GetItemGlobalData(int itemId)
        {
            return GetItemGlobalDataAsync(itemId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<TsmItemGlobalData> GetItemGlobalDataAsync(int itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{itemId}";
            return GetDataFromTsm<TsmItemGlobalData>(uri, cancellationToken);
        }

        /// <inheritdoc />
        public IEnumerable<TsmItemRegionData> GetRegionalData(TsmRegion region)
        {
            return GetRegionalDataAsync(region).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TsmItemRegionData>> GetRegionalDataAsync(TsmRegion region, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"region/{region}";
            return GetDataFromTsm<IEnumerable<TsmItemRegionData>>(uri, cancellationToken);
        }

        /// <inheritdoc />
        public IEnumerable<TsmItemRealmData> GetRealmData(TsmRegion region, string realm)
        {
            return GetRealmDataAsync(region, realm).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<IEnumerable<TsmItemRealmData>> GetRealmDataAsync(TsmRegion region, string realm, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{region}/{realm.NormalizeServerName()}";
            return GetDataFromTsm<IEnumerable<TsmItemRealmData>>(uri, cancellationToken);
        }

        /// <inheritdoc />
        public TsmItemRealmData GetItemRealmData(TsmRegion region, string realm, int itemId)
        {
            return GetItemRealmDataAsync(region, realm, itemId).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public Task<TsmItemRealmData> GetItemRealmDataAsync(TsmRegion region, string realm, int itemId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = $"{region}/{realm.NormalizeServerName()}/{itemId}";
            return GetDataFromTsm<TsmItemRealmData>(uri, cancellationToken);
        }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private async Task<T> GetDataFromTsm<T>(string uriPart, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = CreateUri(uriPart);

            using(var request = new HttpRequestMessage(HttpMethod.Get, uri))
            using (var response = await _httpClient.SendAsync(request, cancellationToken))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        return stream.DeserializeJson<T>();
                    }
                }

                var content = await response.Content.ReadAsStringAsync();
                throw new TsmFailedException("Failed to get data from TSM.", response.StatusCode, content, uri);
            }
        }

        private Uri CreateUri(string uri)
        {
            return new Uri($"{BaseUrl}{uri}?format=json&apiKey={_apiKey}");
        }
    }
}
