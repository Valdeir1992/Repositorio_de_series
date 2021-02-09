using System.Collections.Generic; 

namespace DIO.Series.Interfaces
{
    /// <summary>
    /// Interface que controla implementacao do respositorio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorio<T>
    { 
        ///<value>Lista de entidades</value>
        List<T> ListaDeSeries
        {
            get; 
        }
        /// <summary>
        /// Método responsavel por retornar lista com todas as entidades.
        /// </summary>
        /// <returns></returns>
        
        T GetEntidade(int id);

        /// <summary>
        /// Método responsavel por adicionar uma determinada entidade no repositorio.
        /// </summary>
        /// <param name="entidade">Receve a entidade a ser adicionada</param>
        void Inserir(T entidade);

        /// <summary>
        /// Exclui uma determinada entidade do reposito com base no seu id.
        /// </summary>
        /// <param name="id">Recebe o id da entidade a ser excluida</param>
        void Excluir(int id);

        /// <summary>
        /// Método responsavel por atualizar informacoes de uma deteminada entidade.
        /// </summary>
        /// <param name="id">Recebe o id da entidade a ser atualizada</param>
        /// <param name="entidade">Receve a entidade com dados atualizados</param>
        void Atualizar(int id, T entidade);

        /// <summary>
        /// Métoro responsavel por retornar o seguinte id.
        /// </summary>
        /// <returns></returns>
        int ProximoId();

    }
}
