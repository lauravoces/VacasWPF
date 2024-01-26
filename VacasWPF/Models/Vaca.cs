using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacasWPF.Models
{
    public class Vaca : INotifyPropertyChanged,IEditableObject
    {

        #region Constructores

        public Vaca() { }

        public Vaca(int id, string nomMunicipio, DateTime f_nacim, DateTime f_destete, int alzada, int peso, string sexo, string tipo)
        {
            this.id = id;
            _nomMunicipio = nomMunicipio;
            _f_nacim = f_nacim;
            _f_destete = f_destete;
            _alzada = alzada;
            _peso = peso;
            _sexo = sexo;
            _tipo = tipo;
        }


        #endregion

        #region Propiedades
        [Key] 
        public int id { get; set; }
        public string nomMunicipio
        {
            get { return _nomMunicipio; }
            set { if (_nomMunicipio != value)
                {
                    _nomMunicipio = value;
                    OnPropertyChanged(nameof(nomMunicipio));
                }
                }
        }
        [Format("dd/MM/YYYY")]
        public DateTime f_nacim { get => _f_nacim; set => _f_nacim = value; }
        [Format("dd/MM/YYYY")]
        public DateTime f_destete { get => _f_destete; set => _f_destete = value; }
        public int alzada { get => _alzada; set => _alzada = value; }
        public int peso { get => _peso; set => _peso = value; }
        public string sexo { get => _sexo; set => _sexo = value; }
        public string tipo { get => _tipo; set => _tipo = value; }

        #endregion

        #region Variables miembro privadas
        private string _nomMunicipio;
        private DateTime _f_nacim;
        private DateTime _f_destete;
        private int _alzada;
        private int _peso;
        private string _sexo;
        private string _tipo;


        #endregion

        #region Implementacion de interfaces
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string oldNomMunicipio;
        public void BeginEdit()
        {
            oldNomMunicipio = this._nomMunicipio;
        }
        public void CancelEdit() {
            this._nomMunicipio = oldNomMunicipio;
        }
        public void EndEdit() {   }
        #endregion


    }

}
