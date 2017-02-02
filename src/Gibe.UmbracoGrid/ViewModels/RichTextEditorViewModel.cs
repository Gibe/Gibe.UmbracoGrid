using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.ViewModels
{
	public class RichTextEditorViewModel
	{
		[UmbracoProperty("value")]
		public string Html { get; set; }
	}
}