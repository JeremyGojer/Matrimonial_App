using Happy_Marriage.Models;

namespace Happy_Marriage.BusinessLogic.Interfaces
{
    public interface IAjaxManager
    {
        public List<string> GetAllCountries();
        public List<string> GetStatesFromCountry(string country);
        public List<string> GetDistrictsFromState(string state);
    }
}
