using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace exercicio_lambda1 {
    class Program {
        static void Main(string[] args) {

            List<Product> list = new List<Product>();

            string path = @"D:\c#\Curso c# completo - udemy\Exercicios e exemplos\exercicio-lambda1\exercicio-lambda1\products.txt.txt";
            
            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(",");
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }

            }

            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"Average price: {avg.ToString("F2", CultureInfo.InvariantCulture)}" );

            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach(String x in names) {
                Console.WriteLine(x);
            }
        }
    }
}
