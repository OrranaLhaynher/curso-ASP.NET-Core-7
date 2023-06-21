using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents
{
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersonGridModel grid = new PersonGridModel()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>()
                {
                    new Person() {Name="Orrana Lhaynher", JobTitle="Software Developer", JobDescription="Develops software with differents languages"},
                    new Person() {Name="Lee Taemin", JobTitle="Kpop Idol", JobDescription="Kpop singer that has multiple talents"},
                    new Person() {Name="Joaquim da Vaquejada", JobTitle="Vaqueiro", JobDescription="Já fiquei com preguiça"},
                    new Person() {Name="Orraniely Veloso", JobTitle="Students", JobDescription="Studes to be someone"},
                    new Person() {Name="Lula da Silva", JobTitle="Brazil's president", JobDescription="Governs Brazil"},
                }
            };

            //ViewData["personList"] = grid;

            return View("Sample", grid); //invoke a partial view -> ~/Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
