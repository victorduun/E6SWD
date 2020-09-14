    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine.SystemComponents.Algorithms
{
    public class BinScoreAlgorithm : IAssignmentAlgorithm
    {

        public int Next(List<IBin> bins, IItem nextItem)
        {

            foreach (var bin in bins)
            {
                double combinedWeight = bin.CurrentWeight + nextItem.AssignedWeight;

                if (combinedWeight <= bin.TargetWeight)
                    bin.Score = 1;
                else
                {
                    if (bin.TargetWeight == 0)
                        bin.Score = 1;
                    else
                    {
                        double giveaway = (((bin.CurrentWeight + nextItem.AssignedWeight) / bin.TargetWeight) * 100) -
                                          100;
                        bin.Score = (1 - giveaway);
                    }

                }
            }

            bins.OrderByDescending(b => b.Score);

            return bins.First().BinNumber;
        }


    }
}
