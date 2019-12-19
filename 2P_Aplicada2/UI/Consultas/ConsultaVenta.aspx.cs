using _2P_Aplicada2.BLL;
using _2P_Aplicada2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2P_Aplicada2.UI.Consultas
{
    public partial class ConsultaVenta : System.Web.UI.Page
    {
            List<Venta> lista = new List<Venta>();

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    this.FechaDesdeTextBox.Text = DateTime.Now.ToFormatDate();
                    this.FechaHastaTextBox.Text = DateTime.Now.ToFormatDate();
                }
            }

            protected void FechaCheckBox_CheckedChanged(object sender, EventArgs e)
            {
                if (FechaCheckBox.Checked)
                {
                    FechaDesdeTextBox.Enabled = true;
                    FechaHastaTextBox.Enabled = true;
                }
                else
                {
                    FechaDesdeTextBox.Enabled = false;
                    FechaHastaTextBox.Enabled = false;
                }
            }

            protected void BuscarButton_Click(object sender, EventArgs e)
            {
                SetDataSource(BuscarDatos());
            }

            public void SetDataSource(List<Venta> listaVentas)
            {
                DatosGridView.DataSource = null;
                DatosGridView.DataSource = listaVentas;
                lista = listaVentas;
                DatosGridView.DataBind();
            }

            public List<Venta> BuscarDatos()
            {
                int filtroIndex = BuscarPorDropDownList.SelectedIndex;
                string criterio = FiltroTextBox.Text;
                DateTime fechaInicio = FechaDesdeTextBox.Text.ToDatetime();
                DateTime fechaFin = FechaHastaTextBox.Text.ToDatetime();

                Expression<Func<Venta, bool>> expression = x => true;

                if (FechaCheckBox.Checked)
                {
                    switch (filtroIndex)
                    {
                        case 0:
                            expression = x => true && x.Fecha >= fechaInicio && x.Fecha <= fechaInicio;
                            break;
                        case 1:
                            expression = x => x.VentaId == criterio.ToInt() && x.Fecha >= fechaInicio && x.Fecha <= fechaInicio;
                            break;
                    }
                }
                else
                {
                    switch (filtroIndex)
                    {
                        case 0:
                            expression = x => true;
                            break;
                        case 1:
                            int id = criterio.ToInt();
                            expression = x => x.VentaId == id;
                            break;
                    }
                }

                List<Venta> listaVentas = new RepositorioBase<Venta>().GetList(expression);
                return listaVentas;
            }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~\ReporteVenta.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("Venta", lista));
                ReportViewer1.LocalReport.Refresh();
            }
        }
    }
}