using System;
using System.ServiceModel;
using System.ServiceProcess;
using WCFAsyncService;

namespace WCFHost
{
    public partial class MathWinService : ServiceBase
    {
        private ServiceHost myHost;

        public MathWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Just to be really safe.     
            if (myHost != null)
            {
                myHost.Close();
                myHost = null;
            }

            // Create the host.     
            myHost = new ServiceHost(typeof (MathService));

            // The ABCs in code
            var address = new Uri("http://localhost:8080/MathService");
            var binding = new WSHttpBinding();
            var contract = typeof (IBasicMath);

            // Add this endpoint.  
            myHost.AddServiceEndpoint(contract, binding, address);

            // Open the host.      
            myHost.Open();
        }

        protected override void OnStop()
        {
            // Shut down the host.  
            myHost?.Close();
        }
    }
}