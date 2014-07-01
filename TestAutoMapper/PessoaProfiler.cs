using AutoMapper;

namespace TestAutoMapper
{
    class PessoaProfiler : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Pessoa, PessoaDTO>()
                .ForMember(para => para.PrimeiroNome, de => de.MapFrom(p => p.PrimeiroNome))
                .ForMember(para => para.SegundoNome, de => de.MapFrom(p => p.SegundoNome))
                .ForMember(para => para.NomeCompleto, de => de.DecompileMap(p => p.NomeCompleto));
            //.ForMember(para => para.NomeCompleto, de => de.MapFrom(p => p.NomeCompleto));

            base.Configure();
        }
    }
}