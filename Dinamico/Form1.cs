using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dinamico
{

    /*
     * FORM que trabaja con un groupbox y un flowlayout.
     * Para el segundo caso se plantea generar un nº de botones determinados por el usuario
     * Mostrará proverbios aleatorios de un array con 5 elementos de prueba.
     */
    public partial class Form1 : Form
    {
        // Array que contendrá 5 mensajes para mostrar en botones.
       static String[] arrayMensajes = new string[5];

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
              // Método que crea el contenido de los comboBox.
               cargarColecciones();
            // Método que carga frases del array.
                asignarMensajes();

        }

        private void cargarColecciones() {
            // Cargar la primera colección
            for (int i = 0; i <= 20; i++) {
                comboBox1.Items.Add(i);
            }

            // Cargar segunda coleccion

            for (int i = 0; i <= 20; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                // Limpiamos el group para mostrar cada vez el numero de botones dado por el usuario.
                
            groupBox1.Controls.Clear();
            for (int i = 0; i < Convert.ToInt16(comboBox1.Text); i++) {
                Button boton = new Button();
                boton.SetBounds(100 * i, 10, 70, 20);
                boton.Text = Convert.ToString(i + 1);
                groupBox1.Controls.Add(boton);
            }
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * El flowlayout ajusta de forma automática los elementos dentro del panel.
             */

            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < Convert.ToInt16(comboBox2.Text); i++)
            {
                Button boton = new Button();
                boton.Click += Boton_Click;
                boton.Text = Convert.ToString(i+1);
                flowLayoutPanel1.Controls.Add(boton);
            }
        }



        private void Boton_Click(object sender, EventArgs e)

        {
            MessageBox.Show(arrayMensajes[aleatorio()], "Proverbios");

           //  MessageBox.Show(Convert.ToString(aleatorio()),"Número aleatorio");
        }

        private int aleatorio() {
            Random aleatorio = new Random();
           return  aleatorio.Next(0, 4);
            
        }

        private void asignarMensajes() {
            arrayMensajes[0] = "El que busca un amigo sin defectos se queda sin amigos.";
            arrayMensajes[1] = "La gente se arregla todos los días el cabello. ¿Por qué no el corazón?";
            arrayMensajes[2] = "Si lo que vas a decir no es más bello que el silencio: no lo digas.";
            arrayMensajes[3] = "La paciencia es un árbol de raíz amarga pero de frutos muy dulces.";
            arrayMensajes[4] = "Si te caes siete veces, levántate ocho.";
        }

      
    }
}
