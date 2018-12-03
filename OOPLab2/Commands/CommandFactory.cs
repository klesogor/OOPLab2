using InputParser;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Commands
{
    class CommandFactory : ICommandFactory
    {
        private readonly IAnimalCRUDService _crudService;
        private readonly IZooVoiceService _voiceService;
        private readonly IWeightService _weightService;
        private readonly ILogger _logger;

        public CommandFactory(
            IAnimalCRUDService crudService, 
            IZooVoiceService voiceService, 
            IWeightService weightService,
            ILogger logger
        ) {
            _crudService = crudService;
            _voiceService = voiceService;
            _weightService = weightService;
            _logger = logger;
        }

        public ICommand Create(string command, params string[] args)
        {
            try {
                switch (command)
                {
                    case "create":
                        return CreateCreateAnimalCommand(args);
                    case "delete":
                        return new DeleteAnimalCommand(args[0], _crudService);
                    case "list":
                        return new ListAllAnimalsCommand(_crudService);
                    case "weight":
                        return CreateWeightCommand(args);
                    case "exit":
                        return new ExitCommand();
                    case "voice":
                        return CreateVoiceCommand(args);
                    case "mode":
                        return new SetTimeModeCommand(
                            _logger, 
                            _voiceService, 
                            new Services.Strategies.StrategyFactory(_logger), 
                            args[0]
                        );
                    default:
                        throw new CommandException();

                }
            } catch (Exception) { throw new CommandException(); }
        }

        private ICommand CreateCreateAnimalCommand(string[] args)
        {
            if (args.Count() == 3) return new CreateNewConcreteAnimal(_crudService, args[1], args[0], float.Parse(args[2]));
            return new CreateAnimalCommand(args[0], float.Parse(args[1]), _crudService);
        }

        private ICommand CreateWeightCommand(string[] args)
        {
            if (args.Length > 0) return new GetAverageWieghtByTypeCommand(_weightService,args[0]);
            return new GetAverageWeightCommand(_weightService);
        }

        private ICommand CreateVoiceCommand(string[] args)
        {
            if (args.Length > 0) return new MakeVoiceByNameCommand(_voiceService, args[0]);
            return new AllMakeVoiceCommand(_voiceService);
        }

    }
}
