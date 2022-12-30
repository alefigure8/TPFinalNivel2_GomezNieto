using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using helper;
using configuracion;
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace presentación
{
    public partial class frmPresupuesto : Form
    {
        List<Presupuesto> listaPresupuesto = null;
        List<Producto> listaProducto = null;
        ProductoNegocio productoNegocio = null;
        bool GridViewOpen = false;
        Presupuesto auxModificar = null;
        PrintPreviewDialog printPreview = null;

        public frmPresupuesto()
        {
            InitializeComponent();
        }

        private void frmPresupuesto_Load(object sender, EventArgs e)
        {
            listaPresupuesto = new List<Presupuesto>();
            productoNegocio = new ProductoNegocio();
            panelPrespuesto.Height = 50;

            fechaPresupuesto.Text = DateTime.Now.ToShortDateString();

            ComboBoxOptions.comboBoxProductos(cbAgregarPresupuesto);

            listaProducto = productoNegocio.listar();

            OptionGridViewOpen(GridViewOpen);
            opcionModificar();
            cargarImagenes();

            ToolTip guardar = new ToolTip();
            guardar.SetToolTip(btnFile, "Guardar Excel");
            ToolTip imprimir = new ToolTip();
            imprimir.SetToolTip(btnPrinter, "Imprimir presupuesto");
            ToolTip exportar = new ToolTip();
            exportar.SetToolTip(btnExportar, "Copiar a Excel");
        }

        private void cargarImagenes()
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            btnExportar.Load(path + Opciones.Folder.EXPORTAR);
            btnPrinter.Load(path + Opciones.Folder.IMPRIMIR);
            btnFile.Load(path + Opciones.Folder.GUARDARARCHIVO);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridViewOpen = !GridViewOpen;

            if(!GridViewOpen)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show("¿Seguro quiere eliminar el presupuesto?", "Eliminar presupuesto", btn);

                if(result == DialogResult.OK)
                {
                    OptionGridViewOpen(GridViewOpen);
                }
                else
                {
                    GridViewOpen = !GridViewOpen;
                }

                return;
            }

            OptionGridViewOpen(GridViewOpen);
        }

        private void btnAgregarPrespuesto_Click(object sender, EventArgs e)
        {
            if(GridViewOpen)
            {
                if (listaProducto.Any(x => x.Nombre == cbAgregarPresupuesto.Text))
                {
                    //Producto existente
                    Producto producto = (Producto)cbAgregarPresupuesto.SelectedValue;
                    decimal cantidad = numericPrespuesto.Value;
                    Presupuesto productoAux = new Presupuesto();

                    productoAux.Id = producto.Id;
                    productoAux.Codigo = producto.Codigo;
                    productoAux.Nombre = producto.Nombre;
                    productoAux.Descripcion = producto.Descripcion;
                    productoAux.Precio = producto.Precio;
                    productoAux.ImagenURL = producto.ImagenURL;
                    Categoria categoriaAux = new Categoria();
                    categoriaAux.Id = producto.CategoriaInfo.Id;
                    categoriaAux.Descripcion = producto.CategoriaInfo.Descripcion;
                    Marca marcaAux = new Marca();
                    marcaAux.Id = producto.MarcaInfo.Id;
                    marcaAux.Descripcion = producto.MarcaInfo.Descripcion;
                    productoAux.CategoriaInfo = categoriaAux;
                    productoAux.MarcaInfo = marcaAux;
                    productoAux.total = producto.Precio * cantidad;
                    productoAux.cantidad = (int)numericPrespuesto.Value;

                    listaPresupuesto.Add(productoAux);
                    numericPrespuesto.Value = 1;

                    cargarGridView();
                    Total();
                }
                else
                {
                    //Producto Custom
                    Presupuesto aux = new Presupuesto();
                    Marca marca = new Marca();
                    Categoria categoria = new Categoria();
                    aux.Nombre = cbAgregarPresupuesto.Text;
                    aux.cantidad = 1;
                    aux.total = 0;
                    aux.MarcaInfo = marca;
                    aux.CategoriaInfo = categoria;
                    listaPresupuesto.Add(aux);

                    cargarGridView();
                    Total();
                }
            }
            else
            {
                MessageBox.Show("Debe crear un presupuesto primero");
            }

        }

        private void OptionGridViewOpen(bool isOpen)
        {
            panelDescarga.Visible = isOpen;
            panelPrecioTotal.Visible = isOpen;
            fechaPresupuesto.Visible = isOpen;
            panelCargarArchivo.Visible = isOpen;
            btnAgregarPrespuesto.Visible = isOpen;

            if(isOpen)
            {
                lbAgregarPresupuesto.Text = "PRESUPUESTO";
                panelPrespuesto.Height = 300;
                panelBuscadorPresupuesto.Width = 396;
                btnAgregarGrid.Text = "-";
            }
            else
            {
                lbAgregarPresupuesto.Text = "Iniciar nuevo presupuesto";
                btnAgregarGrid.Text = "+";
                panelPrespuesto.Height = 50;
                panelBuscadorPresupuesto.Width = 350;
                dgvPresupuesto.DataSource = null;
                lbDescuentoPrecio.Text = "";
                lbPrecio.Text = "";
                txtDescuento.Text = "";
                listaPresupuesto.Clear();
            }
        }

        private void btEliminarProducto_Click(object sender, EventArgs e)
        {
            if(listaPresupuesto.Count > 0)
            {
                auxModificar = (Presupuesto)dgvPresupuesto.CurrentRow.DataBoundItem;
                listaPresupuesto.Remove(auxModificar);
                auxModificar = null;

                cargarGridView();
                Total();
            }
        }

        private void Total()
        {
            decimal totalPresupuesto = 0;

            foreach (var item in listaPresupuesto)
            {
                totalPresupuesto += item.total;
            }

            if(string.IsNullOrEmpty(txtDescuento.Text))
            {
                lbDescuentoPrecio.Text = "";
                lbPrecio.Text = totalPresupuesto.ToString("c");
            }
            else
            {
                if(Validacion.esNumero(txtDescuento.Text))
                {
                    decimal descuento = Convert.ToDecimal(txtDescuento.Text);
                    decimal totalDescuento = ((descuento * totalPresupuesto) / 100);

                    lbDescuentoPrecio.Text = "-" + (totalPresupuesto * descuento / 100).ToString("c");
                    lbPrecio.Text = (totalPresupuesto - totalDescuento).ToString("c");
                }
            }

        }

        private void cargarGridView()
        {
            dgvPresupuesto.DataSource = null;
            dgvPresupuesto.DataSource = listaPresupuesto;

            dgvPresupuesto.Columns[Opciones.Campo.ID].Visible = false;
            dgvPresupuesto.Columns[Opciones.Campo.URLIMAGEN].Visible = false;
            dgvPresupuesto.Columns[Opciones.Campo.CODIGO].DisplayIndex = 0;
            dgvPresupuesto.Columns[Opciones.Campo.NOMBRE].DisplayIndex = 1;
            dgvPresupuesto.Columns[Opciones.Campo.DESCRIPCION].DisplayIndex = 2;
            dgvPresupuesto.Columns["CategoriaInfo"].DisplayIndex = 3;
            dgvPresupuesto.Columns["MarcaInfo"].DisplayIndex = 4;
            dgvPresupuesto.Columns[Opciones.Campo.PRECIO].DisplayIndex = 5;
            dgvPresupuesto.Columns["Cantidad"].DisplayIndex = 6;
            dgvPresupuesto.Columns["Total"].DisplayIndex = 7;

            dgvPresupuesto.EnableHeadersVisualStyles = false;
        }

        private void dgvPresupuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            auxModificar = (Presupuesto)dgvPresupuesto.CurrentRow.DataBoundItem;
            numericModificarPresupuesto.Value = auxModificar.cantidad;
            txtModificarPrecio.Text = auxModificar.Precio.ToString("N2");
            opcionModificar(true);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar objeto
            auxModificar.cantidad = (int)numericModificarPresupuesto.Value;
            auxModificar.Precio = Convert.ToDecimal(txtModificarPrecio.Text.Replace(".", ","));
            auxModificar.total = auxModificar.cantidad * auxModificar.Precio;

            listaPresupuesto.Remove(auxModificar);
            listaPresupuesto.Add(auxModificar);

            cargarGridView();

            Total();
            opcionModificar();
        }

        private void  opcionModificar(bool isModicado = false)
        {
            btnModificar.Visible = isModicado;
            numericModificarPresupuesto.Visible = isModicado;
            lbModificarcantidad.Visible = isModicado;
            lbModificarPrecio.Visible = isModicado;
            txtModificarPrecio.Visible = isModicado;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog() { Filter = "Excel|*.xlsx", Title = "Guardar Presupuesto", FileName = $"Presupuesto - {DateTime.Now.ToString("dddd, dd MMMM yyyy")}"})
            {
                //Validar si el gridView está vacío
                if(listaPresupuesto.Count() == 0)
                {
                    MessageBox.Show("Selecciones algunos productos antes de generar un archivo");
                    return;
                }

                //Generar archivo
                if(saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveDialog.FileName;
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)excel.ActiveSheet;
                    excel.Visible = false;

                    int index = 6;

                    //Logo de la empresa
                    string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
                    ws.Shapes.AddPicture(path + Opciones.Folder.LOGO, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 180, 15, 100, 35);
                    
                    //Header Documento
                    Range formatRange;
                    formatRange = ws.get_Range("a2");
                    formatRange.Font.Size = 16;
                    formatRange.EntireRow.Font.Bold = true;
                    ws.Cells[2, 1] = "PRESUPUESTO";
                    ws.Cells[2, 7] = "FECHA";
                    ws.Cells[2, 8] = fechaPresupuesto.Text.ToString();

                    //Header de la Grilla
                    formatRange = ws.get_Range("a5", $"h5");
                    formatRange.BorderAround(XlLineStyle.xlContinuous,
                    XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic,
                    XlColorIndex.xlColorIndexAutomatic);
                    formatRange.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    formatRange.Font.Bold = true;

                    ws.Cells[5, 1] = "Código";
                    ws.Cells[5, 2] = "Nombre";
                    ws.Cells[5, 3] = "Descripción";
                    ws.Cells[5, 4] = "Marca";
                    ws.Cells[5, 5] = "Categoria";
                    ws.Cells[5, 6] = "Precio";
                    ws.Cells[5, 7] = "Cantidad";
                    ws.Cells[5, 8] = "Precio Total";

                    //Lista de Productos
                    foreach (var item in listaPresupuesto)
                    {
                        ws.Cells[index, 1] = item.Codigo;
                        ws.Cells[index, 2] = item.Nombre;
                        ws.Cells[index, 3] = item.Descripcion;
                        ws.Cells[index, 4] = item.MarcaInfo.Descripcion;
                        ws.Cells[index, 5] = item.CategoriaInfo.Descripcion;
                        ws.Cells[index, 6] = Math.Round(item.Precio, 2);
                        ws.Cells[index, 7] = item.cantidad;
                        ws.Cells[index, 8] = Math.Round(item.total, 2);

                        index++;
                    }

                    //Recuadro a la grilla
                    formatRange = ws.get_Range("a6", $"h{index - 1}");
                    formatRange.BorderAround(XlLineStyle.xlContinuous,
                    XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic,
                    XlColorIndex.xlColorIndexAutomatic);

                    //Calculos de totales y descuentos
                    decimal total = listaPresupuesto.Sum(x => x.total);
                    decimal descuento = String.IsNullOrEmpty(txtDescuento.Text) ? 0 : (total * Convert.ToDecimal(txtDescuento.Text)) / 100;

                    // Total
                    index += 2;
                    ws.Cells[index, 7].Font.Bold = true;
                    ws.Cells[index, 7] = "TOTAL";
                    ws.Cells[index, 8] = total;
                    ws.Cells[index, 8].NumberFormat = "[$$-en-US] #,##0.00";

                    //Porcentaje Descuento
                    index++;
                    ws.Cells[index, 7].Font.Bold = true;
                    ws.Cells[index, 7] = "PORCENTAJE";
                    ws.Cells[index, 8] = txtDescuento.Text;
                    ws.Cells[index, 8].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    ws.Cells[index, 8].NumberFormat = "@";

                    //Total Descuento
                    index++;
                    ws.Cells[index, 7].Font.Bold = true;
                    ws.Cells[index, 7] = "DESCUENTO";
                    ws.Cells[index, 8] = descuento;
                    ws.Cells[index, 8].NumberFormat = "[$$-en-US] #,##0.00";

                    //Total a Pagar
                    index++;
                    ws.Cells[index, 7].Font.Bold = true;
                    ws.Cells[index, 7] = "TOTAL";
                    ws.Cells[index, 8] = total - descuento;
                    ws.Cells[index, 8].NumberFormat = "[$$-en-US] #,##0.00";

                    //Guardar
                    try
                    {
                        ws.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                        MessageBox.Show("El archivo se ha guardado con éxito");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El archivo no se pudo guardar");
                    }
                    excel.Quit();
                }
            }
            
        }

        private void printPresupuesto_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Font font = new System.Drawing.Font("Tahoma", 18, FontStyle.Bold);
            System.Drawing.Font fontProductos = new System.Drawing.Font("Tahoma", 14);
            System.Drawing.Font fontProductosBold = new System.Drawing.Font("Tahoma", 14, FontStyle.Bold);
            int width = 800;
            int y = 150;

            //Logo de la empresa
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            Bitmap myBitmap = new Bitmap(path + Opciones.Folder.LOGO);
            
            e.Graphics.DrawImage(myBitmap, new System.Drawing.Rectangle(300, 20, 250, 75));
            e.Graphics.DrawString("PRESUPUESTO", font, Brushes.Black, new RectangleF(40, y, width, 40 ));
            e.Graphics.DrawString($"{fechaPresupuesto.Text}", font, Brushes.Black, new RectangleF(450, y, width, 40 ));

            y += 80;
            e.Graphics.DrawString("NOMBRE", fontProductosBold, Brushes.Black, new RectangleF(40, y, width, 40));
            e.Graphics.DrawString("PRECIO", fontProductosBold, Brushes.Black, new RectangleF(240, y, width, 40));
            e.Graphics.DrawString("CANTIDAD", fontProductosBold, Brushes.Black, new RectangleF(440, y, width, 40));
            e.Graphics.DrawString("TOTAL", fontProductosBold, Brushes.Black, new RectangleF(640, y, width, 40));

            y += 40;
            foreach (var item in listaPresupuesto)
            {
                y += 20;
                e.Graphics.DrawString($"{item.Nombre}", fontProductos, Brushes.Black, new RectangleF(40, y, width, 20));
                e.Graphics.DrawString($"{item.Precio}", fontProductos, Brushes.Black, new RectangleF(240, y, width, 20));
                e.Graphics.DrawString($"{item.cantidad}", fontProductos, Brushes.Black, new RectangleF(440, y, width, 20));
                e.Graphics.DrawString($"{item.total}", fontProductos, Brushes.Black, new RectangleF(640, y, width, 20));
            }

            y += 80;
            e.Graphics.DrawString($"DESCUENTO: {lbDescuentoPrecio.Text}", fontProductosBold, Brushes.Black, new RectangleF(450, y, width, 40));

            y += 40;
            e.Graphics.DrawString($"TOTAL: {lbPrecio.Text}", font, Brushes.Black, new RectangleF(450, y, width, 40));
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if(listaPresupuesto.Count() == 0)
            {
                MessageBox.Show("Pruebe cargando algunos productos antes de imprimir");
                return;
            }

            printPresupuesto = new PrintDocument();
            PrinterSettings printerSetting = new PrinterSettings();
            printPresupuesto.PrinterSettings = printerSetting;
            printPresupuesto.PrintPage += printPresupuesto_PrintPage;

            printPreview = new PrintPreviewDialog();
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            printPreview.Icon = new System.Drawing.Icon(path + Opciones.Folder.ICONO);
            printPreview.MinimumSize = new Size(375, 250);
            printPreview.SetBounds(100, -550, 800, 800);
            printPreview.Document = printPresupuesto;

            printPreview.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Total();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dgvPresupuesto.SelectAll();
            DataObject copyData = dgvPresupuesto.GetClipboardContent();
            if (copyData != null)
            {
                Clipboard.SetDataObject(copyData);
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                xlapp.Visible = true;
                Workbook xlwbook;
                Worksheet xlsheet;

                object miseddata = System.Reflection.Missing.Value;
                xlwbook = xlapp.Workbooks.Add(miseddata);

                xlsheet = (Worksheet)xlwbook.Worksheets.get_Item(1);
                Range xlr = (Range)xlsheet.Cells[1, 1];
                xlr.Select();

                xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            //cargar archivo
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Excel Files | *.xls; *.xlsx; *.xlsm;";
            oFile.Title = "Importar presupuesto";

            if(oFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    importarPresupuestoExcel(oFile.FileName);
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al cargar Archivo");
                }
                cargarGridView();
                Total();
                opcionModificar();
            }
        }

        List<Presupuesto> importarPresupuestoExcel(string path)
        {
            listaPresupuesto.Clear();

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;

            int iRow;

            xlWorkBook = xlApp.Workbooks.Open(path);         
            xlWorkSheet = xlWorkBook.Worksheets["Hoja1"];

            for (iRow = 6; iRow <= xlWorkSheet.Rows.Count; iRow++) 
            {
                if (xlWorkSheet.Cells[iRow, 1].value != null)
                {
                    try
                    {
                        Presupuesto aux = new Presupuesto();
                        aux.Codigo = xlWorkSheet.Cells[iRow, 1].value;
                        aux.Nombre = xlWorkSheet.Cells[iRow, 2].value;
                        aux.Descripcion = xlWorkSheet.Cells[iRow, 3].value;
                        Marca marca = new Marca();
                        marca.Descripcion = xlWorkSheet.Cells[iRow, 4].value;
                        aux.MarcaInfo = marca;
                        Categoria categoria = new Categoria();
                        categoria.Descripcion = xlWorkSheet.Cells[iRow, 5].value;
                        aux.CategoriaInfo = categoria;
                        aux.Precio = Convert.ToDecimal(xlWorkSheet.Cells[iRow, 6].value);
                        aux.cantidad = Convert.ToInt32(xlWorkSheet.Cells[iRow, 7].value);
                        aux.total = Convert.ToDecimal(xlWorkSheet.Cells[iRow, 8].value);
                        listaPresupuesto.Add(aux);

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    break;
                }
            }

             iRow +=3;

            if (xlWorkSheet.Cells[iRow, 8].value != null)
            {
                txtDescuento.Text = xlWorkSheet.Cells[iRow, 8].value.ToString();
            }

            Total();

            xlWorkBook.Close();
            xlApp.Quit();

            return listaPresupuesto;
        }
    }
}
