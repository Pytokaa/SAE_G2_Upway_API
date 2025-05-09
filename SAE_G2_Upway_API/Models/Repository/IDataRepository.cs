﻿using Microsoft.AspNetCore.Mvc;

namespace SAE_G2_Upway_API.Models.Repository;

public interface IDataRepository<TEntity, TDto>
{
    Task<ActionResult<IEnumerable<TDto>>> GetAllAsync();
    Task<ActionResult<TEntity>> GetByIdAsync(int id);
    Task<ActionResult<TEntity>> GetByStringAsync(string str) => throw new NotImplementedException();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
    Task DeleteAsync(TEntity entity);
    
}