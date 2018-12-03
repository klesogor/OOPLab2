using OOPLab2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services.Strategies
{
    class StrategyFactory
    {
        private readonly ILogger _logger;

        public StrategyFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IVoiceStrategy CreateDayStrategy() => new ZooDayVoiceStrategy();

        public IVoiceStrategy CreateNightStrategy() => new ZooNightVoiceStrategy(_logger);
    }
}
