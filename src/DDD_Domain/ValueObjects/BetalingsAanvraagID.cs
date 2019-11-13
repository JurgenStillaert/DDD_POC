using Marketplace.Framework;
using System;

namespace DDD_Domain
{
	public class BetalingsAanvraagId : Value<BetalingsAanvraagId>
	{
		public Guid Value { get; }

		public BetalingsAanvraagId(Guid value)
		{
			if (value == Guid.Empty)
				throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

			Value = value;
		}

		public static implicit operator Guid(BetalingsAanvraagId self) => self.Value;

		public static implicit operator BetalingsAanvraagId(string value) => new BetalingsAanvraagId(Guid.Parse(value));

		public override string ToString() => Value.ToString();
	}
}