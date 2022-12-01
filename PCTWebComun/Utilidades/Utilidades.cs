//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24/12/2020 - Ticket N° 039274 - Caso: Se agrega funcion para calcular las paginas en que se dividirá una consulta - Participantes: Jaime Zuleta

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Utilidades
{
    public class UtilidadesComun
    {
        public String lmensaje;
        public Int32 lNumPrimeraPagina, lUltimaPagina;
        public DataTable dtContenidoPaginacion, dtPagActual;

        public string ConvertirFecha(string FormatoEntrada, string FormatoSalida, string Fecha)
        {
            string FechaNueva = DateTime.ParseExact(Fecha,
                                               FormatoEntrada,
                                               CultureInfo.InvariantCulture).ToString(FormatoSalida);
            return FechaNueva;
        }

        public Boolean CalculoPaginasConsSqlPag(DataTable dtTotalReg)
        {
            Boolean resp = true;
            Int32 TotalRegistros;

            try
            {
                TotalRegistros = Convert.ToInt32(dtTotalReg.Rows[0][0].ToString());

                if (TotalRegistros > 0)
                {
                    if ((TotalRegistros % 15) == 0)
                    {
                        lUltimaPagina = (TotalRegistros / 15);
                    }
                    else
                    {
                        lUltimaPagina = ((TotalRegistros / 15) + 1);
                    }

                    lNumPrimeraPagina = 1;
                }
                else
                {
                    lNumPrimeraPagina = 0;
                    lUltimaPagina = 0;
                }
            }
            catch (Exception)
            {
                resp = false;
                lNumPrimeraPagina = 0;
                lUltimaPagina = 0;
            }

            return resp;
        }

        public Boolean EscribirLog(String Mensaje)
        {
            Boolean resp = true;
            try
            {
                string Ruta = "C:\\PCTG\\Logs";

                using (StreamWriter ArchivoLog = new StreamWriter(Path.Combine(Ruta, "LogComun.log"), true))
                {
                    ArchivoLog.WriteLine("Date: " + DateTime.Now.ToString() + " - " + Mensaje);
                }


            }
            catch (Exception)
            {
                resp = false;

            }

            return resp;

        }
    }
}
