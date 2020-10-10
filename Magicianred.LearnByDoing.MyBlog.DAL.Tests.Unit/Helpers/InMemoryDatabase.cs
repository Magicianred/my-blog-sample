using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System.Collections.Generic;
using System.Data;

namespace Magicianred.LearnByDoing.MyBlog.DAL.Tests.Unit.Helpers
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory dbFactory =
            new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection OpenConnection() => this.dbFactory.OpenDbConnection();

        public void Init()
        {
            OrmLiteConfig.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();
        }

        public void Insert<T>(IEnumerable<T> items)
        {
            using (var db = this.OpenConnection())
            {
                /******************** For show table name ********************/
                var dialect = db.Dialect(); //older API db.GetDialectProvider()
                var tableName = dialect.GetQuotedTableName(nameof(T));
                //var columnName = dialect.GetQuotedColumnName(nameof(FooBar.BarFoo));

                var modelDef = typeof(T).GetModelMetadata();
                //var fieldDef = modelDef.GetFieldDefinition(nameof(FooBar.BarFoo));

                var tableName1 = dialect.GetQuotedTableName(modelDef);
                //var columnName = dialect.GetQuotedColumnName(modelDef, fieldDef);
                /******************** End show table name ********************/

                db.CreateTableIfNotExists<T>();
                foreach (var item in items)
                {
                    db.Insert(item);
                }
            }
        }
    }
}
