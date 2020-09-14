using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine.SystemComponents.Algorithms
{
    public class RoundRobinAlgorithm : IAssignmentAlgorithm
    {
        private int? _lastAssignedBinIndex = null;
        

        private List<int> _binNumbers;


        public int Next(List<IBin> bins)
        {
            
            _binNumbers = bins.OrderBy(b=>b.BinNumber).Select(b=>b.BinNumber).ToList();

            if (!_lastAssignedBinIndex.HasValue)
            {
                _lastAssignedBinIndex = 0;
                return _binNumbers[_lastAssignedBinIndex.Value];
            }

            _lastAssignedBinIndex++;
            if (_lastAssignedBinIndex.Value >= _binNumbers.Count)
                _lastAssignedBinIndex = 0;

            return _binNumbers[_lastAssignedBinIndex.Value];


        }
    }
}
