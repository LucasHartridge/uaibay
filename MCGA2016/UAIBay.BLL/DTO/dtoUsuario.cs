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
        public int IdRol { get; set; }

        public void Crear(dtoUsuario usuario)
        {
          

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var BIZ = Mapper.Map<dtoUsuario, bizUsuario>(usuario);

            var repository = new UsuarioRepository();
            var repositoryDir = new DireccionRepository();

            repository.Insertar(BIZ);
            repository.Save();


            //var nuevoUsuario = repository.UltimoUsuario();

            //BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            //var bizDir = Mapper.Map<dtoDireccion, bizDireccion>(usuario.Direccion.FirstOrDefault());

            //bizDir.UserId = nuevoUsuario.UserId;

            //repositoryDir.Insertar(bizDir);
            //repositoryDir.Save();

        }

        public List<dtoUsuario> TraerTodosLosUsuarios()
        {
            var repo = new UsuarioRepository();
            var biz = repo.ObtenerTodos();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoUsuario>>(biz);

            return DTO;
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

        public List<dtoVenta> MisCompras(int idUsuario)
        {
            var repository = new VentaRepository();
            var BIZ = repository.ObtenerTodos().Where(x => x.UserId == idUsuario).ToList();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var DTO = Mapper.Map<List<dtoVenta>>(BIZ);

            return DTO;
        }

        //public virtual ICollection<ActivityLog> ActivityLog { get; set; }
        //public virtual ICollection<DataLog> DataLog { get; set; }
        public virtual ICollection<dtoDireccion> Direccion { get; set; }
        //public virtual ICollection<ErrorLog> ErrorLog { get; set; }
        //public virtual ICollection<History> History { get; set; }
        //public virtual ICollection<TarjetaCredito> TarjetaCredito { get; set; }
        //public virtual ICollection<Venta> Venta { get; set; }
        public virtual dtoRoles Roles { get; set; }


    }
}
