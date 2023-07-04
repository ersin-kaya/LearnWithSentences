﻿using System;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IStudySetDal : IEntityRepository<StudySet>
	{
		void Add(StudySet studySet, int accountId);
	}
}

