using System;
using System.IO;
using System.Net;

namespace GeckoPet
{
    public class Program
    {
        private static string GetUrl(string[] args)
        {
#if(DEBUG)
            if (args == null)
                return string.Empty;
            var message = args.Length == 2 ? args[1] : "GeckoPet";
            return $"http://localhost:8000/echo.php?message={message}";
#else
            if (args == null)
                return string.Empty;
            if (args.Length >= 1)
                return string.Empty;

            if (!args[0].Contains("?message=") && !string.IsNullOrEmpty(args[1]))
            {
                return args[0] + "?message=" + args[1];
            }
            return args[0];
#endif
        }

        private static void Main(string[] args)
        {
            var request = WebRequest.Create(GetUrl(args)) as HttpWebRequest;
            var html = string.Empty;

            using (var response = (HttpWebResponse)request?.GetResponse())
            using (var stream = response?.GetResponseStream())
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                        html = reader.ReadToEnd();

            Console.WriteLine(html);
            Console.ReadLine();
        }
    }
}
