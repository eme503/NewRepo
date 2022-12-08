using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Sistema_Comedor_.Models;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Comedor_.Controllers
{
    public class InicioSesionController : Controller
    {
        static string CC = "Data Source=DESKTOP-GT757EA;Initial Catalog=Sistema_Comedor;Integrated Security=true";

        // GET: InicioSesion
        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(ViewModelPersonal personal)
        {
            //Declaramos dos variables
            bool registrado;
            string mensaje;
            //Realizamos una validacion la cual va a verificar la contraseña ingresada 
            //sea la misma al momento de confirmar
            if(personal.Contraseña == personal.Confirmar)
            {
                //Encriptamos la contraseña ingresada
                personal.Contraseña = ConvertirSha256(personal.Contraseña);
            }
            else//en caso contrario muestra un mensaje
            {
                //Mostramos un mensaje
                ViewData["Mensaje"] = "LAS CONTRASEÑAS NO COINCIDEN ;(";
                return View();//Devuelve la vista
            }
            //Procedemos a realizar las operaciones por medio del espacio de nombre
            using (SqlConnection con = new SqlConnection(CC))
            {
                //Creamos un comando para poder realizar nuestra operacion por 
                //medio de  un procedimiento almacenado
                SqlCommand cmd = new SqlCommand("sp_Registrarse", con);
                cmd.Parameters.AddWithValue("Usuario",personal.Usuario);//Le pasamos los parametros a recibir
                cmd.Parameters.AddWithValue("Contraseña", personal.Contraseña);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;//Especificamos que es un procedimiento almacenado
                con.Open();//Abrimos la conexion
                //Ejecutamos el comando
                cmd.ExecuteNonQuery();
                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            //Realizamos una validacion
            //Mostramos un mensaje
            ViewData["Mensaje"] = mensaje;
            if (registrado)//Si el usuario esta registrado con exito nos envia a la siguiente pagina
            {
                return RedirectToAction("", "");
            }
            else
            {
                return View();//Nos devuelve la vista si el proceso sale mal
            }
        }

        [HttpPost]
        public ActionResult Inicio(ViewModelPersonal personal)
        {
            return View();
        }
        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}