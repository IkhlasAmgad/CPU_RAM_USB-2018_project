using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;


namespace USBPorject
{
    public partial class Form1 : Form
    {
        USB_Interface_PC usbDevice;
        PerformanceCounter CPU;
        PerformanceCounter RAM;


        public Form1()
        {
            InitializeComponent();
            InitializeUSBdevice();
            InitializeCounter();
            timer1.Start();
        }

        private void InitializeUSBdevice()
        {
            usbDevice = new USB_Interface_PC(0x1234, 0x0001);
            usbDevice.usbEvent += new USB_Interface_PC.usbEventsHandler(usbEventReceiver);
            usbDevice.findTargetDevice();
        }
        private void usbEventReceiver (object o , EventArgs e)
        {
            if (usbDevice.isDeviceAttached)
            {
                label3.Text = "Attached";
            }
            else
            {
                label3.Text = "UnAttached";
            }
        }
        private void InitializeCounter()
        {
            CPU = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            RAM = new PerformanceCounter("Memory", "Available MBytes");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.textBox1.Text = Convert.ToInt32(CPU.NextValue()).ToString();
            this.textBox2.Text = Convert.ToInt32(RAM.NextValue()).ToString();
            string s ="CPU" + Convert.ToInt32(CPU.NextValue()).ToString()
                + "RAM" +Convert.ToInt32(RAM.NextValue()).ToString();

            char[] values = s.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);


            }
            if (usbDevice.isDeviceAttached)
            {
                byte[] send = new byte[65];
                send[0] = 0;
                send[1] = 0x80;
                for (int i = 2 ; i < s.Length-1; i++)
                {
                    //send[i] = Convert.ToByte(CPU.NextValue());
                    send[i] = Convert.
                    Console.WriteLine(send[i]);
                }
                usbDevice.sendData(send);
            }
            }
        }





}
