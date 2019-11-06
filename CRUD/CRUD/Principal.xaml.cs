using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CRUD.Clase;
using SQLite;

namespace CRUD
{
    public partial class Principal : Window
    {
        List<Contactos> contactos;
        public Principal()
        {
            InitializeComponent();
            contactos = new List<Contactos>();
            LeerBaseDatos();
        }

        void LeerBaseDatos()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contactos>();
                contactos = (conn.Table<Contactos>().ToList()).OrderBy(c => c.Nombre).ToList();
                if (contactos != null)
                {
                    lvContactos.ItemsSource = contactos;
                }
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            CRUD.MainWindow form = new CRUD.MainWindow();
            form.ShowDialog();
        }
    }
}
