using Dapper;
using LibraryDatabaseCoffe.Models.DB.Context.@interface;
using LibraryDatabaseCoffe.Models.DB.Repository;
using LibraryDatabaseCoffe.Models.DB.Request.AbstractRepositorys;
using LibraryDatabaseCoffe.Models.DB.Tables;

namespace LibraryDatabaseCoffe.Models.DB.Request.Repositories
{
    public class UserRepository : AbstractRepository, IRepositiry<User>
    {
        public const string table_name = "users";
        private const string _name = "@NameUser";
        private const string _email = "@EmailUser";
        private const string _password = "@Password";
        private const string _status = "@Status";
        private const string _total = "@TotalSpent";
        internal const string _id = "@iD";
        public UserRepository(IDapperConnectionProvider connectiomProvider) : base(connectiomProvider)
        {
        }

        public async Task AddAsync(User record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<User>($"INSERT INTO {table_name} ( user_name , email, password, status, total) VALUES ({_name}, {_email}, {_password}, {_status}, {_total});",new { record.NameUser,record.EmailUser,record.Password, record.Status,record.TotalSpent });
            return;
        }
        public async Task<bool> SearchUserByEmail(string email) 
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<bool>($"select exists (select true from {table_name} where {table_name}.email = {_email});",new { EmailUser = email});
        }
        public async Task<bool> SearchUserByName(string name)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<bool>($"select exists (select true from {table_name} where {table_name}.user_name = {_name});", new { NameUser = name });
        }
        public async Task<User?> GetUserByEmailAndPassword(string email, string password)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            var searchedUser = await conn.QueryAsync<User?>($"select * from {table_name} where email = {_email} and password = {_password} LIMIT 1;", new { EmailUser = email, Password = password });
            return searchedUser.FirstOrDefault();
        }
        public async Task AddRangeAsync(List<User> values)
        {
            // SKip this method
            /*await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"INSERT INTO \"User\"(\"userName\", email, password, status, total) VALUES ");
            for (int i = 0; i < values.Count; i++)
            {
                stringQuery.Append($"({_name}{i}, {_email}{i}, {_password}{i}, {_status}{i}, {_total}{i}),");
            }
            stringQuery.Replace(',', ';', stringQuery.Length - 1, 1);
            await conn.QueryAsync<User>(stringQuery.ToString(),values.Select(x=> new { x.NameUser,x.EmailUser, x.Password,x.Status,x.TotalSpent}));*/
            return;
        }
        public async Task<User?> GetFullInfoUser(int id_user)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            string sql = $"SELECT * FROM {table_name} LEFT JOIN {OrderRepository.table_name} ON {table_name}.user_id = {OrderRepository.table_name}.user_id " +
                                                    $"LEFT JOIN {DescriptionOrderRepository.table_name} ON {OrderRepository.table_name}.order_id = {DescriptionOrderRepository.table_name}.order_id " +
                                                    $"LEFT JOIN {SweetStaffRepository.table_name} ON {SweetStaffRepository.table_name}.staff_id = {DescriptionOrderRepository.table_name}.staff_id " +
                                                    $"WHERE {table_name}.user_id = {_id};";

            User mainUser = null;
            List<Order> mainOrders = new List<Order>();
            List<DescriptionOrder> mainDescorders = new List<DescriptionOrder>();
            List<SweetStaff> mainStaffs = new List<SweetStaff>();

            var dataInfo = await conn.QueryAsync<User, Order, DescriptionOrder, SweetStaff, User>(
                            sql,
                            (user, orders, descOrders,staffs) =>
                            {
                                mainUser = user;
                                if (orders != null)
                                {
                                    if (mainOrders.All(x => x.OrderId != orders.OrderId)) mainOrders.Add(orders);
                                    mainDescorders.Add(descOrders);
                                    mainStaffs.Add(staffs);
                                }
                                
                                return user;
                            },
                            splitOn: "order_id,order_id,staff_id",
                            param: new { id = id_user });

            if (mainUser is null) 
            {
                return null;
            }

            mainDescorders.ForEach(x => x.SweetStaff = mainStaffs.First(y => x.StaffId == y.StaffId));
            mainOrders.ForEach(x => x.DescriptionOrders = mainDescorders.Where(y => y.Orderid == x.OrderId).ToList());
            mainUser.Orders = mainOrders;

            return mainUser;
        }
        public async Task<User> GetAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<User>($"SELECT * FROM {table_name} WHERE user_id = {_id};",id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QueryAsync<User>($"SELECT * FROM {table_name};");
        }

        public async Task UpdateAsync(int id, User record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<User>($"UPDATE {table_name} SET user_name = {_name}, email = {_email}, password = {_password}, status = {_status}, total = {_total} WHERE user_id = {_id};",new {record.NameUser, record.EmailUser,record.Password,record.Status,record.TotalSpent,id });
            return;
        }

        public async Task DeleteAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<User>($"DELETE FROM {table_name} WHERE user_id = {_id};",id);
            return;
        }

        public async Task DeleteListAsync(int[] ids)
        {
            // SKip this method
/*            if (ids.Length == 0)
                return;

            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"DELETE FROM {table_name} WHERE \"userId\" = {_id}{1}");
            for (int i = 0; i < ids.Length; i++)
            {
                stringQuery.Append($" or \"userId\" = {_id}{i}");
            }
            stringQuery.Append(';');
            await conn.QueryAsync<User>(stringQuery.ToString());*/
            return;
        }
    }
}
