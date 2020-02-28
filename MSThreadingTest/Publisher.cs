using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MSThreadingTest
{
    class Publisher
    {
        private Channel<Msg> _channel;
        public Publisher(Channel<Msg> channel)
        {
            _channel = channel;

        }

        public void PublishData(int antal)
        {
            for(int i = 0; i < antal; i++)
            {
                if (_channel.Writer.TryWrite(new Msg()))
                {
              //      Console.WriteLine("Sent" + (i+1));
                }
            }
            
        }
    }
}
