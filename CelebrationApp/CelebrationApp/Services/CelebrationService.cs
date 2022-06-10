using CelebrationApp.Models;
using CelebrationApp.Services.Factory;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.DbContexts;
using Repository.DTOs;
using Repository.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Services
{
    public class CelebrationService : ICelebrationService
    {
        private readonly CelebrationFactory _celebrationFactory;
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

            CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);
            _celebrationRepository.Update(celebrationDTO);
            await _celebrationRepository.Commit();
        }

        public async Task DeleteCelebration(Celebration celebration)
        {

            CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);
            _celebrationRepository.Remove(celebrationDTO);
            await _celebrationRepository.Commit();
        }

        public IEnumerable<Celebration> GetAllCelebrations(int celebrationLimit)
        {
            IEnumerable<CelebrationDTO> celebrationDTOs = _celebrationRepository.GetAll(celebrationLimit);
            return celebrationDTOs.Select(res => _celebrationFactory.ToCelebration(res));
        }

    }
}
