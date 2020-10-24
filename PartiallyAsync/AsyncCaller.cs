namespace PartiallyAsync
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncCaller
    {
        private readonly EventHandler eventHandler;

        public AsyncCaller(EventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public bool Invoke(int timeToWaitBeforeReturn, object sender, EventArgs args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var task = new Task(() => this.eventHandler.Invoke(sender, args), token);
            task.Start();
            var completed = task.Wait(timeToWaitBeforeReturn, token);

            return completed;
        }
    }
}