    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine.SystemComponents.Algorithms
{
    public class BinScoreAlgorithm : IAssignmentAlgorithm
    {

        public int Next(IEnumerable<IBin> bins, IItem nextItem)
        {

            foreach (var bin in bins)
            {
                double combinedWeight = bin.CurrentWeight + nextItem.AssignedWeight;

                if (bin.TargetWeight == 0)
                    bin.Score = 1;
                double giveaway = (((bin.CurrentWeight + nextItem.AssignedWeight) / bin.TargetWeight));

                if (combinedWeight <= bin.TargetWeight)
                    bin.Score = 1+giveaway;
                else
                {
                    bin.Score = (1 - giveaway);
                }
            }

            IEnumerable<IBin> sortedBins = bins.OrderByDescending(b => b.Score);

            return sortedBins.First().BinNumber;
        }


    }
}
