using Microsoft.AspNetCore.Mvc;

namespace ModelBindingAndValidation.Models
{
    public class Book
    {
        // if we want to set one of the parameters to FromQuery/FromRoute add [FromRoute] before the parameter
        [FromRoute]
        public int? BookId { get; set; }

        [FromQuery]
        public string? Author { get; set; }

        [FromForm]
        public bool? IsLoggedIn { get; set; }

        public override string ToString()
        {
            return $"Book id: {BookId}, Author: {Author}, Is logged in: {IsLoggedIn}";
        }
    }
}
