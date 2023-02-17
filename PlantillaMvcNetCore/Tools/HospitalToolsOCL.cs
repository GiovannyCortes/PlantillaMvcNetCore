using Oracle.ManagedDataAccess.Client;
using System.Data;

#region Procedures
/*
    CREATE OR REPLACE PROCEDURE SP_GETMAX_HOSPITAL_COD (P_MAXOUT OUT HOSPITAL.HOSPITAL_COD%TYPE) AS
    BEGIN
       SELECT MAX(HOSPITAL_COD)+1 INTO P_MAXOUT FROM HOSPITAL;
      END;
 */
#endregion

namespace PlantillaMvcNetCore.Tools {
    public class HospitalToolsOCL : IHospitalTools {

        OracleConnection connection;
        OracleCommand command;

        public HospitalToolsOCL() {
            string connectionString =
                @"Data Source=LOCALHOST:1521/XE; Persist Security Info=True;User Id=SYSTEM;Password=oracle";
            this.connection = new OracleConnection(connectionString);
            this.command = new OracleCommand();
            this.command.Connection = this.connection;
        }

        public int GetMaximoHospital() {
            this.command.CommandText = "SP_GETMAX_HOSPITAL_COD";
            this.command.CommandType = CommandType.StoredProcedure;

            OracleParameter pamout = new OracleParameter();
                            pamout.ParameterName = "P_MAXOUT";
                            pamout.DbType = DbType.Int32;
                            pamout.Direction = ParameterDirection.Output;

            this.command.Parameters.Add(pamout);

            this.connection.Open();
            this.command.ExecuteNonQuery();
            this.connection.Close();
            int res = int.Parse(pamout.Value.ToString());
            this.command.Parameters.Clear();

            return res;
        }

    }
}
