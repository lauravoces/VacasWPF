using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VacasWPF.Models;

namespace VacasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillDataGrid();
        }

        /// <summary>
        /// Lista de vacas
        /// </summary>
        private List<Vaca> lstVacas { get; set; }

        private AppVacasDBContext context = new AppVacasDBContext();

        private void fillDataGrid()
        {
            this.DataContext = context;
            using (var reader = new StreamReader(LogicaNegocio.RutaArchivo))
            using (var csv = new CsvReader(reader, LogicaNegocio.CsvConfig))
            {
                lstVacas = new List<Vaca>(csv.GetRecords<Vaca>().ToList());
                lstVacas.ForEach(v => context.Vacas.Add(v));
            }
        }

        private void btnNueva_Click(object sender, RoutedEventArgs e)
        {
            int newKey = context.Vacas.Max(v => v.id) + 1;
            Vaca newVaca = new Vaca(newKey, 
                "Oviedo", 
                new DateOnly(2008, 4, 2), 
                new DateOnly(2008, 9, 21), 
                123, 
                87, 
                "H",
                "C");
            context.Vacas.Add(newVaca);
            context.SaveChanges();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            context.Vacas.Remove(dgVacas.SelectedItem as Vaca);
            context.SaveChanges();
        }
    }
}