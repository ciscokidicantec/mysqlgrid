using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace mysqlgrid
{
    internal class MySqlCommand
    {
        private string rtn;
        private MySqlConnection conn;
        private string query;

        public MySqlCommand()
        {
        }

        public MySqlCommand(string rtn, MySqlConnection conn)
        {
            this.rtn = rtn;
            this.conn = conn;
        }

        public MySqlCommand(string query)
        {
            this.query = query;
        }

        public MySqlConnection Connection { get; internal set; }
        public CommandType CommandType { get; internal set; }
        public object Parameters { get; internal set; }
        public string CommandText { get; internal set; }

        internal MySqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        internal int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}