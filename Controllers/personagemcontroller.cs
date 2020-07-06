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
    }
}