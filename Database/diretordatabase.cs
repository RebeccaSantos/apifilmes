using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Database
{
    
    public class diretordatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbDiretor Inserir(Models.TbDiretor diretor)
        {
          ctx.TbDiretor.Add(diretor);
          ctx.SaveChanges();
          return diretor;
        }
        public Models.TbDiretor Consultar(string nome)
        {
           Bussines.diretorbussines bussines=new Bussines.diretorbussines();
           Models.TbDiretor diretor=ctx.TbDiretor.FirstOrDefault(x=>x.NmDiretor.Contains(nome));
            bussines.Consultar(diretor);
            return diretor;
        }
        public Models.TbDiretor alterar(int id,Models.TbDiretor tabela)
        {
          Models.TbDiretor agora=ctx.TbDiretor.First(x=>x.IdDiretor==id);
          agora.IdFilme=tabela.IdFilme;
          agora.NmDiretor=tabela.NmDiretor;
          agora.DtNascimento=tabela.DtNascimento;
          ctx.SaveChanges();

          return agora;

        }
        public Models.TbDiretor ConsultarId(int id)
        {
          Models.TbDiretor retornar=ctx.TbDiretor.First(x=>x.IdDiretor==id);
          return retornar;
        }
        public Models.TbDiretor DeletarPorId(int id)
        {
          Models.TbDiretor remover=ctx.TbDiretor.FirstOrDefault(x=>x.IdDiretor==id);
          ctx.Remove(remover);
          ctx.SaveChanges();
          return remover;
        }
        
    }
}