using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialDesarrolloWeb
{
    public partial class Contact : Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var clientes = from cliente in db.CLIENTES
                               select new
                               {
                                   ID = cliente.CODIGO,
                                   Nombre = cliente.NOMBRE
                               };


                dropDownListClientes.DataSource = clientes;
                dropDownListClientes.DataTextField = "Nombre"; // Nombre del campo a mostrar
                dropDownListClientes.DataValueField = "ID";
                dropDownListClientes.DataBind();
            }
        }

        

        string codigoClienteSeleccionado = "";

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                int codigoCliente = int.Parse(dropDownListClientes.SelectedValue);
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                string serie = TxtSerie.Text;
                decimal numero = decimal.Parse(TxtNumero.Text);
                decimal monto = decimal.Parse(TxtMonto.Text);
                var saldo = (from cliente in db.CLIENTES where cliente.CODIGO == codigoCliente select cliente).First();
                decimal presupuesto = (decimal)saldo.SALDO;
                if(presupuesto >= monto) { 
                var st = new VENTAS
                    {
                        CODIGO = codigo,
                        CODIGO_CLIENTE = codigoCliente,
                        FECHA = fecha,
                        SERIE_FACTURA = serie,
                        NUMERO_FACTURA = numero,
                        MONTO = monto,
                        ESTADO = "ACTIVO"

                    };
                    db.VENTAS.InsertOnSubmit(st);
                    db.SubmitChanges();

                var clientesaldo = (from cliente in db.CLIENTES where cliente.CODIGO == codigoCliente select cliente).First();
                clientesaldo.SALDO = clientesaldo.SALDO - monto;
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Ingreso de datos');", true);
                    this.TxtMensaje.Text = "";
                    cargaDatos();
                    limpiarCarjas();
                }else
                {
                    this.TxtMensaje.Text = "Saldo Insuficiente, Realice sus pagos lo mas pronto posible";
                }

                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }
       


        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string codigoClienteSeleccionado = dropDownListClientes.SelectedValue;
                int codigoCliente = int.Parse(codigoClienteSeleccionado.ToString());
                decimal monto = decimal.Parse(TxtMonto.Text);

                var stupdate = (from cliente in db.CLIENTES where cliente.CODIGO == codigoCliente select cliente).First();
                decimal saldo = decimal.Parse(stupdate.SALDO.ToString());
                stupdate.SALDO = saldo + monto;
                db.SubmitChanges();

                var stupdate1 = (from venta in db.VENTAS where venta.CODIGO == codigo select venta).First();
                stupdate1.ESTADO = "INACTIVO";
                db.SubmitChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Actualizado los datos');", true);
                TxtMonto.Enabled = true;
                cargaDatos();
                limpiarCarjas();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }

        void cargaDatos()
        {
            var query = from venta in db.VENTAS where venta.ESTADO == "ACTIVO" select venta;
            VistaVenta.DataSource = query;
            VistaVenta.DataBind();
        }

        void limpiarCarjas()
        {
            this.TxtCodigo.Text = "";
            this.TxtSerie.Text = "";
            this.TxtNumero.Text = "";
            this.TxtMonto.Text = "";
            TxtCodigo.Focus();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaVenta.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                TxtCodigo.Text = VistaVenta.Rows[rowind].Cells[1].Text;
                dropDownListClientes.SelectedValue = VistaVenta.Rows[rowind].Cells[2].Text;
                TxtMonto.Text = VistaVenta.Rows[rowind].Cells[6].Text;
                TxtMonto.Enabled = false;
            }
            else
            {
                this.TxtCodigo.Text = "";
                this.TxtMonto.Text = "";
                TxtCodigo.Focus();
            }
        }


        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != string.Empty)
            {
                var stBuscar = from venta in db.VENTAS where venta.CODIGO == int.Parse(TxtCodigo.Text) && venta.ESTADO == "ACTIVO" select venta;
                VistaVenta.DataSource = stBuscar;
                VistaVenta.DataBind();
            }
        }
         void cargarClientes()
        {

                var clientes = from cliente in db.CLIENTES select cliente;
                dropDownListClientes.DataSource = clientes;
                dropDownListClientes.DataTextField = "Nombre"; 
                dropDownListClientes.DataValueField = "Codigo"; 
                dropDownListClientes.DataBind();
            
        }
    }
}