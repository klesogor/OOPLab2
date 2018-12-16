using InputParser;
using OOPLab2.Commands;
using OOPLab2.IO;
using OOPLab2.Entities;
using OOPLab2.Storage;
using OOPLab2.Services;
using OOPLab2.Services.Strategies;
using System;

namespace OOPLab2
{
    class InteractionObject
    {
        private readonly ILogger _logger;
        private readonly IParser _parser;
        private readonly IRepository<Animal> _repo;

        public InteractionObject()
        {
            _repo = new AnimalRepository();
            _logger = new ConsoleLogger();
            var factory = new CommandFactory(
                new AnimalCRUDService(new AnimalFactoryRandomizer(_logger), _logger, _repo),
                new ZooVoiceService(new ZooDayVoiceStrategy(), _repo),
                new WeightService(_logger, _repo),
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
