using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace stoplicht
{
    class GpioButton
    {
        private readonly GpioPin Pin;

        public GpioButton(int pinID)
        {
            GpioController gpio = GpioController.GetDefault();

            if (gpio != null)
            {
                Pin = gpio.OpenPin(pinID);
                Pin.DebounceTimeout = TimeSpan.FromMilliseconds(50);
                Pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            }
        }

        public GpioPin GetPin
        {
            get { return Pin; }
        }
    }
}
