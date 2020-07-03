using System;
namespace apifilmes.Models.Request
{
    public class diretorrequest
    {
        public int Filme{get;set;}
        public string Diretor{get;set;}
        public DateTime Nascimento{get;set;}
    }
}