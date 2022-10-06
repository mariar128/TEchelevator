using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDao accountDao;
        private readonly ITransferDao transferDao;

        public AccountController(IAccountDao _accountDao, ITransferDao _transferDao)
        {
            accountDao = _accountDao;
            transferDao = _transferDao;
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            Account a = accountDao.GetAccountByUserId(userId.Value);
            if (a == null)
            {
                return NotFound();
            }
            return Ok(a.Balance);
        }

        [HttpGet("transfers")]
        public IActionResult GetTransfers()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            return Ok(transferDao.GetTransfersForUser(userId.Value));
        }

        [HttpGet("pending")]
        public IActionResult GetPendingTransfers()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }

            return Ok(transferDao.GetPendingTransfersForUser(userId.Value));
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
