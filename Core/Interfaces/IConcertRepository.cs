using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IConcertRepository
{
    Task<IReadOnlyList<Concert>> GetConcertsAsync();
    Task<Concert?> GetConcertByIdAsync(int id);
    void AddConcert(Concert concert);
    void UpdateConcert(Concert concert);
    void DeleteConcert(Concert concert);
    bool ConcertExists(int id);
    Task<bool> SaveChangesAsync();
}
