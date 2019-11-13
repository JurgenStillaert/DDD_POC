using DDD.Services.AanvraagIndienen.In;
using DDD_Domain;
using DDD_Domain.ValueObjects;
using System;

namespace DDD.Services
{
	public class AanvraagIndienenUseCase
	{
		private IRepoGetAanvraagById mRepoGetAanvraagById;
		private IRepoAddAanvraag mRepoAddAanvraag;
		private IUnitOfWork mUnitOfWork;

		public AanvraagIndienenUseCase(
			IRepoGetAanvraagById repoGetAanvraagById, 
			IRepoAddAanvraag repoSaveAanvraag)
		{
			mRepoGetAanvraagById = repoGetAanvraagById;
			mRepoAddAanvraag = repoSaveAanvraag;
		}

		public void Handle(AanvraagIndienenCommand command)
		{
			//Get aanvraag
			var aanvraag = mRepoGetAanvraagById.GetAanvraagById(new AanvraagId(command.AanvraagId));

			//Aanvraag indienen
			aanvraag.Indienen();

			//Persisteren
			mRepoAddAanvraag.Add(aanvraag);

			//Commit
			using (var a = new Transaction()) //Transactie beheren is verantwoordelijkheid van deze 
			{
				mUnitOfWork.Commit(); 
			}
		}
	}

	public interface IRepoGetAanvraagById
	{
		Aanvraag GetAanvraagById(AanvraagId id);
	}

	public interface IRepoAddAanvraag
	{
		Aanvraag Add(Aanvraag aanvraag);
	}

	public interface IUnitOfWork
	{
		bool Commit();
	}

	public class Transaction : IDisposable
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}