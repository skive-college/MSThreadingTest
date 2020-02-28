using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MSThreadingTest
{
    class Program
    {
        private static Channel<Msg> _channel;
        static async Task Main(string[] args)
        {
            _channel = Channel.CreateBounded<Msg>(10000);

            for (int i = 0; i < 1; i++)
            {
                var c = new Consumer(_channel.Reader);
                await c.BeginConsuming();
            }

            var p = new Publisher(_channel);
            var start = DateTime.Now;
            var publishTime = new TimeSpan(0);
            p.PublishData(1000);         
            publishTime = publishTime.Add(DateTime.Now - start);

            Console.WriteLine(" Skriv = " + (publishTime).TotalMilliseconds + " ms");
            Console.WriteLine(" Skriv = " + (publishTime).TotalSeconds + " s");
            Console.ReadLine();
        }
    }
}
