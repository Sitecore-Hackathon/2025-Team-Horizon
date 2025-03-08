using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScExtensions.ContentMigration.Services
{
    public class XmCloudContentService
    {
        private readonly ILogger<XmCloudContentService> _logger;
        private readonly HttpClient _httpClient;

        public XmCloudContentService(ILogger<XmCloudContentService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<List<ContentItem>> GetItemsAsync(
            string environmentUrl, 
            string accessToken, 
            string rootItemPath, 
            bool includeChildren)
        {
            try
            {
                // Set up authentication
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Build the query to get items
                var endpoint = $"{environmentUrl}/sitecore/api/ssc/item/Path={rootItemPath}";
                if (includeChildren)
                {
                    endpoint += "?database=master&fields=*&language=en&sc_apikey={apiKey}&includeStandardTemplateFields=true&deep=true";
                }
                else
                {
                    endpoint += "?database=master&fields=*&language=en&sc_apikey={apiKey}&includeStandardTemplateFields=true";
                }

                // Execute the request
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                // Process the response
                var content = await response.Content.ReadAsStringAsync();
                var items = JsonSerializer.Deserialize<ItemResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var result = new List<ContentItem>();
                if (items?.Result != null)
                {
                    // Process the root item
                    var rootItem = new ContentItem
                    {
                        Id = items.Result.ItemId,
                        Path = rootItemPath,
                        Fields = items.Result.Fields
                    };
                    result.Add(rootItem);

                    // Process children if any
                    if (includeChildren && items.Result.Children != null)
                    {
                        ProcessChildren(items.Result.Children, result, rootItemPath);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting items from {environmentUrl}{rootItemPath}");
                throw;
            }
        }

        private void ProcessChildren(List<ItemResult> children, List<ContentItem> result, string parentPath)
        {
            foreach (var child in children)
            {
                var childPath = $"{parentPath}/{child.Name}";
                var item = new ContentItem
                {
                    Id = child.ItemId,
                    Path = childPath,
                    Fields = child.Fields
                };
                result.Add(item);

                if (child.Children != null && child.Children.Count > 0)
                {
                    ProcessChildren(child.Children, result, childPath);
                }
            }
        }

        public async Task ImportItemsAsync(
            string environmentUrl,
            string accessToken,
            List<ContentItem> items)
        {
            try
            {
                // Set up authentication
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                foreach (var item in items)
                {
                    // Check if item exists
                    var checkEndpoint = $"{environmentUrl}/sitecore/api/ssc/item{item.Path}?database=master&sc_apikey={accessToken}";
                    var checkResponse = await _httpClient.GetAsync(checkEndpoint);
                    
                    if (checkResponse.IsSuccessStatusCode)
                    {
                        // Update existing item
                        await UpdateItemAsync(environmentUrl, accessToken, item);
                    }
                    else
                    {
                        // Create new item
                        await CreateItemAsync(environmentUrl, accessToken, item);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error importing items to {environmentUrl}");
                throw;
            }
        }

        private async Task UpdateItemAsync(string environmentUrl, string accessToken, ContentItem item)
        {
            var endpoint = $"{environmentUrl}/sitecore/api/ssc/item{item.Path}";
            var payload = new
            {
                fields = item.Fields
            };

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PatchAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            
            _logger.LogInformation($"Updated item: {item.Path}");
        }

        private async Task CreateItemAsync(string environmentUrl, string accessToken, ContentItem item)
        {
            // Extract parent path and name
            var lastSlashIndex = item.Path.LastIndexOf('/');
            var parentPath = item.Path.Substring(0, lastSlashIndex);
            var name = item.Path.Substring(lastSlashIndex + 1);

            // Get template ID (in a real implementation, this would come from the exported data)
            var templateId = "{0EE1F455-C80C-4121-8D98-C2819DE1F9A2}"; // Example template ID

            var endpoint = $"{environmentUrl}/sitecore/api/ssc/item{parentPath}/children";
            var payload = new
            {
                itemName = name,
                templateId = templateId,
                fields = item.Fields
            };

            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            
            _logger.LogInformation($"Created item: {item.Path}");
        }
    }

    public class ContentItem
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public Dictionary<string, object> Fields { get; set; }
    }

    public class ItemResponse
    {
        public ItemResult Result { get; set; }
    }

    public class ItemResult
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> Fields { get; set; }
        public List<ItemResult> Children { get; set; }
    }
}
