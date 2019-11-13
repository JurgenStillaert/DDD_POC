using Marketplace.Framework;
using System;

namespace DDD_Domain
{
	public class KlantId : Value<KlantId>
	{
		public Guid Value { get; }

		public KlantId(Guid value)
		{
			if (value == Guid.Empty)
				throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

			Value = value;
		}

		public static implicit operator Guid(KlantId self) => self.Value;

		public static implicit operator KlantId(string value) => new KlantId(Guid.Parse(value));

		public override string ToString() => Value.ToString();
	}
}