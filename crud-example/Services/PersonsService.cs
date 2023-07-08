using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            throw new NotImplementedException();
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public PersonResponse? GetPerson(Guid? PersonId)
        {
            throw new NotImplementedException();
        }
    }
}
