using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("folder.add,folder,admin")]
        [ValidationAspect(typeof(FolderValidator))]
        [CacheRemoveAspect("IFolderService.Get")]
        public IResult Add(Folder folder, int accountId)
        {
            IResult result = BusinessRules.Run(CheckIfFolderNameExists(folder));
            if (result != null)
            {
                return result;
            }

            folder.AccountId = accountId;
            _folderDal.Add(folder);
            return new SuccessResult(_message.FolderAdded);
        }

        [SecuredOperation("folder.delete,folder,admin")]
        [CacheRemoveAspect("IFolderService.Get")]
        public IResult Delete(Folder folder)
        {
            folder.Visibility = false;
            _folderDal.Update(folder);
            return new SuccessResult(_message.FolderDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<Folder>> GetAll()
        {
            return new SuccessDataResult<List<Folder>>(_folderDal.GetAll(), _message.FoldersListed);
        }

        [CacheAspect]
        [PerformanceAspect(2)]
        public IDataResult<List<Folder>> GetByAccountId(int accountId)
        {
            return new SuccessDataResult<List<Folder>>(_folderDal.GetAll(f => f.AccountId == accountId));
        }

        [CacheAspect]
        public IDataResult<Folder> GetById(int folderId)
        {
            return new SuccessDataResult<Folder>(_folderDal.Get(f => f.Id == folderId));
        }

        [SecuredOperation("folder.update,folder,admin")]
        [ValidationAspect(typeof(FolderValidator))]
        [CacheRemoveAspect("IFolderService.Get")]
        public IResult Update(Folder folder)
        {
            IResult result = BusinessRules.Run(CheckIfFolderNameExists(folder));
            if (result != null)
            {
                return result;
            }

            _folderDal.Update(folder);
            return new SuccessResult(_message.FolderUpdated);
        }

        private IResult CheckIfFolderNameExists(Folder folder)
        {
            var result = _folderDal.GetAll(f => f.AccountId == folder.AccountId && f.Name == folder.Name).Any();
            if (result)
            {
                return new ErrorResult(_message.FolderAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

