using _2P_Aplicada2.BLL;
using _2P_Aplicada2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2P_Aplicada2.UI.Registros
{
    public partial class RegistroVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
            this.textboxId.ReadOnly = true;
            if (!IsPostBack)
            {
                ViewState["venta"] = new Venta();
                int id = Request.QueryString["id"].ToInt();
                if (id > 0)
                {
                    RepositorioBase<Venta> repositorio = new RepositorioBase<Venta>();
                    Venta venta = repositorio.Buscar(id);
                    if (venta == null)
                    {
                        Utilidades.ShowToastr(this, "Venta no encontrada!", "Advertencia", "warning");
                        return;
                    }

                    LlenaCampos(venta);
                    Utilidades.ShowToastr(this, "Venta Encontrada", "Exito!");
                    textboxId.ReadOnly = true;
                }
            }
            else
            {
                Venta venta = (Venta)ViewState["venta"];
            }
        }

        public Venta LlenaClase()
        {
            Venta venta = new Venta
            {
                VentaId = textboxId.Text.ToInt(),
                ClienteId = textboxIdCliente.Text.ToInt(),
                Monto = textboxMonto.Text.ToDecimal(),
                Balance = textboxBalance.Text.ToDecimal()        
            };
            return venta;
        }

        public void LlenaCampos(Venta venta)
        {
            LabelFecha.Text = DateTime.Now.ToString();
            textboxId.Text = venta.VentaId.ToString();
            textboxMonto.Text = venta.Monto.ToString();
            textboxBalance.Text = venta.Balance.ToString();
 
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = textboxId.Text.ToInt();
            if (id == 0)
            {
                Utilidades.ShowToastr(this, "Debes ingresar los datos de busqueda correctamente", "Advertencia", "warning");
                return;
            }

            Venta venta = new RepositorioBase<Venta>().Buscar(id);
            if (venta == null)
            {
                Utilidades.ShowToastr(this, "No se encontro ninguna venta con este id", "Advertencia", "warning");
                return;
            }

            LlenaCampos(venta);
            Utilidades.ShowToastr(this, "Venta Encontrada", "Exito!");
            textboxId.ReadOnly = true;
            return;

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Utilidades.ClearControls(formRegistro, new List<Type>() { typeof(TextBox) });
            textboxId.ReadOnly = false;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Venta venta = LlenaClase();

            bool paso = true;
            if (venta.VentaId > 0)
            {
                paso = new RepositorioBase<Venta>().Modificar(venta);
            }
            else
            {
                paso = new RepositorioBase<Venta>().Guardar(venta);
            }
            if (!paso)
            {
                Utilidades.ShowToastr(this, "Error al intentar guardar la venta!", "Error", "error");
                return;
            }

            Utilidades.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
            Utilidades.ClearControls(formRegistro, new List<Type>() { typeof(TextBox) });
            return;
        }

        private bool EsValido(Venta usuario)
        {
            return true;
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = textboxId.Text.ToInt();
            if (id < 0)
            {
                Utilidades.ShowToastr(this, "Id invalido", "Advertencia", "warning");
                return;
            }
            RepositorioBase<Venta> repositorio = new RepositorioBase<Venta>();
            if (repositorio.Buscar(id) == null)
            {
                Utilidades.ShowToastr(this, "Registro no encontrado", "Advertencia", "warning");
                return;
            }

            bool paso = repositorio.Eliminar(id);
            if (!paso)
            {
                Utilidades.ShowToastr(this, "Error al intentar eliminar el registro", "Error", "error");
                return;
            }

            Utilidades.ShowToastr(this, "Registro eliminado correctamente!", "exito", "success");
            return;
        }

    }
}