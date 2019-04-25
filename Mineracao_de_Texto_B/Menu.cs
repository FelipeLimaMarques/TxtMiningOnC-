using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineracao_de_Texto_B
{
    class Menu
    {
        TxtReader tr = new TxtReader();
        private StringBuilder artigoIdentity;
        public Dictionary<string, int> aI;
        private StringBuilder artigoSecurity;
        public Dictionary<string, int> aS;
        private StringBuilder artigoNetwork;
        public Dictionary<string, int> aN;
        private StringBuilder artigoVerification;
        public Dictionary<string, int> aV;
        private int esc, esc5;

        // Menu
        public void menuPrincipal(string escolha)
        {

            removerStopWords();

            // Separa as Keywords dos artigos em um Dictionary baseado num número mínimo de ocorrências
            aI = splitWords(getArtigoIdentity(), 15);
            aS = splitWords(getArtigoSecurity(), 15);
            aN = splitWords(getArtigoNetwork(), 7);
            aV = splitWords(getArtigoVerification(), 7);

            do
            {
                Console.Clear();
                print(
                "-----Menu Principal-----\n" +
                "(1) Imprimir StopWords\n" +
                "(2) Imprimir Artigo\n" +
                "(3) Comparar Artigos\n" +
                "(4) Ocorrencia de palavras\n" +
                "(0) Sair\n" +
                "Escolha: "
                );

                escolha = Console.ReadLine();
                esc = Convert.ToInt32(escolha);

                // (1) Imprimir StopWords
                if (esc == 1)
                {
                    tr.testaStopWord();
                    //Console.ReadLine();
                }
                // Imprimir Artigo
                else if (esc == 2)
                {
                    print("Escolha um artigo: \n" +
                        "(1) Cloud_1\n" +
                        "(2) Cloud_2\n" +
                        "(3) IoT_1\n" +
                        "(4) IoT_2\n" +
                        "Escolha: "
                        );

                    escolha = Console.ReadLine();
                    esc5 = Convert.ToInt32(escolha);

                    if (esc5 == 1)
                    {
                        tr.printPaper(tr.getArtigoCloudIdentity());
                    }
                    else if (esc5 == 2)
                    {
                        tr.printPaper(tr.getArtigoCloudSecurity());
                    }
                    else if (esc5 == 3)
                    {
                        tr.printPaper(tr.getArtigoIotNetwork());
                    }
                    else if (esc5 == 4)
                    {
                        tr.printPaper(tr.getArtigoIotVerification());
                    }
                }
                // Comparar Artigos
                else if (esc == 3)
                {
                    int co = 0;
                    print("Escolha um artigo: \n" +
                        "(1) Cloud_1 e Cloud_2\n" +
                        "(2) IoT_1 e IoT_2\n" +
                        "(3) IoT_1 e Cloud_1\n" +
                        "(4) Iot_2 e Cloud_2\n" +
                        "Escolha: "
                        );

                    escolha = Console.ReadLine();
                    esc5 = Convert.ToInt32(escolha);

                    if (esc5 == 1)
                    {
                        co = comparaOcorrencia(aI, aS, 15, 15);
                        if (co >= 10)
                        {
                            print("Artigos sao similares\n");

                        }
                        else
                        {
                            print("Artigos nao sao similares\n");
                        }
                        Console.ReadLine();
                    }
                    else if (esc5 == 2)
                    {
                        co = comparaOcorrencia(aN, aV, 7, 7);
                        if (co >= 10)
                        {
                            print("Artigos sao similares\n");

                        }
                        else
                        {
                            print("Artigos nao sao similares\n");
                        }
                        Console.ReadLine();
                    }
                    else if (esc5 == 3)
                    {
                        co = comparaOcorrencia(aI, aN, 15, 7);
                        if (co >= 10)
                        {
                            print("Artigos sao similares\n");

                        }
                        else
                        {
                            print("Artigos nao sao similares\n");
                        }
                        Console.ReadLine();
                    }
                    else if (esc5 == 4)
                    {
                        co = comparaOcorrencia(aS, aV, 15, 7);
                        if (co >= 10)
                        {
                            print("Artigos sao similares\n");

                        }
                        else
                        {
                            print("Artigos nao sao similares\n");
                        }
                        Console.ReadLine();
                    }

                }
                // Ocorrencia de palavras
                else if (esc == 4)
                {
                    print("Escolha um artigo: \n" +
                        "(1) Cloud_1\n" +
                        "(2) Cloud_2\n" +
                        "(3) IoT_1\n" +
                        "(4) IoT_2\n" +
                        "Escolha: "
                        );

                    escolha = Console.ReadLine();
                    esc5 = Convert.ToInt32(escolha);

                    if (esc5 == 1)
                    {
                        printOcorrencia(aI);
                        Console.ReadLine();
                    }
                    else if(esc5 == 2)
                    {
                        printOcorrencia(aS);
                        Console.ReadLine();
                    }
                    else if(esc5 == 3)
                    {
                        printOcorrencia(aN);
                        Console.ReadLine();
                    }
                    else if(esc5 == 4)
                    {
                        printOcorrencia(aV);
                        Console.ReadLine();
                    }
                }

            }while (esc != 0);
            
        }

        // (1) Imprimir StopWords
        public void imprimirStopWords()
        {
            tr.getStopWords();
        }

        // (2) Remover StopWords
        public void removerStopWords()
        {
            // Setta os artigos sem StopWords
            setArtigoIdentity(tr.removeStopWords(tr.getArtigoCloudIdentity()));
            setArtigoSecurity(tr.removeStopWords(tr.getArtigoCloudSecurity()));
            setArtigoNetwork(tr.removeStopWords(tr.getArtigoIotNetwork()));
            setArtigoVerification(tr.removeStopWords(tr.getArtigoIotVerification()));

            /*print("StopWords removidas dos artigos\n");
            System.Console.ReadLine();*/

        }

        // (3) Comparar Artigos
        public int comparaOcorrencia (Dictionary<string, int>artigo1, Dictionary<string, int>artigo2, int v1, int v2)
        {
            int cont = 0;
            foreach (var entry in artigo1)
            {
                foreach (var entry2 in artigo2)
                {
                    if (entry.Value >= v1 && entry2.Value >= v2)
                    {
                        if (entry.Key == entry2.Key)
                        {
                            Console.WriteLine("Artigo1: [{0} {1}]\n", entry.Key, entry.Value);
                            Console.WriteLine("Artigo2: [{0} {1}]\n", entry2.Key, entry2.Value);
                            cont++;
                        }
                    }
                        
                }
            }
            return cont;
        }

        // (4) Ocorrencia de palavras
        // Metodo 1: Split
        public Dictionary<string, int> splitWords(StringBuilder artigo, int v)
        {
            string aux = artigo.ToString();
            string[] words = aux.Split(' ');

            Dictionary<string, int> counts = words.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            return counts;

        }

        //Metodo 2: Print
        public void printOcorrencia(Dictionary<string, int> counts)
        {
            foreach (var entry in counts)
            {
                Console.WriteLine("[{0} {1}]", entry.Key, entry.Value);
            }
        }

        // Setters
        public void setArtigoIdentity(StringBuilder artigoIdentity)
        {
            this.artigoIdentity = artigoIdentity;
        }

        public void setArtigoSecurity(StringBuilder artigoSecurity)
        {
            this.artigoSecurity = artigoSecurity;
        }

        public void setArtigoNetwork(StringBuilder artigoNetwork)
        {
            this.artigoNetwork = artigoNetwork;
        }

        public void setArtigoVerification(StringBuilder artigoVerification)
        {
            this.artigoVerification = artigoVerification;
        }

        // Getters
        public StringBuilder getArtigoIdentity()
        {
            return artigoIdentity;
        }

        public StringBuilder getArtigoSecurity()
        {
            return artigoSecurity;
        }

        public StringBuilder getArtigoNetwork()
        {
            return artigoNetwork;
        }

        public StringBuilder getArtigoVerification()
        {
            return artigoVerification;
        }

        public void print (string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}
