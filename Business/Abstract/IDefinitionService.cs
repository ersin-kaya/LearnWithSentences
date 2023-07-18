using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IDefinitionService
	{
		IResult Add(Definition definition);
		IResult Update(Definition definition);
		IResult Delete(Definition definition);
		IDataResult<Definition> GetById(int id);
		IDataResult<List<Definition>> GetByTermId(int termId);
	}
}

