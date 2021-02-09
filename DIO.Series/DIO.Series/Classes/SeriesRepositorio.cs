using System;
using System.Collections.Generic; 
using DIO.Series.Interfaces;

namespace DIO.Series.Classes
{
    /// <summary>
    /// Classe responsavel por gerenciar o repositorio de series.
    /// </summary>
    /// <see cref="IRepositorio{T}"/>
    class SeriesRepositorio : IRepositorio<Serie>
    {
        private List<Serie> _lista = new List<Serie>();

        public List<Serie> ListaDeSeries { get => _lista;}

        #region MÉTODOS PRÓPRIOS
        public void Atualizar(int id, Serie entidade)
        {
            _lista[id] = entidade;

            Console.WriteLine($"Série atualizada com sucesso"); 

            Console.ReadKey();
        }

        public void Excluir(int id)
        {
            _lista[id].Excluir();

            Console.WriteLine($"Série excluido com sucesso"); 

            Console.ReadKey();
        }

        public Serie GetEntidade(int id)
        {
            return _lista[id];
        } 
        public void Inserir(Serie entidade)
        {
            _lista.Add(entidade);

            Console.WriteLine($"Série cadastrada com sucesso");

            Console.ReadKey();
        }

        public int ProximoId()
        {
            return _lista.Count;
        }
        #endregion

    }
}
