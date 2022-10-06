using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TransfersController : ControllerBase
    {
        private readonly ITransferDao transferDao;
        private readonly IAccountDao accountDao;

        public TransfersController(ITransferDao _transferDao, IAccountDao _accountDao)
        {
            transferDao = _transferDao;
            accountDao = _accountDao;
        }

        [HttpGet("{id}")]
        public IActionResult GetTransfer(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }
            Transfer t = transferDao.GetTransferById(id);
            // Only return the transfer if it involves the current user
            if (t != null && (t.AccountFrom.UserId == userId || t.AccountTo.UserId == userId))
            {
                return Ok(t);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateTransfer(NewTransfer transfer)
        {
            IActionResult result = BadRequest();

            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            // If this is a Send, the current user *must be* the from user.
            if (transfer.TransferType == TransferType.Send && transfer.UserFrom != userId)
            {
                return Forbid();
            }
            Account fromAcct = accountDao.GetAccountByUserId(transfer.UserFrom);
            Account toAcct = accountDao.GetAccountByUserId(transfer.UserTo);
            if (fromAcct == null || toAcct == null)
            {
                return NotFound();
            }

            // If this is a Send (pre-approved), make sure there is enough balance
            if (transfer.TransferType == TransferType.Send && fromAcct.Balance < transfer.Amount)
            {
                return StatusCode(402); //402 = Payment Required, could be BadRequest
            }

            Transfer newTransfer = transferDao.AddTransfer(transfer, fromAcct.AccountId, toAcct.AccountId);
            if (newTransfer != null)
            {
                result = Created("transfers/" + newTransfer.TransferId, newTransfer);
            }

            return result;
        }

        [HttpPut("{id}/approve")]
        public IActionResult ApproveTransfer(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Transfer transfer = transferDao.GetTransferById(id);

            if (transfer == null)
            {
                return NotFound();
            }
            if (transfer.TransferType == TransferType.Request && transfer.AccountFrom.UserId == userId)
            {
                if (transfer.TransferStatus != TransferStatus.Pending)
                {
                    return Conflict();
                }
                else if (transfer.AccountFrom.Balance < transfer.Amount)
                {
                    // Insufficient balance to do the transfer
                    return StatusCode(402); //402 = Payment Required, could be BadRequest
                }
                else if (transferDao.ApproveTransfer(id))
                {
                    return Ok(transferDao.GetTransferById(id)); //return newly approved transaction
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Conflict(); //or BadRequest
            }
        }

        [HttpPut("{id}/reject")]
        public IActionResult RejectTransfer(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Transfer transfer = transferDao.GetTransferById(id);

            if (transfer == null)
            {
                return NotFound();
            }
            if (transfer.TransferType == TransferType.Request && transfer.AccountFrom.UserId == userId)
            {
                if (transfer.TransferStatus != TransferStatus.Pending)
                {
                    return Conflict();
                }
                else if (transferDao.RejectTransfer(id))
                {
                    return Ok(transferDao.GetTransferById(id)); //return newly rejected transaction
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Conflict(); //or BadRequest
            }
        }

        private int? GetCurrentUserId()
        {
            string userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return null;
            int.TryParse(userId, out int userIdInt);
            return userIdInt;
        }
    }
}
