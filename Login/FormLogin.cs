﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.Login
{
    public partial class FormLogin : Form
    {
        int intentos = 0;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {

            rolesDeUsuario objRolUsuario = new rolesDeUsuario();
            modeloUsuario objUsuario = new modeloUsuario();
            SqlDataReader loguear;
            objUsuario.usuario = txtUsuario.Text;
            objUsuario.contrasena = txtPassword.Text;
            loguear = objUsuario.iniciarSesion();
            if (loguear.Read()==true)
            {
                Program.sesion.setUsuario(txtUsuario.Text);
                if(objRolUsuario.contarRolesSegunUsuario(txtUsuario.Text) == 1)
                {
                    int unRol = 0;
                    string rol;
                    Program.sesion.setIdRol(objRolUsuario.encontrarRolSegunUsuario(txtUsuario.Text,unRol, out rol));
                    Program.sesion.setRol(rol);
                    ventanaAdmin nuevaVentanaAdmin = new ventanaAdmin();
                    this.Hide();
                    nuevaVentanaAdmin.Show();
                    this.Close();
                    
                }
                else if(objRolUsuario.contarRolesSegunUsuario(txtUsuario.Text) >= 2)
                {
                    //lo mando a la ventana para que elija que rol quiere elegir

                    listadoDeRol nuevaVentanaListadoDeRol = new listadoDeRol();
                    this.Hide();
                    nuevaVentanaListadoDeRol.Show();
                    this.Close();
                    
                }
            }
            else if (intentos < 2) 
            {
                intentos = intentos + 1;
                MessageBox.Show("Usuario/Contraseña invalida"); 
                
            }
            else 
            { 
                ventanaSesionCaducada sesionCaducada = new ventanaSesionCaducada();
                this.Hide();
                sesionCaducada.Show();
                this.Close(); 
            }
        }

    }
}


