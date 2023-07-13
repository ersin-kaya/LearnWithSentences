using System;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFolderDal : EfEntityRepositoryBase<Folder, LearnWithSentencesContext>, IFolderDal
    {
    }
}

