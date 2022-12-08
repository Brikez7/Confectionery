using Dapper;
using LibraryDatabaseCoffe.Models.DB.Context.@interface;
using LibraryDatabaseCoffe.Models.DB.Repository;
using LibraryDatabaseCoffe.Models.DB.Request.AbstractRepositorys;
using LibraryDatabaseCoffe.Models.DB.Tables;
using System.Text;

namespace LibraryDatabaseCoffe.Models.DB.Request.Repositories
{
    public class DescriptionOrderRepository : AbstractRepository, IRepositiry<DescriptionOrder>
    {
        public const string table_name = "description_order";
        private const string _orderId = "@order_id";
        private const string _staff_id = "@staff_id";
        private const string _amount = "@amount";
        private const string _description_id = "@description_id";
        private const string _user_id = "@user_id";
        public DescriptionOrderRepository(IDapperConnectionProvider connectiomProvider) : base(connectiomProvider)
        {
        }

        public async Task AddAsync(DescriptionOrder record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<DescriptionOrder>($"INSERT INTO {table_name}(user_id, staff_id, amount) VALUES({_user_id},{_staff_id},{_amount});", new { user_id = record.UserId, staff_id = record.StaffId, amount = record.AmountSweetStaff });
            return;
        }

        public async Task<IEnumerable<DescriptionOrder>> GetBascket(int id_user)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            string sql = $"SELECT * FROM {table_name} LEFT JOIN {SweetStaffRepository.table_name} ON {table_name}.staff_id = {SweetStaffRepository.table_name}.staff_id WHERE {table_name}.user_id = {UserRepository._id};";


            return await conn.QueryAsync< DescriptionOrder,SweetStaff,DescriptionOrder > (
                        sql,
                        (desc, staff) =>
                        {
                            desc.SweetStaff = staff;
                            return desc;
                        },
                        splitOn: "staff_id",
                        param: new { id = id_user });
        }
        public async Task AddRangeAsync(List<DescriptionOrder> values)
        {
/*            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new ($"INSERT INTO {table_name}(\"orderId\", \"staffId\", amount) VALUES ");
            foreach (var record in values)
                stringQuery.Append($"({record.Orderid},{record.StaffId},{record.AmountSweetStaff}),");
            stringQuery.Replace(',', ';', stringQuery.Length - 1, 1);
            await conn.QueryAsync<DescriptionOrder>(stringQuery.ToString());*/
            return;
        }

        public async Task<DescriptionOrder> GetAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<DescriptionOrder>($"SELECT * FROM {table_name} WHERE \"descriptionId\" = {id};");
        }

        public async Task<IEnumerable<DescriptionOrder>> GetAllAsync()
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QueryAsync<DescriptionOrder>($"SELECT * FROM {table_name};");
        }

        public async Task UpdateAsync(int id, DescriptionOrder record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<DescriptionOrder>($"UPDATE {table_name} SET \"orderId\"={record.Orderid}, \"staffId\"={record.StaffId}, amount={record.AmountSweetStaff} WHERE \"descriptionId\" = {id};");
            return;
        }

        public async Task DeleteAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<DescriptionOrder>($"DELETE FROM {table_name} WHERE \"descriptionId\" = {id}");
            return;
        }

        public async Task DeleteListAsync(int[] ids)
        {
/*            if (ids.Length == 0)
                return;

            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"DELETE FROM {table_name} WHERE \"descriptionId\" = {ids[0]}");
            foreach (var item in ids.Skip(1))
                stringQuery.Append($"or \"descriptionId\" = {item}");
            stringQuery.Append(';');*/
            return;
        }
    }
}
