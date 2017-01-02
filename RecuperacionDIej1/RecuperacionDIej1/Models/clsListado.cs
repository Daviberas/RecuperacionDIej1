using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionDIej1.Models
{
    public class clsListado
    {
        #region Atributos

        ObservableCollection<clsCarta> lista;

        #endregion

        #region Métodos

        /// <summary>
        /// Método que proporciona un listado de Cartas.
        /// </summary>
        /// <returns>Un listado de Cartas</returns>
        public ObservableCollection<clsCarta> getListado()
        {
            lista = new ObservableCollection<clsCarta>();

            lista.Add(new clsCarta(1, "/Assets/AR-15.jpg"));
            lista.Add(new clsCarta(2, "/Assets/Ballesta.jpg"));
            lista.Add(new clsCarta(3, "/Assets/Colt.jpg"));
            lista.Add(new clsCarta(4, "/Assets/Katana.jpg"));
            lista.Add(new clsCarta(5, "/Assets/Lucille.jpg"));
            lista.Add(new clsCarta(6, "/Assets/Martillo.jpg"));
            lista.Add(new clsCarta(1, "/Assets/Sasha.jpg"));
            lista.Add(new clsCarta(2, "/Assets/Daryl.jpg"));
            lista.Add(new clsCarta(3, "/Assets/Rick.jpg"));
            lista.Add(new clsCarta(4, "/Assets/Michonne.jpg"));
            lista.Add(new clsCarta(5, "/Assets/Negan.jpg"));
            lista.Add(new clsCarta(6, "/Assets/Tyreese.jpg"));

            return lista;
        }

        #endregion
    }
}
