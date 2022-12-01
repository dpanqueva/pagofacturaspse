using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Configuration;

namespace PCTWebComun.Utilidades
{
    public class UtilidadesReporte
    {
       public Stream GenerarReporte(string Reporte, string Modulo, List<DataTable> Datos, string NombreDataset, out string NombreArchivo)
        {
            // Creamos el dataset
            DataSet dsReporte = new DataSet();
            dsReporte.DataSetName = NombreDataset;

            // Añadimos las tablas

            foreach (var dato in Datos)
            {
                dsReporte.Tables.Add(dato);
            }

            // D:/PCT .NET/PCT .NET/Views/{mod}/reportes/{reporte}.rpt
            // Obtenemos el directorio donde se encuentran los reportes
            string rutaBaseReportes = WebConfigurationManager.AppSettings["DirectorioReportes"];

            // Creamos la ruta completa teniendo en cuenta el modulo y el reporte
            string rutaReporte = rutaBaseReportes.Replace("{mod}", Modulo).Replace("{reporte}", Reporte);

            // Creamos un nuevo reporte
            ReportDocument rpt = new ReportDocument();

            // Cargamos el reporte que queremos obtener
            rpt.Load(rutaReporte);

            // Cargamos el dataset con las tablas correspondientes
            // rpt.SetDatabaseLogon(WebConfigurationManager.AppSettings["usuario"], WebConfigurationManager.AppSettings["clave"]);
            rpt.SetDataSource(dsReporte);

            // Creamos un flujo de datos para obtener el archivo del reporte, especificando el formato

            NombreArchivo = Reporte + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

            return rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }
    }
}
