using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Controllers
{    
    [ApiController]
    [Route("[controller]")]
     public class personagemcontroller:ControllerBase
    {
        Bussines.personagembussines bussines=new Bussines.personagembussines();
        Database.personagemdatabase database=new Database.personagemdatabase();
        utils.personagemconversor conversor=new utils.personagemconversor();

        [HttpPost]
        public ActionResult<Models.Response.personagemresponse> Inserir (Models.Request.personagemrequest req)
        {
            try
            {
                    Models.TbFilmeAtor tabela=conversor.ParaModeloTabela(req);
                    bussines.ValidarPersonagem(tabela);
                    tabela=database.Inserir(tabela);
                    Models.Response.personagemresponse resp=conversor.ParaModeloResponse(tabela);

                    return resp;
            }
            catch(System.Exception ex)
            {
                return BadRequest(new Models.Response.erroresponse(400,ex.Message));

            }    
        }
        [HttpGet("{filmeid}/[personagem]")]
          public ActionResult<Models.Response.personagemresponse> ConsultarPorId(int id)
          {
              try
              {
                   Models.TbFilmeAtor pers=database.ConsultarPorId(id);
                   Models.Response.personagemresponse resposta=conversor.ParaModeloResponse(pers);

                   return resposta;
              }
              catch
              {
                  return new NotFoundObjectResult(new Models.Response.erroresponse(404,"personagem nao encontrado"));
              }
          }
          [HttpPut("{filmeid}/[personagem]/{id}")]

          public ActionResult<Models.Response.personagemresponse> Alterar(Models.Request.personagemrequest req,int filmeid,string personagem,int id)
          {
              try
              {
                  bussines.ValidarAlteracao(req);
                  Models.TbFilmeAtor tabela=database.Alterar(req,filmeid,id);
                  Models.Response.personagemresponse resposta=conversor.ParaModeloResponse(tabela);

                  return resposta;
              }
              catch(System.Exception ex)
              {
                  return BadRequest(new Models.Response.erroresponse(400,ex.Message));
              }
          }
     
           [HttpGet("{filmeid}/[personagem]/{id}")]
           public ActionResult<Models.Response.personagemresponse> ConsultarPorIdNome(int filmeid,int id)
           {
               try
               {
                     Models.TbFilmeAtor tabela=database.ConsultarPorIdNome(filmeid,id);
                     Models.Response.personagemresponse resposta=conversor.ParaModeloResponse(tabela);

                     return resposta;
               }
                catch
                {
                       return new NotFoundObjectResult(new Models.Response.erroresponse(404,"personagem nao encontrado"));
 
                }
           }  
           [HttpDelete("{filmeid}/[personagem]/{id}")]
           public ActionResult<Models.Response.personagemresponse> DeletarPersonagem (int filmeid,int id)
           {
               try
               {
                     Models.TbFilmeAtor tabela=database.DeletarPorId(filmeid,id);
                     Models.Response.personagemresponse resp=conversor.ParaModeloResponse(tabela);
                     return resp;
               }
               catch
               {
                   return new NotFoundObjectResult(new Models.Response.erroresponse(404,"personagem nao encontrado"));
               }

           }
            
    }
}