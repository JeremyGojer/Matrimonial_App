using Happy_Marriage.Models;

namespace Happy_Marriage.Services.Interfaces
{
    public interface IAjaxServices
    {
        public List<string> GetAllCountries();
        public List<string> GetStatesFromCountry(string country);
        public List<string> GetDistrictsFromState(string state);
    }
}
