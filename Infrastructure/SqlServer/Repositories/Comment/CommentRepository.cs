﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    
    public class CommentRepository : ICommentRepository
    {
        public const string TableName = "comment";
        
        public const string ColId = "id",
            ColContent = "content",
            ColScore = "score",
            ColImage = "image",
            ColDifficulty = "difficulty",
            ColIdUser = "idUser",
            ColIdRide = "idRide";
        
        public static readonly string ReqGetAll = $"SELECT * FROM {TableName}";

        public static readonly string ReqCreateComment = $@"
            INSERT INTO {TableName}({ColContent}, {ColScore}, {ColImage},
            {ColDifficulty}, {ColIdUser}, {ColIdRide})
            OUTPUT INSERTED.{ColId}
            VALUES(@{ColContent}, @{ColScore}, @{ColImage}, @{ColDifficulty},
            @{ColIdUser}, {ColIdRide})";

        public static readonly string ReqGetById = $"SELECT * FROM {TableName} WHERE {ColId} = @{ColId}";

        public static readonly string ReqUpdate =
            $"UPDATE {TableName}"
            + $" SET {ColContent} = @{ColContent}, {ColScore}, {ColImage}, {ColDifficulty}, {ColIdUser}, {ColIdRide}"
            + $" WHERE {ColId} = @{ColId}";

        public static readonly string ReqDelete = $"DELETE FROM {TableName} WHERE {ColId} = @{ColId}";
        
        private readonly CommentFactory _commentFactory = new CommentFactory();

        
        public List<Domain.Comment> GetAll()
        {
            var comments = new List<Domain.Comment>();

            using var connection = Database.GetConnection();
            connection.Open();

            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetAll
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                comments.Add(_commentFactory.CreateFromSqlDataReader(reader));
            }

            return comments;
        }

        public Domain.Comment GetById(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqGetById
            };
            
            command.Parameters.AddWithValue("@" + ColId, id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return reader.Read() ? _commentFactory.CreateFromSqlDataReader(reader) : null;

        }

        public Domain.Comment Create(Domain.Comment comment)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqCreateComment
            };
            
            command.Parameters.AddWithValue("@" + ColContent, comment.Content);
            command.Parameters.AddWithValue("@" + ColScore, comment.Score);
            command.Parameters.AddWithValue("@" + ColImage, comment.Image);
            command.Parameters.AddWithValue("@" + ColDifficulty, comment.Difficulty);
            command.Parameters.AddWithValue("@" + ColIdUser, comment.IdUser);
            command.Parameters.AddWithValue("@" + ColIdRide, comment.IdRide);

            comment.Id = (int) command.ExecuteScalar();

            return comment;
        }

        public bool Update(int id, Domain.Comment comment)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqUpdate
            };
            
            command.Parameters.AddWithValue("@" + ColId, id);
            command.Parameters.AddWithValue("@" + ColContent, comment.Content);
            command.Parameters.AddWithValue("@" + ColScore, comment.Score);
            command.Parameters.AddWithValue("@" + ColDifficulty, comment.Difficulty);
            command.Parameters.AddWithValue("@" + ColImage, comment.Image);
            command.Parameters.AddWithValue("@" + ColIdUser, comment.IdUser);
            command.Parameters.AddWithValue("@" + ColIdRide, comment.IdRide);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();
            
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = ReqDelete
            };
            
            command.Parameters.AddWithValue("@" + ColId, id);

            return command.ExecuteNonQuery() > 0;
        }
        
    }
}