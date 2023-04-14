using Microsoft.AspNetCore.Mvc;
using Prioritify.Data.Repositories;
using Prioritify.Data.Repositories.Base;
using Prioritify.Data.Tables;
using Prioritify.Models;
using System.Diagnostics;

namespace Prioritify.Controllers {
    public class HomeController: Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ISystemRepository<TbLogs> _log;
        private readonly IUserRepository<TbUsers> _user;
        private readonly IPrioritifyRepository<TbTasks> _tasks;
        private readonly IRepositoryBase<TestDbContext, TbTest> _test;

        public HomeController(IRepositoryBase<TestDbContext, TbTest> test, ILogger<HomeController> logger, ISystemRepository<TbLogs> log, IUserRepository<TbUsers> user, IPrioritifyRepository<TbTasks> tasks) {
            _logger = logger;
            _log = log;
            _user = user;   
            _tasks = tasks;
            _test = test;
        }

        public async Task<IActionResult> Index() {
            //var tasks = await _tasks.GetAllAsync();
            var test = new TbTest {
                Age = 18,
                CreatedAt = DateTime.UtcNow,
                Name = "Test",
                RowVersion = 1,
                UpdatedAt = null
            };
            var a = await _test.InsertAsync(test);

            return View();
        }

        public async Task<IActionResult> AddTask() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TbTasks tbTasks) {
            tbTasks.flStatus = Data.Tables.TaskStatus.NotStarted;
            tbTasks.CreatedAt = DateTime.UtcNow;
            tbTasks.UpdatedAt = DateTime.UtcNow;
            tbTasks.flDeadline = DateTime.UtcNow;
            tbTasks.FinishedAt = DateTime.UtcNow;
            tbTasks.flUserId = -1;
            tbTasks.flPrevVersionsInJson = "";
            tbTasks.Tags = "";
            tbTasks.flId = Guid.NewGuid().ToString();
            await _tasks.InsertAsync(tbTasks);
            return View(nameof(Index));
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}