namespace ModelBindingAndValidation.Models
{
    public class Book
    {
        public int? BookId { get; set; }

        public string? Author { get; set; }
        //public bool? IsLoggedIn { get; set; }

        public override string ToString()
        {
            return $"Book id: {BookId}, Author: {Author}";
        }
    }
}
