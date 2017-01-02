using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionDIej1.Models
{
    public class clsCarta:INotifyPropertyChanged
    {
        #region Atributos

        private int _id;
        private String _imagen;
        private Windows.UI.Xaml.Visibility _visible;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public clsCarta(int id, String imagen)
        {
            _id = id;
            _imagen = imagen;
            _visible = Windows.UI.Xaml.Visibility.Collapsed;
        }

        #endregion

        #region GettersSetters

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public String Imagen
        {
            get
            {
                return _imagen;
            }
            set
            {
                _imagen = value;
                OnPropertyChanged("Imagen");
            }
        }

        public Windows.UI.Xaml.Visibility Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                OnPropertyChanged("Visible");
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
