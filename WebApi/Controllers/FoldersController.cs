using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages.Abstract;
using Core.Utilities.AccountProvider;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoldersController : ControllerBase
    {
        IFolderService _folderService;
        IAccountProvider _accountProvider;
        IMessage _message;

        public FoldersController(IFolderService folderService, IAccountProvider accountProvider, IMessage message)
        {
            _folderService = folderService;
            _accountProvider = accountProvider;
            _message = message;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _folderService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _folderService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyaccountid")]
        public IActionResult GetByAccountId(int accountId)
        {
            var result = _folderService.GetByAccountId(accountId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Folder folder)
        {
            if (Int32.TryParse(_accountProvider.GetAccountId(), out int accountId))
            {
                var result = _folderService.Add(folder, accountId);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(_message.FolderCouldNotBeCreated);
        }

        [HttpPost("update")]
        public IActionResult Update(Folder folder)
        {
            var result = _folderService.Update(folder);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

