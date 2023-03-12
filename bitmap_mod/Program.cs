using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace bitmap_mod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool continua = false;
            string path = @"mesi.bmp";
            int width = 0, height = 0, offSet = 0, rowSize = 0;
            Color[][] BitmapPixels = LoadBitmapPixels(path, ref width, ref height, ref offSet, ref rowSize);
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
        public static Color[][] LoadBitmapPixels(string filePath, ref int width, ref int height, ref int pixelOffset, ref int rowSize)
        {
            const int BitmapFileHeaderSize = 14;                                //definizione della costante BitmapFileHeaderSize (14)
            const int BitmapInfoHeaderSize = 40;                                //definizione della costante BitmapInfoHeaderSize (40)
            using (FileStream stream = new FileStream(filePath, FileMode.Open)) //apertura del bitmap come file binario
            {
                byte[] bitmapFileHeader = new byte[BitmapFileHeaderSize];       //dichiarazione di bitmapFileHeader, matrice (monodimensionale) di byte contenete il FileHeader del BMP
                stream.Read(bitmapFileHeader, 0, BitmapFileHeaderSize);         //lettura del FileHeader e salvataggio nella matrice bitmapFileHeader

                byte[] bitmapInfoHeader = new byte[BitmapInfoHeaderSize];       //dichiarazione di bitmapInfoHeader, matrice (monodimensionale) di byte contenete l'InfoHeader del BMP
                stream.Read(bitmapInfoHeader, 0, BitmapInfoHeaderSize);         //lettura dell'InfoHeader e salvataggio nella matrice bitmapInfoHeader
                width = BitConverter.ToInt32(bitmapInfoHeader, 4);          //dichiarazione e inizializzazione della variabile width, con valore di larghezza del BMP
                height = BitConverter.ToInt32(bitmapInfoHeader, 8);         //dichiarazione e inizializzazione della variabile height, con valore di altezza del BMP
                pixelOffset = BitConverter.ToInt32(bitmapFileHeader, 10);   //dichiarazione e inizializzazione della variabile pixelOffSet, con valore di offset del BMP
                rowSize = ((width * 24 + 31) / 32) * 4;                     //dichiarazione e inizializzazione della variabile rowsize, contenente il numero di righe (compresi i bytes di padding)
                Color[][] pixels = new Color[height][];                         //dichiarazione della matrice pixels per contenere i colori dei pixel del BMP
                for (int row = 0; row < height; row++)
                {
                    pixels[row] = new Color[width];
                }
                stream.Seek(pixelOffset, SeekOrigin.Begin);         //ricerca dell'inizio della matrice di pixels
                for (int row = height - 1; row >= 0; row--)         //lettura della matrice di pixels riga per riga
                {
                    byte[] rowData = new byte[rowSize];             //matrice unidimensionale di appoggio per il salvataggio temporaneo dei pixel letti
                    stream.Read(rowData, 0, rowSize);               //lettura di una riga di dati contenuti nei pixel
                    int pixelIndex = 0;                             //estrazione del colore di ogni pixel e salvataggio in pixels
                    for (int col = 0; col < width; col++)
                    {
                        byte blue = rowData[pixelIndex++];
                        byte green = rowData[pixelIndex++];
                        byte red = rowData[pixelIndex++];
                        pixels[row][col] = Color.FromArgb(red, green, blue);
                    }
                }
                return pixels;                          //restituisce il colore dei pixels
            }
        }
        public static void SaveBitmap(string fileName, Color[][] pixels)
        {
            int width = pixels[0].Length;
            int height = pixels.Length;
            int paddingSize = (4 - ((width * 3) % 4)) % 4;
            int fileSize = 54 + (width * height * 3) + (height * paddingSize);
            byte[] header = new byte[54];
            header[0] = (byte)'B';
            header[1] = (byte)'M';
            header[2] = (byte)(fileSize);
            header[3] = (byte)(fileSize >> 8);
            header[4] = (byte)(fileSize >> 16);
            header[5] = (byte)(fileSize >> 24);
            header[10] = (byte)54;
            header[14] = (byte)40;
            header[18] = (byte)(width);
            header[19] = (byte)(width >> 8);
            header[20] = (byte)(width >> 16);
            header[21] = (byte)(width >> 24);
            header[22] = (byte)(height);
            header[23] = (byte)(height >> 8);
            header[24] = (byte)(height >> 16);
            header[25] = (byte)(height >> 24);
            header[26] = (byte)1;
            header[28] = (byte)24;
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                stream.Write(header, 0, header.Length);
                for (int y = height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color color = pixels[y][x];
                        byte[] colorData = new byte[] { color.B, color.G, color.R };
                        stream.Write(colorData, 0, 3);
                    }
                    byte[] padding = new byte[paddingSize];
                    stream.Write(padding, 0, paddingSize);
                }
            }
        }
        #region funzioni di modifica
        static void BiancoNero(Color[][] pixels, ref int width, ref int height)
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
        static void merge(Color[][] M, int percM, Color[][] M1, int percM1)
        {

        }
        #endregion
    }
}