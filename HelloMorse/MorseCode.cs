using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;


public class MorseCode
{
    private OutputPort led;
    private Hashtable alphabet;
    private int len;

    public MorseCode(OutputPort op, int length)
    {
        len = length;
        led = op;
        led.Write(false);
        alphabet = new Hashtable(37);

        alphabet.Add("A", "01");
        alphabet.Add("B", "1000");
        alphabet.Add("C", "1010");
        alphabet.Add("D", "100");
        alphabet.Add("E", "0");
        alphabet.Add("F", "0010");
        alphabet.Add("G", "110");
        alphabet.Add("H", "0000");
        alphabet.Add("I", "00");
        alphabet.Add("J", "0111");
        alphabet.Add("K", "101");
        alphabet.Add("L", "0100");
        alphabet.Add("M", "11");
        alphabet.Add("N", "10");
        alphabet.Add("O", "111");
        alphabet.Add("P", "0110");
        alphabet.Add("Q", "1101");
        alphabet.Add("R", "010");
        alphabet.Add("S", "000");
        alphabet.Add("T", "1");
        alphabet.Add("U", "001");
        alphabet.Add("V", "0001");
        alphabet.Add("W", "011");
        alphabet.Add("X", "1001");
        alphabet.Add("Y", "1011");
        alphabet.Add("Z", "1100");
        alphabet.Add(" ", "2");

        alphabet.Add("1", "01111");
        alphabet.Add("2", "00111");
        alphabet.Add("3", "00011");
        alphabet.Add("4", "00001");
        alphabet.Add("5", "00000");
        alphabet.Add("6", "10000");
        alphabet.Add("7", "11000");
        alphabet.Add("8", "11100");
        alphabet.Add("9", "11110");
        alphabet.Add("0", "11111");

    }

    private void parseChar(Char c)
    {
        String morse = (String) alphabet[c.ToString()];

        for (int i = 0; i < morse.Length; i++)
        {
            if (morse[i] == '0')
            {
                led.Write(true);
                Thread.Sleep(len);
                led.Write(false);
            }
            else if (morse[i] == '1')
            {
                led.Write(true);
                Thread.Sleep(len * 3);
                led.Write(false);
            }
            else if (morse[i] == '2')
            {
                led.Write(false);
                Thread.Sleep(len * 6);
            }
            Thread.Sleep(len);
        }
    }

    public void parseMorse(String str)
    {
        String str2 = str.ToUpper();

        led.Write(false);
        for (int i = 0; i < str2.Length; i++)
        {
            parseChar(str2[i]);
            Thread.Sleep(len * 3);
        }
        led.Write(false);

    }
}