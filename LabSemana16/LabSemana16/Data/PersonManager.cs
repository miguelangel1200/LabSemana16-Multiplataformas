using LabSemana16.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LabSemana16.Data
{
    public class PersonManager
    {
        IRestService restService;

        public PersonManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Person>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Person item, bool isNewPerson = false)
        {
            return restService.SavePersonAsync(item, isNewPerson);
        }

        public Task DeleteTaskAsync(Person item)
        {
            return restService.DeletePersonAsync(item.Id);
        }
    }
}
