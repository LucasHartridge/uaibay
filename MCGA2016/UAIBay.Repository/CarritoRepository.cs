﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;
using UAIBay.ORM.Context;
using UAIBay.BIZ;
using AutoMapper;

namespace UAIBay.Repository
{
    public class CarritoRepository : Repository<Carrito>
    {
        private readonly UAIBayContext contexto = new UAIBayContext();


        public void CrearCarrito(bizCarrito objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizCarrito, Carrito>(objeto);

            ORM.CreatedOn = DateTime.Now;

            contexto.Carritos.Add(ORM);
        }

        public List<bizCarrito> ObtenerTodos()
        {

            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Carritos.ToList();

            var BIZ = Mapper.Map<List<bizCarrito>>(ORM);

            return BIZ;

        }

        public bizCarrito TraerPorId(int idUser)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = contexto.Carritos.Where(x => x.UserId == idUser).ToList().FirstOrDefault();

            if (ORM != null)
            {
                var BIZ = Mapper.Map<Carrito, bizCarrito>(ORM);
                return BIZ;
            }

            return null;
        }

        public void AgregarProducto(bizItemCarrito objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizItemCarrito, ItemCarrito>(objeto);

            contexto.ItemCarrito.Add(ORM);

            var repoProducto = new ProductoRepository();
            var producto = repoProducto.BuscarUnORMProducto(objeto.CodProducto);
            producto.Cantidad -= 1;
            repoProducto.Actualizar(producto);
            repoProducto.Save();

        }

        public void ActualizarProducto(bizItemCarrito objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizItemCarrito, ItemCarrito>(objeto);

            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;

            var repoProducto = new ProductoRepository();
            var producto = repoProducto.BuscarUnORMProducto(objeto.CodProducto);
            producto.Cantidad -= 1;
            repoProducto.Actualizar(producto);
            repoProducto.Save();

        }


        public void QuitarProducto(int codProducto, int nroCarrito)
        {

            ItemCarrito item = (ItemCarrito)contexto.ItemCarrito.Where(b => b.IdCarrito == nroCarrito && b.CodProducto == codProducto).First();

            contexto.ItemCarrito.Remove(item);
        }

        public void Actualizar(bizCarrito objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizCarrito, Carrito>(objeto);

            ORM.LastUpdate = DateTime.Now;

            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        public void Eliminar(bizCarrito objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();

            List<ItemCarrito> items = (List<ItemCarrito>)contexto.ItemCarrito.Where(b => b.IdCarrito == objeto.IdCarrito).ToList();

            foreach (var item in items)
            {
                contexto.ItemCarrito.Remove(item);
            }

            Carrito carrito = (Carrito)contexto.Carritos.Where(b => b.IdCarrito == objeto.IdCarrito).First();
            contexto.Carritos.Remove(carrito);
            contexto.SaveChanges();
        }

        public void QuitarTodosLosProductos(int IdCarrito)
        {

            List<ItemCarrito> items = (List<ItemCarrito>)contexto.ItemCarrito.Where(b => b.IdCarrito == IdCarrito).ToList();

            foreach (var item in items)
            {
                contexto.ItemCarrito.Remove(item);
            }

        }

        public void Save()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                string texto = e.ToString();
                throw e;
            }
        }



    }
}
