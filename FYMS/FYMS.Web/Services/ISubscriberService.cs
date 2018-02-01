using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYMS.Web.Services
{
    public interface ISubscriberService
    {
        void CheckReceivedMessage(object data);
    }
}
