using OOPLab2.Entities;
using OOPLab2.Exceptions;
using OOPLab2.IO;
using OOPLab2.Services.Strategies;
using OOPLab2.Storage;
using OOPLab2.Storage.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2.Services
{
    class ZooVoiceService : IZooVoiceService
    {
        private readonly IRepository<Animal> _repository;

        public IVoiceStrategy VoiceStrategy { get;set; }

        public ZooVoiceService(IVoiceStrategy voiceStrategy)
        {
            VoiceStrategy = voiceStrategy;
            _repository = AnimalRepository.GetInstance();//we could potentially pass this as dependency, but I'm running out of time so I can't do it
        }

        public void AllZooMakeSound()
        {
            VoiceStrategy.MakeVoiceAllAnimals(_repository.GetAll());
        }

        public void MakeSoundByAnimal(Guid id)
        {
            var animal = _repository.GetBySpecification(new ByIdSpecification(id)).FirstOrDefault();
            if (animal == null) throw new AnimalNotFoundException();
            animal.MakeSound();
        }

        public void MakeSoundByAnimal(string name)
        {
            var animal = _repository.GetBySpecification(new NameSpecification(name)).FirstOrDefault();
            if (animal == null) throw new AnimalNotFoundException();
            animal.MakeSound();
        }
    }
}
