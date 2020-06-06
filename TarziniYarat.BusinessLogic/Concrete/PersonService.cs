using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.DataAccess.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.BusinessLogic.Concrete
{
    public class PersonService : IPersonService
    {
        IPersonDAL _personDAL;

        public PersonService(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }

        public bool Add(Person entity)
        {
            return _personDAL.Add(entity) > 0;


        }

        public bool Delete(int entityID)
        {
            Person person = _personDAL.Get(a => a.PersonID == entityID);
            return _personDAL.Delete(person) > 0;
        }

        public List<Person> GetAll()
        {
            return _personDAL.GetAll().ToList();
        }

        public Person GetByID(int entityID)
        {
            return _personDAL.Get(a => a.PersonID == entityID);
        }

        public bool Update(Person entity)
        {
            return _personDAL.Update(entity) > 0;
        }
    }
}
