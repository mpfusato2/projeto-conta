using Microsoft.Data.Sqlite;
using System.Text;

namespace Questao5.Infrastructure.Database.Repository
{
    public class SqLiteBaseRepository
    {
        public static string DbFile { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\database.sqlite";

        public static SqliteConnection SimpleDbConnection()
        => new SqliteConnection("Data Source=" + DbFile);

        internal static bool CriarArquivoDb()
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(DbFile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(DbFile));

                if (!File.Exists(DbFile))
                {
                    StreamWriter file = new StreamWriter(DbFile, true, Encoding.Default);
                    file.Dispose();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
