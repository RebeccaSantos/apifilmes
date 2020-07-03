using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace apifilmes.Database
{
    
    public class diretordatabase
    {
        Models.apidbContext ctx = new Models.apidbContext();

        public Models.TbDiretor inserir(Models.TbDiretor diretor)
        {
          ctx.TbDiretor.Add(diretor);
          ctx.SaveChanges();
          return diretor;
        }
        public Models.TbDiretor consultar(string nome)
        {
          Bussines.diretorbussines bussines=new Bussines.diretorbussines();
           Models.TbDiretor diretor=ctx.TbDiretor.FirstOrDefault(x=>x.NmDiretor.Contains(nome));
            bussines.consultar(diretor);
            return diretor;
        }
        
    }
}