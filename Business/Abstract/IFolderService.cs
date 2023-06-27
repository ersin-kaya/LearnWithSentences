using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IFolderService
    {
        IResult Add(Folder folder);
        IResult Update(Folder folder);
        IDataResult<List<Folder>> GetAll();
        IDataResult<Folder> GetById(int folderId);
        IDataResult<List<Folder>> GetByAccountId(int accountId);
    }
}

