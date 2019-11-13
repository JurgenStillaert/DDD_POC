using Marketplace.Framework;
using System;

namespace DDD_Domain.ValueObjects
{
	public class AanvraagId : Value<AanvraagId>
	{
		public Guid Value { get; }

		public AanvraagId(Guid value)
		{
			if (value == Guid.Empty)
				throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

			Value = value;
		}

		public static implicit operator Guid(AanvraagId self) => self.Value;

		public static implicit operator AanvraagId(string value) => new AanvraagId(Guid.Parse(value));

		public override string ToString() => Value.ToString();
	}
}