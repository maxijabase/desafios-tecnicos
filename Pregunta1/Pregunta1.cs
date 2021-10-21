/*
1) Crear una función que devuelva una versión simplificada de una fracción
   Ejemplos
   Simplificar("4/6") = "2/3"
   Simplificar("10/11) = "10/11"
   Simplificar("100/400") = "10/4"; (<-- "1/4")
   Notas: una fracción simplificada no tiene divisores comunes mínimos (excepto 1) entre el
   numerador y el denominador. Por ejemplo, 4/6 no esta simplificada, ya que tanto 4 y 6
   comparten 2 como factor
   Si una fracción puede ser transformada en entero, también debe tenerse en cuenta
 */

using System;

namespace DesafioTecnico;

public class Pregunta1
{
    public static void Main()
    {
        while (true)
        {
            // Capturo el input para procesarlo en Simplificar()
            Console.Write("Inserte una fracción con el formato numero/numero. Si es posible, será devuelta simplificada: ");
            try
            {
                Console.WriteLine($"Resultado: {Simplificar(Console.ReadLine())}");
            }
            // Capturo cualquier error genéricamente para reducir la complejidad de la validación del input
            catch (Exception)
            {
                Console.WriteLine($"Entrada incorrecta.");
                continue;
            }
        }
    }

    private static string Simplificar(string fraccion)
    {
        // Extraigo y parseo numerador y denominador del input
        var numer = int.Parse(fraccion.Split('/')[0]);
        var denom = int.Parse(fraccion.Split('/')[1]);
        // Obtengo MCD mediante algoritmo de Euclides
        var mcd = ObtenerMCD(numer, denom);

        // Si el MCD no fue 0, no es una fracción entera, reducimos
        // Sino, MCD 0 indica que es una fracción entera, dividimos normalmente
        return mcd == 0 ? $"{numer / denom}" : $"{numer / mcd}/{denom / mcd}";
    }

    private static int ObtenerMCD(int numer, int denom)
    {
        // Aplicando mcd(a, b) = mcd(b, a mod b) recursivamente,
        // llegamos al resto que resulta ser el MCD, o continuamos 
        // pidiéndolo hasta que lo obtenemos
        var remainder = numer % denom;
        return remainder == 0 || denom % remainder == 0 ? remainder : ObtenerMCD(denom, numer % denom);
    }
}
