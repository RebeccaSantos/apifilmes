using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class diretorcontroller:ControllerBase
    {
        Database.diretordatabase database =new Database.diretordatabase();
        Bussines.diretorbussines bussines=new Bussines.diretorbussines();
        utils.diretorconversor conversor=new utils.diretorconversor();
        
        [HttpPost]
        public ActionResult<Models.Response.diretorresponse> Salvar(Models.Request.diretorrequest diretor)
        {
          try{          
          
          Models.TbDiretor d=conversor.ParamodeloTabela(diretor);
          bussines.Inserir(d);
          Models.Response.diretorresponse r=conversor.ParamodeloResponse(d);

          return r;
          }
          catch (System.Exception ex)
             {
                return BadRequest(new Models.Response.erroresponse(400,ex.Message)); 
                
             }
            

        }
        [HttpGet]
        public ActionResult<Models.Response.diretorresponse> ConsultarNome(string nome)
        {
             try{
             
             Models.TbDiretor diretor=database.Consultar(nome);
             Models.Response.diretorresponse r=conversor.ParamodeloResponse(diretor);
             return r; 
             }
             catch(System.Exception ex)
             {

                return new NotFoundObjectResult(new Models.Response.erroresponse2(404,ex.Message));
             }

          

        }
        [HttpPut("{id}")]
        public ActionResult<Models.Response.diretorresponse> alterarfk(Models.Request.diretorrequest req,int id)
        {
             try{
                
                bussines.ValidarAlteracao(req);
                Models.TbDiretor tabela=conversor.ParamodeloTabela(req);
                tabela=database.alterar(id,tabela);
                Models.Response.diretorresponse resposta=conversor.ParamodeloResponse(tabela);
                return resposta;
                }
                catch(System.Exception ex)
                {
                   return BadRequest(new Models.Response.erroresponse(400,ex.Message));
                }       

        } 
         
           [HttpGet("{id}")]
           public ActionResult<Models.Response.diretorresponse> ConsultarPorId(int id)
           {
              try
              {
               Models.TbDiretor tabela=database.ConsultarId(id);
               Models.Response.diretorresponse resposta=conversor.ParamodeloResponse(tabela);

               return resposta;
              }
              catch(System.Exception)
              {
                   return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Diretor não encontrado"));
              } 
           } 
           [HttpDelete("{id}")]
           public ActionResult<Models.Response.diretorresponse> DeletarPorId(int id)
           {
              try
              {
                Models.TbDiretor remover=database.DeletarPorId(id);
                Models.Response.diretorresponse resposta=conversor.ParamodeloResponse(remover);

                return resposta; 
              }
              catch
              {
                 return new NotFoundObjectResult(new Models.Response.erroresponse(404,"Diretor não encontrado"));
              }
           } 

    }
}