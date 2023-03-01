using Google.Protobuf.WellKnownTypes;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Utilities;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;

namespace Happy_Marriage.BusinessLogic
{
    
    public class AjaxManager:IAjaxManager
    {
        private readonly DBEntityContext dBEntityContext;
        public AjaxManager(DBEntityContext dBEntityContext) {
            this.dBEntityContext = dBEntityContext;
        }

        public List<string> GetAllCountries() { 
            
            var list = from country in dBEntityContext.Countries select country.Name;
            return list.ToList();
        }
        public int GetCountryIdFromCountry(string country) { 
            var list = from countries in dBEntityContext.Countries where (countries.Name == country) select countries.Id;
            int id = list.FirstOrDefault();
            return id;
        }

        public List<string> GetStatesFromCountry(string country)
        {
            int id = GetCountryIdFromCountry(country);
            var list = from states in dBEntityContext.States where (states.Country_Id == id) select states.Name;
            return list.ToList();
        }

        public int GetStateIdFromState(string state)
        {
            var list = from states in dBEntityContext.States where (states.Name == state) select states.Id;
            int id = list.FirstOrDefault();
            return id;
        }

        public List<string> GetDistrictsFromState(string state)
        {
            int id = GetStateIdFromState(state);
            var list = from cities in dBEntityContext.Cities where (cities.State_Id == id) select cities.Name;
            return list.ToList();
        }



    }

    
}
