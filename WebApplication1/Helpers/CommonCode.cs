namespace WebApplication1.Helpers
{
    public class CommonCode
    {
        internal static string NewGUID()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
    }
}