using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace vocal
{
	public class VocalDatabase
	{
		Boolean FlagIsPopulated;
		readonly SQLiteAsyncConnection database;

		public VocalDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<VocalUser>().Wait();
		}

		public Task<List<VocalUser>> GetItemsAsync()
		{
			return database.Table<VocalUser>().ToListAsync();
		}

		public Task<List<VocalUser>> GetItemsNotDoneAsync()
		{
			return database.QueryAsync<VocalUser>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
		}

		public Task<VocalUser> GetItemAsync(int id)
		{
			return database.Table<VocalUser>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(VocalUser item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(VocalUser item)
		{
			return database.DeleteAsync(item);
		}
	}
}
