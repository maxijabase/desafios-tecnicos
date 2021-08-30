/*
2) Validar Nombres
   Tener en cuenta las siguientes definiciones
    a) El termino ingresado pueden ser iniciales o palabras completas
    b) Una inicial es solo un caracter mas un punto
    c) Una palabra se comprende de 2 o mas caracteres, sin punto

   Reglas
    a) Tanto las iniciales como las palabras completas deben estar capitalizadas (la primera letra
     en mayúsculas)
    b) Las iniciales deben terminar en punto (.)
    c) Solo habrán 2 o 3 términos en el ingreso. Es decir, o dos nombres y un apellido o solo un
     nombre y un apellido
    d)Si se ingresan dos nombres y un apellido, los dos primeros pueden ser iniciales, o solo el
     segundo. Nunca puede ser una inicial el primer nombre y no el segundo
    e) El apellido siempre debe ser una palabra completa

 */

using System;
using System.Linq;

namespace DesafioTecnico
{
    public class Pregunta2
    {
        public static void Main()
        {
            while (true)
            {
                try
                {
                    Console.Write("Inserte el nombre: ");
                    Console.WriteLine($"El formato del nombre es {(ValidarNombre(Console.ReadLine()) ? "VÁLIDO" : "INVÁLIDO")}.\n");
                }
                catch (Exception)
                {
                    Console.WriteLine("Entrada incorrecta.\n");
                    continue;
                }
            }
        }

        private static bool ValidarNombre(string input)
        {
            var nombres = input.Split(' ');
            return ComienzanConMayuscula(nombres) &&
                   CantidadCorrectaDePalabras(nombres) &&
                   TienePalabrasValidas(nombres) &&
                   TieneInicialesValidas(nombres) &&
                   TieneApellidoValido(nombres) &&
                   OrdenCorrectoDeIniciales(nombres);
                   
        }

        #region Reglas Generales

        private static bool CantidadCorrectaDePalabras(string[] nombres)
        {
            // No deben ser menos de 1 y más de 3 palabras
            return nombres.Length > 1 && nombres.Length <= 3;
        }

        private static bool ComienzanConMayuscula(string[] nombres)
        {
            foreach (var parte in nombres)
            {
                // Todas las partes del input deben comenzar con mayúscula
                if (parte[0].ToString() != parte[0].ToString().ToUpper())
                {
                    return false;
                }
            }
            return true;
        }

        private static bool TienePalabrasValidas(string[] nombres)
        {
            foreach (var parte in nombres)
            {
                // Todas las palabras válidas deben tener igual o más de 2 caracteres alfabéticos
                if (parte.Length == 1 || (!parte.Any(x => char.IsLetter(x)) && parte.Length > 1))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool TieneInicialesValidas(string[] nombres)
        {
            foreach (var parte in nombres)
            {
                // Ninguna inicial válida contiene un punto sin contener 2 caracteres en total
                if (parte.Length != 2 && parte.Contains("."))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Reglas Particulares

        private static bool OrdenCorrectoDeIniciales(string[] nombres)
        {
            // El input ingresado es inválido si consta de 3 partes,
            // pero el nombre intenta ser una inicial mientras que el segundo nombre no
            return !(nombres.Length == 3 && nombres[0].Contains(".") && !nombres[1].Contains("."));
        }


        private static bool TieneApellidoValido(string[] nombres)
        {
            // El apellido será válido si no intenta ser una inicial
            var apellido = nombres[^1];
            return !(apellido.Contains("."));
        }

        #endregion
    }
}
