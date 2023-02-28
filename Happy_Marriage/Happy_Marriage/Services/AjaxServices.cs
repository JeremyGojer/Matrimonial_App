using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class AjaxServices:IAjaxServices
    {
        private readonly IAjaxManager _ajaxManager;
        //The Reference for Constructor Dependency Injection should be Interface Type
        public AjaxServices(IAjaxManager ajaxManager) { 
             _ajaxManager = ajaxManager;
        }

        public List<string> GetAllCountries() => _ajaxManager.GetAllCountries();
        public List<string> GetStatesFromCountry(string country) => _ajaxManager.GetStatesFromCountry(country);
        public List<string> GetDistrictsFromState(string state) => _ajaxManager.GetDistrictsFromState(state);

    }
}
