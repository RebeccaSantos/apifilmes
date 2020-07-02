using System;
using System.Collections;
using System.Collections.Generic;
namespace apifilmes.Bussines
{
    public class filmebussines
    {
        Database.filmedatabase db=new Database.filmedatabase();
        public Models.TbFilme inserir(Models.TbFilme filme)
        {
            string a="";
            if(filme.NmFilme==a)
               throw new ArgumentException("nome do filme é obrigatorio");

               filme=db.inserir(filme);
               return filme;
        }
         public List<Models.TbFilme> inserir2(List<Models.TbFilme> filme)
        {
            List<Models.TbFilme> r=filme;
            if(filme.Count==0)
               r=new List<Models.TbFilme>();
               
               return r;
        }
        public Models.TbFilme inserir3(Models.TbFilme filme)
        {
            if(filme.NrDuracao<1)
              throw new ArgumentException("Duração invalida");
              
              return filme;

        }
       public List<Models.TbFilme> inserir4(List<Models.TbFilme> filme)
       {

           if(filme.Count==0)
           {
               throw new ArgumentException(null);


               
           }
           return filme;
       }
    }
}