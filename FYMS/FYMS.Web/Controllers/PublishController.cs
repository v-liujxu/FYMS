using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.CAP;
using FYMS.Data;

namespace FYMS.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Publish")]
    public class PublishController : Controller
    {
        private readonly ICapPublisher _publisher;

        public PublishController(ICapPublisher publisher)
        {
            _publisher = publisher;
        }

        [Route("~/checkAccountWithTrans")]
        public async Task<IActionResult> PublishMessageWithTransaction([FromServices]ApplicationDbContext dbContext)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                //指定发送的消息标题（供订阅）和内容
                await _publisher.PublishAsync("fyms.services.account.check",
                    new { Name = "Foo", Age = 11 });
                // 你的业务代码。
                trans.Commit();
            }
            return Ok();
        }

        [NonAction]
        [CapSubscribe("fyms.services.account.check")]
        public Task CheckReceivedMessage(object data)
        {
            return Task.CompletedTask;
        }
    }
}