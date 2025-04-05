using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2023_1721
{
    public partial class Contactos : Form
    {
        private int idSeleccionado;
        public Contactos()
        {
            InitializeComponent();
            CargarContactos();
        }

        private void CargarContactos()
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Contactos", cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Contactos (Nombre, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)", cn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.ExecuteNonQuery();
                CargarContactos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Contactos SET Nombre=@Nombre, Telefono=@Telefono, Correo=@Correo WHERE Id=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", idSeleccionado);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.ExecuteNonQuery();
                CargarContactos();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Contactos WHERE Id=@Id", cn);
                cmd.Parameters.AddWithValue("@Id", idSeleccionado);
                cmd.ExecuteNonQuery();
                CargarContactos();
            }
        }
    }
    
}
