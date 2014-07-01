using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace TestAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.AddProfile<PessoaProfiler>();
            var pessoas = new List<Pessoa>
            {
                new Pessoa {PrimeiroNome = "Alberto", SegundoNome = "Monteiro"}
            }.AsQueryable();

            foreach (var result in pessoas.Project().To<PessoaDTO>())
            {
                Console.WriteLine(result.NomeCompleto);
            }
        }
    }
}
