using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Database
{
    public class personagemdatabase
    {
        Models.apidbContext ctx=new Models.apidbContext();
        public Models.TbFilmeAtor Inserir(Models.TbFilmeAtor tabela)
        {
            ctx.TbFilmeAtor.Add(tabela);
            ctx.SaveChanges();
            return tabela;
        }
        public Models.TbFilmeAtor ConsultarPorId (int id)
        {
            Models.TbFilmeAtor personagem=ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilmeAtor==id);

            return personagem;
        }
        public Models.TbFilmeAtor Alterar(Models.Request.personagemrequest req,int filmeid,int id)
        {
            Models.TbFilmeAtor atual=ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme==filmeid&&x.IdFilmeAtor==id);
            atual.IdAtor=req.ator;
            atual.IdFilme=req.Filme;
            atual.NmPersonagem=req.Personagem;
            ctx.SaveChanges();

            return atual;
        }
        public Models.TbFilmeAtor ConsultarPorIdNome(int filmeid,int id)
        {
          Models.TbFilmeAtor filmeAtor=ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme==filmeid&&x.IdFilmeAtor==id);
            return filmeAtor;
        }
        public Models.TbFilmeAtor DeletarPorId(int filmeid,int id)
        {
            Models.TbFilmeAtor tabela=ctx.TbFilmeAtor.FirstOrDefault(x=>x.IdFilme==filmeid&&x.IdFilmeAtor==id);
            ctx.TbFilmeAtor.Remove(tabela);
            ctx.SaveChanges();
            return tabela;
        }
    }
}