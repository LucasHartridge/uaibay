using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UAIBay.BIZ;
using UAIBay.Repository;

namespace UAIBay.BLL.DTO
{
   public class dtoUsuario
    {
        public int UserId { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public bool Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }

        public void Crear(dtoUsuario usuario)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoUsuario, bizUsuario>(usuario);

            var repository = new UsuarioRepository();
            repository.Insertar(BIZ);
            repository.Save();
        }

        public dtoUsuario BuscarUsuario(string email)
        {
            var repo = new UsuarioRepository();
            var biz = repo.TraerPorEmail(email);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var dto = Mapper.Map<bizUsuario, dtoUsuario>(biz);

            return dto;
        }

        public dtoUsuario BuscarCuenta(int id)
        {
            var repo = new UsuarioRepository();
            var biz = repo.TraerCuenta(id);

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var dto = Mapper.Map<bizUsuario, dtoUsuario>(biz);

            return dto;
        }

        public void Actualizar(dtoUsuario dtoUsuario)
        {
            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var biz = Mapper.Map<dtoUsuario, bizUsuario>(dtoUsuario);

            var repo = new UsuarioRepository();
            repo.Actualizar(biz);
            repo.Save();
        }



        //public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        //public virtual ICollection<DataLog> DataLog { get; set; }
        //public virtual ICollection<Direccion> Direccion { get; set; }
        //public virtual ICollection<ErrorLog> ErrorLog { get; set; }
        //public virtual ICollection<History> History { get; set; }
        //public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
        //public virtual ICollection<Venta> Venta { get; set; }
        public virtual ICollection<dtoRoles> Roles { get; set; }
    }
}
