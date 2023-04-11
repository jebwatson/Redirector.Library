using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using NLog;

namespace Redirector;

public class RedirectionService
{
    private TimeSpan cacheDuration;
    private Logger logger;
    public IMemoryCache ResponseCache { get; }

    public RedirectionService()
    {
        // TODO: Make app setting
        cacheDuration = TimeSpan.FromMinutes(15);
        this.ResponseCache = new MemoryCache(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromSeconds(30) });
        this.logger = LogManager.GetCurrentClassLogger();
    }

    public async Task HandleRedirectsAsync(IEnumerable<Redirect> redirects)
    {
        try
        {
            using HttpClient client = new HttpClient();

            foreach (var redirect in redirects)
            {
                // Try the target url
                var response = await client.GetAsync(redirect.TargetUrl);
                var statusCode = ((int)response.StatusCode);

                // Try the redirect url if 300 status code
                if (statusCode >= 300 && statusCode <= 399)
                {
                    response = await client.GetAsync(redirect.RedirectUrl);
                }

                var timeStamp = DateTime.Now;
                ResponseCache.Set(DateTime.Now, response, DateTimeOffset.Now + cacheDuration);

                logger.Info("Successful API call");
            }

            // TODO: Log results
        }
        catch (System.Exception e)
        {
            // Log error
            logger.Error("Error encountered while calling API - " + e);
        }
    }
}