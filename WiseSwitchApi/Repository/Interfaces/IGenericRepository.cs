﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace WiseSwitchApi.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<T>> GetAllAsNoTrackingAsync();
        Task<T> GetAsNoTrackingAsync(int id);
        Task<IEnumerable<SelectListItem>> GetComboAsync();
        T Update(T entity);
    }
}
