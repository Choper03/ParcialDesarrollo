using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParcialDesarrolloWeb
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DataClasses1DataContext db = new DataClasses1DataContext("");
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string direccion = TxtDireccion.Text;
                decimal saldo = decimal.Parse(TxtSueldo.Text);
                string estado = TxtEstado.Text;

                var st = new CLIENTES
                {
                    CODIGO = codigo,
                    NOMBRE = nombre,
                    APELLIDO = apellido,
                    DIRECCION = direccion,
                    SALDO = saldo,
                    ESTADO = estado
                };

                db.CLIENTES.InsertOnSubmit(st);
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Ingreso de datos');", true);

                cargaDatos();
                limpiarCarjas();
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
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string direccion = TxtDireccion.Text;
                string estado = TxtEstado.Text;
                decimal saldo = decimal.Parse(TxtSueldo.Text);

                var stupdate = (from cliente in db.CLIENTES where cliente.CODIGO == codigo select cliente).First();
                stupdate.NOMBRE = nombre;
                stupdate.APELLIDO = apellido;
                stupdate.DIRECCION = direccion;
                stupdate.SALDO = saldo;
                stupdate.ESTADO = estado;
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Actualizado los datos');", true);

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
            var query = from cliente in db.CLIENTES select cliente;
            VistaCliente.DataSource = query;
            VistaCliente.DataBind();
        }

        void limpiarCarjas()
        {
            this.TxtCodigo.Text = "";
            this.TxtNombre.Text = "";
            this.TxtApellido.Text = "";
            this.TxtDireccion.Text = "";
            this.TxtSueldo.Text = "";
            this.TxtEstado.Text = "";
            TxtCodigo.Focus();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaCliente.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                TxtCodigo.Text = VistaCliente.Rows[rowind].Cells[1].Text;
                TxtNombre.Text = VistaCliente.Rows[rowind].Cells[2].Text;
                TxtApellido.Text = VistaCliente.Rows[rowind].Cells[3].Text;
                TxtDireccion.Text = VistaCliente.Rows[rowind].Cells[4].Text;
                TxtSueldo.Text = VistaCliente.Rows[rowind].Cells[5].Text;
                TxtEstado.Text = VistaCliente.Rows[rowind].Cells[6].Text;
            }
            else
            {
                this.TxtCodigo.Text = "";
                this.TxtNombre.Text = "";
                this.TxtApellido.Text = "";
                this.TxtDireccion.Text = "";
                this.TxtSueldo.Text = "";
                this.TxtEstado.Text = "";
                TxtCodigo.Focus();
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = int.Parse(TxtCodigo.Text);


                var stEliminar = (from cliente in db.CLIENTES where cliente.CODIGO == codigo select cliente).First();
                db.CLIENTES.DeleteOnSubmit(stEliminar);
                db.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Eliminados los datos');", true);

                cargaDatos();
                limpiarCarjas();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text != string.Empty)
            {
                var stBuscar = from cliente in db.CLIENTES where cliente.CODIGO == int.Parse(TxtCodigo.Text) select cliente;
                VistaCliente.DataSource = stBuscar;
                VistaCliente.DataBind();
            }
        }
    }
}