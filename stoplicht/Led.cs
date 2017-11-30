using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls.Primitives;

namespace stoplicht
{
    public class Led
    {
        private readonly GpioPin Pin;
        private GpioPinValue PinValue;

        public Led(int PinId)
        {
            GpioController gpio = GpioController.GetDefault();

            if (gpio != null)
            {
                Pin = gpio.OpenPin(PinId);
                PinValue = GpioPinValue.High;
                Pin.Write(PinValue);
                Pin.SetDriveMode(GpioPinDriveMode.Output);
            }
        }

        public void Toggle()
        {
            switch (PinValue)
            {
                case GpioPinValue.High:
                    Enable();
                    break;
                case GpioPinValue.Low:
                    Disable();
                    break;
            }
        }

        public void Enable()
        {
            PinValue = GpioPinValue.Low;
            Pin.Write(PinValue);
        }

        public void Disable()
        {
            PinValue = GpioPinValue.High;
            Pin.Write(PinValue);
        }
    }
}
