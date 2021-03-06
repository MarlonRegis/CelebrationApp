using CelebrationCore.Interfaces;
using CelebrationCore.Models;
using CelebrationCore.Services.Factory;
using Repository;
using Repository.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebrationCore.Services
{
    public class CelebrationService : ICelebrationService
    {
        private readonly ICelebrationFactory _celebrationFactory;
        private readonly CelebrationRepository _celebrationRepository;


        public CelebrationService(CelebrationRepository celebrationRepository)
        {
            _celebrationRepository = celebrationRepository;
            _celebrationFactory = new CelebrationFactory();
        }

        public async Task CreateCelebration(Celebration celebration)
        {
            CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);

            await _celebrationRepository.Save(celebrationDTO);
            await _celebrationRepository.Commit();
        }

        public async Task UpdateCelebration(Celebration celebration)
        {

            CelebrationDTO celebrationDTO = _celebrationRepository.GetById(celebration.Id);

            celebrationDTO.Name = celebration.Name;
            celebrationDTO.Description = celebration.Description;
            celebrationDTO.CelebrationDate = celebration.CelebrationDate;
            celebrationDTO.RecordDate = celebration.RecordDate;

            _celebrationRepository.Update(celebrationDTO);
            await _celebrationRepository.Commit();
        }

        public async Task DeleteCelebration(object id)
        {

            var celebration = _celebrationRepository.GetById(id);
            _celebrationRepository.Remove(celebration);
            await _celebrationRepository.Commit();
        }

        public IEnumerable<Celebration> GetAllCelebrations(int celebrationLimit)
        {
            IEnumerable<CelebrationDTO> celebrationDTOs = _celebrationRepository.GetAll(celebrationLimit);
            return celebrationDTOs.Select(res => _celebrationFactory.ToCelebration(res));
        }

        public Celebration GetCelebrationByID(object id)
        {
            Celebration celebration = _celebrationFactory.ToCelebration(_celebrationRepository.GetById(id));
            return celebration;
        }

    }
}
