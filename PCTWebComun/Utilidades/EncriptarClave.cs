using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace PCTWebComun.Utilidades
{
    public static class EncriptarClave
    {
        private static string ClaveDeCifrado = "CIFRADO PCT LTDA";
        /// <summary>
        /// Metodo para encriptar la contraseña ingresada
        /// </summary>
        /// <param name="ClaveOriginal"></param>
        /// <returns></returns>
        public static string Encriptar(string ClaveOriginal)
        {
            string ClaveEnciptada = "";

            string key = ClaveDeCifrado; //llave para encriptar datos

            byte[] keyArray;

            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(ClaveOriginal);

            //Se utilizan las clases de encriptación MD5

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo TripleDES
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            ClaveEnciptada = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            return ClaveEnciptada;
        }

        /// <summary>
        /// Metodo para desencriptar la contraseña ingresada
        /// </summary>
        /// <param name="ClaveEnciptada"></param>
        /// <returns></returns>
        public static string Desencriptar(string ClaveEnciptada)
        {
            string CalveOrginal = "";

            string key = ClaveDeCifrado;
            byte[] keyArray;
            byte[] Array_a_Descifrar = Convert.FromBase64String(ClaveEnciptada);

            //algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

            tdes.Clear();
            CalveOrginal = UTF8Encoding.UTF8.GetString(resultArray);

            return CalveOrginal;
        }

    }

}