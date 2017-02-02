using System;
using NUnit.Framework;
using Umbraco.Core.Models;

namespace Gibe.UmbracoGrid.Attributes
{
	internal class ConstantPublishedProperty : IPublishedProperty
	{
		public ConstantPublishedProperty(object value)
		{
			if (value == null) throw new NullReferenceException($"{nameof(value)} must be non-null.");
			Value = value;
			DataValue = value;
			HasValue = true;
		}
		public string PropertyTypeAlias { get; }
		public bool HasValue { get; }
		public object DataValue { get; }
		public object Value { get; }
		public object XPathValue { get; }

		public override string ToString()
		{
			return $"({Value})";
		}

		protected bool Equals(ConstantPublishedProperty other)
		{
			return Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ConstantPublishedProperty) obj);
		}

		public override int GetHashCode()
		{
			return (Value != null ? Value.GetHashCode() : 0);
		}

		public static bool operator ==(ConstantPublishedProperty left, ConstantPublishedProperty right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ConstantPublishedProperty left, ConstantPublishedProperty right)
		{
			return !Equals(left, right);
		}
	}

	internal class ConstantPublishedPropertyTests
	{
		[Test]
		public void Constructor_Sets_Value()
		{
			var property = new ConstantPublishedProperty("Hello :)");
			Assert.That(property.Value, Is.EqualTo("Hello :)"));
		}

		[Test]
		public void HasValue_Is_Always_True()
		{
			var property = new ConstantPublishedProperty(string.Empty);
			Assert.That(property.HasValue, Is.True);
		}

		[Test]
		public void Constructor_Throws_On_Null()
		{
			Assert.Throws<NullReferenceException>(() => new ConstantPublishedProperty(null));
		}

		[Test]
		public void PropertyTypeAlias_is_unset()
			=> Assert.That(new ConstantPublishedProperty(string.Empty).PropertyTypeAlias, Is.Null);

		[Test]
		public void XPathValue_is_unset()
			=> Assert.That(new ConstantPublishedProperty(string.Empty).XPathValue, Is.Null);

		[Test]
		public void DataValue_is_set()
			=> Assert.That(new ConstantPublishedProperty("Zoop").DataValue, Is.EqualTo("Zoop"));

		[Test]
		public void ToString_includes_values()
			=> Assert.That(new ConstantPublishedProperty("Zip").ToString(), Is.EqualTo("(Zip)"));

		[Test]
		public void Is_equal_if_value_identical()
			=>
				Assert.That(new ConstantPublishedProperty("hello"),
					Is.EqualTo(new ConstantPublishedProperty("hello")));

		[Test]
		public void Is_not_equal_if_value_different()
			=>
				Assert.That(new ConstantPublishedProperty("one"),
					Is.Not.EqualTo(new ConstantPublishedProperty("two")));
	}
}