using System;

namespace MSThreadingTest
{
    class Msg
    {
        public Byte[] Navn { get; set; }

        public Msg()
        {
            //Navn = new Byte[10];
            Navn = new Byte[1024*10];
        }
    }
}
