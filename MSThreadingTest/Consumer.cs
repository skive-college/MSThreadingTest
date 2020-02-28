using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MSThreadingTest
{
    class Consumer
    {
        private ChannelReader<Msg> _channelReader;
        public Consumer(ChannelReader<Msg> channelreader)
        {
            _channelReader = channelreader;
           
        }

        private static int counter = 0;

        public async Task BeginConsuming()
        {
            DateTime start = DateTime.Now;
            DateTime end;

            await Task.Factory.StartNew(async () =>
            {
                while (await _channelReader.WaitToReadAsync())
                {
                    while (_channelReader.TryRead(out var data))
                    {
                        if (counter == 0)
                        {
                            start = DateTime.Now;
                        } 
                        else if (counter == 999)
                        {
                            end = DateTime.Now;
                            Console.WriteLine("Læs = " + (end - start).TotalMilliseconds + " ms");
                            Console.WriteLine("Læs = " + (end - start).TotalSeconds + " s");
                        }
                        counter++;
                    }
                }
            });
        }
    }
}
