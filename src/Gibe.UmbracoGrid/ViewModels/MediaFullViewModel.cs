using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.ViewModels
{
	public class MediaFullViewModel
	{
		[UmbracoProperty("value")]
		public GridMediaItemModel Image { get; set; }
	}

	public class GridMediaItemModel
	{
		[UmbracoProperty("image")]
		public string Url { get; set; }
		[UmbracoProperty("altText")]
		public string Alt { get; set; }
		[UmbracoProperty("caption")]
		public string Caption { get; set; }
	}
}