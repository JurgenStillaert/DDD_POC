using System;
using System.Collections.Generic;
using System.Text;

namespace DDD_Domain.Events
{
	public static class BetalingsAanvraag
	{
		public class ToegevoegdAanAanvraag
		{
			public Guid Id { get; set; }
			public Guid ParentId { get; set; }
		}

		public class BedragAangepast
		{
			public Guid Id { get; set; }
			public decimal Bedrag { get; set; }
		}
	}
}
