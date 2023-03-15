using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Models;
using Happy_Marriage.Services.Interfaces;

namespace Happy_Marriage.Services
{
    public class AppConfigServices:IAppConfigServices
    {
        //All the configuration is available in this object
        ApplicationConfiguration _appConfig;
        public string? Directory { get; set; }

        public AppConfigServices(Microsoft.Extensions.Options.IOptions<ApplicationConfiguration> options)
        {
            _appConfig= options.Value;
            Directory = options.Value.Directory;
        }

        public ApplicationConfiguration GetApplicationConfiguration()
        {
            return _appConfig;
        }

    }
}
