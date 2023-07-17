using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Domain Model for storing Country 
    /// </summary>
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; } //public string CountryName { get; set; } = "", ou pelo construtor

    }
}