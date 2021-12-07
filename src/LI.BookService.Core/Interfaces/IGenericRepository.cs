using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Получение записи по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAllAsync();

        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task CreateAsync(T item);

        /// <summary>
        /// Обновление записи
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateAsync(T item);

        /// <summary>
        /// Запись существует, проверка по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(int id);

        /// <summary>
        /// удаление объекта
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task DeleteAsync(T item);
    }
}
