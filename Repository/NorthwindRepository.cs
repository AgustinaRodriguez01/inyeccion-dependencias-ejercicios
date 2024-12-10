using inyeccion_dependencias_ejercicios.DataContext;
using inyeccion_dependencias_ejercicios.Model;
using inyeccion_dependencias_ejercicios.QueryResponse;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace inyeccion_dependencias_ejercicios.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNorthwind _dataContext;

        public NorthwindRepository(DataContextNorthwind dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Employees>> ObtenerTodosEmpleados()
        {
            var result =  from emp in _dataContext.Employees
                          select emp;
            return await result.ToListAsync();
        }

        public async Task<int> ObtenerCantidadEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorID(int id)
        {
            var result = await _dataContext.Employees.Where(x => x.EmployeeID == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorNombre(string name)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == name);
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorTitulo(string title)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Title == title
                         select emp;
            return await result.FirstOrDefaultAsync();
        }

        public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> ObtenerEmpleadosPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName
                         };
            return await result.ToListAsync();
        }

        public async Task<Employees> ObtenerEmpleadoMasGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             BirthDate = emp.BirthDate
                         };
            return await result.FirstOrDefaultAsync();
        }


        public async Task<List<EmployeesTitleCount>> ObtenerCantidadEmpleadosPorTitulo()
        {
            var result = from emp in _dataContext.Employees
                         group emp by emp.Title into g
                         select new EmployeesTitleCount
                         {
                             Title = g.Key,
                             Count = g.Count()
                         };
            return await result.ToListAsync();
        }

        public async Task<List<ProductsCategories>> ObtenerProductosConCategorias()
        {
            var result = from pro in _dataContext.Products
                         join cat in _dataContext.Categories on pro.CategoryID equals cat.CategoryID
                         select new ProductsCategories
                         {
                             ProductName = pro.ProductName,
                             CategoryName = cat.CategoryName
                         };

            return await result.ToListAsync();
        }

        public async Task<List<Products>> ObtenerProductosConChef()
        {
            var result = from pro in _dataContext.Products
                         where pro.ProductName.Contains("Chef")
                         select new Products
                         {
                             ProductID = pro.ProductID,
                             ProductName = pro.ProductName,
                             UnitPrice = pro.UnitPrice

                         };
            return await result.ToListAsync();
        }

        public async Task<bool> EliminarOrdenPorID (int orderId)
        {
            Orders? order = await _dataContext.Orders.Where(ord => ord.OrderID == orderId).FirstOrDefaultAsync();
            OrderDetails? orderDetail = await _dataContext.OrderDetails.Where(od => od.OrderID == orderId).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(orderDetail);
            _dataContext.Orders.Remove(order);

            var result = await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActualizarNombreEmpleado (int empleadoId, string empleadoNombre)
        {
            bool actualizado = false;

            Employees? employee = await _dataContext.Employees.Where(emp => emp.EmployeeID == empleadoId).FirstOrDefaultAsync();

            if (employee != null)
            {
                employee.FirstName = empleadoNombre;
                var result = await _dataContext.SaveChangesAsync();
                actualizado = true;
            }

            return actualizado;
        }

        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.FirstName = "Juan";
            employee.LastName = "Perez";
            employee.Title = "Sales Representative";
            employee.Country = "Argentina";
            employee.HireDate = DateTime.Now;
            employee.BirthDate = new DateTime(1980, 1, 1);

            var newEmployee = await _dataContext.Employees.AddAsync(employee);
            var result = await _dataContext.SaveChangesAsync();

            return (result > 0);
        }
    }
}
