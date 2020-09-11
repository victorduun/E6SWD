using System;

namespace CompressionStocking.UserInterface
{
    public class ConsoleInput : IUserInput
    {
        private SimulatedPressureSensor pressureSensor;

        public ConsoleInput(SimulatedPressureSensor pressureSensorSim)
        {
            pressureSensor = pressureSensorSim;
        }

        public void WaitForUserInput()
        {
            ConsoleKeyInfo consoleKeyInfo;

            Console.WriteLine("Compression Stocking Control User Interface");
            Console.WriteLine("A:   Compress");
            Console.WriteLine("Z:   Decompress");
            Console.WriteLine("Q:   Decrease pressure");
            Console.WriteLine("W:   Increase pressure");
            Console.WriteLine("ESC: Terminate application");

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                if (consoleKeyInfo.Key == ConsoleKey.A)
                {
                    if (inputHandler != null)
                    {
                        inputHandler.HandleStartButtonPushed();
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Z)
                {
                    if (inputHandler != null)
                    {
                        inputHandler.HandleStopButtonPushed();
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.Q)
                {
                    pressureSensor.DecreasePressure(1000);
                }
                if (consoleKeyInfo.Key == ConsoleKey.W)
                {
                    pressureSensor.IncreasePressure(1000);
                }
            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
