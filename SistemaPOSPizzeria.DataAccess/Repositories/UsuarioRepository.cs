using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaPOSPizzeria.DataAccess.Helper;
using SistemaPOSPizzeria.DataAccess.Interfaces;
using SistemaPOSPizzeria.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOSPizzeria.DataAccess.Repositories
{
   public  class UsuarioRepository:IUsuarioRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;
        public UsuarioRepository(SistemaPOSPizzeriaContext context)
        {
            _context = context;
        }
        public int Insert(Usuario model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.UsuarioInsert,
                    new SqlParameter("@usuario_nombre", model.UsuarioNombre),
                    new SqlParameter("@usuario_password", model.UsuarioPassword)
                    );

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }
        public UserResponseAuth Login(Usuario model)
        {
            
           
                try
                {
                    var response = _context.UsuarioResponse.FromSqlRaw(StoreProcedures.UsuarioLogin,
                         new SqlParameter("@usuario_nombre", model.UsuarioNombre),
                    new SqlParameter("@usuario_password", model.UsuarioPassword)).AsEnumerable().FirstOrDefault();
             
                    return response;
                }
            catch (Exception e)
            {
                string error = e.Message;
                throw;
            }
        }
    }
}
