using SMSLive247.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSLive247
{
    public class SMSProcessingCall
    {
        public SMSProcessingCall()
        {
            SMSHandler.SendBulkSMSUsingSMSLive247("23480988", "SMSLive247 Testing");
        } 
    }
}
