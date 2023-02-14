using PlantillaMvcNetCore.Models;
using System.Data.SqlClient;

namespace PlantillaMvcNetCore.Repositories {

    public class RepositorySeriesSQL {

        IRepositorySeries repo_series;

        public RepositorySeriesSQL(IRepositorySeries repo_series) {
            this.repo_series = repo_series;
        }

    }

}
