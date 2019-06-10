using System;
using System.Data;
using System.Data.SqlClient;
using DouglasStore.Shared;

namespace DouglasStore.Infra.DataContexts{
    public class DouglasDataContext : IDisposable{
        public SqlConnection Connection { get; set; }
        
        public DouglasDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
    
        public void Dispose()
        {
            if(Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}