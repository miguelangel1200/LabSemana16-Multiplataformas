using LabSemana16.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LabSemana16.Data
{
    public interface IRestService
    {
        Task<List<Person>> RefreshDataAsync();
        Task SavePersonAsync(Person item, bool isNewPerson);

        Task DeletePersonAsync(string id);
    }
}
