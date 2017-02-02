using System;
using Newtonsoft.Json;
using NUnit.Framework;
using Our.Umbraco.Ditto;

namespace Gibe.UmbracoGrid.Attributes
{
	public class GridAttribute : DittoProcessorAttribute
	{
		public override object ProcessValue()
		{
			if (string.IsNullOrEmpty(Value?.ToString())) return null;

			var t = Context.PropertyDescriptor.PropertyType;

			var gridContent = JsonConvert.DeserializeObject(Value.ToString(), t);

			if (gridContent == null)
				throw new ArgumentException($"Type {t.FullName} must derive from {typeof(GridContentModel<>).FullName}.");

			return gridContent;
		}
	}
}