using System.Threading;


namespace UiTest
{
    internal static class DemoHelper
    {
        public static void pause(int pauseTime = 3000)
        {
            Thread.Sleep(pauseTime);
        }
    }
}
