using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;


namespace arduinofinder
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementScope connectionScope = new ManagementScope();
      
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            Console.WriteLine("viewpoint device detector");

            AutodetectArduinoPort();

            Console.WriteLine("press any key to continue");

            Console.ReadKey();

          }
            static private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            //StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            //standardOutput.AutoFlush = true;
            //Console.SetOut(standardOutput);
      


            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        Console.WriteLine("Arduino found on {0} ({1})]", deviceId, desc);
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }
        }
    }

