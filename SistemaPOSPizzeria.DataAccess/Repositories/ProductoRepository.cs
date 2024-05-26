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
    public class ProductoRepository:IProductoRepository
    {
        private readonly SistemaPOSPizzeriaContext _context;
        public ProductoRepository(SistemaPOSPizzeriaContext context)
        {
            _context = context;
        }
        public IEnumerable<Producto> ProductosList()
        {
            try
            {
                IEnumerable<Producto> productos = _context.Productos.FromSqlRaw(StoreProcedures.ProductosList).ToList();

                return productos;
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public int Insert(Producto model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ProductosInsert,
                    new SqlParameter("@producto_nombre ", model.Producto_Nombre),
                    new SqlParameter("@producto_descripcion", model.Producto_Descripcion),
                    new SqlParameter("@producto_precio", model.Producto_Precio),
                    new SqlParameter("@producto_stok", model.Producto_Stok),
                    new SqlParameter("@producto_Imagen", model.Producto_Imagen));



                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }
        public int Update(Producto model)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ProductosUpdate,
                    new SqlParameter("@producto_id", model.Producto_Id),
                    new SqlParameter("@producto_nombre", model.Producto_Nombre),
                    new SqlParameter("@producto_descripcion", model.Producto_Descripcion),
                    new SqlParameter("@producto_precio", model.Producto_Precio),
                    new SqlParameter("@producto_stok", model.Producto_Stok),
                    new SqlParameter("@producto_Imagen", model.Producto_Imagen)
                    );

                return result;

            }
            catch (Exception e)
            {
                string error = e.Message;
                return -1;
            }
        }

        public int Delete(int producto_Id)
        {
            int result = 0;
            try
            {

                result = _context.Database.ExecuteSqlRaw(StoreProcedures.ProductosDelete,
                     new SqlParameter("@producto_id", producto_Id));

                return result;

            }
            catch (Exception)
            {
                return -1;
            }
        }

    }
}
