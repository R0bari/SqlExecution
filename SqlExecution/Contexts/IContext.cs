using System;
using System.Data.Entity;

namespace SqlExecution.Contexts
{
    internal interface IExecute
    {
        int Execute(string sqlCommand, params object[] parameters);
    }
}
