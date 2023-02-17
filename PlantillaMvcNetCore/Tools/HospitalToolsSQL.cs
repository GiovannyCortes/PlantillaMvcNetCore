using System.Data;
using System.Data.SqlClient;

#region Procedure
/*
    CREATE PROCEDURE SP_GETMAX_HOSPITAL_COD (@MAXOUT INT OUT) AS
	    SELECT @MAXOUT = (HOSPITAL_COD)+1 FROM HOSPITAL
    GO
 */
#endregion

namespace PlantillaMvcNetCore.Tools {
    public class HospitalToolsSQL : IHospitalTools {

        SqlConnection connection;
        SqlCommand command;

        public HospitalToolsSQL() {
            string connectionString = 
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public int GetMaximoHospital() {
            this.command.CommandText = "SP_GETMAX_HOSPITAL_COD";
            this.command.CommandType = CommandType.StoredProcedure;

            SqlParameter pamout = new SqlParameter("@MAXOUT", 0);
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
