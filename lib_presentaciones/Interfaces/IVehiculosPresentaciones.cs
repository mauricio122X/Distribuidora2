﻿using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IVehiculosPresentacion
    {
        Task<List<Vehiculos>> Listar();
        Task<List<Vehiculos>> PorCodigo(Vehiculos? entidad);
        Task<Vehiculos?> Guardar(Vehiculos? entidad);
        Task<Vehiculos?> Modificar(Vehiculos? entidad);
        Task<Vehiculos?> Borrar(Vehiculos? entidad);
    }
}