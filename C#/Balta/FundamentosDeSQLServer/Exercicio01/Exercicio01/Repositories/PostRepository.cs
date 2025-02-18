using Dapper;
using Dapper.Contrib.Extensions;
using Exercicio01.Models;
using Microsoft.Data.SqlClient;

namespace Exercicio01.Repositories;

internal class PostRepository : Repository<Post> {
    private readonly SqlConnection _connection;

    public PostRepository(SqlConnection connection) : base(connection) {
        _connection = connection;
    }

    public IEnumerable<Post> GetPostFromPeson(int authorId) {
        var query = @"SELECT 
                        [Title],
                        [Summary],
                        [Body],
                        [CreateDate]
                    FROM
                        [Post]
                    WHERE
                        [AuthorId] = @AuthorId";

        var posts = _connection.Query<Post>(query, new { AuthorId = authorId });
        return posts;
    }

    public IEnumerable<Post> GetPosts() {
        var query = @"SELECT 
                            [Post].[Title],
                            [Post].[Summary],
                            [Post].[Body],
                            [Post].[CreateDate],
                            [User].[Name]
                        FROM
                            [Post]
                            Inner Join [User] ON [User].[Id] = [Post].[AuthorId]";

        var posts = _connection.Query<Post, User, Post>(
            query,
            (post, user) => {
                post.User = user;
                return post;
            }, splitOn: "Name"
        );

        return posts;
    }
}