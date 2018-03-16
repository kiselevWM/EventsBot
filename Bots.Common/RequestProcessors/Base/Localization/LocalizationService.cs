using System.Globalization;

namespace Bots.Common.RequestProcessors.Base.Localization
{
	public class LocalizationService: ILocalizationService
	{
		public void SetLocale(string locale)
		{
			if(locale == null) return;

			//todo 4.5.2 cultureInfo set is not implemented
			var cultureInfo = new CultureInfo(locale);
			CultureInfo.CurrentCulture = cultureInfo;
			CultureInfo.CurrentUICulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
			CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
		}
	}
}