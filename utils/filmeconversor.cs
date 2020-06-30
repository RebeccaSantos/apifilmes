namespace apifilmes.utils
{
    public class filmeconversor
    {
        public Models.TbFilme paramodelotabela(Models.Request.filmerequest req)
        {
            Models.TbFilme filme =new Models.TbFilme();
            filme.NmFilme=req.Filme;
            filme.DsGenero=req.Genero;
            filme.VlAvaliacao=req.Avaliacao;
            filme.NrDuracao=req.Duracao;
            filme.BtDisponivel=req.Disponivel;
            filme.DtLancamento=req.Lancamento;

            return filme;
        }
        public Models.Response.filmeresponse paramodeloresponse(Models.TbFilme filme)
        {
            Models.Response.filmeresponse resp=new Models.Response.filmeresponse();
            resp.id=filme.IdFilme;
            resp.Filme=filme.NmFilme;
            resp.Genero=filme.DsGenero;
            resp.Avaliacao=filme.VlAvaliacao;
            resp.Duracao=filme.NrDuracao;
            resp.Disponivel=filme.BtDisponivel;
            resp.Lancamento=filme.DtLancamento;

            return resp;
        }
    }
}