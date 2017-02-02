using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.ViewModels
{
	public class HeadlineViewModel
	{
		[UmbracoProperty("value")]
		public string Headline { get; set; }
	}
}