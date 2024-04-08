using System;
namespace GuessTheNumberCSharp
{
    /*
    Características de la clase Player:
    Propiedad que almacena el nombre.
    Propiedad que almacena el último intento realizado por la jugadora.
    Constructor que inicializa el último intento en cero y el nombre según el valor con el que fue instanciado.
    Método que se encarga de hacer la predicción(MakeGuess()) solicitando por terminal un número y validando que sea correcto.*/

    public abstract class Player

    {
        //campo y propiedad nombre
        private string name = "";
        public string Name { get => name; set => name = value; }

        //campo y propiedad que almancena intentos
        private List<int> listGuess;
        public List<int> ListGuess { get => listGuess; set => listGuess = value; }

        //constructor
        protected Player(string name)
        {
            Name = name;
            listGuess = new List<int>();
        }

        //metodo abstracto
        public abstract int MakeGuess();
    }
}

