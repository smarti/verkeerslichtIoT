using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace stoplicht
{
    public sealed partial class MainPage : Page
    {
        private Led redLed;
        private Led yellowLed;
        private Led greenLed;

        private GpioButton switchButton;

        public MainPage()
        {
            this.InitializeComponent();

            redLed = new Led(13);
            yellowLed = new Led(6);
            greenLed = new Led(5);

            switchButton = new GpioButton(21);

            switchButton.GetPin.ValueChanged += SwitchButton_ValueChanged;

            redLed.Enable();
        }

        private void SwitchButton_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            if (args.Edge == GpioPinEdge.FallingEdge)
            {
                StartTrafficLight().Wait();
            }
        }

        private async Task StartTrafficLight()
        {
            redLed.Disable();
            greenLed.Enable();
            await Task.Delay(10000);
            greenLed.Disable();
            yellowLed.Enable();
            await Task.Delay(3000);
            yellowLed.Disable();
            redLed.Enable();
        }

    }
}
