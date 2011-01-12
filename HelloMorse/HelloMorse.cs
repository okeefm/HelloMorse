using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace HelloMorse
{
    public class HelloMorse
    {
        public static void Main()
        {
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            MorseCode mc = new MorseCode(led, 150);

            mc.parseMorse("Hello World");

        }

    }
}
