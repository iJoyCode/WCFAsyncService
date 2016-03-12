using System.Threading;

namespace WCFAsyncService
{
    public class MathService : IBasicMath
    {
        public int Add(int x, int y)
        {
            // To simulate a lengthy request.   
            Thread.Sleep(5000);
            return x + y;
        }
    }
}