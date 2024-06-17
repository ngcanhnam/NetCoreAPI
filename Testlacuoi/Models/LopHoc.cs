using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testlacuoi.Models{

    public class LopHoc(){
        [Key]
        [Display (Name="Ma Lop")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaLop{ get; set; }
        [Display (Name="TenLop")]

        [MaxLength(50)]
        public string TenLop{ get; set;}
    }
}
//dotnet aspnet-codegenerator controller -name LophocController -m lophoc -dc LTQLDb --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -SQLite



//cac package:

//dotnet add package Microsoft.EntityFrameworkCore.Design 
//dotnet add package Microsoft.EntityFrameworkCore.SQLite 
//dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design 
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//dotnet add package Microsoft.EntityFrameworkCore.Tools
//dotnet add package X.PagedList.Mvc.Core 
//dotnet add package EPPLUS


//Trong view phan page o Index:
//@using (Html.BeginForm("Index", "Sinhvien", FormMethod.Get, new { id = "form1"}))
//{
  //  <div class = "row">
    //    <div class="col-md-11">
//
  //          @Html.PagedListPager((IPagedList) Model, page => Url.Action("Index", new //{ page = page,
  //              pageSize = ViewBag.psize}),
    //            new X.PagedList.Mvc.Core.PagedListRenderOptions { LiElementClasses = //new string[] { "page-item" },
  //                  PageClasses = new string[] { "page-link" } })

    //    </div>
      //  <div class="col-md-1">
        //    @Html.DropDownList("pageSize", null, new {@class = "form-select"})
     //   <div>
    //</div>
//}
//<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
//<script>
  //  $(document).ready(function () {
    //    $("#pageSize").change(function () {
      //      $("#form1").submit();
     //   });
   // });
//</script>


//ExcelProcess:


//using System.Data;
//using System.Xml;
//using OfficeOpenXml;

//namespace HaManhKien_11.Models.Process
//{
  //  public class ExcelProcess
    //{
      //  public DataTable ExcelToDataTable(string strPath)
        //{
          //  FileInfo fi = new FileInfo(strPath);
            //ExcelPackage excelPackage = new ExcelPackage(fi);
            //DataTable dt = new DataTable();
            //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty
            //if (worksheet.Dimension == null)
            //{
              //  return dt;
            //}
            //create a list to hold the column names
            //List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers
            //int currentColumn = 1;
            //loop all columns in the sheet and add them to the datatable
            //foreach (var cell in worksheet.Cells[1, 1, 1, //worksheet.Dimension.End.Column])
  //          {
    //            string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
      //          if (cell.Start.Column != currentColumn)
        //        {
          //          columnNames.Add("Header_" + currentColumn);
            //        dt.Columns.Add("Header_" + currentColumn);
              //      currentColumn++;
                //}
                //add the column name to the list to count the duplicates
                //columnNames.Add(columnName);
                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
               // int occurrences = columnNames.Count(x => x.Equals(columnName));
                //if (occurrences > 1)
                //{
                  //  columnName = columnName + "_" + occurrences;
               // }
                //add the column to the datatable
                //dt.Columns.Add(columnName);
                //currentColumn++;
            //}

            //start adding the contents of the excel file to the datatable
            //for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            //{
              //  var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                //DataRow newRow = dt.NewRow();
                //loop all cells in the row
                //foreach (var cell in row)
                //{
                  //  newRow[cell.Start.Column - 1] = cell.Text;
                //}
                //dt.Rows.Add(newRow);
            //}
            //return dt;
        //}
    //}
//})

