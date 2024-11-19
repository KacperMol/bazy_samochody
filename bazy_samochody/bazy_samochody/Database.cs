using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bazy_samochody
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Car>().Wait();
        }
        public Task<int> CreateCarAsync(Car car)
        {
            return _database.InsertAsync(car);
        }
        public Task<List<Car>> ReadCarAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }
        public Task<int> UpdateCarAsync(Car car)
        {
            return _database.UpdateAsync(car);
        }
        public Task<int> DeleteCarAsync(Car car)
        {
            return _database.DeleteAsync(car);
        }

        public Task<List<Car>> GetCarAsync()
        {
            return _database.Table<Car>().ToListAsync();
        }

        public Task<int> SaveCarAsync(Car car)
        {
            return _database.InsertAsync(car);
        }
    }
}
