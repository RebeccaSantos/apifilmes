namespace apifilmes.Database
{
    public class personagemdatabase
    {
        Models.apidbContext ctx=new Models.apidbContext();
        public Models.TbFilmeAtor Inserir(Models.TbFilmeAtor tabela)
        {
            ctx.TbFilmeAtor.Add(tabela);
            ctx.SaveChanges();
            return tabela;
        }
    }
}