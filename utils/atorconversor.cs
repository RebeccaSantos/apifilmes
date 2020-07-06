
namespace apifilmes.utils
{
    public class atorconversor
    {
        public Models.TbAtor ParaModeloTabela(Models.Request.atorrequest req)
        {
            Models.TbAtor tabela=new Models.TbAtor();
            tabela.NmAtor=req.Nome;
            tabela.VlAltura=req.Altura;
            tabela.DtNascimento=req.Nascimento;
            
            return tabela;
        }
        public Models.Response.atorresponse ParaModeloResponse(Models.TbAtor tabela)
        {
            Models.Response.atorresponse resp=new Models.Response.atorresponse();
            resp.Id=tabela.IdAtor;
            resp.Nome=tabela.NmAtor;
            resp.Altura=tabela.VlAltura;
            resp.Nascimento=tabela.DtNascimento;

            return resp;
        }
    }
}