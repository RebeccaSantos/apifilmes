using System;
namespace apifilmes.Bussines
{
    public class diretorbussines
    {
        

        public Models.TbDiretor inserir(Models.TbDiretor diretor)
        {
            Database.diretordatabase db=new Database.diretordatabase();
            if(diretor.IdFilme<1||diretor.NmDiretor=="")
              throw new ArgumentException("Campo invalido");

             diretor=db.inserir(diretor);
             return diretor;
        }
        public Models.TbDiretor consultar(Models.TbDiretor diretor)
        {
           
            if(diretor.NmDiretor=="")
                    throw new ArgumentException(message: "Diretor não encontrado");

             return diretor;
        }
    }
}