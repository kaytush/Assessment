using Assessment.Models;
using System;
using System.Collections.Generic;

namespace Assessment.Services
{
    public class PersonList
    {
        static List<Person> empList = null;
        static PersonList()
        {
            empList = new List<Person>()
            {
                new Person()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kayode Omotosho",
                    Age = 38,
                    DateOfBirth = DateTime.Now

                }
            };
        }
        public static List<Person>SelectpersonList()
        {
            return empList;
        }
        public static void InsertPersonList(Person emp)
        { empList.Add(emp); }
        public static void UpdatePersonList(Person emp)
        {
            Person empUpdate = empList.Find(x => x.Id == emp.Id);
            empUpdate.Name = emp.Name;
            empUpdate.Age = emp.Age;
            empUpdate.DateOfBirth = emp.DateOfBirth;
        }

        public static void DeletePersonList(Guid id)
        {
            Person empDelete = empList.Find(x => x.Id == id);
            empList.Remove(empDelete);
        }
    }
}
