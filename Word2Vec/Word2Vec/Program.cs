using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word2Vec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Train ? { Y / N} ");
            if (Console.ReadKey().Key == ConsoleKey.Y) Train();
            Console.WriteLine();
            // Load model from file.
            var model = new Model();
            model.LoadVectors("model.bin");
            // Get 10 nearest words to user input
            while (true)
            {
                Console.Write("Input > ");
                var word = Console.ReadLine();
                foreach (var item in model.NearestWords(word, 10))
                    Console.WriteLine("{ 0:0.0000} t{ 1}", item.Value, item.Key);
                Console.WriteLine();
            }
        }
        private static void Train()
        {
            // Train vector model and save to file.
            var word2vec = new word2vec();
            word2vec.Train("corpus.txt", "model.bin");
        }
    }
}
