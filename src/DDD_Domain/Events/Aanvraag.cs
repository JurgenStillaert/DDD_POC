using System;

namespace DDD_Domain.Events
{
	public static class Aanvraag
	{
		public class AanvraagCreated
		{
			public Guid Id { get; set; }
			public Guid KlantId { get; set; }
			public DDD_Domain.Aanvraag.AanvraagType Type { get; set; }
		}

		public class Ingediend
		{
			public Guid Id { get; set; }
		}

		public class BetalingsAanvraagToegevoegd
		{

		}
	}
}