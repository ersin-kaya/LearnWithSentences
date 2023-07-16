using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ITermService
	{
		IResult Add(Term term);
		IResult Update(Term term);
		IResult Delete(Term term);
		IDataResult<List<Term>> GetByStudySetId(int studySetId);
		IDataResult<Term> GetById(int id);
	}
}

