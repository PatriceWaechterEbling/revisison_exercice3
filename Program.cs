using System;
//source initiale trouvée sur internet 
// https://favtutor.com/blogs/dijkstras-algorithm-cpp
//

namespace exercice3
{
    class GFG
    {
        static int V = 9;//nombre de sommets 
        public int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            return min_index;
        }
        public void Afficher(int[] dist, int n)
        {
            Console.Write("Distance depuis l'origine\n");
            for (int i = 0; i < V; i++)
                Console.Write((i+1) + " \t\t " + dist[i] + "\n");
        }

        public void Implentation_Dijkstra(int[,] graph, int src)
        {
            int[] dist = new int[V]; // array des valeurs de distance
            bool[] sptSet = new bool[V];
            for (int i = 0; i < V; i++)
            { //initialisation des distances
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0; //source d'origine
            for (int count = 0; count < V - 1; count++)
            {//recherche des valeurs de distance les plus courtes
                int u = minDistance(dist, sptSet);//distance minimales
                sptSet[u] = true; //indiquer comme etant réussi
                for (int v = 0; v < V; v++)//mise a jour des valeurs de distance au prochain point

                    //mettre dist[v] seulement si  dist[v]!=sptSet
                    // correlatif entre u->v && (src->v && u>dist[v])
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }
            Afficher(dist, V);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // la taille de la matrice doit correspondre a la valeur V ou plus 
            int[,] graphe = new int[,] { //initialisation de la matrice initiale
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },{ 4, 2, 8, 2, 2, 2, 2, 11, 2 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 0 },{ 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },{ 0, 0, 4, 14, 10, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 1, 6 },{ 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 0, 0, 0, 0, 6, 7, 0 },{ 4, 1, 8, 1, 1, 1, 1, 11, 1 },
                { 1, 1, 1, 1, 1, 1, 6, 7, 1 }
            };
            GFG t = new GFG();
           Console.WriteLine("L’algorithme du plus court chemin de Dijkstra\n\nCeci est une adaptation d'un code C++ trouvé sur Internet:\nhttps://favtutor.com/blogs/dijkstras-algorithm-cpp");
            t.Implentation_Dijkstra(graphe, 0);//initialiser la fonction avec la matrice "graphe ci haut"
        }
    }
}
