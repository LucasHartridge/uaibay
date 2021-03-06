﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIBay.ORM.Business;
using AutoMapper;
using UAIBay.BIZ;
using UAIBay.ORM.Context;

namespace UAIBay.Repository
{
    public class VentaRepository : Repository<Venta>
    {

        private readonly UAIBayContext contexto = new UAIBayContext();


        public List<bizVenta> ObtenerTodos()
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = contexto.Ventas.ToList();

            var biz = Mapper.Map<List<bizVenta>>(orm);

            return biz;

        }

        public bizVenta TraerPorId(int id)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var orm = contexto.Ventas.Find(id);
            var biz = Mapper.Map<Venta, bizVenta>(orm);

            return biz;
        }


        public int NroUltimaVenta()
        {
            var idMax = contexto.Ventas.Max(x => x.NroVenta);

            return idMax;

        }

        public void Insertar(bizVenta objeto)
        {

            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizVenta, Venta>(objeto);

            ORM.CreatedOn = DateTime.Now;
            ORM.CreatedBy = objeto.UserId;
            ORM.UserId = objeto.UserId;

            using (var t = contexto.Database.BeginTransaction())
            {
                try
                {
                    contexto.Ventas.Add(ORM);
                    contexto.SaveChanges();

                    t.Commit();
                }
                catch (Exception)
                {
                    t.Rollback();
                }

            }
        }


        public void Actualizar(bizVenta objeto)
        {
            Mapeador.AutoMapperORMConfiguration.Configure();
            var ORM = Mapper.Map<bizVenta, Venta>(objeto);

            ORM.ChangedBy = objeto.UserId;
            ORM.ChangedOn = DateTime.Now;

            contexto.Entry(ORM).State = System.Data.Entity.EntityState.Modified;
        }

        //public void Eliminar(bizCategoria objeto)
        //{
        //    Mapeador.AutoMapperORMConfiguration.Configure();

        //    Categoria categoria = (Categoria)contexto.Categorias.Where(b => b.IdCategoria == objeto.IdCategoria).First();
        //    contexto.Categorias.Remove(categoria);
        //    contexto.SaveChanges();
        //}

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
