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
        [HttpPost]
        public ActionResult<Models.Response.diretorresponse> salvar(Models.Request.diretorrequest diretor)
        {
          try{          
          utils.diretorconversor conversor=new utils.diretorconversor();
          Models.TbDiretor d=conversor.paramodelotabela(diretor);
          Bussines.diretorbussines bussines=new Bussines.diretorbussines();
          bussines.inserir(d);
          Models.Response.diretorresponse r=conversor.paramodeloresponse(d);

          return r;
          }
        catch (System.Exception ex)
             {
                return BadRequest(new Models.Response.erroresponse(400,ex.Message)); 
                
             }
            

        }
        [HttpGet]
        public ActionResult<Models.Response.diretorresponse> consultarnome(string nome)
        {
             try{
             utils.diretorconversor conversor=new utils.diretorconversor();
             Bussines.diretorbussines bussines=new Bussines.diretorbussines();
             Database.diretordatabase database =new Database.diretordatabase();
             Models.TbDiretor diretor=database.consultar(nome);
             Models.Response.diretorresponse r=conversor.paramodeloresponse(diretor);
             return r; 
             }
             catch(System.Exception ex)
             {

                return new NotFoundObjectResult(new Models.Response.erroresponse2(404,"diretor nao encontrado"));
             }

          

        }       

    }
}