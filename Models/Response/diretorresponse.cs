using System;
namespace apifilmes.Models.Response
{
    public class diretorresponse
    {
        public int Id{get;set;}
        public int Filme{get;set;}
        public string Diretor{get;set;}
        public DateTime Nascimento{get;set;}
    }
}