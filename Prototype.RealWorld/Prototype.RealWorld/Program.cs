using System;
using System.Collections.Generic;

namespace Prototype.RealWorld
{

    public class Program
    {
        public static void Main(string[] args)
        {
            ColorManager colormanager = new ColorManager();

            // incializamos colores primarios para mezclar
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            // Añadimos varioantes para ampliar la paleta de colores
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            // seleccionamos que colores se mezclaran entre si para obtener nuevos tonos
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;


            Console.ReadKey();
        }
    }

    // Prototipo declara una interfaz para clonarse a sí misma

    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }


    public class Color : ColorPrototype
    {
        int red;
        int green;
        int blue;

        // Constructor implementa una operación para clonarse a sí misma

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                "Cloning color RGB: {0,3},{1,3},{2,3}",
                red, green, blue);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }

    // CLiente crea un nuevo objeto pidiéndole a un prototipo que se clone a sí mismo

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors =
            new Dictionary<string, ColorPrototype>();


        public ColorPrototype this[string key]
        {
            get { return colors[key]; }
            set { colors.Add(key, value); }
        }

        public ColorPrototype ColorPrototype
        {
            get => default;
            set
            {
            }
        }
    }
}
