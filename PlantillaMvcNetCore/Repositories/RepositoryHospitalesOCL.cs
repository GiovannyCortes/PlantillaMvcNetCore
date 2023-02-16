using PlantillaMvcNetCore.Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace PlantillaMvcNetCore.Repositories {
    public class RepositoryHospitalesOCL : IRepositoryHospitales {

        OracleConnection connection;
        OracleCommand command;
        DataTable tabla_hospital;

        public RepositoryHospitalesOCL() {
            string connectionString =
                @"Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User Id=SYSTEM;Password=oracle";
            this.connection = new OracleConnection(connectionString);
            this.command = new OracleCommand();
            this.command.Connection = this.connection;

            // LinQ
            string sql_hospital = "SELECT * FROM HOSPITAL";
            OracleDataAdapter adapter_hospital = new OracleDataAdapter(sql_hospital, connectionString);
            this.tabla_hospital = new DataTable();
            adapter_hospital.Fill(this.tabla_hospital);

        }

        public List<Hospital> GetHospitales() {
            var consulta = from datos in this.tabla_hospital.AsEnumerable()
                           select new Hospital {
                               HospitalCod = datos.Field<int>("HOSPITAL_COD"),
                               Nombre = datos.Field<string>("NOMBRE"),
                               Direccion = datos.Field<string>("DIRECCION"),
                               Telefono = datos.Field<string>("TELEFONO"),
                               NumCama = datos.Field<int>("NUM_CAMA")
                           };
            return consulta.ToList();
        }

        public Hospital? FindHospital(int hospital_cod) {
            var consulta = from datos in this.tabla_hospital.AsEnumerable()
                           where datos.Field<int>("HOSPITAL_COD") == hospital_cod
                           select new Hospital {
                               HospitalCod = datos.Field<int>("HOSPITAL_COD"),
                               Nombre = datos.Field<string>("NOMBRE"),
                               Direccion = datos.Field<string>("DIRECCION"),
                               Telefono = datos.Field<string>("TELEFONO"),
                               NumCama = datos.Field<int>("NUM_CAMA")
                           };
            return consulta.FirstOrDefault();
        }

        public void InsertHospital(Hospital hospital) {
            this.command.CommandText = "SP_INSERT_HOSPITAL";
            this.command.CommandType = CommandType.StoredProcedure;

            OracleParameter pamnombre = new OracleParameter(":NOMBRE", hospital.Nombre);
            OracleParameter pamdireccion = new OracleParameter(":DIRECCION", hospital.Direccion);
            OracleParameter pamtelefono = new OracleParameter(":TELEFONO", hospital.Telefono);
            OracleParameter pamnumcamas = new OracleParameter(":NUM_CAMAS", hospital.NumCama);

            this.command.Parameters.Add(pamnombre);
            this.command.Parameters.Add(pamdireccion);
            this.command.Parameters.Add(pamtelefono);
            this.command.Parameters.Add(pamnumcamas);

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();
            this.command.Parameters.Clear();
        }

        public void UpdateHospital(Hospital hospital) {
            this.command.CommandText = "SP_UPDATE_HOSPITAL";
            this.command.CommandType = CommandType.StoredProcedure;

            OracleParameter pamhospitalcod = new OracleParameter(":HOSPITAL_COD", hospital.HospitalCod);
            OracleParameter pamnombre = new OracleParameter(":NOMBRE", hospital.Nombre);
            OracleParameter pamdireccion = new OracleParameter(":DIRECCION", hospital.Direccion);
            OracleParameter pamtelefono = new OracleParameter(":TELEFONO", hospital.Telefono);
            OracleParameter pamnumcamas = new OracleParameter(":NUM_CAMAS", hospital.NumCama);

            this.command.Parameters.Add(pamhospitalcod);
            this.command.Parameters.Add(pamnombre);
            this.command.Parameters.Add(pamdireccion);
            this.command.Parameters.Add(pamtelefono);
            this.command.Parameters.Add(pamnumcamas);

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();
            this.command.Parameters.Clear();
        }

        public void DeleteHospital(int hospital_cod) {
            this.command.CommandText = "SP_DELETE_HOSPITAL";
            this.command.CommandType = CommandType.StoredProcedure;

            OracleParameter pamhospitalcod = new OracleParameter(":HOSPITAL_COD", hospital_cod);
            this.command.Parameters.Add(pamhospitalcod);

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();
            this.command.Parameters.Clear();
        }

        /* ============================================================= */

        public void DeleteDepartamento(int dept_no) {
            throw new NotImplementedException();
        }

        public void DeleteDoctor(int hospital_cod) {
            throw new NotImplementedException();
        }

        public void DeleteEmpleado(int emp_no) {
            throw new NotImplementedException();
        }

        public void DeleteEnfermo(int inscripcion) {
            throw new NotImplementedException();
        }

        public void DeleteOcupacion(int inscripcion) {
            throw new NotImplementedException();
        }

        public void DeletePlantilla(int hospital_cod) {
            throw new NotImplementedException();
        }

        public void DeleteSala(int hospital_cod) {
            throw new NotImplementedException();
        }

        public Departamento FindDepartamento(int dept_no) {
            throw new NotImplementedException();
        }

        public Doctor FindDoctor(int hospital_cod) {
            throw new NotImplementedException();
        }

        public Empleado FindEmpleado(int emp_no) {
            throw new NotImplementedException();
        }

        public Enfermo FindEnfermo(int inscripcion) {
            throw new NotImplementedException();
        }

        public Ocupacion FindOcupacion(int inscripcion) {
            throw new NotImplementedException();
        }

        public Plantilla FindPlantilla(int hospital_cod) {
            throw new NotImplementedException();
        }

        public Sala FindSala(int hospital_cod) {
            throw new NotImplementedException();
        }

        public List<Departamento> GetDepartamentos() {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctores() {
            throw new NotImplementedException();
        }

        public List<Empleado> GetEmpleados() {
            throw new NotImplementedException();
        }

        public List<Enfermo> GetEnfermos() {
            throw new NotImplementedException();
        }

        public List<Ocupacion> GetOcupaciones() {
            throw new NotImplementedException();
        }

        public List<Plantilla> GetPlantillas() {
            throw new NotImplementedException();
        }

        public List<Sala> GetSalas() {
            throw new NotImplementedException();
        }

        public void InsertDepartamento(Departamento departamento) {
            throw new NotImplementedException();
        }

        public void InsertDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public void InsertEmpleado(Empleado empleado) {
            throw new NotImplementedException();
        }

        public void InsertEnfermo(Enfermo enfermo) {
            throw new NotImplementedException();
        }

        public void InsertOcupacion(Ocupacion ocupacion) {
            throw new NotImplementedException();
        }

        public void InsertPlantilla(Plantilla plantilla) {
            throw new NotImplementedException();
        }

        public void InsertSala(Sala sala) {
            throw new NotImplementedException();
        }

        public void UpdateDepartamento(Departamento departamento) {
            throw new NotImplementedException();
        }

        public void UpdateDoctor(Doctor doctor) {
            throw new NotImplementedException();
        }

        public void UpdateEmpleado(Empleado empleado) {
            throw new NotImplementedException();
        }

        public void UpdateEnfermo(Enfermo enfermo) {
            throw new NotImplementedException();
        }

        public void UpdateOcupacion(Ocupacion ocupacion) {
            throw new NotImplementedException();
        }

        public void UpdatePlantilla(Plantilla plantilla) {
            throw new NotImplementedException();
        }

        public void UpdateSala(Sala sala) {
            throw new NotImplementedException();
        }
    }
}
