using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Database
{
    public class atordatabase
    {
        Models.apidbContext ctx=new Models.apidbContext();

        public Models.TbAtor Inserir(Models.TbAtor tabela)
        {

            ctx.TbAtor.Add(tabela);
            ctx.SaveChanges();

            return tabela;
        }
        public Models.TbAtor ConsultarPorNome(string nome)
        {
              Models.TbAtor tabela=ctx.TbAtor.FirstOrDefault(x=>x.NmAtor==nome);

              return tabela;   
        }
        public Models.TbAtor AlterarPorId (int id,Models.TbAtor ator)
        {
            Models.TbAtor tabela=ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==id);
            tabela.NmAtor=ator.NmAtor;
            tabela.VlAltura=ator.VlAltura;
            tabela.DtNascimento=ator.DtNascimento;

            ctx.SaveChanges();

            return tabela;
        }
        public Models.TbAtor ConsultarPorId(int id)
        {
            Models.TbAtor tabela=ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==id);

            return tabela;
        }
        public Models.TbAtor DeletarPorID(int id)
        {
            Models.TbAtor tabela=ctx.TbAtor.FirstOrDefault(x=>x.IdAtor==id);

            ctx.TbAtor.Remove(tabela);
            ctx.SaveChanges();
            return tabela;
        }
    }
}