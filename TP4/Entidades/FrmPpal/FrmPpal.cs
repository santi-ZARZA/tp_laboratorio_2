using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        #region Atributo
        private Correo correo;
        #endregion

        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        #region Metodos

        private void ActualizarEstados()
        {
            foreach (Control item in this.groupBox1.Controls)
            {
                if(item is ListBox)
                {
                    ((ListBox)item).Items.Clear();
                }
            }

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(((object)elemento) != null)
            {
                if(elemento is Correo)
                {
                    this.rtbMostrar.Text += ((Correo)elemento).ToString();
                }
                else if (elemento is Paquete)
                {
                    this.rtbMostrar.Text += ((Paquete)elemento).ToString();
                }

                GuardarString.Guardar(this.rtbMostrar.Text,"Salida");
            }
        } 

        private void paq_InformaEstado(object sender , EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke( d, new object[] {sender, e} );
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);

            try
            {
                this.correo += paquete;
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException NoSeEspera)
            { MessageBox.Show(NoSeEspera.Message); }
            catch(Exception SeEspera)
            { MessageBox.Show(SeEspera.Message); }

        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void lstEstadoEntregado_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.cmsListas.Show((ListBox)sender, e.Location, ToolStripDropDownDirection.Right);
            }
        }
    }
}
