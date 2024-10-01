using RosticeriaCardelV2.Clases;
using RosticeriaCardelV2.Contenedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Services
{
    public class VentaService
    {
        private readonly VentaRepository _ventaRepository;

        public VentaService(VentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        // Crear una nueva venta
        public void AddVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.Total <= 0)
                throw new ArgumentException("El total de la venta debe ser mayor que cero.");

            // Aquí puedes añadir más lógica de negocio si es necesario

            _ventaRepository.AddVenta(venta);
        }

        // Obtener todas las ventas
        public List<Venta> GetAllVentas()
        {
            return _ventaRepository.GetAllVentas();
        }

        // Obtener una venta por ID
        public Venta GetVentaById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la venta debe ser mayor que cero.");

            return _ventaRepository.GetVentaById(id);
        }

        // Actualizar una venta
        public void UpdateVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.IdVenta <= 0)
                throw new ArgumentException("El ID de la venta debe ser mayor que cero.");

            if (venta.Total <= 0)
                throw new ArgumentException("El total de la venta debe ser mayor que cero.");

            // Aquí puedes añadir más lógica de negocio si es necesario

            _ventaRepository.UpdateVenta(venta);
        }

        // Eliminar una venta
        public void DeleteVenta(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la venta debe ser mayor que cero.");

            // Aquí puedes añadir más lógica de negocio si es necesario

            _ventaRepository.DeleteVenta(id);
        }
    }
}
