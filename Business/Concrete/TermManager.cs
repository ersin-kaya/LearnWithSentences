using System;
using Business.Abstract;
using Business.Constants.Messages.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class TermManager : ITermService
	{
        ITermDal _termDal;
        IMessage _message;

		public TermManager(ITermDal termDal, IMessage message)
		{
            _termDal = termDal;
            _message = message;
		}

        public IResult Add(Term term)
        {
            _termDal.Add(term);
            return new SuccessResult(_message.TermAdded);
        }

        public IResult Delete(Term term)
        {
            term.Visibility = false;
            _termDal.Update(term);
            return new SuccessResult(_message.TermDeleted);
        }

        public IDataResult<Term> GetById(int id)
        {
            return new SuccessDataResult<Term>(_termDal.Get(t => t.Id == id && t.Visibility == true));
        }

        public IDataResult<List<Term>> GetByStudySetId(int studySetId)
        {
            return new SuccessDataResult<List<Term>>(_termDal.GetAll(t => t.StudySetId == studySetId && t.Visibility == true));
        }

        public IResult Update(Term term)
        {
            _termDal.Update(term);
            return new SuccessResult(_message.TermUpdated);
        }
    }
}

