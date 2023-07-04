using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfStudySetDal : EfEntityRepositoryBase<StudySet, LearnWithSentencesContext>, IStudySetDal
    {
        public void Add(StudySet studySet, int accountId)
        {
            studySet.AccountId = accountId;
            Add(studySet);
        }
    }
}

