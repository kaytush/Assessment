using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public interface IPersonService
    {
		Task AddAsync(Person person);
		Task<IEnumerable<Person>> GetAllAsync();
		Task<Person> FindAsync(Guid personId);
		Task RemoveAsync(Guid personId);
		Task UpdateAsync(Person person);
	}
}
