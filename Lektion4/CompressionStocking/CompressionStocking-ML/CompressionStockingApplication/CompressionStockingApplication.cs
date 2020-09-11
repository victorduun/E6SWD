using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompressionStocking;
using CompressionStocking.UserInterface;
using CompressionStocking.BusinessLogic;
using CompressionStocking.HardwareControl;

namespace CompressionStockingApplication
{
    class CompressionStockingApplication
    {
        const UInt32 PRESSURE_WHEN_RELAXED = 101000;
        const UInt32 PRESSURE_WHEN_COMPRESSED = 120000;

        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;

            Console.WriteLine("Select compression mechanism");
            Console.WriteLine("1:   Pump");
            Console.WriteLine("2:   Lace");
            Console.WriteLine("ESC: Terminate application");

            ICompressionCtrl compressionControl = null;

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                if (consoleKeyInfo.Key == ConsoleKey.D1)
                {
                    Pump pump = new Pump();
                    compressionControl = new PumpCompressionCtrl(pump);
                }
                if (consoleKeyInfo.Key == ConsoleKey.D2)
                {
                    Lace lace = new Lace();
                    compressionControl = new LaceCompressionCtrl(lace);

                }
            } while (consoleKeyInfo.Key != ConsoleKey.Escape
                     && consoleKeyInfo.Key != ConsoleKey.D1
                     && consoleKeyInfo.Key != ConsoleKey.D2);

            if (consoleKeyInfo.Key != ConsoleKey.Escape)
            {
                SimulatedPressureSensor pressureSensor = new SimulatedPressureSensor(PRESSURE_WHEN_RELAXED);
                StockingController stockingController = new StockingController(compressionControl, pressureSensor, PRESSURE_WHEN_COMPRESSED, PRESSURE_WHEN_RELAXED);
                ConsoleInput consoleInput = new ConsoleInput(pressureSensor);

                StockingInputHandler stockingInputHandler = new StockingInputHandler(stockingController);
                consoleInput.SetInputHandler(stockingInputHandler);

                CompressionProgressIndicator compressionProgressIndicator = new CompressionProgressIndicator();
                compressionProgressIndicator.AddCompressionRunningIndicator(new LED("Green"));
                compressionProgressIndicator.AddDecompressionRunningIndicator(new LED("Red"));
                VibratingDevice vibratingDevice = new VibratingDevice();
                compressionProgressIndicator.AddCompressionRunningIndicator(vibratingDevice);
                compressionProgressIndicator.AddDecompressionRunningIndicator(vibratingDevice);

                stockingController.SetCompressionProgressListener(compressionProgressIndicator);

                consoleInput.WaitForUserInput();
            }
        }
    }
}
