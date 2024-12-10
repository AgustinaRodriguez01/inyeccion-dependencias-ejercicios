using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using inyeccion_dependencias_ejercicios.Repository;
using inyeccion_dependencias_ejercicios.Model;
using inyeccion_dependencias_ejercicios.QueryResponse;

namespace inyeccion_dependencias_ejercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosEmpleados()
        {
            return await _repository.ObtenerTodosEmpleados();
        }

        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadEmpleados()
        {
            return await _repository.ObtenerCantidadEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorID")]
        public async Task<Employees> ObtenerEmpleadoPorID([FromQuery] int id)
        {
            return await _repository.ObtenerEmpleadoPorID(id);
        }

        [HttpGet]
        [Route("api/EmpleadoPorNombre")]
        public async Task<Employees> ObtenerEmpleadoPorNombre([FromQuery] string name)
        {
            return await _repository.ObtenerEmpleadoPorNombre(name);
        }

        [HttpGet]
        [Route("api/EmpleadoPorTitulo")]
        public async Task<Employees> ObtenerEmpleadoPorTitulo([FromQuery] string title)
        {
            return await _repository.ObtenerEmpleadoPorTitulo(title);
        }

        [HttpGet]
        [Route("api/EmpleadoPorPais")]
        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadoPorPais(country);
        }

        [HttpGet]
        [Route("api/EmpleadosPorPais")]
        public async Task<List<Employees>> ObtenerEmpleadosPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadosPorPais(country);
        }

        [HttpGet]
        [Route("api/EmpleadoMasGrande")]
        public async Task<Employees> ObtenerEmpleadoMasGrande()
        {
            return await _repository.ObtenerEmpleadoMasGrande();
        }

        [HttpGet]
        [Route("api/CantidadEmpleadosPorTitulo")]
        public async Task<List<EmployeesTitleCount>> ObtenerCantidadEmpleadosPorTitulo()
        {
            return await _repository.ObtenerCantidadEmpleadosPorTitulo();
        }

        [HttpGet]
        [Route("api/ProductosConCategorias")]
        public async Task<List<ProductsCategories>> ObtenerProductosConCategorias()
        {
            return await _repository.ObtenerProductosConCategorias();
        }

        [HttpGet]
        [Route("api/ProductosConChef")]
        public async Task<List<Products>> ObtenerProductosConChef()
        {
            return await _repository.ObtenerProductosConChef();
        }

        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([FromQuery] int orderId)
        {
            return await _repository.EliminarOrdenPorID(orderId);
        }

        [HttpPut]
        [Route("api/ActualizarNombreEmpleado")]
        public async Task<bool> ActualizarNombreEmpleado([FromQuery] int empleadoId, [FromQuery] string empleadoNombre)
        {
            return await _repository.ActualizarNombreEmpleado(empleadoId, empleadoNombre);
        }

        [HttpPost]
        [Route("api/InsertarEmpleado")]
        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }
    }
}
