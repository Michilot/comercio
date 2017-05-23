using AutoMapper;

namespace EC.ElComercio.AutoMapper
{
    public class AutoMapperConfig
    {

        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
                                {
                                    cfg.AddProfile<DomainToViewModelMapperProfile>();
                                    cfg.AddProfile<ViewModelToDomainMapperProfile>();
                                }
                             );
        }


    }
}

