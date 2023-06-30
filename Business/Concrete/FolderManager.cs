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
            IResult result = BusinessRules.Run(CheckIfFolderNameExists(folder.Name));
            if (result != null)
            {
                return result;
            }

            _folderDal.Update(folder);
            return new SuccessResult(_message.FolderUpdated);
        }

        //refactor - add accountId
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

