﻿using İnternshipManagementSystem.Domain.Entities;

namespace İnternshipManagementSystem.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsyncRange(List<T> entities);
        bool Remove(T entities);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveRangeAsync(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool  Update(T entity);

        Task<int> SaveAsync();
    }
}
