﻿using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repositories.Comment
{
    public class CommentFactory 
    {
        public Domain.Comment CreateFromSqlDataReader(SqlDataReader reader)
        {
            return new Domain.Comment()
            {
                Id = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColId)),
                Content = reader.GetString(reader.GetOrdinal(CommentRepository.ColContent)),
                Score = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColScore)),
                Image = reader.GetString(reader.GetOrdinal(CommentRepository.ColImage)),
                Difficulty = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColDifficulty)),
                IdUser = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColIdUser)),
                IdRide = reader.GetInt32(reader.GetOrdinal(CommentRepository.ColIdRide))

            };
        }
    }
}