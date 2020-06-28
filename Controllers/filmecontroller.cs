using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace apifilmes.Controllers
{
     [ApiController]
    [Route("[controller]")]
     public class filmecontroller:ControllerBase
    {
              [HttpPost]
              public Models.TbFilme inserir (Models.TbFilme filme)
              {
                  Models.apidbContext db=new Models.apidbContext();
                  db.Add(filme);
                  db.SaveChanges();
                  return filme;
              }
              [HttpGet]
              public List<Models.TbFilme> listar()
              {
                  Models.apidbContext db=new Models.apidbContext();
                  List<Models.TbFilme> filmes=db.TbFilme.ToList();
                  return filmes;
              }
              [HttpPut("{id}")]
              public Models.TbFilme alterar (int id,Models.TbFilme filme)
              {
                  Models.apidbContext context=new Models.apidbContext();
                  Models.TbFilme agora=context.TbFilme.First(x=>x.IdFilme ==id);
                  agora.NmFilme=filme.NmFilme;
                  agora.DsGenero=filme.DsGenero;
                  agora.VlAvaliacao=filme.VlAvaliacao;
                  agora.BtDisponivel=filme.BtDisponivel;
                  agora.NrDuracao=filme.NrDuracao;
                  agora.DtLancamento=filme.DtLancamento;
                  context.SaveChanges();
                  return agora;
              }
              
              public Models.TbFilme consultarid(int id)
               {
                   Models.apidbContext ctx=new Models.apidbContext();
                   Models.TbFilme filme=ctx.TbFilme.FirstOrDefault(x=>x.IdFilme==id);
                   return filme;
               }
                [HttpGet("filtrar")]
               public List<Models.TbFilme> filtrar (string nome,string genero)
               {
                     Models.apidbContext ctx=new Models.apidbContext();
                     List<Models.TbFilme> filmes=ctx.TbFilme.Where(x=>x.NmFilme.Contains(nome)&&x.DsGenero==genero)
                                                            .ToList();
                return filmes;
               }
               [HttpDelete("{id}")]
               public Models.TbFilme deletar(int id)
               {
                   Models.apidbContext ctx=new Models.apidbContext();
                   Models.TbFilme atual=ctx.TbFilme.FirstOrDefault(x=>x.IdFilme==id);
                   ctx.TbFilme.Remove(atual);
                   ctx.SaveChanges();
                   return atual;
               }

               

    }
}