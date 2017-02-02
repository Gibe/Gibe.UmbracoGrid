using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gibe.UmbracoGrid.Attributes
{
	public class GridContentModel<TRowConfiguration>
	{
		public IList<GridSection> Sections { get; set; }

		public class GridSection
		{
			public int Grid { get; set; }

			public IList<GridRow> Rows { get; set; }

			public class GridRow
			{
				public string Name { get; set; }

				[JsonProperty("config")]
				public TRowConfiguration Settings { get; set; }


				public IList<GridArea> Areas { get; set; }

				public class GridArea
				{
					public int Grid { get; set; }

					[JsonProperty("controls")]
					public IList<JObject> JsonControls { private get; set; }

					[JsonIgnore]
					public IEnumerable<GridItem> Controls
						=> JsonControls.Select(c => new GridItem(JsonConvert.DeserializeObject<JObject>(c.ToString())));
				}
			}
		}
	}
}