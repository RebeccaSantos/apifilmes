namespace apifilmes.Models.Response
{
    public class erroresponse
    {
        public erroresponse(int codigo,string erro)
        {
            this.Codigo=codigo;
            this.Erro=erro;
        }
        public int Codigo{get;set;}
        public string Erro{get;set;}
    }
}