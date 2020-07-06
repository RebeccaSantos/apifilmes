using System;
using System.Collections;
using System.Collections.Generic;
namespace apifilmes.Bussines
{
    public class diretorbussines
    {
         public Models.TbDiretor Inserir(Models.TbDiretor diretor)
        {
            Database.diretordatabase db=new Database.diretordatabase();
            if(diretor.IdFilme<1||diretor.NmDiretor=="")
              throw new ArgumentException("Campo invalido");

             diretor=db.Inserir(diretor);
             return diretor;
        }
        public Models.TbDiretor Consultar(Models.TbDiretor diretor)
        {
           
            if(diretor.NmDiretor=="")
                    throw new ArgumentException("Diretor não encontrado");

             return diretor;
        }
        public Models.Request.diretorrequest ValidarAlteracao(Models.Request.diretorrequest req)
        {
            if(req.Filme<1)
                   throw new ArgumentException("O id não pode ser menor que 1");

            if(req.Diretor==string.Empty)
                 throw new ArgumentException("Diretor nao pode estar vazio");

            if(req.Nascimento<=new DateTime())
                  throw new ArgumentException("Data invalida");


                  return req;         
        }
    }
}