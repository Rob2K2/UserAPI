using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.DB;
using UserAPI.Models;

namespace UserAPI.DAL
{
    public class UserDAL
    {
        public List<User> ListarUsuarios()
        {
            var users = new List<User>();
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "SELECT  id userid, first_name firstname, last_name lastname, nickname " +
                                "FROM kudos_usuarios.kudos_users";

                    var cmd = new MySqlCommand(query, con);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var user = new User
                            {
                                UserID = Convert.ToInt32(dr["userid"]),
                                FirstName = dr["firstname"].ToString(),
                                LastName = dr["lastname"].ToString(),
                                NickName = dr["nickname"].ToString()
                            };
                            users.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return users;
        }

        public User ObtenerUsuario(int id)
        {
            var user = new User();
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "SELECT  id userid, first_name firstname, last_name lastname, nickname " +
                                "FROM kudos_usuarios.kudos_users " +
                                "WHERE id = ?";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                    using (var dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            user.UserID = Convert.ToInt32(dr["userid"]);
                            user.FirstName = dr["firstname"].ToString();
                            user.LastName = dr["lastname"].ToString();
                            user.NickName = dr["nickname"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public bool CrearUsuario(User user)
        {
            bool respuesta = false;
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "INSERT INTO kudos_usuarios.kudos_users (first_name, last_name, nickname) " +
                                "VALUES(?, ?, ?)";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = user.NickName;
                    
                    respuesta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool ActualizarUsuario(User user)
        {
            bool respuesta = false;
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();
                    var query = "UPDATE kudos_usuarios.kudos_users " +
                                "SET first_name=?, last_name=?, nickname =? " +
                                "WHERE id = ?";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = user.FirstName;
                    cmd.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = user.LastName;
                    cmd.Parameters.Add("@nickname", MySqlDbType.VarChar).Value = user.NickName;
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = user.UserID;

                    respuesta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool EliminarUsuario(int userID)
        {
            bool respuesta = false;
            try
            {
                using (var con = Connection.ConexionMysql())
                {
                    con.Open();

                    var query = "DELETE FROM kudos_usuarios.kudos_users " +
                                "WHERE id=? ";

                    var cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = userID;

                    respuesta = Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
    }
}
