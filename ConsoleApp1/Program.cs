using System;
using System.Collections.Generic;

namespace Crud
{
    class Program
    {

        public class Libro
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }

            public Libro(int id, string titulo, string autor)
            {
                Id = id;
                Titulo = titulo;
                Autor = autor;
            }
        }


        static List<Libro> libros = new List<Libro>();
        static int contador = 1;

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("CRUD de Libros");
                Console.WriteLine("1. Crear libro");
                Console.WriteLine("2. Leer libros");
                Console.WriteLine("3. Actualizar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearLibro();
                        break;
                    case 2:
                        LeerLibros();
                        break;
                    case 3:
                        ActualizarLibro();
                        break;
                    case 4:
                        EliminarLibro();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 0);
        }

        static void CrearLibro()
        {
            Console.Write("Introduce el título del libro: ");
            string titulo = Console.ReadLine();
            Console.Write("Introduce el autor del libro: ");
            string autor = Console.ReadLine();
            Libro nuevoLibro = new Libro(contador++, titulo, autor);
            libros.Add(nuevoLibro);
            Console.WriteLine("Libro creado con éxito.");
        }

        static void LeerLibros()
        {
            Console.WriteLine("Lista de Libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"ID: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
            }
        }

        static void ActualizarLibro()
        {
            Console.Write("Introduce el ID del libro a actualizar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var libro = libros.Find(l => l.Id == id);

            if (libro != null)
            {
                Console.Write("Introduce el nuevo título del libro: ");
                libro.Titulo = Console.ReadLine();
                Console.Write("Introduce el nuevo autor del libro: ");
                libro.Autor = Console.ReadLine();
                Console.WriteLine("Libro actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        static void EliminarLibro()
        {
            Console.Write("Introduce el ID del libro a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var libro = libros.Find(l => l.Id == id);

            if (libro != null)
            {
                libros.Remove(libro);
                Console.WriteLine("Libro eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }
    }
}
