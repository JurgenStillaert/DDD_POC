using DDD_Domain.ValueObjects;
using Marketplace.Framework;
using System;

namespace DDD_Domain
{
	public class BetalingsAanvraag : Entity<BetalingsAanvraagId>
	{
		public AanvraagId ParentId { get; set; }
		public Money Bedrag { get; set; }

		public BetalingsAanvraag(Action<object> applier) : base(applier)
		{

		}

		protected override void When(object @event)
		{
			switch (@event)
			{
				case Events.BetalingsAanvraag.ToegevoegdAanAanvraag e:
					Id = new BetalingsAanvraagId(e.Id);
					ParentId = new AanvraagId(e.ParentId);
					break;

				case Events.BetalingsAanvraag.BedragAangepast e:
					Bedrag = new Money(e.Bedrag);
					break;

				default:
					break;
			}
		}
	}
}