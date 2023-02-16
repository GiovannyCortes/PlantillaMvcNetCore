using PlantillaMvcNetCore.Models;
using System.Data;
using System.Data.SqlClient;

#region PROCEDURES HOSPITAL SQL
/*
    CREATE PROCEDURE SP_INSERT_HOSPITAL (@NOMBRE NVARCHAR(50), @DIRECCION NVARCHAR(50), @TELEFONO NVARCHAR(50), @NUM_CAMAS INT)
    AS
        DECLARE @HOSPITAL_COD INT;
	    SET @HOSPITAL_COD = (SELECT MAX(HOSPITAL_COD) + 1 FROM HOSPITAL)
	    INSERT INTO HOSPITAL VALUES(@HOSPITAL_COD, @NOMBRE, @DIRECCION, @TELEFONO, @NUM_CAMAS)
    GO

    CREATE PROCEDURE SP_UPDATE_HOSPITAL (@HOSPITAL_COD INT, @NOMBRE NVARCHAR(50), @DIRECCION NVARCHAR(50), @TELEFONO NVARCHAR(50), @NUM_CAMAS INT)
    AS
	    UPDATE HOSPITAL SET	NOMBRE = @NOMBRE,
						    DIRECCION = @DIRECCION,
						    TELEFONO = @TELEFONO, 
						    NUM_CAMA = @NUM_CAMAS
						    WHERE HOSPITAL_COD = @HOSPITAL_COD;
    GO

    CREATE PROCEDURE SP_DELETE_HOSPITAL (@HOSPITAL_COD INT)
    AS
	    DELETE FROM HOSPITAL WHERE HOSPITAL_COD = @HOSPITAL_COD;
    GO
 */
#endregion

#region PROCEDURES HOSPITAL ORACLE
/*
    CREATE OR REPLACE PROCEDURE SP_INSERT_HOSPITAL 
    (P_NOMBRE HOSPITAL.NOMBRE%TYPE, P_DIRECCION HOSPITAL.DIRECCION%TYPE, P_TELEFONO HOSPITAL.TELEFONO%TYPE, P_CAMAS HOSPITAL.NUM_CAMA%TYPE)
    AS P_HOSPITAL_COD INT;
    BEGIN
      SELECT MAX(HOSPITAL_COD)+1 INTO P_HOSPITAL_COD FROM HOSPITAL;
      INSERT INTO HOSPITAL VALUES(P_HOSPITAL_COD, P_NOMBRE, P_DIRECCION, P_TELEFONO, P_CAMAS);
      COMMIT;
    END;

    CREATE OR REPLACE PROCEDURE SP_UPDATE_HOSPITAL
    (P_HOSPITAL_COD HOSPITAL.HOSPITAL_COD%TYPE, P_NOMBRE HOSPITAL.NOMBRE%TYPE, P_DIRECCION HOSPITAL.DIRECCION%TYPE, P_TELEFONO HOSPITAL.TELEFONO%TYPE, P_CAMAS HOSPITAL.NUM_CAMA%TYPE)
    AS
    BEGIN
      UPDATE HOSPITAL SET NOMBRE = P_NOMBRE, DIRECCION = P_DIRECCION, TELEFONO = P_TELEFONO, NUM_CAMA = P_CAMAS WHERE HOSPITAL_COD = P_HOSPITAL_COD;
      COMMIT;
    END;

    CREATE OR REPLACE PROCEDURE SP_DELETE_HOSPITAL (P_HOSPITAL_COD HOSPITAL.HOSPITAL_COD%TYPE)
    AS
    BEGIN
      DELETE FROM HOSPITAL WHERE HOSPITAL_COD = P_HOSPITAL_COD;
      COMMIT;
    END;
 */
#endregion

namespace PlantillaMvcNetCore.Repositories {
    public class RepositoryHospitalesSQL : IRepositoryHospitales {

        SqlConnection connection;
        SqlCommand command;
        DataTable tabla_hospital, 
                  tabla_departamento, 
                  tabla_doctor, 
                  tabla_empleado, 
                  tabla_enfermo,
                  tabla_ocupacion, 
                  tabla_plantilla,
                  tabla_sala;

        public RepositoryHospitalesSQL() {
            string connectionString = 
                @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;

            // LinQ
            string sql_hospital = "SELECT * FROM HOSPITAL";
            //string sql_departamento = "SELECT * FROM DEPT";
            //string sql_doctor = "SELECT * FROM DOCTOR";
            //string sql_empleado = "SELECT * FROM EMP";
            //string sql_enfermo = "SELECT * FROM ENFERMO";
            //string sql_ocupacion = "SELECT * FROM OCUPACION";
            //string sql_plantilla = "SELECT * FROM PLANTILLA";
            //string sql_sala = "SELECT * FROM SALA";

            SqlDataAdapter adapter_hospital = new SqlDataAdapter(sql_hospital, connectionString);
            //SqlDataAdapter adapter_departamento = new SqlDataAdapter(sql_departamento, connectionString);
            //SqlDataAdapter adapter_doctor = new SqlDataAdapter(sql_doctor, connectionString);
            //SqlDataAdapter adapter_empleado = new SqlDataAdapter(sql_empleado, connectionString);
            //SqlDataAdapter adapter_enfermo = new SqlDataAdapter(sql_enfermo, connectionString);
            //SqlDataAdapter adapter_ocupacion = new SqlDataAdapter(sql_ocupacion, connectionString);
            //SqlDataAdapter adapter_plantilla = new SqlDataAdapter(sql_plantilla, connectionString);
            //SqlDataAdapter adapter_sala = new SqlDataAdapter(sql_sala, connectionString);

            this.tabla_hospital = new DataTable();
            //this.tabla_departamento = new DataTable();
            //this.tabla_doctor = new DataTable();
            //this.tabla_empleado = new DataTable();
            //this.tabla_enfermo = new DataTable();
            //this.tabla_ocupacion = new DataTable();
            //this.tabla_plantilla = new DataTable();
            //this.tabla_sala = new DataTable();

            adapter_hospital.Fill(this.tabla_hospital);
            //adapter_departamento.Fill(this.tabla_departamento);
            //adapter_doctor.Fill(this.tabla_doctor);
            //adapter_empleado.Fill(this.tabla_empleado);
            //adapter_enfermo.Fill(this.tabla_enfermo);
            //adapter_ocupacion.Fill(this.tabla_ocupacion);
            //adapter_plantilla.Fill(this.tabla_plantilla);
            //adapter_sala.Fill(this.tabla_sala);
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

            SqlParameter pamnombre = new SqlParameter("@NOMBRE", hospital.Nombre);
            SqlParameter pamdireccion = new SqlParameter("@DIRECCION", hospital.Direccion);
            SqlParameter pamtelefono = new SqlParameter("@TELEFONO", hospital.Telefono);
            SqlParameter pamnumcamas = new SqlParameter("@NUM_CAMAS", hospital.NumCama);

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

            SqlParameter pamhospitalcod = new SqlParameter("@HOSPITAL_COD", hospital.HospitalCod);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", hospital.Nombre);
            SqlParameter pamdireccion = new SqlParameter("@DIRECCION", hospital.Direccion);
            SqlParameter pamtelefono = new SqlParameter("@TELEFONO", hospital.Telefono);
            SqlParameter pamnumcamas = new SqlParameter("@NUM_CAMAS", hospital.NumCama);

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

            SqlParameter pamhospitalcod = new SqlParameter("@HOSPITAL_COD", hospital_cod);
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
