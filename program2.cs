﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

using System.IO.Ports;
using System.Text;

namespace NetduinoPlusApplication1
{
    public class Program
    {
        public static void Main()
        {
            //Robot de detection et de géolocalisation Test ver 1.0

            //liqson série (Uart1)
            //Caractèrs transmise (taille connue)
            //Format de chaine 7 caracteres : [S] [B/F/0] [R/L/0] [VITESSE(3)] [S]

            SerialPort serial = new SerialPort(SerialPorts.COM1, 9600, Parity.None, 8, StopBits.One);
            serial.Open();
                Debug.Print("Opend");
            serial.Flush(); //pause la programme avant que la transmission de buffer est finit. et apres netoiye le buffer
                Debug.Print("Flushed");
            int buffersize = 7;
            byte[] buffer = new byte[buffersize]; //on declare le nouveau variable de type byte et on inistialise le nombre de variable "buffersize" avec lui


            while (true) test edit file
            {
                if (serial.BytesToRead >= buffersize) //on lit buffer et on verifie si les nombre des bits son au buffer est superrieur ou egale a buffersize(7) alors on rentre dans if loop
                {
                    serial.Read(buffer, 0, buffer.Length);

                    if (buffer[0] == 'S') //si le premier bit de buffer egal au S on rentre dans if loop
                    {
                        char marche = Convert.ToChar(buffer[1]); 
                        char direction = Convert.ToChar(buffer[2]);

                        byte[] vitessechar = new byte[3];
                        Array.Copy(buffer, 3, vitessechar, 0, 3);
                        uint vitesse = Convert.ToUInt16(new string(System.Text.Encoding.UTF8.GetChars(vitessechar)));


                        //debug
                        Debug.Print("Marche=" + marche.ToString());
                        Debug.Print("Direction=" + direction.ToString());
                    }
                }
            }


        }

    }
}
