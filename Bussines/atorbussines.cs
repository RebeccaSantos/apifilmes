using System;
namespace apifilmes.Bussines
{
    public class atorbussines
    {
        public Models.TbAtor ValidarAtor(Models.TbAtor ator)
        {
            if(ator.NmAtor==string.Empty)
                 throw new ArgumentException("Nome Obrigatorio");
            
            if(ator.VlAltura==0)
                    throw new ArgumentException("Altura invalida");

            if(ator.DtNascimento==new DateTime())
                    throw new ArgumentException("Data invalida");
                    
                    return ator;
        }
    }
}