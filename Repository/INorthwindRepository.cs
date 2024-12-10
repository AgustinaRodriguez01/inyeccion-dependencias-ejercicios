using inyeccion_dependencias_ejercicios.Model;
using inyeccion_dependencias_ejercicios.QueryResponse;

namespace inyeccion_dependencias_ejercicios.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosEmpleados();

        Task<int> ObtenerCantidadEmpleados();

        Task<Employees> ObtenerEmpleadoPorID(int id);

        Task<Employees> ObtenerEmpleadoPorNombre(string name);

        Task<Employees> ObtenerEmpleadoPorTitulo(string title);

        Task<Employees> ObtenerEmpleadoPorPais(string country);

        Task<List<Employees>> ObtenerEmpleadosPorPais(string country);

        Task<Employees> ObtenerEmpleadoMasGrande();

        Task<List<EmployeesTitleCount>> ObtenerCantidadEmpleadosPorTitulo();

        Task<List<ProductsCategories>> ObtenerProductosConCategorias();

        Task<List<Products>> ObtenerProductosConChef();

        Task<bool> EliminarOrdenPorID(int orderId);

        Task<bool> ActualizarNombreEmpleado(int empleadoId, string empleadoNombre);

        Task<bool> InsertarEmpleado();
    }
}
