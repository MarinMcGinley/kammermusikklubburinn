using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ConcertRepository(ConcertContext context) : IConcertRepository
{
    public void AddConcert(Concert concert)
    {
        throw new NotImplementedException();
    }

    public bool ConcertExists(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteConcert(Concert concert)
    {
        throw new NotImplementedException();
    }

    public Task<Concert?> GetConcertByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Concert>> GetConcertsAsync()
    {
        return await context.Concerts.ToListAsync();
    }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void UpdateConcert(Concert concert)
    {
        throw new NotImplementedException();
    }
}
