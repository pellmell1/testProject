using System;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace testProject
{



	public partial class Form1 : Form
	{


		Microsoft.Office.Interop.Excel.Application app = null;
		Workbook wb = null;
		Worksheet ws = null;

		enum Column { NO,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,AA,AB,AC,AD,AE,AF }		

		public Form1()
		{
			InitializeComponent();
			
		}


		private void Button_Click(object sender, EventArgs e)
		{
		

			try
			{
                
                
                app = new Microsoft.Office.Interop.Excel.Application();
				app.Visible = true;
	
				wb = app.Workbooks.Open(Filename : @"C:\projector\illuminance meter.xlsx");
				ws = wb.Worksheets.get_Item(1) as Worksheet;
				Microsoft.Office.Interop.Excel.Range range = ws.UsedRange;

				for (int row = 1; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복
				{
					for (int column = 1; column <= range.Columns.Count; column++)  // 가져온 열 만큼 반복
					{
						string str = (string)(range.Cells[row, column] as Microsoft.Office.Interop.Excel.Range).Value2;  // 셀 데이터 가져옴

						Console.Write(str + " ");
					}
					Console.WriteLine();
				}
				//Microsoft.Office.Interop.Excel.Range Area = ws.Cells[Column.G, 2];
				//Microsoft.Office.Interop.Excel.Range G5 = ws.Cells[Column.G, 5];

				// nsole.WriteLine("test--" + Area.Value);

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
			finally
			{
				//변경점 저장하면서 닫기
				wb.Close(true);
				//Excel 프로그램 종료
				app.Quit();
				//오브젝트 해제
				ReleaseExcelObject(wb);
				ReleaseExcelObject(app);
			}
		}

		private void ReleaseExcelObject(object obj)
		{
			try
			{
				if (obj != null)
				{
					Marshal.ReleaseComObject(obj);
					obj = null;
				}
			}
			catch (Exception ex)
			{
				obj = null;
				throw ex;
			}
			finally
			{
				GC.Collect();
			}
		}

    }



}



