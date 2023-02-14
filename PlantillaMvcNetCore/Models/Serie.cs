namespace PlantillaMvcNetCore.Models {

    public class Serie {

        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string Imagen{ get; set; }
        public int Puntuacion { get; set; }
        public int Anyo { get; set; }

        public Serie() {
            this.IdSerie = 0;
            this.Nombre = "";
            this.Imagen = "";
            this.Puntuacion = 0;
            this.Anyo = 0;
        }        
        
        public Serie(int idSerie, string nombre, string imagen, int puntuacion, int anyo) {
            this.IdSerie = idSerie;
            this.Nombre = nombre;
            this.Imagen = imagen;
            this.Puntuacion = puntuacion;
            this.Anyo = anyo;
        }

    }

}
