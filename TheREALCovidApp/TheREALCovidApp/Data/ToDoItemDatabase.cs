using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{
    public class ToDoItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ToDoItemDatabase() { InitializeAsync().SafeFireAndForget(false); }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if(!Database.TableMappings.Any(m=>m.MappedType.Name==typeof(ToDoItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ToDoItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<ToDoItem>> GetItemAsync() { return Database.Table<ToDoItem>().ToListAsync(); }
        public Task<List<ToDoItem>> GetItemsNotDoneAsync() { return Database.QueryAsync<ToDoItem>("SELECT * FROM [ToDoItem]"); }
        public Task<ToDoItem>GetItemAsync(int id) { return Database.Table<ToDoItem>().Where(i => i.ID == id).FirstOrDefaultAsync(); }
        public Task<int> SaveItemAsync(ToDoItem item)
        {
            if (item.ID != 0) { return Database.UpdateAsync(item); }
            else { return Database.InsertAsync(item); }
        }
        public Task<int> DeleteItemAsync(ToDoItem item) { return Database.DeleteAsync(item); }
    }
}
