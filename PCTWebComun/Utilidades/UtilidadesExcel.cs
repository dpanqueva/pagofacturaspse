using ClosedXML.Excel;
using ClosedXML.Extensions;
using System.Data;
using System.Web.Mvc;

namespace PCTWebComun.Utilidades
{
    public static class UtilidadesExcel
    {
        public static FileStreamResult GenerarExcel(DataTable data, string NombreArchivo)
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(data,data.TableName);
                return workbook.Deliver(NombreArchivo + ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }


    }
}
