using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace BlogPostApi
{
    public class BlogPost{

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        internal AppDb Db { get; set; }

        public BlogPost(){

        }
        internal BlogPost(AppDb db){
            Db = db;
        }

        public async Task InsertAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO 'BlogPost' ('Title', 'Content') VALUES (@title, @content);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int) cmd.LastInsertedId;
        }

        public async Task UpdateAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE 'BlogPost' SET 'Title' = @title, 'Content' = @content WHERE 'Id' = @id; ";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(){
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "DELETE FROM 'BlogPost' WHERE 'Id' = @id; ";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        //Now lets write the Id Binder....
        public void BindId(MysqlCommand cmd){
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }

        //Bind the parameters title and content to the respective column names
        public void BindParams(MysqlCommand cmd){
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@title",
                DbType = DbType.String,
                Value = Title,
            });
            cmd.Parameters.Add(new MySqlParameter{
                ParameterName = "@content",
                DbType = DbType.String,
                Value = Content,
            });
        }
    }
}