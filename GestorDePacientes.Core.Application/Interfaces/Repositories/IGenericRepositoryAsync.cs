﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDePacientes.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, int id);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllWithIncludeAsync(List<string> properties);

    }
}
