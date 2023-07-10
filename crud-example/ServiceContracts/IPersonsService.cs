using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    public interface IPersonsService
    {
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);
        List<PersonResponse> GetAllPersons();
        PersonResponse? GetPerson(Guid? personId);

        /// <summary>
        /// Returns all person objects that matches with the given search field and search string
        /// </summary>
        /// <param name="searchBy"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);

        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
    }
}
