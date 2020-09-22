using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab15._2Creating_a_REST_API
{
    public class DAL
    {
        public static List<Movie> Read()
        {
            IDbConnection db = new SqlConnection("Server=CXJSN13\\SQLEXPRESS;Database=smallmovieDB;user id=da;password=P@$$word!@#;");
            db.Open();

            List<Movie> movie = db.GetAll<Movie>().ToList();
            return movie;

        }

        public static List<Movie> Read(string category)
        {
            IDbConnection db = new SqlConnection("Server=CXJSN13\\SQLEXPRESS;Database=smallmovieDB;user id=da;password=P@$$word!@#;");
            db.Open();

            List<Movie> movie = db.Query<Movie>($"select * from Movie where category like '%{category}%'").AsList();
            return movie;
        }

        public static List<Movie> Read(long id)
        {
            IDbConnection db = new SqlConnection("Server=CXJSN13\\SQLEXPRESS;Database=smallmovieDB;user id=da;password=P@$$word!@#;");
            db.Open();

            List<Movie> movie = db.Query<Movie>($"select * from Movie where id  = '{id}'").AsList();
            return movie;
        }

    }
}
