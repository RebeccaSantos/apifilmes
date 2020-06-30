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
         [HttpGet]
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

               

    }
}