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
         [HttpGet]
         public ActionResult<List<Models.Response.filmeresponse>> consultarporparametro(string nome,string genero)
         {
             try{         
             utils.filmeconversor conversor=new utils.filmeconversor();
            Database.filmedatabase database=new Database.filmedatabase();
            List<Models.TbFilme> filme=new List<Models.TbFilme>();
            filme= database.filtrar(nome,genero);
            List<Models.Response.filmeresponse> result=filme.Select(x=>conversor.paramodeloresponse(x)).ToList();
            return result;
            }
            catch{
            return new NotFoundObjectResult(new List<Models.Response.filmeresponse>());
            }
         }
         [HttpDelete("{id}")]
         public ActionResult<Models.TbFilme> deletar(int id)
         {
             try{
             Database.filmedatabase database=new Database.filmedatabase();
             Models.TbFilme filme=new Models.TbFilme();
             database.deletar(id);
             return Ok(null);
             }
                catch
             {
                 
                 return new NotFoundObjectResult(null);
             }
 

         }
         //[HttpGet("{id}")]
         public ActionResult<Models.Response.filmeresponse> consultarporid(int id)
         {
             try
             {
             utils.filmeconversor conversor=new utils.filmeconversor();
             Database.filmedatabase database=new Database.filmedatabase();
             Models.TbFilme filme=new Models.TbFilme();
             filme=database.inserir4(id);
             Models.Response.filmeresponse result=conversor.paramodeloresponse(filme);
             return result;

             }
             catch
             {
                 
                 return new NotFoundObjectResult(null);
             }
 
            
          

         }
         [HttpPost]
         public ActionResult<Models.Response.filmeresponse> inserir(Models.Request.filmerequest req)
         {
             try
             {
             utils.filmeconversor conversor=new utils.filmeconversor();
             Models.TbFilme filme=conversor.paramodelotabela(req);
             Bussines.filmebussines Bussines=new Bussines.filmebussines();
             filme=Bussines.inserir(filme);
             Models.Response.filmeresponse resp=conversor.paramodeloresponse(filme);
             return resp;
             }
             catch (System.Exception ex)
             {
                return BadRequest(new Models.Response.erroresponse(400,ex.Message)); 
                
             }
           
         }
         //[HttpGet]
         public ActionResult<List<Models.Response.filmeresponse>> consultar()
         {
            try
            {
                utils.filmeconversor conversor=new utils.filmeconversor();
             List<Models.TbFilme> filme=new List<Models.TbFilme>();
             Database.filmedatabase database=new Database.filmedatabase();
             filme=database.inserir2(filme);
             List<Models.Response.filmeresponse> resp=filme.Select(x=>conversor.paramodeloresponse(x)).ToList();
             
             return resp;
            }
            catch
            {
                return new List<Models.Response.filmeresponse>();
            } 
         }
         [HttpPut("{id}")]
         public ActionResult<dynamic> alterar(int id,Models.Request.filmerequest modelo)
         {
                try
                {
                utils.filmeconversor conversor=new utils.filmeconversor();
                Models.TbFilme filme=new Models.TbFilme();
                Database.filmedatabase database=new Database.filmedatabase();
                Models.TbFilme tabela=conversor.paramodelotabela(modelo);
                filme=database.inserir3(id,tabela);
                return null;
                }
                catch (System.Exception ex)
                {
                    return BadRequest(new Models.Response.erroresponse(400,ex.Message));
                    
                }


         }

               

    }
}