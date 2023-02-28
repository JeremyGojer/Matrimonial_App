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
            var list = new List<string>();
            list.Add("India");
            list.Add("China");
            list.Add("USA");
            return list;
        }

        public List<string> GetStatesFromCountry(string country)
        {
            var list = new List<string>();
            return list;
        }

        public List<string> GetDistrictsFromState(string state)
        {
            var list = new List<string>();
            return list;
        }



    }

    
}
