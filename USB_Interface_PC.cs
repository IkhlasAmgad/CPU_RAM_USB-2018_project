using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usbGenericHidCommunications;
namespace USBPorject
{
    class USB_Interface_PC : usbGenericHidCommunication

    {
        public USB_Interface_PC(int vid, int pid)
            : base(vid, pid)
        {

        }

        public bool sendData(Byte []  data)
        {
            bool succees = writeRawReportToDevice(data);
            return succees;
        }
            

    }
}
