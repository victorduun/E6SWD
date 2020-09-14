using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PortioningMachine.ItemHandlers;
using PortioningMachine.SystemComponents;
using PortioningMachine.SystemComponents.Algorithms;
using PortioningMachine.SystemComponents.Interfaces;

namespace PortioningMachine
{
    public class PortioningMachine
    {
        private readonly ILog _log;

        private readonly ControlUnit _controlUnit;
        private readonly InFeed _inFeed;
        private readonly Weight _weight;
        private readonly Portioner _portioner;
        private readonly List<IBin> _bins = new List<IBin>();
        private readonly Container _container;

        public PortioningMachine(Container container, ILog log, int nBins)
        {
            _container = container;
            _log = log;

            for (int i = 0; i < nBins; i++)
                _bins.Add(new Bin(container, i));
            
            _portioner = new Portioner();
            _weight = new Weight(_portioner);
            _inFeed = new InFeed(_weight);


            IAssignmentAlgorithm assignmentAlgorithm = new BinScoreAlgorithm();
            _controlUnit = new ControlUnit(_weight,_portioner,_bins, assignmentAlgorithm);

            _inFeed.ItemArrived += new ItemArrivedHandler(delegate(object o, IItem i)
            {
                _log.LogMessage($"Item with id {i.Id} arrived at infeed");
            });

            foreach (IBin bin in _bins)
            {
                bin.BinEmptied += new BinEmptiedHandler(delegate (object o, BinStat binStat)
                {
                    IBin bin = o as IBin;
                    _log.LogMessage($"Bin {binStat.BinNumber} emptied. Current weight: {binStat.Weight:n0}. Target weight: {binStat.TargetWeight:n0}, Give-away: {binStat.Giveaway:n2}%");
                });
            }
            

        }

       

        public void Feed(IItem item)
        {
            (_inFeed as IItemConveyer)?.PutItemInConveyer(item);
        }

    }
}
