using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace FYMS.Web.Services
{
    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        [CapSubscribe("fyms.services.account.check")]
        public void CheckReceivedMessage(object data)
        {

        }
    }
}
