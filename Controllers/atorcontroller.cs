using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class atorcontroller:ControllerBase
    {
         Database.atordatabase database=new Database.atordatabase();
         Bussines.atorbussines bussines=new Bussines.atorbussines();
         utils.atorconversor conversor=new utils.atorconversor();

        [HttpPost]
        public ActionResult<Models.Response.atorresponse> Inserir(Models.Request.atorrequest req)
        {
           try
           {
                    Models.TbAtor tabela=conversor.ParaModeloTabela(req);
                    bussines.ValidarAtor(tabela);
                    database.Inserir(tabela);
                    Models.Response.atorresponse resposta=conversor.ParaModeloResponse(tabela);

                    return resposta;
           }
           catch(System.Exception ex)
           {
               return BadRequest(new Models.Response.erroresponse(400,ex.Message));
           }
           

        }

       [HttpGet]
       public ActionResult<Models.Response.atorresponse> ConsultaPorNome(string nome)
       {
           try
           {
                Models.TbAtor tabela=database.ConsultarPorNome(nome);
                Models.Response.atorresponse resposta=conversor.ParaModeloResponse(tabela);

                return resposta;
           }
           catch
           {
               return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Ator não encontrado"));
           }
       }
       [HttpPut("{id}")]
       public ActionResult<Models.Response.atorresponse> AlterarPorId(int id,Models.Request.atorrequest req)
       {
           try
           {
                Models.TbAtor tabela=conversor.ParaModeloTabela(req);
                tabela=database.AlterarPorId(id,tabela);
                Models.Response.atorresponse resposta=conversor.ParaModeloResponse(tabela);

                return resposta;
           }
           catch
           {
               return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Ator não encontrado"));
           }

       }
       [HttpGet("{id}")]
       public ActionResult<Models.Response.atorresponse> ConsultarPorId(int id)
       {
           try{
                Models.TbAtor tabela=database.ConsultarPorId(id);
                Models.Response.atorresponse resposta=conversor.ParaModeloResponse(tabela);
                return resposta;
              }
              catch
              {
                   return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Ator não encontrado"));
              }
           
       }
       [HttpDelete("{id}")]
       public ActionResult<Models.Response.atorresponse> DeletarPorId(int id)
       {
          try
          {
              Models.TbAtor tabela=database.DeletarPorID(id);
              Models.Response.atorresponse resposta=conversor.ParaModeloResponse(tabela);
              return resposta;
          }
          catch
          {
             return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Ator não encontrado"));   
          }
       }          

    }
}