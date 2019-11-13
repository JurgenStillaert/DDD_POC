using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Services.AanvraagIndienen.In
{
	public class AanvraagIndienenCommand
	{
		internal Guid AanvraagId { get; set; }

		public AanvraagIndienenCommand(Guid aanvraagId)
		{
			//Do checks

			if (aanvraagId == Guid.Empty)
			{
				throw new ArgumentNullException("AanvraagId mag niet leeg zijn");
			}

			AanvraagId = aanvraagId;
		}
	}
}
