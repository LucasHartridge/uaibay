using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.Repository;
using UAIBay.BIZ;

namespace UAIBay.BLL.DTO
{
    public class dtoRoles
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        //public virtual ICollection<dtoUsuario> Usuario { get; set; }



        public object TraerRoles()
        {
            var repository = new RolesRepository();
            var rolesBiz = repository.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var rolesDTO = Mapper.Map<List<dtoRoles>>(rolesBiz);

            return rolesDTO;
        }

        public void Crear(dtoRoles dtoRol)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var biz = Mapper.Map<dtoRoles, bizRoles>(dtoRol);

            var repository = new RolesRepository();
            repository.Insertar(biz);
            repository.Save();

        }

        public dtoRoles BuscarRol(int id)
        {
            var repo = new RolesRepository();
            var biz = repo.TraerPorId(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var dto = Mapper.Map<bizRoles, dtoRoles>(biz);

            return dto;
        }

        public dtoRoles BuscarRolCliente()
        {
            var repo = new RolesRepository();
            var biz = repo.TraerRolCliente();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var dto = Mapper.Map<bizRoles, dtoRoles>(biz);

            return dto;
        }

        public void Actualizar(dtoRoles dtoRol)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var biz = Mapper.Map<dtoRoles, bizRoles>(dtoRol);

            var repo = new RolesRepository();
            repo.Actualizar(biz);
            repo.Save();
        }

        public void Eliminar(dtoRoles dtoRol)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();

            var biz = Mapper.Map<dtoRoles, bizRoles>(dtoRol);

            var repo = new RolesRepository();
            repo.Eliminar(biz);
            repo.Save();
        }
    }
}
