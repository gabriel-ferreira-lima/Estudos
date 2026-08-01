using Aula01.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula01 {

    internal class Program {

        private static void Main(string[] args) {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=Gordaojoga10;Trusted_Connection=False;TrustServerCertificate=True;";
            // Microsoft.Data.SqlClient
            // dotnet add package Microsoft.data.sqlclient instalando o pacote do SQL server no c#

            /*
            // Metodo raiz para fazer uma query, muito verboso, pouco usado
            using (var connection = new SqlConnection(connectionString)) {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
            */

            // Utilizando Dapper
            // abrindo conexão com o banco e executando o método.
            using (var connection = new SqlConnection(connectionString)) {
                //CreateManyCategory(connection);
                //ListCategories(connection);
                //CreateCategory(connection);
                //ExecuteProcedure(connection);
                //ListCategories(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteScalar(connection);
                //OneToOne(connection);
                //oneToMany(connection);
                //SelectIn(connection);
                //Like(connection, "api");
                Transaction(connection);

            }
        }

        // Criando um simples select utilizando Dapper
        private static void ListCategories(SqlConnection connection) {
            var categories = connection.Query<Category>("Select [Id], [Title] FROM [Category]");
            foreach (var item in categories) {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        // Fazendo um insert into utilizando Dapper
        private static void CreateCategory(SqlConnection connection) {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            // ponto importante abaixo, sempre que for fazer o insert into, trabalhar com variaveis dentro da query para evitar sql injection (ataque cibernetico)
            var insertSql = @"INSERT INTO
                                [Category]
                            VALUES(
                                @Id,
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";

            var rows = connection.Execute(insertSql, new {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }

        // Fazendo um update utilizando Dapper
        private static void UpdateCategory(SqlConnection connection) {
            var updateQuery = "Update [Category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Frontend 2024"
            });

            Console.WriteLine($"{rows} registros atualizados");
        }

        // Fazendo um delete utilizando Dapper
        private static void DeleteCategory(SqlConnection connection) {
            var deleteQuery = "DELETE FROM [Category] where [Id] =@Id";

            var rows = connection.Execute(deleteQuery, new {
                Id = new Guid("89c4ea83-befd-4202-b67f-d6a39c495596")
            });

            Console.WriteLine($"{rows} linhas afetadas");
        }

        // Fazendo um insert multiplo utilizando Dapper
        private static void CreateManyCategory(SqlConnection connection) {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = "Categoria Nova";
            category2.Url = "categoria-nova";
            category2.Description = "Categoria nova";
            category2.Order = 9;
            category2.Summary = "Categoria";
            category2.Featured = true;

            var insertSql = @"INSERT INTO
                                [Category]
                            VALUES(
                                @Id,
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";

            var rows = connection.Execute(insertSql, new[]{
                new{
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            },
                new{
                category2.Id,
                category2.Title,
                category2.Url,
                category2.Summary,
                category2.Order,
                category2.Description,
                category2.Featured
            }});
            Console.WriteLine($"{rows} linhas inseridas");
        }

        // Fazendo um update utilizando um Procedure utilizando Dapper
        private static void ExecuteProcedure(SqlConnection connection) {
            var procedure = "spDeleteStudent";
            var pars = new { StudentId = "fc06e52f-6fef-4313-ba63-448e78422f9d" };
            var rows = connection.Execute(
                procedure,
                pars,
                commandType: System.Data.CommandType.StoredProcedure);

            Console.WriteLine($"{rows} - linhas afetadas");
        }

        // Fazendo um select utilizando umna Procedure utilizando Dapper
        private static void ExecuteReadProcedure(SqlConnection connection) {
            var procedure = "spGetCoursesByCategory";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var course = connection.Query(
                procedure,
                pars,
                commandType: System.Data.CommandType.StoredProcedure);

            foreach (var item in course) {
                Console.WriteLine(item.Title);
            }
        }

        // usado para quando é necessario fazer um insert e obter o ID logo na sequencia.
        private static void ExecuteScalar(SqlConnection connection) {
            var category = new Category();
            category.Title = "Amazon AWS";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                                [Category]
                            OUTPUT INSERTED.[Id] /* Esse comando é bom para ter o retorno do ID que eu acabei de inserir no banco, só serve para id GUID */
                            VALUES(
                                NEWID(),
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";
            // SELECT SCOPE_IDENTITY() <<-- Esse comando é bom para ter o retorno do ID que eu acabei de inserir no banco, só serve para id INT

            var id = connection.ExecuteScalar<Guid>(insertSql, new {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"A categoria inserida foi: {id}");
        }

        // Utilizando Inner Join ligação 1:1
        private static void OneToOne(SqlConnection connection) {
            var sql = @"SELECT
                            *
                        FROM
                            [CareerItem]
                        INNER JOIN
                            [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

            //Importante para quando se é necessario fazer um join com informação de duas tabelas,
            // a sintax do metodo query seria, eu quero coletar dados de carrerItem e de course,
            // que esta dentro de carrerItem
            var itens = connection.Query<CareerItem, Course, CareerItem>(
                sql,
                (careerItem, course) => {
                    careerItem.Course = course;
                    return careerItem;
                }, splitOn: "Id");

            foreach (var item in itens) {
                Console.WriteLine($"{item.Title}\r\n   -{item.Course.Title}");
                Console.WriteLine();
            }
        }

        // Utilizando InnerJoin ligação 1:N
        private static void OneToMany(SqlConnection connection) {
            var sql = @"SELECT
                            [Career].[Id],
                            [Career].[Title],
                            [CareerItem].[CareerId],
                            [CareerItem].[Title]
                        FROM
                            [Career]
                        INNER JOIN
                            [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
                        ORDER BY
                            [Career].[Title]";

            var careers = new List<Career>();
            var items = connection.Query<Career, CareerItem, Career>(
                sql,
                (career, item) => {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null) {
                        car = career;
                        car.Items.Add(item);
                        careers.Add(car);
                    }
                    else {
                        car.Items.Add(item);
                    }
                    return career;
                }, splitOn: "CareerId");

            foreach (var career in careers) {
                Console.WriteLine(career.Title);
                foreach (var item in career.Items) {
                    Console.WriteLine($" - {item.Title}");
                }
            }
        }

        // Utilizando ligação N:N
        private static void QueryMultiple(SqlConnection connection) {
            var query = "SELECT * FROM [Category]; Select * from [Course]";

            using (var multi = connection.QueryMultiple(query)) {
                var categories = multi.Read<Category>();
                var courses = multi.Read<Course>();

                foreach (var item in categories) {
                    Console.WriteLine(item.Title);
                }

                foreach (var item in courses) {
                    Console.WriteLine(item.Title);
                }
            }
        }

        // Fazendo um select usando In
        private static void SelectIn(SqlConnection connection) {
            var sql = @"select * from Career where Id IN @Id";

            var items = connection.Query<Career>(sql, new {
                Id = new[] {
                    "4327ac7e-963b-4893-9f31-9a3b28a4e72b",
                    "e6730d1c-6870-4df3-ae68-438624e04c72"
                }
            });

            foreach (var item in items) {
                Console.WriteLine(item.Title);
            }
        }

        // Fazendo um select usando like
        private static void Like(SqlConnection connection, string term) {

            var sql = "SELECT * FROM [Course] WHERE Title Like @expression";

            var query = connection.Query<Course>(sql, new {

                expression = $"%{term}%"
            });

            foreach (var item in query) {
                Console.WriteLine(item.Title);
            }
        }

        // Fazendo uma transaction
        private static void Transaction(SqlConnection connection) {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Minha categoria não vai salvar";
            category.Url = "Amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            // ponto importante abaixo, sempre que for fazer o insert into, trabalhar com variaveis dentro da query para evitar sql injection (ataque cibernetico)
            var insertSql = @"INSERT INTO
                                [Category]
                            VALUES(
                                @Id,
                                @Title,
                                @Url,
                                @Summary,
                                @Order,
                                @Description,
                                @Featured)";

            connection.Open();
            using (var transaction = connection.BeginTransaction()) {
                var rows = connection.Execute(insertSql, new {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                }, transaction);
                //transaction.Commit();
                transaction.Rollback ();

                Console.WriteLine($"{rows} linhas inseridas");
            }          
        }
    }
}