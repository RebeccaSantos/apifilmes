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
    }
}