namespace Infrastructure.SqlServer.Repositories.User
{
    public partial class UserRepository
    {
        public const string TableName = "users";

        public const string ColId = "id",
            ColName = "name",
            colEmail = "email",
            colPassword = "password";

        public static readonly string ReqCreate = $@"
            INSERT INTO {TableName}({ColName}, {colEmail}, {colPassword})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColName}, @{colEmail}, @{colPassword})";

        public static readonly string ReqGetAll = $@"
            SELECT * FROM {TableName}
        ";

        public static readonly string ReqDelete = $@"
            DELETE FROM {TableName} WHERE {ColName} = @{ColName}";
    }
}