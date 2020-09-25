using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics_365_Plugins
{
    public class PreOperationLowerEmailCreateUpdate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (!context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                throw new InvalidPluginExecutionException();

            var entity = (Entity)context.InputParameters["Target"];
            if (!entity.Attributes.Contains("emailaddress1"))
                return;

            var emailAddress = (string)entity["emailaddress1"];
            var formattedEmail = emailAddress.ToLower();

            entity["emailaddress1"] = formattedEmail;
        }
    }
}
