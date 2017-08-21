using System;
using System.IO;
using System.Net.Http;

namespace Wget
{
    public class WebClient : IDisposable
    {
        private readonly HttpClient _client;

        public WebClient()
        {
            _client = new HttpClient();
        }

        public void DownloadFile(string src, string dest)
        {
            using (var srcStream = _client.GetStreamAsync(src).Result)
            using (var destStream = new FileStream(dest, FileMode.OpenOrCreate))
            {
                srcStream.CopyTo(destStream);
            }
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}