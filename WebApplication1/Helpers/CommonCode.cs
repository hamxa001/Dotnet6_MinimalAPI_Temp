namespace WebApplication1.Helpers
{
    public class CommonCode
    {
        internal static string NewGUID()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }

        internal static string? ConvertByteToString(byte[] source)
        {
            return source != null ? System.Text.Encoding.UTF8.GetString(source) : null;
        }
    }
}