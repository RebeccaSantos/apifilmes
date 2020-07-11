using System;
namespace apifilmes.Bussines
{
    public class personagembussines
    {
        public Models.TbFilmeAtor ValidarPersonagem(Models.TbFilmeAtor personagem)
        {
            if(personagem.NmPersonagem==string.Empty)
                throw new ArgumentException("Personagem obrigatorio");
            
            if(personagem.IdFilme==0)
                throw new ArgumentException("O id deve ser maior que 0");

            if(personagem.IdAtor==0)
                throw new ArgumentException("O id deve ser maior que 0");

                return personagem;
        }
        public Models.Request.personagemrequest ValidarAlteracao(Models.Request.personagemrequest req)
        {
                    if(req.Personagem=="")
                            throw new ArgumentException("Personagem obrigatorio");

                    
                    if(req.Filme==0)
                        throw new ArgumentException("O id deve ser maior que 0");

                    if(req.ator==0)
                        throw new ArgumentException("O id deve ser maior que 0");

                        return req;

        }
        
    }
}