using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Prioritify.Data.Repositories;
using Prioritify.Data.Tables;
using Prioritify.Sources.Operations;
using Prioritify.Sources.Operations.AccountOperations;

namespace Prioritify.Controllers {
    public class AccountController : Controller {
        private readonly IRepositoryAccessor _repoAccessor;


        public AccountController(
            IRepositoryAccessor repoAccessor
        ) {
            _repoAccessor = repoAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterOpModel model) {
            var registerOp = new RegisterOperation(model, _repoAccessor);
            var opResult = await registerOp.ExecuteAsync();
            if(opResult.Status == OperationStatus.Executed) {
                return View();
            }
            return View();
        }
    }
}
