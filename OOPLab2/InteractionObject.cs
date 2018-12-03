using InputParser;
using OOPLab2.Commands;
using OOPLab2.IO;
using OOPLab2.Services;
using OOPLab2.Services.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2
{
    class InteractionObject
    {
        private readonly ILogger _logger;
        private readonly IParser _parser;

        public InteractionObject()
        {
            _logger = new ConsoleLogger();
            var factory = new CommandFactory(
                new AnimalCRUDService(new Entities.AnimalFactoryRandomizer(_logger), _logger),
                new ZooVoiceService(new ZooDayVoiceStrategy()),
                new WeightService(_logger),
                _logger
            );
            _parser = new Parser(factory);
        }

        public void Run()
        {
            _logger.Log("Welcome to Zoo App!");
            while (true)
            {
                try
                {
                    _parser.Parse(GetInput()).Execute();
                }
                catch (Exception ex) { _logger.LogError(ex.Message); }
            }
        }

        private string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
