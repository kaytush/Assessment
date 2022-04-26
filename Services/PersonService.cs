using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public class PersonService : IPersonService
    {
        public Task AddAsync(Person person)
        {
            PersonList.InsertPersonList(person);
            return Task.CompletedTask;
        }
      
        public Task<Person> FindAsync(Guid personId)
        {
            var pers = PersonList.SelectpersonList().Find(x => x.Id == personId);
            return Task.FromResult(pers);
        }
        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Task<IEnumerable<Person>> GetAllAsync()
        {
            var pers = PersonList.SelectpersonList();
            return Task.FromResult<IEnumerable<Person>>(pers);
        }

        // DELETE api/Person/1
        public Task RemoveAsync(Guid personId)
        {
            PersonList.DeletePersonList(personId);
            return Task.CompletedTask;
        }
        // PUT api/Person/int
        public Task UpdateAsync(Person person)
        {
            PersonList.UpdatePersonList(person);
            return Task.CompletedTask;
        }
    }
}
