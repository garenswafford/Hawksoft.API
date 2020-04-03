using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace HawkSoft.Razor.UI
{
    // was having various difficulties with http client so I wrapped it in a class abstraction. Probably not ideal but for time contraints got this working.
    public class HttpCoreClient : IDisposable
    {
        private string _baseAddress;
        private HttpResponseMessage _httpResponseMessage;
        private HttpClient _httpClient;
        private HttpClient HttpClientInstance
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = HttpClientFactory.Create();
                    _baseAddress = "http://localhost:64138";
                    SetupClientDefaults();
                }

                return _httpClient;
            }

            set { _httpClient = value; }
        }

       
        private void SetupClientDefaults()
        {
            HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
            HttpClientInstance.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClientInstance.Timeout = TimeSpan.FromSeconds(120); 
            HttpClientInstance.BaseAddress = new Uri(_baseAddress);
        }
        public ObservableCollection<T> CallWebService<T>(string webmethodName)
        {
            try
            {
                string webUrl = HttpClientInstance.BaseAddress + webmethodName;


                _httpResponseMessage = HttpClientInstance.GetAsync(webUrl).Result;

                if (!_httpResponseMessage.IsSuccessStatusCode)
                    throw new Exception(_httpResponseMessage.StatusCode.ToString());

                var dataObjects = _httpResponseMessage.Content.ReadAsAsync<ObservableCollection<T>>().Result;

                return dataObjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            HttpClientInstance.Dispose();
        }
    }
}
