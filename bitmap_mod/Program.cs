using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitmap_mod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool continua = false;
            do
            {
                Console.WriteLine("Scelta:\n1 - BiancoNero\n2 - BiancoNero (2)\n3 - ChiaroScuro\n4 - ChiaroScuro (2)\n5 - Sfocatura\n6 - Gradiente Nero Orizzontale\n7 - Gradiente Bianco Verticale\n8 - Gradiente Diagonale\n9 - Contorno\n10 - Contrasto\n11 - Specchia Orizzontale\n12 - Specchia Verticale\n13 - Ruota di 180°\n14 - Merge\n15 - Uscita");
                input = Console.ReadLine();
                Console.Clear();
                switch (input) 
                {
                    case "1":

                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        continua = true;
                        break;
                }
            } while (!continua);
        }
        static void BiancoNero() 
        {

        }
        static void BiancoNero(int PR, int PG, int PB) 
        {

        }
        static void ChiaroScuro(int k)
        {

        }
        static void ChiaroScruro(float k)
        {

        }
        static void Sfocatura()
        {

        }
        static void CreaGradienteOrizzontaleNero(int R, int G, int B)
        {

        }
        static void CreaGradienteVerticaleBianco(int R, int G, int B)
        {

        }
        static void CreaGradienteDiagonale(int R1, int G1, int B1, int R2, int G2, int B2)
        {

        }
        static void Contorno(int sogliaNero, int sogliaGrigio)
        {

        }
        static void Contrasto(float k)
        {

        }
        static void SpecchiaOrizzontale()
        {

        }
        static void SpecchiaVerticale()
        {

        }
        static void ruota180()
        {

        }
        static void merge(Color M[][], int percM, Color M1[][], int percM1)
        {

        }
    }
}
