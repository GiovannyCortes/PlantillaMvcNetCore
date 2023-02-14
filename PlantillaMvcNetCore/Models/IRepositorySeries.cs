using System.Data.SqlClient;

namespace PlantillaMvcNetCore.Models {

    public interface IRepositorySeries {

        List<Serie> GetSeries();
        Serie FindSerie(int idserie);
        void InsertSerie(Serie serie);
        void InsertSerie(int idserie, string nombre, string imagen, int puntuacion, int anyo);
        void UpdateSerie(Serie serie);
        void DeleteSerie(int idserie);

    }

}
