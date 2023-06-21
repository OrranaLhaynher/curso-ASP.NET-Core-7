namespace Services
{
    public class CitiesService
    {
        private List<string> _cities; //é recomendando adicionar o _ antes do nome de propriedades privadas

        public CitiesService() 
        { 
            _cities = new List<string>()
            {
                "London",
                "Paris",
                "New York",
                "Tokyo",
                "Rome"
            };
        }

        public List<string> GetCities()
        {
            return _cities;
        }
    }
}