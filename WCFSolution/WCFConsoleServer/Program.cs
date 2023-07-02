using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFClasses;
using WCFInterfaces;

namespace WCFConsoleServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost/DATAServ");
            ServiceHost host = new ServiceHost(typeof(DATAClass), uri);
            host.AddServiceEndpoint(typeof(IDataLayer), new WSHttpBinding(), uri);

            ServiceMetadataBehavior metad= new ServiceMetadataBehavior();
            metad.HttpGetEnabled = true;
            host.Description.Behaviors.Add(metad);

            Binding mexBinding = MetadataExchangeBindings.CreateMexHttpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");

            host.Open();
            Console.WriteLine("Waiting for client invocations");
            Console.ReadLine();
            host.Close();
        }
    }
}
