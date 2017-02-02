using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.ViewModels
{
	public class QuoteViewModel
	{
		[UmbracoProperty("value")]
		public QuoteImpl Quote { get; set; }
	}

	public class QuoteImpl
	{
		[UmbracoProperty("text")]
		public string Text { get; set; }
		[UmbracoProperty("author")]
		public string Author { get; set; }
	}
}