using AutoMapper;
using EC.ElComercio.Models;
using EC.MVC.Domain.Entities;

namespace EC.ElComercio.AutoMapper
{
    public class ViewModelToDomainMapperProfile : Profile
    {
        public ViewModelToDomainMapperProfile()
        {
            CreateMap<Banco, BancoModel>();
            CreateMap<Sucursal, SucursalModel>().ForMember(pts => pts.Banco, opt => opt.MapFrom(ps => ps.Banco)); ;

            CreateMap<OrdenPago, OrdenPagoModel>()
                .ForMember(pts => pts.Sucursal, opt => opt.MapFrom(ps => ps.Sucursal))
                .ForMember(pts => pts.Estado, opt => opt.MapFrom(ps => ps.Estado))
                .ForMember(pts => pts.Moneda, opt => opt.MapFrom(ps => ps.Moneda));
        }

    }
}
