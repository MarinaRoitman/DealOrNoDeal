using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp8___DealOrNoDeal.Models
{
    public class Maletin
    {
        private int _numMaletin;
        private int _importe;
        private bool _estaAbierto;
        private bool _esMiMaletin;


        public Maletin(int numMaletin, int importe, bool estaAbierto, bool esMiMaletin)
        {
            _numMaletin = numMaletin;
            _importe = importe;
            _estaAbierto = estaAbierto;
            _esMiMaletin = esMiMaletin;
        }

        public bool esMiMaletin
        {
            get
            {
                return _esMiMaletin;
            }

            set
            {
                _esMiMaletin = value;
            }
        }

        public bool estaAbierto
        {
            get
            {
                return _estaAbierto;
            }

            set
            {
                _estaAbierto = value;
            }
        }
        public int NumMaletin
        {
            get
            {
                return _numMaletin;
            }

            private set //Al ser solo lectura el set es privado
            {
                _numMaletin = value;
            }
        }
        public int Importe
        {
            get
            {
                return _importe;
            }

            private set //Al ser solo lectura el set es privado
            {
                _importe = value;
            }
        }
    }
}