using System;
using System.Drawing;
using System.IO;
namespace bitmap_mod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool continua = false, ending;
            int redPerc, greenPerc, bluePerc;
            float multiplier;
            string path = @"rio.bmp", path2 = @"mesi.bmp", pathMod = @"rioMOD.bmp";
            Color[][] BitmapPixels;
            BitmapPixels = LoadBitmapPixels(path);
            do
            {
                Console.WriteLine("Scelta:\n1 - BiancoNero\n2 - BiancoNero (2)\n3 - ChiaroScuro\n4 - ChiaroScuro (2)\n5 - Sfocatura\n6 - Gradiente Nero Orizzontale\n7 - Gradiente Bianco Verticale\n8 - Gradiente Diagonale\n9 - Contorno\n10 - Contrasto\n11 - Specchia Orizzontale\n12 - Specchia Verticale\n13 - Ruota di 180°\n14 - Merge\n15 - Uscita");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        BiancoNero(BitmapPixels);
                        SaveBitmap(pathMod, BitmapPixels);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Percentuale di rosso: ");
                        redPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di verde: ");
                        greenPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di blu: ");
                        bluePerc = int.Parse(Console.ReadLine());
                        ending = BiancoNeroPerc(redPerc, greenPerc, bluePerc, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Percentuali non valide");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Indice di schiarimento k (-255 < k < 255): ");
                        int index = int.Parse(Console.ReadLine());
                        ending = ChiaroScuro(index, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Valore dell'indice non consentito");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Indice moltplicatore k (0 <= k <= 2): ");
                        multiplier = float.Parse(Console.ReadLine());
                        ending = ChiaroScuroMult(multiplier, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Valore dell'indice non consentito");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "5":
                        Sfocatura(BitmapPixels);
                        SaveBitmap(pathMod, BitmapPixels);
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Percentuale di rosso: ");
                        redPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di verde: ");
                        greenPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di blu: ");
                        bluePerc = int.Parse(Console.ReadLine());
                        ending = CreaGradienteOrizzontaleNero(redPerc, greenPerc, bluePerc, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Percentuali non valide");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Percentuale di rosso: ");
                        redPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di verde: ");
                        greenPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di blu: ");
                        bluePerc = int.Parse(Console.ReadLine());
                        ending = CreaGradienteVerticaleBianco(redPerc, greenPerc, bluePerc, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Percentuali non valide");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "8":
                        Console.Clear();
                        Console.WriteLine("Percentuale di rosso: ");
                        redPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di verde: ");
                        greenPerc = int.Parse(Console.ReadLine());
                        Console.WriteLine("Percentuale di blu: ");
                        bluePerc = int.Parse(Console.ReadLine());
                        ending = CreaGradienteDiagonale(redPerc, greenPerc, bluePerc, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Percentuali non valide");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Soglia di nero N (0 < N < 255): ");
                        int black = int.Parse(Console.ReadLine());
                        Console.WriteLine("Soglia di grigio G (N < G < 255): ");
                        int grey = int.Parse(Console.ReadLine());
                        ending = Contorno(black, grey, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Soglie non valide");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        };
                        break;
                    case "10":
                        Console.Clear();
                        Console.WriteLine("Indice moltplicatore k (0 <= k <= 2): ");
                        multiplier = float.Parse(Console.ReadLine());
                        ending = Contrasto(multiplier, BitmapPixels);
                        if (!ending)
                        {
                            Console.WriteLine("Valore dell'indice non consentito");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "11":
                        SpecchiaOrizzontale(BitmapPixels);
                        SaveBitmap(pathMod, BitmapPixels);
                        break;
                    case "12":
                        SpecchiaVerticale(BitmapPixels);
                        SaveBitmap(pathMod, BitmapPixels);
                        break;
                    case "13":
                        Ruota180(BitmapPixels);
                        SaveBitmap(pathMod, BitmapPixels);
                        break;
                    case "14":
                        Console.Clear();
                        Console.WriteLine("Percentuale opacità k della prima foto: (0 <= k <= 100): ");
                        int perc = int.Parse(Console.ReadLine());
                        Color[][] BitmapPixels2 = LoadBitmapPixels(path2);
                        ending = Merge(BitmapPixels, BitmapPixels2, perc);
                        if (!ending)
                        {
                            Console.WriteLine("Percentuale non valida");
                        }
                        else
                        {
                            SaveBitmap(pathMod, BitmapPixels);
                        }
                        break;
                    case "15":
                        continua = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida");
                        break;
                }
                if (continua == false)
                {
                    Console.WriteLine("Premere un tasto per continuare: ");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (!continua);
        }
        public static Color[][] LoadBitmapPixels(string filePath)
        {
            const int BitmapFileHeaderSize = 14;                                //definizione della costante BitmapFileHeaderSize (14)
            const int BitmapInfoHeaderSize = 40;                                //definizione della costante BitmapInfoHeaderSize (40)
            using (FileStream stream = new FileStream(filePath, FileMode.Open)) //apertura del bitmap come file binario
            {
                byte[] bitmapFileHeader = new byte[BitmapFileHeaderSize];       //dichiarazione di bitmapFileHeader, matrice (monodimensionale) di byte contenete il FileHeader del BMP
                stream.Read(bitmapFileHeader, 0, BitmapFileHeaderSize);         //lettura del FileHeader e salvataggio nella matrice bitmapFileHeader

                byte[] bitmapInfoHeader = new byte[BitmapInfoHeaderSize];       //dichiarazione di bitmapInfoHeader, matrice (monodimensionale) di byte contenete l'InfoHeader del BMP
                stream.Read(bitmapInfoHeader, 0, BitmapInfoHeaderSize);         //lettura dell'InfoHeader e salvataggio nella matrice bitmapInfoHeader
                int width = BitConverter.ToInt32(bitmapInfoHeader, 4);          //dichiarazione e inizializzazione della variabile width, con valore di larghezza del BMP
                int height = BitConverter.ToInt32(bitmapInfoHeader, 8);         //dichiarazione e inizializzazione della variabile height, con valore di altezza del BMP
                int pixelOffset = BitConverter.ToInt32(bitmapFileHeader, 10);   //dichiarazione e inizializzazione della variabile pixelOffSet, con valore di offset del BMP
                int rowSize = ((width * 24 + 31) / 32) * 4;                     //dichiarazione e inizializzazione della variabile rowsize, contenente il numero di righe (compresi i bytes di padding)
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
                for (int i = height - 1; i >= 0; i--)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Color color = pixels[i][j];
                        byte[] colorData = new byte[] { color.B, color.G, color.R };
                        stream.Write(colorData, 0, 3);
                    }
                    byte[] padding = new byte[paddingSize];
                    stream.Write(padding, 0, paddingSize);
                }
            }
        }
        #region funzioni di modifica
        static void BiancoNero(Color[][] pixels)
        {
            int len = pixels.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < pixels[i].Length; j++)
                {
                    int red = pixels[i][j].R;
                    int green = pixels[i][j].G;
                    int blue = pixels[i][j].B;
                    int avg = (red * 50 + green * 25 + blue * 75) / (50 + 25 + 75);
                    pixels[i][j] = Color.FromArgb(avg, avg, avg);
                }
            }
        }
        static bool BiancoNeroPerc(int PR, int PG, int PB, Color[][] pixels)
        {
            bool ending = false;
            if (PR >= 0 && PG >= 0 && PB >= 0 && PR <= 255 && PG <= 255 && PB <= 255)
            {
                int len = pixels.Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < pixels[i].Length; j++)
                    {
                        int red = pixels[i][j].R;
                        int green = pixels[i][j].G;
                        int blue = pixels[i][j].B;
                        int avg = (red * PR + green * PG + blue * PB) / (PR + PG + PB);
                        pixels[i][j] = Color.FromArgb(avg, avg, avg);
                        ending = true;
                    }
                }
            }
            return ending;
        }
        static bool ChiaroScuro(int k, Color[][] pixels)
        {
            bool ending = false;
            if (k <= 255 && k >= -255)
            {
                int len = pixels.Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < pixels[i].Length; j++)
                    {
                        int red = pixels[i][j].R + k;
                        if (red + k < 0)
                        {
                            red = 0;
                        }
                        else if (red > 255)
                        {
                            red = 255;
                        }
                        int green = pixels[i][j].G + k;
                        if (green < 0)
                        {
                            green = 0;
                        }
                        else if (green > 255)
                        {
                            green = 255;
                        }
                        int blue = pixels[i][j].B + k;
                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        else if (blue > 255)
                        {
                            blue = 255;
                        }
                        pixels[i][j] = Color.FromArgb(red, green, blue);
                    }
                }
                ending = true;
            }
            return ending;
        }
        static bool ChiaroScuroMult(float k, Color[][] pixels)
        {
            bool ending = false;
            if (k <= 2 && k >= 0)
            {
                int len = pixels.Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < pixels[i].Length; j++)
                    {
                        float red = pixels[i][j].R * k;
                        if (red * k > 255)
                        {
                            red = 255;
                        }
                        float green = pixels[i][j].G * k;
                        if (green * k > 255)
                        {
                            green = 255;
                        }
                        float blue = pixels[i][j].B * k;
                        if (blue > 255)
                        {
                            blue = 255;
                        }
                        pixels[i][j] = Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));
                    }
                }
                ending = true;
            }
            return ending;
        }
        static void Sfocatura(Color[][] pixels)
        {
            Color[][] modified = pixels;
            for (int i = 0; i < pixels.Length; i++)
            {
                for (int j = 0; j < pixels[0].Length; j++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    if (i > 0 && i < pixels.Length - 1)
                    {
                        if (j > 0 && j < pixels[0].Length - 1)
                        {
                            avgR = (modified[i - 1][j - 1].R + modified[i][j - 1].R + modified[i + 1][j - 1].R + modified[i - 1][j].R + modified[i + 1][j].R + modified[i - 1][j + 1].R + modified[i][j + 1].R + modified[i + 1][j + 1].R) / 8;
                            avgG = (modified[i - 1][j - 1].G + modified[i][j - 1].G + modified[i + 1][j - 1].G + modified[i - 1][j].G + modified[i + 1][j].G + modified[i - 1][j + 1].G + modified[i][j + 1].G + modified[i + 1][j + 1].G) / 8;
                            avgB = (modified[i - 1][j - 1].B + modified[i][j - 1].B + modified[i + 1][j - 1].B + modified[i - 1][j].B + modified[i + 1][j].B + modified[i - 1][j + 1].B + modified[i][j + 1].B + modified[i + 1][j + 1].B) / 8;
                        }
                        if (j == 0)
                        {
                            avgR = (modified[i - 1][j].R + modified[i + 1][j].R + modified[i - 1][j + 1].R + modified[i][j + 1].R + modified[i + 1][j + 1].R) / 5;
                            avgG = (modified[i - 1][j].G + modified[i + 1][j].G + modified[i - 1][j + 1].G + modified[i][j + 1].G + modified[i + 1][j + 1].G) / 5;
                            avgB = (modified[i - 1][j].B + modified[i + 1][j].B + modified[i - 1][j + 1].B + modified[i][j + 1].B + modified[i + 1][j + 1].B) / 5;
                        }
                        if (j == pixels[0].Length - 1)
                        {
                            avgR = (modified[i - 1][j - 1].R + modified[i][j - 1].R + modified[i + 1][j - 1].R + modified[i - 1][j].R + modified[i + 1][j].R) / 5;
                            avgG = (modified[i - 1][j - 1].G + modified[i][j - 1].G + modified[i + 1][j - 1].G + modified[i - 1][j].G + modified[i + 1][j].G) / 5;
                            avgB = (modified[i - 1][j - 1].B + modified[i][j - 1].B + modified[i + 1][j - 1].B + modified[i - 1][j].B + modified[i + 1][j].B) / 5;
                        }
                    }
                    if (i == 0)
                    {
                        if (j > 0 && j < pixels[0].Length - 1)
                        {
                            avgR = (modified[i][j - 1].R + modified[i + 1][j - 1].R + modified[i + 1][j].R + modified[i][j + 1].R + modified[i + 1][j + 1].R) / 5;
                            avgG = (modified[i][j - 1].G + modified[i + 1][j - 1].G + modified[i + 1][j].G + modified[i][j + 1].G + modified[i + 1][j + 1].G) / 5;
                            avgB = (modified[i][j - 1].B + modified[i + 1][j - 1].B + modified[i + 1][j].B + modified[i][j + 1].B + modified[i + 1][j + 1].B) / 5;
                        }
                        if (j == 0)
                        {
                            avgR = (modified[i + 1][j].R + modified[i][j + 1].R + modified[i + 1][j + 1].R) / 3;
                            avgG = (modified[i + 1][j].G + modified[i][j + 1].G + modified[i + 1][j + 1].G) / 3;
                            avgB = (modified[i + 1][j].B + modified[i][j + 1].B + modified[i + 1][j + 1].B) / 3;
                        }
                        if (j == pixels[0].Length - 1)
                        {
                            avgR = (modified[i][j - 1].R + modified[i + 1][j - 1].R + modified[i + 1][j].R) / 3;
                            avgG = (modified[i][j - 1].G + modified[i + 1][j - 1].G + modified[i + 1][j].G) / 3;
                            avgB = (modified[i][j - 1].B + modified[i + 1][j - 1].B + modified[i + 1][j].B) / 3;
                        }
                    }
                    if (i == pixels.Length - 1)
                    {
                        if (j > 0 && j < pixels[0].Length - 1)
                        {
                            avgR = (modified[i - 1][j - 1].R + modified[i][j - 1].R + modified[i - 1][j].R + modified[i - 1][j + 1].R + modified[i][j + 1].R) / 5;
                            avgG = (modified[i - 1][j - 1].G + modified[i][j - 1].G + modified[i - 1][j].G + modified[i - 1][j + 1].G + modified[i][j + 1].G) / 5;
                            avgB = (modified[i - 1][j - 1].B + modified[i][j - 1].B + modified[i - 1][j].B + modified[i - 1][j + 1].B + modified[i][j + 1].B) / 5;
                        }
                        if (j == 0)
                        {
                            avgR = (modified[i - 1][j].R + modified[i - 1][j + 1].R + modified[i][j + 1].R) / 3;
                            avgG = (modified[i - 1][j].G + modified[i - 1][j + 1].G + modified[i][j + 1].G) / 3;
                            avgB = (modified[i - 1][j].B + modified[i - 1][j + 1].B + modified[i][j + 1].B) / 3;
                        }
                        if (j == pixels[0].Length - 1)
                        {
                            avgR = (modified[i - 1][j - 1].R + modified[i][j - 1].R + modified[i - 1][j].R) / 3;
                            avgG = (modified[i - 1][j - 1].G + modified[i][j - 1].G + modified[i - 1][j].G) / 3;
                            avgB = (modified[i - 1][j - 1].B + modified[i][j - 1].B + modified[i - 1][j].B) / 3;
                        }
                    }
                    pixels[i][j] = Color.FromArgb(avgR, avgG, avgB);
                }
            }
        }
        static bool CreaGradienteOrizzontaleNero(int R, int G, int B, Color[][] pixels)
        {
            bool ending = false;
            if (R >= 0 && G >= 0 && B >= 0 && R <= 255 && G <= 255 && B <= 255)
            {
                int len = pixels.Length;
                for (int i = 0; i < len; i++)
                {
                    for (float j = 0; j < pixels[i].Length; j++)
                    {
                        int k = Convert.ToInt32(j);
                        float red = pixels[i][k].R;
                        red = ((pixels[i].Length - j) / pixels[i].Length) * R;
                        if (red > 255)
                        {
                            red = 255;
                        }
                        if (red < 0)
                        {
                            red = 0;
                        }
                        float green = pixels[i][k].G;
                        green = ((pixels[i].Length - j) / pixels[i].Length) * G;
                        if (green > 255)
                        {
                            green = 255;
                        }
                        if (green < 0)
                        {
                            green = 0;
                        }
                        float blue = pixels[i][k].B;
                        blue = ((pixels[i].Length - j) / pixels[i].Length) * B;
                        if (blue > 255)
                        {
                            blue = 255;
                        }
                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        pixels[i][k] = Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));
                    }
                }
                ending = true;
            }
            return ending;
        }
        static bool CreaGradienteVerticaleBianco(int R, int G, int B, Color[][] pixels)
        {
            bool ending = false;
            if (R >= 0 && G >= 0 && B >= 0 && R <= 255 && G <= 255 && B <= 255)
            {
                int len = pixels.Length;
                for (float i = 0; i < len; i++)
                {
                    for (int j = 0; j < pixels[0].Length; j++)
                    {
                        int k = Convert.ToInt32(i);
                        float red = pixels[k][j].R;
                        red = ((pixels.Length - i) / pixels.Length) * (255 - R) + R;
                        if (red > 255)
                        {
                            red = 255;
                        }
                        if (red < 0)
                        {
                            red = 0;
                        }
                        float green = pixels[k][j].G;
                        green = ((pixels.Length - i) / pixels.Length) * (255 - G) + G;
                        if (green > 255)
                        {
                            green = 255;
                        }
                        if (green < 0)
                        {
                            green = 0;
                        }
                        float blue = pixels[k][j].B;
                        blue = ((pixels.Length - i) / pixels.Length) * (255 - B) + B;
                        if (blue > 255)
                        {
                            blue = 255;
                        }
                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        pixels[k][j] = Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));
                    }
                }
                ending = true;
            }
            return ending;
        }
        static bool CreaGradienteDiagonale(int R, int G, int B, Color[][] pixels)
        {
            bool ending = false;
            if (R >= 0 && G >= 0 && B >= 0 && R <= 255 && G <= 255 && B <= 255)
            {
                int len = pixels.Length;
                for (float i = 0; i < len; i++)
                {
                    for (float j = 0; j < pixels[0].Length; j++)
                    {
                        int k = Convert.ToInt32(i), l = Convert.ToInt32(j);
                        float red = pixels[k][l].R;
                        red += ((pixels[0].Length + pixels.Length) - (j + i)) / (pixels[0].Length + pixels.Length) * (R - red);
                        if (red > 255)
                        {
                            red = 255;
                        }
                        if (red < 0)
                        {
                            red = 0;
                        }
                        float green = pixels[k][l].G;
                        green += ((pixels[0].Length + pixels.Length) - (j + i)) / (pixels[0].Length + pixels.Length) * (G - green);
                        if (green > 255)
                        {
                            green = 255;
                        }
                        if (green < 0)
                        {
                            green = 0;
                        }

                        float blue = pixels[k][l].B;
                        blue += ((pixels[0].Length + pixels.Length) - (j + i)) / (pixels[0].Length + pixels.Length) * (B - blue);
                        if (blue > 255)
                        {
                            blue = 255;
                        }
                        if (blue < 0)
                        {
                            blue = 0;
                        }
                        pixels[k][l] = Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));
                        ending = true;
                    }
                }
            }
            return ending;
        }
        static bool Contorno(int sogliaNero, int sogliaGrigio, Color[][] pixels)
        {
            bool ending = false;
            if (sogliaNero >= 0 && sogliaNero < sogliaGrigio && sogliaGrigio <= 255)
            {
                Color[][] modified = pixels;
                for (int i = 0; i < pixels.Length; i++)
                {
                    for (int j = 0; j < pixels[0].Length; j++)
                    {
                        int red = pixels[i][j].R;
                        int green = pixels[i][j].G;
                        int blue = pixels[i][j].B;
                        if (red < sogliaGrigio && green < sogliaGrigio && blue < sogliaGrigio)
                        {
                            int media = (red + green + blue) / 3;
                            if (red < sogliaNero && green < sogliaNero && blue < sogliaNero)
                            {
                                red = media - sogliaNero;
                                green = media - sogliaNero;
                                blue = media - sogliaNero;
                            }
                            else
                            {
                                red = media - sogliaGrigio;
                                green = media - sogliaGrigio;
                                blue = media - sogliaGrigio;
                            }
                        }
                        if (red < 0)
                            red = 0;
                        if (green < 0)
                            green = 0;
                        if (blue < 0)
                            blue = 0;
                        pixels[i][j] = Color.FromArgb(red, green, blue);
                    }
                }
                ending = true;
            }
            return ending;
        }
        static bool Contrasto(float k, Color[][] pixels)
        {
            bool ending = false;
            if (k <= 2 && k >= 0)
            {
                int len = pixels.Length;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < pixels[i].Length; j++)
                    {
                        float red = pixels[i][j].R;
                        if (red > 127)
                        {
                            red *= k;
                        }
                        else
                        {
                            red /= k;
                        }
                        if (red > 255)
                        {
                            red = 255;
                        }
                        float green = pixels[i][j].G;
                        if (green > 127)
                        {
                            green *= k;
                        }
                        else
                        {
                            green /= k;
                        }
                        if (green > 255)
                        {
                            green = 255;
                        }
                        float blue = pixels[i][j].G;
                        if (blue > 127)
                        {
                            blue *= k;
                        }
                        else
                        {
                            blue /= k;
                        }
                        if (blue > 255)
                        {
                            blue = 255;
                        }
                        pixels[i][j] = Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));
                    }
                }
                ending = true;
            }
            return ending;
        }
        static void SpecchiaOrizzontale(Color[][] pixels)
        {
            int len = pixels.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < pixels[i].Length / 2; j++)
                {
                    (pixels[i][j], pixels[i][pixels[i].Length - j - 1]) = (pixels[i][pixels[i].Length - j - 1], pixels[i][j]);
                }
            }
        }
        static void SpecchiaVerticale(Color[][] pixels)
        {
            int len = pixels.Length;
            for (int i = 0; i < len / 2; i++)
            {
                for (int j = 0; j < pixels[i].Length; j++)
                {
                    (pixels[len - i - 1][j], pixels[i][j]) = (pixels[i][j], pixels[len - i - 1][j]);
                }
            }
        }
        static void Ruota180(Color[][] pixels)
        {
            SpecchiaOrizzontale(pixels);
            SpecchiaVerticale(pixels);
        }
        static bool Merge(Color[][] M, Color[][] M1, int percM)
        {
            bool ending = false;
            if (percM >= 0 && percM <= 100)
            {
                int len = M.Length;
                int percM1 = 100 - percM;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < M[0].Length; j++)
                    {
                        float redM = M[i][j].R, redM1 = M1[i][j].R;
                        redM = (redM * percM + redM1 * percM1)/100;
                        float greenM = M[i][j].G, greenM1 = M1[i][j].G;
                        greenM = (greenM * percM + greenM1 * percM1) / 100;
                        float blueM = M[i][j].B, blueM1 = M1[i][j].G;
                        blueM = (blueM * percM + blueM1 * percM1) / 100;
                        M[i][j] = Color.FromArgb(Convert.ToInt32(redM), Convert.ToInt32(greenM), Convert.ToInt32(blueM));
                    }
                }
                ending = true;
            }
            return ending;
        }
        #endregion
    }
}