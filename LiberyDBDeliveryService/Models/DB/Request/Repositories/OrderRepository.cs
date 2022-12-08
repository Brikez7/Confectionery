using Dapper;
using LibraryDatabaseCoffe.Models.DB.Context.@interface;
using LibraryDatabaseCoffe.Models.DB.Repository;
using LibraryDatabaseCoffe.Models.DB.Request.AbstractRepositorys;
using LibraryDatabaseCoffe.Models.DB.Tables;
using System.Text;

namespace LibraryDatabaseCoffe.Models.DB.Request.Repositories
{
    public class OrderRepository : AbstractRepository,IRepositiry<Order>
    {
        public const string table_name = "orders";
        public const string user_id = "@user_id";
        public OrderRepository(IDapperConnectionProvider connectiomProvider) : base(connectiomProvider)
        {
        }

        public async Task AddAsync(int idUser)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Order>($"INSERT INTO {table_name} (user_id) VALUES ({user_id});",new {user_id = idUser});
            return;
        }

        public async Task AddRangeAsync(List<Order> values)
        {
/*            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"INSERT INTO {table_name} (\"userId\", \"orderDate\", total) VALUES ");
            foreach (var record in values)
                stringQuery.Append($"({record.UserId},{record.DateOrder},{record.Total}),");
            stringQuery.Replace(',', ';', stringQuery.Length - 1, 1);
            await conn.QueryAsync<Order>(stringQuery.ToString());*/
            return;
        }


        public async Task<Order> GetAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<Order>($"SELECT * FROM {table_name} WHERE \"orderId\" = {id};");
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QueryAsync<Order>($"SELECT * FROM {table_name};");
        }

        public async Task UpdateAsync(int id, Order record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Order>($"UPDATE FROM {table_name} SET \"userId\" ={record.UserId}, \"orderDate\" ={record.DateOrder}, total ={record.Total} WHERE \"orderId\" = {id};");
            return;
        }

        public async Task DeleteAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Order>($"DELETE FROM {table_name} WHERE \"orderId\" = {id};");
            return;
        }

        public async Task DeleteListAsync(int[] ids)
        {
/*            if (ids.Length == 0)
                return;

            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"DELETE FROM {table_name} WHERE \"orderId\" = {ids[0]}");
            foreach (int id in ids.Skip(1))
                stringQuery.Append($"or \"orderId\" = {id}");
            stringQuery.Append(';');
            await conn.QueryAsync<Order>(stringQuery.ToString());*/
            return;
        }

        public Task AddAsync(Order record)
        {
            throw new NotImplementedException();
        }
    }
}
