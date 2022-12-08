using Dapper;
using LibraryDatabaseCoffe.Models.DB.Context.@interface;
using LibraryDatabaseCoffe.Models.DB.Repository;
using LibraryDatabaseCoffe.Models.DB.Request.AbstractRepositorys;
using LibraryDatabaseCoffe.Models.DB.Tables;
using System.Text;

namespace LibraryDatabaseCoffe.Models.DB.Request.Repositories
{
    public class CompanyRepository : AbstractRepository, IRepositiry<Company>
    {
        public const string table_name = "company";
        public CompanyRepository(IDapperConnectionProvider connectiomProvider) : base(connectiomProvider)
        {
        }

        public async Task AddAsync(Company record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Company>($"INSERT INTO {table_name} ( \"companyName\", owner, telephone, \"bankingAccount\") VALUES ( {record.CompanyName}, {record.Owner}, {record.Telephone}, {record.BankingAccount});");
        }

        public async Task AddRangeAsync(List<Company> values)
        {
/*            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder stringQuery = new StringBuilder($"INSERT INTO {table_name} ( \"companyName\", owner, telephone, \"bankingAccount\") VALUES ");
            foreach (var record in values)
                stringQuery.Append($"( {record.CompanyName}, {record.Owner}, {record.Telephone}, {record.BankingAccount}),");
            stringQuery.Replace(',', ';', stringQuery.Length - 1, 1);
            await conn.QueryAsync<Company>(stringQuery.ToString());*/
            return;
        }
        
        public async Task<Company> GetAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QuerySingleAsync<Company>($"SELECT * FROM {table_name} WHERE \"companyId\" = {id}");
        }
        
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            return await conn.QueryAsync<Company>($"SELECT * FROM {table_name}");
        }

        public async Task UpdateAsync(int id, Company record)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Company>($"UPDATE {table_name} SET \"companyName\" = {record.CompanyName}, owner = {record.Owner}, telephone = {record.Telephone}, \"bankingAccount\" = {record.BankingAccount} WHERE \"companyId\" = {id};");
            return;
        }

        public async Task DeleteAsync(int id)
        {
            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            await conn.QueryAsync<Company>($"DELETE FROM {table_name} WHERE \"companyId\" = {id};");
            return;
        }

        public async Task DeleteListAsync(int[] ids)
        {
/*            if (ids.Length == 0)
                return;

            await using var conn = await ConnectiomProvider.GetConnectionAsync();
            StringBuilder StringQuery = new StringBuilder($"DELETE FROM {table_name} WHERE \"companyId\" = {ids[0]}");
            foreach (var id in ids.Skip(1))
                StringQuery.Append($" or {id}");
            StringQuery.Append(';');
            await conn.QueryAsync<Company>(StringQuery.ToString());*/
            return;
        }
    }
}
