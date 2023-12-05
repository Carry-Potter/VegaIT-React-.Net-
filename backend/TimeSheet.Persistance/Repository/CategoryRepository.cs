using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Persistance.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection _sqlConnection;
        public CategoryRepository(SqlConnection sql)
        {
            _sqlConnection = sql;
        }
        public void Delete(int id)
        {
            using SqlCommand command = new SqlCommand("DELETE FROM Category WHERE Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

        }
        public Maybe<Category> FindById(int id)
        {
            using SqlCommand command = new SqlCommand("SELECT * FROM Category WHERE Id=@id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return Maybe<Category>.None;
                }
                return Category.Create(reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetInt32(reader.GetOrdinal("Id"))).Value;

            }
        }


        public void Update(Category category)
        {
            using SqlCommand command = new SqlCommand("UPDATE  Category SET  Name=@name WHERE  Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", category.Id);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.ExecuteNonQuery();
        }
        public IEnumerable<Category> FindALL()
        {
            var listCategory = new List<Category>();
            using SqlCommand command = new SqlCommand("SELECT * FROM Category", _sqlConnection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listCategory.Add(Category.Create(reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetInt32(reader.GetOrdinal("Id"))).Value);
                    
                }
                return listCategory;

            }
        }
        public void Create(Category category)
        {
            using SqlCommand command = new SqlCommand("INSERT INTO Category(Id,Name) VALUES  Id = @id," +
                " Name=@name", _sqlConnection);
            command.Parameters.AddWithValue("@id", category.Id);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.ExecuteNonQuery();
        }
    }
}
