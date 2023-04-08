namespace Redirector;

public class RedirectionService
{
    public void HandleRedirect(Redirect redirect)
    {
        try
        {
            Console.WriteLine($"Redirecting from {redirect.RedirectUrl} to {redirect.TargetUrl}...");   
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine($"Error encountered while attempting redirect - {e}");

            // Log error
        }
    }
}