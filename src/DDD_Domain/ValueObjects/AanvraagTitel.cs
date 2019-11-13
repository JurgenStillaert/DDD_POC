using Marketplace.Framework;
using System;

namespace DDD_Domain.ValueObjects
{
	public class AanvraagTitel : Value<AanvraagTitel>
	{
		public static AanvraagTitel FromString(string title)
		{
			CheckValidity(title);
			return new AanvraagTitel(title);
		}

		public string Value { get; private set; }

		internal AanvraagTitel(string value) => Value = value;

		public static implicit operator string(AanvraagTitel title) => title.Value;

		private static void CheckValidity(string value)
		{
			if (value.Length > 100)
				throw new ArgumentOutOfRangeException(
					"Title cannot be longer that 100 characters",
					nameof(value));
		}

		// Satisfy the serialization requirements
		protected AanvraagTitel() { }
	}
}