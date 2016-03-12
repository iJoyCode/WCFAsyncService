using System.ServiceModel;

namespace WCFAsyncService
{
    [ServiceContract(Namespace = "TestingNamespace")]
    public interface IBasicMath
    {
        [OperationContract]
        int Add(int x, int y);
    }
}