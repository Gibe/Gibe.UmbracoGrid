using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Core.Models;

namespace Gibe.UmbracoGrid.Attributes
{
	public class GridItem
	{
		public class GridItemConfig
		{
			public GridEditor Editor { get; set; }
			public class GridEditor
			{
				public string Alias { get; set; }
			}
		}
		public GridItem(JObject json)
		{
			Content = new JsonPublishedContent(json);
			Config = JsonConvert.DeserializeObject<GridItemConfig>(json.ToString());
		}

		public GridItemConfig Config { get; set; }

		public IPublishedContent Content { get; }
	}
}