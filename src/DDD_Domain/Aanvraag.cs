using DDD_Domain.ValueObjects;
using Marketplace.Framework;
using System;
using System.Collections.Generic;

namespace DDD_Domain
{
	public class Aanvraag : AggregateRoot<AanvraagId>
	{
		//Properties
		public AanvraagStatus Status { get; set; }
		public DateTime CreatieDatum { get; set; }
		public AanvraagType Type { get; set; }
		public AanvraagTitel Titel { get; set; }
		public List<BetalingsAanvraag> BetalingsAanvragen { get; private set; }
		public KlantId KlantId { get; set; }

		//Commands
		public Aanvraag(
			AanvraagId aanvraagId,
			KlantId klantId,
			AanvraagType aanvraagType)
		{
			BetalingsAanvragen = new List<BetalingsAanvraag>();
			Apply(new Events.Aanvraag.AanvraagCreated
			{
				Id = aanvraagId,
				KlantId = klantId,
				Type = aanvraagType
			});
		}

		public void Indienen()
		{
			Apply(new Events.Aanvraag.Ingediend { Id = Id });
		}

		//Entity/agregate mag nooit in een invalid state zijn

		protected override void EnsureValidState()
		{
			var valid = Id != null
						&& KlantId != null;

			if (valid)
			{
				switch (Status)
				{
					case AanvraagStatus.Ingediend:
						{
							valid = Titel != null; // als niet null, dan voldoet het ook aan de voorwaarden in value object titel
							break;
						}
					case AanvraagStatus.Afgewerkt:
						{
							break;
						}
					case AanvraagStatus.Geweigerd:
						{
							break;
						}
					case AanvraagStatus.Verwijderd:
						{
							break;
						}

					default:
						//Do nothing
						break;
				}
			}
		}

		//Domain events
		protected override void When(object @event)
		{
			switch (@event)
			{
				case Events.Aanvraag.AanvraagCreated e:
					Id = new AanvraagId(e.Id);
					KlantId = new KlantId(e.KlantId);
					Status = AanvraagStatus.Voorbereiding;
					Type = e.Type;
					break;

				case Events.Aanvraag.Ingediend e:
					Status = AanvraagStatus.Ingediend;
					break;

				default:
					throw new NotImplementedException();
			}
		}

		public enum AanvraagStatus
		{
			Voorbereiding,
			Ingediend,
			Afgewerkt,
			Geweigerd,
			Verwijderd
		}

		public enum AanvraagType
		{
			Plop,
			Plip,
			Plap
		}
	}
}