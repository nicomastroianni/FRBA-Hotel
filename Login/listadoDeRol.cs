﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrbaHotel.Login
{
    public partial class listadoDeRol : Form
    {
        public listadoDeRol()
        {
            InitializeComponent();
        }

        private void listadoDeRol_Load(object sender, EventArgs e)
        {
            ListarRoles();
        }

        private void ListarRoles()
        {

            rolesDeUsuario objRoles = new rolesDeUsuario();
            cmbListaRoles.DataSource = objRoles.listarRoles();
            cmbListaRoles.DisplayMember = "NOMBRE";
            cmbListaRoles.ValueMember = "ID_ROL";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Program.sesion.setRol(cmbListaRoles.Text);
            Program.sesion.setIdRol((Int32)cmbListaRoles.SelectedValue);
           
            ventanaAdmin nuevaVentanaAdmin = new ventanaAdmin();
            this.Hide();
            this.Close();
            
            nuevaVentanaAdmin.Show();
           
        }

    }
}
