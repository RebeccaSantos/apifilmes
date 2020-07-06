namespace apifilmes.utils
{
    public class personagemconversor
    {
        public Models.TbFilmeAtor ParaModeloTabela(Models.Request.personagemrequest req)
        {
            Models.TbFilmeAtor tabela=new Models.TbFilmeAtor();
           tabela.NmPersonagem=req.Personagem;
           tabela.IdFilme=req.Filme;
           tabela.IdAtor=req.ator;
           
           return tabela;
        }
        public Models.Response.personagemresponse ParaModeloResponse(Models.TbFilmeAtor tabela)
        {
            Models.Response.personagemresponse resp=new Models.Response.personagemresponse();
            resp.Id=tabela.IdFilmeAtor;
            resp.Personagem=tabela.NmPersonagem;
            resp.Filme=tabela.IdFilme;
            resp.Ator=tabela.IdAtor;
            

            return resp;
        }
    }
}