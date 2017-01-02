using RecuperacionDIej1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RecuperacionDIej1.ViewModels
{
    public class clsMainPageVM : VMBase
    {
        #region Propiedades

        private ObservableCollection<clsCarta> lista;
        private clsCarta cartaSeleccionada;
        private clsCarta cartaSeleccionada2;
        private bool clickable;
        private String textoReloj;
        private String mensajeVictoria;
        private int parejasCorrectas;
        private Stopwatch reloj = new Stopwatch();

        #endregion

        #region Constructor

        public clsMainPageVM()
        {
            lista = new ObservableCollection<clsCarta>();
            cartaSeleccionada = null;
            cartaSeleccionada2 = null;
            parejasCorrectas = 0;

            Clickable = true;

            lista = new clsListado().getListado();

            mezclarCartas();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            reloj.Start();
        }

        #endregion

        #region GettersSetters

        public ObservableCollection<clsCarta> Lista
        {
            get
            {
                return lista;
            }

            set
            {
                lista = value;
                NotifyPropertyChanged("Lista");
            }
        }

        public clsCarta CartaSeleccionada
        {
            get
            {
                return cartaSeleccionada;
            }

            set
            {
                cartaSeleccionada = value;
                NotifyPropertyChanged("CartaSeleccionada");
                Clickable = false;
                compruebaPareja();

            }
        }

        public clsCarta CartaSeleccionada2
        {
            get
            {
                return cartaSeleccionada2;
            }

            set
            {
                cartaSeleccionada2 = value;
                NotifyPropertyChanged("CartaSeleccionada2");
            }
        }

        public String TextoReloj
        {
            get
            {
                return this.textoReloj;
            }
            set
            {
                this.textoReloj = value;
                NotifyPropertyChanged("TextoReloj");
            }
        }

        public String MensajeVictoria
        {
            get
            {
                return this.mensajeVictoria;
            }
            set
            {
                this.mensajeVictoria = value;
                NotifyPropertyChanged("MensajeVictoria");
            }
        }

        public bool Clickable
        {
            get
            {
                return clickable;
            }

            set
            {
                clickable = value;
                NotifyPropertyChanged("Clickable");
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para mezclar las cartas aleatoriamente.
        /// </summary>

        private void mezclarCartas()
        {
            Random random = new Random();
            int aleatorio;

            for (int i = 0; i < lista.Count; i++)
            {
                aleatorio = random.Next(12);

                lista.Move(i, aleatorio);
            }
        }



        /// <summary>
        /// Método asíncrono que comprueba las parejas correctas y cuando se hayan encontrado todas se para el juego
        /// </summary>

        private async void compruebaPareja()
        {
            if (CartaSeleccionada != null)
            {
                if (CartaSeleccionada.Visible != Windows.UI.Xaml.Visibility.Visible)
                {
                    if (CartaSeleccionada2 == null)
                    {
                        CartaSeleccionada.Visible = Windows.UI.Xaml.Visibility.Visible;
                        CartaSeleccionada2 = CartaSeleccionada;
                    }
                    else
                    {
                        CartaSeleccionada.Visible = Windows.UI.Xaml.Visibility.Visible;

                        if (CartaSeleccionada.Id == CartaSeleccionada2.Id)
                        {
                            parejasCorrectas++;
                        }
                        else
                        {
                            await Task.Delay(1000);

                            CartaSeleccionada.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                            CartaSeleccionada2.Visible = Windows.UI.Xaml.Visibility.Collapsed;
                        }
                        //Como se ha hecho una pareja, me da igual si es correcta o no la CartaSeleccionada2 tiene que ser null para que se pueda formar otra pareja
                        CartaSeleccionada2 = null;

                    }
                }
                //Si la CartaSeleccionada ya era visible (ya se había encontrado su pareja o es la CartaSeleccionada2) hay que ponerla a null
                CartaSeleccionada = null;
            }

            if (parejasCorrectas == 6)
            {
                reloj.Stop();
                MensajeVictoria = "Ha ganado";
            }
            else
            {
                Clickable = true;
            }
        }

        private void timer_Tick(object sender, object e)
        {
            TextoReloj = string.Format("{0}:{1}:{2}", reloj.Elapsed.Hours.ToString(), reloj.Elapsed.Minutes.ToString(), reloj.Elapsed.Seconds.ToString());
        }

        #endregion
    }
}
