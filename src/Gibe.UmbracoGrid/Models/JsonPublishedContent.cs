using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace Gibe.UmbracoGrid.Attributes
{
	internal class JsonPublishedContent : IPublishedContent
	{
		public override string ToString()
		{
			return $"({string.Join(";", _properties.Select(p=>$"({p.Key}: {p.Value})"))})";
		}

		private Dictionary<string, IPublishedProperty> _properties = new Dictionary<string, IPublishedProperty>();

		public JsonPublishedContent(JObject obj)
		{
			foreach (var prop in obj)
			{
				if (prop.Value.Type == JTokenType.Object)
				{
					_properties[prop.Key] = new ConstantPublishedProperty(new JsonPublishedContent((JObject)prop.Value));
				}
				else
				{
					_properties[prop.Key] = new ConstantPublishedProperty(prop.Value.ToString());
				}
			}
		}

		public int GetIndex()
		{
			throw new NotImplementedException();
		}

		public IPublishedProperty GetProperty(string alias)
			=> _properties.ContainsKey(alias) ? _properties[alias] : null;

		public IPublishedProperty GetProperty(string alias, bool recurse)
			=> GetProperty(alias);

		public IEnumerable<IPublishedContent> ContentSet { get; }
		public PublishedContentType ContentType { get; }
		public int Id { get; }
		public int TemplateId { get; }
		public int SortOrder { get; }
		public string Name { get; }
		public string UrlName { get; }
		public string DocumentTypeAlias { get; }
		public int DocumentTypeId { get; }
		public string WriterName { get; }
		public string CreatorName { get; }
		public int WriterId { get; }
		public int CreatorId { get; }
		public string Path { get; }
		public DateTime CreateDate { get; }
		public DateTime UpdateDate { get; }
		public Guid Version { get; }
		public int Level { get; }
		public string Url { get; }
		public PublishedItemType ItemType { get; }
		public bool IsDraft { get; }
		public IPublishedContent Parent { get; }
		public IEnumerable<IPublishedContent> Children => Enumerable.Empty<IPublishedContent>();
		public ICollection<IPublishedProperty> Properties => _properties.Values;

		public object this[string alias]
			=> GetProperty(alias);

		protected bool Equals(JsonPublishedContent other)
		{
			return _properties.SequenceEqual(other._properties);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((JsonPublishedContent) obj);
		}

		public override int GetHashCode()
		{
			return (_properties != null ? _properties.GetHashCode() : 0);
		}

		public static bool operator ==(JsonPublishedContent left, JsonPublishedContent right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(JsonPublishedContent left, JsonPublishedContent right)
		{
			return !Equals(left, right);
		}
	}

	internal class JsonPublishedContentTests
	{
		private JObject J(string json) => JsonConvert.DeserializeObject<JObject>(json);
		private ConstantPublishedProperty Constant(object value) => new ConstantPublishedProperty(value);

		[Test]
		public void Simple_properties_accessible_as_properties()
			=>
				Assert.That(new JsonPublishedContent(J(@"{'value': 'test-value'}")).GetProperty("value"),
					Is.EqualTo(Constant("test-value")));

		[Test]
		public void Complex_properties_accessible_as_inner_content()
			=>
				Assert.That(new JsonPublishedContent(J(@"{'complex': {'inner': 'value'}}")).GetProperty("complex").Value,
					Is.EqualTo(new JsonPublishedContent(J(@"{'inner': 'value'}"))));
	}
}