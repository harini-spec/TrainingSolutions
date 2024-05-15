﻿namespace PizzaApplicationAPI.Repositories
{
    public interface IRepository<K, T> where T: class
    {
        Task<T> GetById(K key);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(K key);
    }
}
