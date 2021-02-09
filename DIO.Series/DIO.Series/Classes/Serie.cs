using DIO.Series.Enum;
using System; 

namespace DIO.Series.Classes
{
    public class Serie: EntidadeBase
    {
        #region VARIAVEIS PRIVADAS

        private Genero _genero { get; set; }

        private string _titulo { get; set; }

        private string _descricao { get; set; }

        private int _ano { get; set; }

        private bool _excluido;
        #endregion

        #region CONSTRUTOR
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
            _excluido = false;
        }
        #endregion

        #region METODOS PRÓpRIOS
        /// <summary>
        /// Método modificado para retornar dados da serie.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string Objeto  = $"Gênero: {_genero}{Environment.NewLine}" +
                             $"Título: {_titulo}{Environment.NewLine} " +
                             $"Descrição: {_descricao}{Environment.NewLine}" +
                             $"Ano: {_ano}";

            return Objeto;
        }
        /// <summary>
        /// Método que retornar o ID.
        /// </summary>
        /// <returns>Id da serie</returns>
        public int GetId()
        {
            return Id;
        }
        /// <summary>
        /// Método que Retonar o título.
        /// </summary>
        /// <returns>Título da serie</returns>
        public string GetTitulo()
        {
            return _titulo;
        }
        /// <summary>
        /// Método responsavel por excluir serie.
        /// </summary>
        public void Excluir() => _excluido = true;

        public bool GetStatus() => _excluido;
        #endregion
    }
}
