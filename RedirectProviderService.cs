namespace Redirector;

public static class RedirectProviderService
{
    public static string GetRedirectsJson()
    {
        return "[" +
                    "{" +
                    "redirectUrl: /campaignA," +
                    "targetUrl: /campaigns/targetcampaign," +
                    "redirectType: 302," +
                    "useRelative: false" +
                    "}," +
                    "{" +
                    "redirectUrl: /campaignB," +
                    "targetUrl: /campaigns/targetcampaign/channelB," +
                    "redirectType: 302," +
                    "useRelative: false" +
                    "}," +
                    "{" +
                    "redirectUrl: /product-directory," +
                    "targetUrl: /products," +
                    "redirectType: 301," +
                    "useRelative: true" +
                    "}" +
                "]";
    }

    public static List<Redirect> GetRedirectsList()
    {
        var redirects = new List<Redirect>();

        redirects.Add(new Redirect {
            RedirectUrl = "/campaignA",
            TargetUrl = "/campaigns/targetcampaign",
            RedirectType = 302,
            UseRelative = false
        });

        redirects.Add(new Redirect {
            RedirectUrl = "/campaignB",
            TargetUrl = "/campaigns/targetcampaign/channelB",
            RedirectType = 302,
            UseRelative = false
        });

        redirects.Add(new Redirect {
            RedirectUrl = "/product-directory",
            TargetUrl = "/products",
            RedirectType = 301,
            UseRelative = true
        });

        return redirects;
    }
}