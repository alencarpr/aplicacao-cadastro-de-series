using System;
using System.Text;
using Dio.Series.Enums;

namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append($"Gênero = {this.Genero}{Environment.NewLine}");
            retorno.Append($"Título = {this.Titulo}{Environment.NewLine}");
            retorno.Append($"Descricao = {this.Descricao}{Environment.NewLine}");
            retorno.Append($"Ano = {this.Ano}{Environment.NewLine}");
            retorno.Append($"Excluído = {(this.Excluido ? "Sim" : "Não")}{Environment.NewLine}");

            return retorno.ToString();
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}