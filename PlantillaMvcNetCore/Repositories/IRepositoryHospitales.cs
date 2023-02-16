using PlantillaMvcNetCore.Models;

namespace PlantillaMvcNetCore.Repositories {
    public interface IRepositoryHospitales {

        #region GETS
        List<Departamento> GetDepartamentos();
        List<Doctor> GetDoctores();
        List<Empleado> GetEmpleados();
        List<Enfermo> GetEnfermos();
        List<Hospital> GetHospitales();
        List<Ocupacion> GetOcupaciones();
        List<Plantilla> GetPlantillas();
        List<Sala> GetSalas();
        #endregion

        #region FINDS
        Departamento FindDepartamento(int dept_no);
        Doctor FindDoctor(int hospital_cod);
        Empleado FindEmpleado(int emp_no);
        Enfermo FindEnfermo(int inscripcion);
        Hospital FindHospital(int hospital_cod);
        Ocupacion FindOcupacion(int inscripcion);
        Plantilla FindPlantilla(int hospital_cod);
        Sala FindSala(int hospital_cod);
        #endregion

        #region INSERT
        void InsertDepartamento(Departamento departamento);
        void InsertDoctor(Doctor doctor);
        void InsertEmpleado(Empleado empleado);
        void InsertEnfermo(Enfermo enfermo);
        void InsertHospital(Hospital hospital);
        void InsertOcupacion(Ocupacion ocupacion);
        void InsertPlantilla(Plantilla plantilla);
        void InsertSala(Sala sala);
        #endregion        
        
        #region UPDATE
        void UpdateDepartamento(Departamento departamento);
        void UpdateDoctor(Doctor doctor);
        void UpdateEmpleado(Empleado empleado);
        void UpdateEnfermo(Enfermo enfermo);
        void UpdateHospital(Hospital hospital);
        void UpdateOcupacion(Ocupacion ocupacion);
        void UpdatePlantilla(Plantilla plantilla);
        void UpdateSala(Sala sala);
        #endregion

        #region DELETE
        void DeleteDepartamento(int dept_no);
        void DeleteDoctor(int hospital_cod);
        void DeleteEmpleado(int emp_no);
        void DeleteEnfermo(int inscripcion);
        void DeleteHospital(int hospital_cod);
        void DeleteOcupacion(int inscripcion);
        void DeletePlantilla(int hospital_cod);
        void DeleteSala(int hospital_cod);
        #endregion



    }
}
