using RosticeriaCardelV2.Contenedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosticeriaCardelV2.Conexion
{
    public class SyncService
    {
        private readonly ProductoRepository _productoRepository;
        private readonly VentaRepository _ventaRepository;
        private readonly int _syncIntervalMilliseconds;
        private bool _isRunning;

        public SyncService(ProductoRepository productoRepository, VentaRepository ventaRepository, int syncIntervalMilliseconds = 6000)
        {
            _productoRepository = productoRepository;
            _ventaRepository = ventaRepository;
            _syncIntervalMilliseconds = syncIntervalMilliseconds;
        }

        public void Start()
        {
            if (_isRunning)
                return;

            _isRunning = true;
            Task.Run(async () =>
            {
                while (_isRunning)
                {
                    try
                    {
                        await _productoRepository.SyncProductosToCloudAsync();
                        await _ventaRepository.SyncSalesToCloudAsync();
                    }
                    catch (Exception ex)
                    {
                        // Log o manejo de errores
                        Console.WriteLine($"Error durante la sincronización: {ex.Message}");
                    }

                    // Esperar el intervalo antes de la próxima sincronización
                    await Task.Delay(_syncIntervalMilliseconds);
                }
            });
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
