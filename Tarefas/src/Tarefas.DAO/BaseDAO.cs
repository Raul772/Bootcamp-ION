using System.Data.SQLite;

public abstract class BaseDAO{

    protected string DataSourceFile => Environment.CurrentDirectory + "AppTarefasDB.sqlite";
    public SQLiteConnection Connection => new SQLiteConnection("DataSource=" + DataSourceFile);

}