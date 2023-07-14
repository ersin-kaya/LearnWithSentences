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
    public class StudySetsController : ControllerBase
    {
        IStudySetService _studySetService;
        IAccountProvider _accountProvider;
        IMessage _message;

        public StudySetsController(IStudySetService studySetService, IAccountProvider accountProvider, IMessage message)
        {
            _studySetService = studySetService;
            _accountProvider = accountProvider;
            _message = message;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _studySetService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _studySetService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyaccountid")]
        public IActionResult GetByAccountId(int accountId)
        {
            var result = _studySetService.GetByAccountId(accountId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyfolderid")]
        public IActionResult GetByFolderId(int folderId)
        {
            var result = _studySetService.GetByFolderId(folderId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytargetandnativelanguageids")]
        public IActionResult GetByTargetAndNativeLanguageIds(int targetLanguageId, int nativeLanguageId)
        {
            var result = _studySetService.GetByTargetAndNativeLanguageIds(targetLanguageId, nativeLanguageId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(StudySet studySet)
        {
            if (Int32.TryParse(_accountProvider.GetAccountId(), out int accountId))
            {
                studySet.AccountId = accountId;
                var result = _studySetService.Add(studySet);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(_message.ParseErrorForAccountId);
        }

        [HttpPost("update")]
        public IActionResult Update(StudySet studySet)
        {
            var result = _studySetService.Update(studySet);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(StudySet studySet)
        {
            var result = _studySetService.Delete(studySet);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

