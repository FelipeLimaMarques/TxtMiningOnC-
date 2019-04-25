using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineracao_de_Texto_B
{
    class TxtReader
    {

        // StopWords em Inglês
        private string[] stopWords = System.IO.File.ReadAllLines(@"C:\Users\lipeu\Downloads\Trab Pesq\Programa\Mineracao_de_Texto_B\StopWords_English.txt");

        // Artigos
        // Cloud_Identity.txt
        private StringBuilder artigoCloudIdentity = new StringBuilder(System.IO.File.ReadAllText(@"C:\Users\lipeu\Downloads\Trab Pesq\Programa\Mineracao_de_Texto_B\Cloud_Identity.txt"));
        // Cloud_Security.txt
        private StringBuilder artigoCloudSecurity = new StringBuilder(System.IO.File.ReadAllText(@"C:\Users\lipeu\Downloads\Trab Pesq\Programa\Mineracao_de_Texto_B\Cloud_Security.txt"));
        // IoT_Network.txt
        private StringBuilder artigoIotNetwork = new StringBuilder(System.IO.File.ReadAllText(@"C:\Users\lipeu\Downloads\Trab Pesq\Programa\Mineracao_de_Texto_B\IoT_Network.txt"));
        // IoT_Verification.txt
        private StringBuilder artigoIotVerification = new StringBuilder(System.IO.File.ReadAllText(@"C:\Users\lipeu\Downloads\Trab Pesq\Programa\Mineracao_de_Texto_B\IoT_Verification.txt"));

        // Imprime Artigo
        public void printPaper (StringBuilder artigo)
        {
            System.Console.WriteLine(artigo);
            System.Console.ReadLine();
        }

        // Imprime StopWords
        public void testaStopWord()
        {
            foreach (string line in stopWords)
            {
                System.Console.WriteLine(line);
            }
            System.Console.ReadLine();
        }

        // Remove Stopwords dos Artigos
        public StringBuilder removeStopWords (StringBuilder artigo)
        {
            StringBuilder aux = new StringBuilder();

            foreach (string word in stopWords)
            {
                aux = artigo.Replace(word, " ");
            }

            return aux;
        }
        // Getters

        public string[] getStopWords()
        {
            return stopWords;
        }

        public StringBuilder getArtigoCloudIdentity ()
        {
            return artigoCloudIdentity;
        }

        public StringBuilder getArtigoIotNetwork()
        {
            return artigoIotNetwork;
        }
        public StringBuilder getArtigoCloudSecurity()
        {
            return artigoCloudSecurity;
        }
        public StringBuilder getArtigoIotVerification()
        {
            return artigoIotVerification;
        }
    }
}
