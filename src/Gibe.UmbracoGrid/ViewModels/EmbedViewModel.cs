using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.ViewModels
{
	public class EmbedViewModel
	{
		[UmbracoProperty("value")]
		public string Url { get; set; }
	}
}