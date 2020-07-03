using System.Collections.Generic;
namespace apifilmes.Models.Response
{
    public class erroresponse2
    {
 
        public erroresponse2(int? codigo,string erro)
        {
            this.Codigo=codigo;
            this.Erro=erro;
        }
        public int? Codigo{get;set;}
        public string Erro{get;set;}
    }
    
}