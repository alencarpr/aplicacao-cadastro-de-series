using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Delete(int id)
        {
            listaSeries[id].Excluir();
        }

        public List<Serie> GetAll()
        {
            return listaSeries;
        }

        public Serie GetByID(int id)
        {
            return listaSeries[id];
        }

        public void Insert(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public int NextId()
        {
            return listaSeries.Count;
        }

        public void Update(Serie entidade)
        {
            listaSeries[entidade.Id] = entidade;
        }
    }
}