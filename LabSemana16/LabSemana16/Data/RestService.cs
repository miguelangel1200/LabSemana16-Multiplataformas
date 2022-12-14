using LabSemana16.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LabSemana16.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<Person> Persons { get; private set; }

        public RestService()
        {
#if DEBUG
            client = new HttpClient(
                DependencyService.Get<IHttpClientHandlerService>()
                .GetInsecureHandler());
#else
            client = newHttpClient();
#endif
        }
        public async Task<List<Person>> RefreshDataAsync()
        {
            Persons = new List<Person>();
            string action = "/Person/Get";

            var uri = new Uri(string.Format(Constants.RestURL, action));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Persons = JsonConvert.DeserializeObject<List<Person>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return Persons;
        }

        public async Task SavePersonAsync(Person item, bool isNewPerson = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewPerson)
                {
                    var uri = new Uri(string.Format(Constants.RestURL, "Person/Insert"));
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constants.RestURL, "Edit"));
                    response = await client.PutAsync(uri, content);
                }
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tPerson Susccessfull saved");
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);

            }
        }

        public async Task DeletePersonAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestURL, id));

            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tPerson deleted");
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }
        }

        public Task DeletePersonAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
