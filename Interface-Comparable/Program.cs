using Interface_Comparable.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Interface_Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problema
            //Faça um programa para ler um arquivo contendo nomes de pessoas(um nome por
            //linha), armazenando - os em uma lista.Depois, ordenar os dados dessa lista e mostra - los
            //ordenadamente na tela.Nota: o caminho do arquivo pode ser informado "hardcode".
            //
            //Maria Brown
            //Alex Green
            //Bob Grey
            //Anna White
            //Alex Black
            //Eduardo Rose
            //Willian Red
            //Marta Blue
            //Alex Brown
            #endregion

            string path = @"c:\temp\in.txt";
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> list = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        list.Add(new Employee(sr.ReadLine()));
                    }
                    list.Sort();                       //para ordenar uma lista
                    foreach (Employee emp in list)
                    {
                        Console.WriteLine(emp);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

        }
    }
}
