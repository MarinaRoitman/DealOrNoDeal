using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tp8___DealOrNoDeal.Models
{
    public static class DealOrNoDeal
    {
        private static Maletin[] _maletines = new Maletin[26];
        private static Maletin _maletinElegido;
        private static int[] _valoresMaletines = new int[26] { 1, 5, 10, 15, 25, 50, 75, 100, 200, 300, 400, 500, 750, 1000, 5000, 10000, 25000, 50000, 75000, 100000, 200000, 300000, 400000, 500000, 750000, 1000000 };
        private static int _cantJugadas;
        private static int _cantOfertasBanca;

        public static Maletin MaletinElegido
        {
            get
            {
                return _maletinElegido;
            }
        }

        public static int cantJugadas
        {
            get
            {
                return _cantJugadas;
            }

            private set
            {
                _cantJugadas = value;
            }
        }

        public static int cantOfertasBanca
        {
            get
            {
                return _cantOfertasBanca;
            }

            private set
            {
                _cantOfertasBanca = value;
            }
        }

        public static Maletin[] Maletines
        {
            get
            {
                return _maletines;
            }

            set
            {
                _maletines = value;
            }
        }

        //Metodos

        public static int[] DevolverValoresPosiblesMaletines()
        {
            //Este metodo solo busca devolver el array que contiene los posibles valores de los maletines
            return _valoresMaletines;
        }

        public static int JugadasRestantes()
        {
            //Este metodo solo busca devolver la cantidad de jugadas
            return _cantJugadas;
        }

        public static float OfertaBanca()
        {
            //El objetivo de este metodo es devolver un importe de oferta (promedio de los maletines no abiertos - 15%) si la cant de jugadas restantes es 0
            int cantMaletinesNoAbiertos;
            cantMaletinesNoAbiertos = 0;
            int valoresMaletinesNoAbiertos;
            valoresMaletinesNoAbiertos = 0;
            float ofertaARealizar;
            ofertaARealizar = 0;
            //Hasta acá solo creé e inicialicé variables
            if (_cantJugadas == 0) //Pregunto si la cantidad de jugadas restantes es 0
            {
                for (int i = 0; i < 26; i++) //Recorro maletines
                {
                    if (!_maletines[i].estaAbierto)//Pregunto si el maletin que estoy viendo (perteneciente a maletines) esta cerrado
                    {
                        valoresMaletinesNoAbiertos += _valoresMaletines[_maletines[i].Importe]; //Guardo los importes de los maletines cerrados en valoresMaletinesNoAbiertos
                        cantMaletinesNoAbiertos += 1; //Sumo uno a cantMaletinesNoAbiertos
                    }
                }
                ofertaARealizar = valoresMaletinesNoAbiertos / cantMaletinesNoAbiertos; //Calculo el promedio de los importes de los maletines cerrados
                ofertaARealizar = ofertaARealizar * 0.85f; //Le resto el 15% al promedio de los importes de los maletines cerrados
            }
            return ofertaARealizar; //Devuelvo la oferta
        }
        public static int AbrirMaletin(int num)
        {
            //Este metodo tiene por objetivo devolver el contenido del maletin y en caso de que el mismo ya haya sido abierto devolverá -1
            int devolver;
            if (!_maletines[num].estaAbierto) //Pregunto si el maletín en cuestion esta abierto o no
            {
                devolver = _maletines[num].Importe; //En caso de que no lo esté devolveré el importe que contiene el mismo
                _cantJugadas--;
                _maletines[num].estaAbierto = true; //Marco que abrí el maletin
            }

            else
            {
                devolver = -1; //En caso que si esté abierto devolveré -1
            }

            return devolver; //Devuelvo devolver
        }

        public static float DecisionOferta(bool aceptar)
        {
            //Este metodo tiene por objetivo devolver el valor del Maletín que eligió el usuario, si es que aceptar == true, si es false, actualizará la cantidad de jugadas y devolverá - 1.
            float devolver;
            _cantOfertasBanca++;//Le sumo uno a la cantidad de veces que la banca hizo una oferta
            if (aceptar == true) //Pregunto si aceptar es true
            {
                devolver = OfertaBanca(); //En cuyo caso devolver valdrá lo mismo que la oferta realizada
            }

            else
            {
                _cantJugadas = 7 - _cantOfertasBanca; //Le resto la cantidad de veces que la banca hizo una oferta a la cantidad de jugadas
                devolver = -1; //Si la oferta no fue elegida devolverá -1
            }

            return devolver; //Devuelvo devolver
        }

        public static Maletin[] ArmarArrayMaletinesNoSelec(int numSelec)
        {
            //Este metodo tiene por objetivo guardar en un array todos los maletines excepto el selecciodo por el usuario
            Maletin[] maletinesNoSeleccionado = new Maletin[25];
            int i = 0;
            int k = 0;
            //Hasta acá cree e inicialicé variables
            while (i < 24) //Recorro
            {
                if (numSelec != _maletines[k].NumMaletin) //Pregunto si el maletin que estoy viendo es el seleccionado
                {
                    maletinesNoSeleccionado[i] = _maletines[k]; //Guardo el maletin en maletinesNoSeleccionado
                    i++; //Sumo y recorro
                }
                k++;
            }
            return maletinesNoSeleccionado; //Devuelvo maletinesNoSeleccionado
        }

        private static int[] GenerarRandomNoRepite()
        {
            //Este metodo tiene por objetivo sacar 26 numeros al azar los cuales no se repitan. Devuelve un array (valoresMaletines) que contiene dichos valores.
            int[] valoresMaletines = new int[26];
            List<int> numerosParaMaletines = new List<int>(); //Creo una hermosa lista
            int i = 0;
            int miNumeroNuevo = -1;
            for (int j = 0; j < 26; j++)
            {
                numerosParaMaletines.Add(j);
            }
            //Hasta acá creé e inicialicé variables
            while (i < 26) //Recorro
            {
                Random num = new Random();
                miNumeroNuevo = num.Next(0, numerosParaMaletines.Count()); //Saca un numero random entre 0 y 25
                valoresMaletines[i] = numerosParaMaletines[miNumeroNuevo]; //LLeno la lista
                numerosParaMaletines.Remove(numerosParaMaletines[miNumeroNuevo]); //Saco elemento ya cargado
                i++; //Itero
            }
            return valoresMaletines; //Devuelvo valoresMaletines
        }

        public static Maletin IniciarJuego(int numMaletin)
        {
            //El objetvo de este metodo es poner los numeros randoms de la función generarRandomNoRepite en los maletines (indice para poder acceder), además se crea e inicializa cantJugadas. Devuelve el maletin seleccionado.
            int[] valoresMaletines = new int[26];
            valoresMaletines = GenerarRandomNoRepite();
            _cantJugadas = 7;
            _cantOfertasBanca = 0;
            for (int i = 0; i < 26; i++) //Recorro
            {
                Maletin miMaletin;

                if (numMaletin == i + 1) //Pregunto si es el maletin seleccionado
                {
                    miMaletin = new Maletin(i + 1, valoresMaletines[i], false, true); //Seteo los maletines (y sus atributos (num de maletin, valor del mismo, si está abierto o no y si es o no el maletin seleccionado))
                    _maletinElegido = miMaletin;
                }
                else
                {
                    miMaletin = new Maletin(i + 1, valoresMaletines[i], false, false); //Seteo los maletines (y sus atributos (num de maletin, valor del mismo, si está abierto o no y si es o no el maletin seleccionado))
                }

                _maletines[i] = miMaletin; //Asigno el valor del maletín a maletines[i]
            }

            return _maletinElegido; //devuelvo el maletin seleccionado
        }
    }
}