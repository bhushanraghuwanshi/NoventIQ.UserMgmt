using Microsoft.Extensions.Localization;
namespace NoventIQ.UserMgmt.Services
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public string GetLocalizedMessage(string key)
        {
            return _localizer[key];
        }

    }
}
