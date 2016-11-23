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
    public class dtoDireccion
    {
        public int IDDireccion { get; set; }
        public int UserId { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }

        //public virtual dtoUsuario Usuario { get; set; }





        public void Crear(dtoDireccion dto, int UserId)
        {
            var repositoryDir = new DireccionRepository();

            BLL.Mapeador.AutoMapperBLLConfiguration.Configure();
            var bizDir = Mapper.Map<dtoDireccion, bizDireccion>(dto);

            bizDir.UserId = UserId;

            repositoryDir.Insertar(bizDir);
            repositoryDir.Save();
          
        }
    }
}
