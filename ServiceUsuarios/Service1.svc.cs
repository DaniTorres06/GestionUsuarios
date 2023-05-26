using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        List<UsuariosDTO> LstUsuarios = new List<UsuariosDTO>();
        

        public string GetData(int value)
        {
            //informacion2 = Getusuarios();
            return string.Format("You entered: {0}", value);
        }

        public List<UsuariosDTO> Consultar()
        {
            SqlConnection sqlConexion = new SqlConnection(connectionString);
            SqlCommand Comm = null;

            try
            {
                //using (SqlConnection sqlConexion = new SqlConnection(connectionString))
                {
                    sqlConexion.Open();


                    Comm = sqlConexion.CreateCommand();
                    Comm.CommandText = "dbo.UsuariosGet";
                    Comm.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = Comm.ExecuteReader();

                    while (reader.Read())
                    {
                        LstUsuarios.Add(new UsuariosDTO()
                        {
                            Id = Int32.Parse(reader["Id"].ToString()),
                            Nombre = reader["Nombre"].ToString(),
                            FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString()),
                            Sexo = reader["Sexo"].ToString()
                        });
                    }
                    sqlConexion.Close();
                }
                return LstUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al mostrar los usuarios." + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }

        public UsuariosDTO GetusuariosXId(int vId)
        {
            SqlConnection sqlConexion = new SqlConnection(connectionString);
            SqlCommand Comm = null;
            UsuariosDTO vObjUsuario = new UsuariosDTO();

            try
            {
                //using (SqlConnection sqlConexion = new SqlConnection(connectionString))
                {
                    sqlConexion.Open();


                    Comm = sqlConexion.CreateCommand();
                    Comm.CommandText = "dbo.UsuariosGetxId";
                    Comm.CommandType = CommandType.StoredProcedure;
                    Comm.Parameters.Add("@Id", SqlDbType.Int).Value = vId;
                    SqlDataReader reader = Comm.ExecuteReader();

                    while (reader.Read())
                    {
                        {
                            vObjUsuario.Id = Int32.Parse(reader["Id"].ToString());
                            vObjUsuario.Nombre = reader["Nombre"].ToString();
                            vObjUsuario.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                            vObjUsuario.Sexo = reader["Sexo"].ToString();
                        };
                        LstUsuarios.Add(vObjUsuario);
                    }
                    sqlConexion.Close();
                }
                return vObjUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al mostrar los usuarios." + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }

        public void Agregar(UsuariosDTO usuariosDTO)
        {
            SqlConnection sqlConexion = new SqlConnection(connectionString);
            SqlCommand Comm = null;
            UsuariosDTO vObjUsuario = new UsuariosDTO();

            try
            {
                //using (SqlConnection sqlConexion = new SqlConnection(connectionString))
                {
                    sqlConexion.Open();
                    Comm = sqlConexion.CreateCommand();
                    Comm.CommandText = "dbo.UsuariosAdd";
                    Comm.CommandType = CommandType.StoredProcedure;

                    Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = usuariosDTO.Nombre;
                    Comm.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = usuariosDTO.FechaNacimiento;
                    Comm.Parameters.Add("@Sexo", SqlDbType.Char,1).Value = usuariosDTO.Sexo;
                    Comm.ExecuteNonQuery();


                    sqlConexion.Close();
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al guardar el usuario." + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }

        public void Modificar(UsuariosDTO usuariosDTO)
        {
            SqlConnection sqlConexion = new SqlConnection(connectionString);
            SqlCommand Comm = null;
            UsuariosDTO vObjUsuario = new UsuariosDTO();

            try
            {
                //using (SqlConnection sqlConexion = new SqlConnection(connectionString))
                {
                    sqlConexion.Open();
                    Comm = sqlConexion.CreateCommand();
                    Comm.CommandText = "dbo.UsuariosUpdate";
                    Comm.CommandType = CommandType.StoredProcedure;
                    Comm.Parameters.Add("@Id", SqlDbType.Int).Value = usuariosDTO.Id;
                    Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = usuariosDTO.Nombre;
                    Comm.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = usuariosDTO.FechaNacimiento;
                    Comm.Parameters.Add("@Sexo", SqlDbType.Char,1).Value = usuariosDTO.Sexo;
                    Comm.ExecuteNonQuery();


                    sqlConexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al editar el usuario." + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }

        public void Eliminar(int vId)
        {
            SqlConnection sqlConexion = new SqlConnection(connectionString);
            SqlCommand Comm = null;
            UsuariosDTO vObjUsuarioxId = new UsuariosDTO();
            vObjUsuarioxId = GetusuariosXId(vId);

            try
            {
                //using (SqlConnection sqlConexion = new SqlConnection(connectionString))
                {
                    sqlConexion.Open();
                    Comm = sqlConexion.CreateCommand();
                    
                    Comm.CommandText = "dbo.UsuariosDelete";
                    Comm.CommandType = CommandType.StoredProcedure;
                    Comm.Parameters.Add("@Id", SqlDbType.Int).Value = vId;
                    Comm.ExecuteNonQuery();

                    sqlConexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al eliminar el usuario." + ex.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }
        }




        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
