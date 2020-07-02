using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Database
{
    public class filmedatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();
        public Models.TbFilme inserir(Models.TbFilme filme)
        {
            ctx.TbFilme.Add(filme);
            ctx.SaveChanges();
            return filme;
        }
        public List<Models.TbFilme> inserir2(List<Models.TbFilme> filmes)
        {
            filmes=ctx.TbFilme.ToList();
            Bussines.filmebussines bussines=new Bussines.filmebussines();
            bussines.inserir2(filmes);
            return filmes;
        }
        public Models.TbFilme inserir3(int id,Models.TbFilme tabela)
        {
            Models.TbFilme agora=ctx.TbFilme.First(x=>x.IdFilme==id);
            agora.NmFilme=tabela.NmFilme;
            agora.DsGenero=tabela.DsGenero;
            agora.VlAvaliacao=tabela.VlAvaliacao;
            agora.BtDisponivel=tabela.BtDisponivel;
            agora.NrDuracao=tabela.NrDuracao;
            agora.DtLancamento=tabela.DtLancamento;
            ctx.SaveChanges();
            Bussines.filmebussines bussines=new Bussines.filmebussines();
            bussines.inserir3(agora);
            return agora;
        }
        public Models.TbFilme inserir4(int id)
        {
            Models.TbFilme filme=ctx.TbFilme.FirstOrDefault(x=>x.IdFilme==id);
            Bussines.filmebussines bussines=new Bussines.filmebussines();
            return filme;
        }
        public void deletar(int id)
        {
            Models.TbFilme atual=ctx.TbFilme.FirstOrDefault(x=>x.IdFilme==id);
            ctx.TbFilme.Remove(atual);
            ctx.SaveChanges();
        }
        public List<Models.TbFilme> filtrar(string nome,string genero)
        {
             Bussines.filmebussines bussines=new Bussines.filmebussines();
            List<Models.TbFilme> filmes=ctx.TbFilme.Where(x=>x.NmFilme.Contains(nome)&&x.DsGenero.Contains(genero)).ToList();
            bussines.inserir4(filmes);
            return filmes;
        }
    }
}