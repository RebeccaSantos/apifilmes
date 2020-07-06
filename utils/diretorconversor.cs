namespace apifilmes.utils
{
    public class diretorconversor
    {
        public Models.TbDiretor ParamodeloTabela(Models.Request.diretorrequest req)
        {
            Models.TbDiretor diretor=new Models.TbDiretor();

            diretor.IdFilme=req.Filme;
            diretor.NmDiretor=req.Diretor;
            diretor.DtNascimento=req.Nascimento;

            return diretor;

        }
        public Models.Response.diretorresponse ParamodeloResponse(Models.TbDiretor tabela)
        {
            Models.Response.diretorresponse resp=new Models.Response.diretorresponse();
            resp.Id=tabela.IdDiretor;
            resp.Filme=tabela.IdFilme;
            resp.Diretor=tabela.NmDiretor;
            resp.Nascimento=tabela.DtNascimento;

            return resp;
        }
    }
}