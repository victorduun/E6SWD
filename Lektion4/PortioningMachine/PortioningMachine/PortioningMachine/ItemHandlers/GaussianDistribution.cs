using System;

namespace PortioningMachine.ItemHandlers
{
    // Adapted from http://stackoverflow.com/questions/1303368/how-to-generate-normally-distributed-random-from-an-integer-range
    public interface IDistribution
    {
        double Next();
    }

    public class GaussianDistribution : IDistribution
    {
        private readonly double _mean;
        private readonly Random _random = new Random(new DateTime().Millisecond);
        private readonly double _standardDeviation;
        private double _nextGaussian;
        private bool _useLast = true;

        public GaussianDistribution(double mean, double standardDeviation)
        {
            _mean = mean;
            _standardDeviation = standardDeviation;
        }

        public double Next()
        {
            return BoxMuller(_mean, _standardDeviation / 3);
        }

        private double BoxMuller()
        {
            if (_useLast)
            {
                _useLast = false;
                return _nextGaussian;
            }
            double v1, v2, s;
            do
            {
                v1 = 2.0 * _random.NextDouble() - 1.0;
                v2 = 2.0 * _random.NextDouble() - 1.0;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0 || Math.Abs(s - 0) < double.Epsilon);

            s = Math.Sqrt((-2.0 * Math.Log(s)) / s);

            _nextGaussian = v2 * s;
            _useLast = true;
            return v1 * s;
        }

        private double BoxMuller(double mean, double standardDeviation)
        {
            return mean + BoxMuller() * standardDeviation;
        }
    }
}