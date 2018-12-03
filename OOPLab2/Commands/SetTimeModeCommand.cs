using InputParser;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Services;
using OOPLab2.Services.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class SetTimeModeCommand : ICommand
    {
        private readonly IZooVoiceService _service;
        private readonly StrategyFactory _strategyFactory;
        private readonly ILogger _logger;
        private readonly string _mode;

        public SetTimeModeCommand(ILogger logger,IZooVoiceService service, StrategyFactory strategyFactory, string mode)
        {
            _logger = logger;
            _service = service;
            _strategyFactory = strategyFactory;
            _mode = mode;
        }

        public void Execute()
        {
            switch (_mode)
            {
                case "day":
                    _service.VoiceStrategy = _strategyFactory.CreateDayStrategy();
                    break;
                case "night":
                    _service.VoiceStrategy = _strategyFactory.CreateNightStrategy();
                    break;
                default:
                    throw new CommandException();

            }
            _logger.Log($"Strategy is set to {_service.VoiceStrategy.Description}");
        }
    }
}
