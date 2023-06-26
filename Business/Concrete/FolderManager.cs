using System;
using Business.Abstract;
using Business.Constants.Messages.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class FolderManager : IFolderService
	{
        IFolderDal _folderDal;
        IMessage _message;

		public FolderManager(IFolderDal folderDal, IMessage message)
		{
            _folderDal = folderDal;
            _message = message;
		}

        public IResult Add(Folder folder)
        {
            IResult result = BusinessRules.Run(CheckIfFolderNameExists(folder.Name));
            if (result != null)
            {
                return result;
            }

            _folderDal.Add(folder);
            return new SuccessResult(_message.FolderAdded);
        }

        public IDataResult<List<Folder>> GetAll()
        {
            return new SuccessDataResult<List<Folder>>(_folderDal.GetAll(), _message.FoldersListed);
        }

        public IDataResult<List<Folder>> GetByAccountId(int accountId)
        {
            return new SuccessDataResult<List<Folder>>(_folderDal.GetAll(f => f.AccountId == accountId));
        }

        public IDataResult<Folder> GetById(int folderId)
        {
            return new SuccessDataResult<Folder>(_folderDal.Get(f => f.Id == folderId));
        }

        private IResult CheckIfFolderNameExists(string folderName)
        {
            var result = _folderDal.GetAll(f => f.Name == folderName).Any();
            if (result)
            {
                return new ErrorResult(_message.FolderAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

