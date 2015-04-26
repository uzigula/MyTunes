using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunes.Repository.ADO
{
    public interface IDatabaseContext : IDisposable
    {
        /// <summary>
        /// permite la ejecucion de un comando sql, usado para operaciones que no devuelven resultados
        /// </summary>
        /// <param name="command"> la cadena sql que se quiere ejecutar</param>
        void ExecuteCommand(string command, Parameter[] parameters);  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">consulta sql</param>
        /// <param name="parameters"> arreglo de parametros</param>
        /// <returns></returns>
        IDataReader ExecuteQuery(string query, Parameter[] parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"> consulta sql</param>
        /// <param name="parameters">arregloparametros</param>
        /// <returns></returns>
        object ExecuteScalar(string query, Parameter[] parameters);


    }
}
