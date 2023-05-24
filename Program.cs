﻿using System;
using System.Collections.Generic;

namespace ToDo {
    internal class Program {
        public static List<string> todoList { get; set; }
        static void Main(string[] args) {
            todoList = new List<string>();
            int option = 0;
            do {
                option = ShowMainMenu();
                if (option == 1) {
                    addTodo();
                } else if (option == 2) {
                    ShowMenuDos();
                } else if (option == 3) {
                    ShowMenuTres();
                } else if (option == 4) {
                    Console.WriteLine("Gracias por usar la aplicación");
                } else {
                    Console.WriteLine("Opción no válida");
                }
            } while (option != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu() {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void addTodo() {
            try {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                todoList.Add(task);
                Console.WriteLine("Tarea registrada");
            } catch (Exception) {}
        }

        public static void ShowMenuDos() {
            try {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < todoList.Count; i++) {
                    Console.WriteLine((i + 1) + ". " + todoList[i]);
                }
                Console.WriteLine("----------------------------------------");

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1) {
                    if (todoList.Count > 0) {
                        string task = todoList[indexToRemove];
                        todoList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            } catch (Exception) {}
        }

        public static void ShowMenuTres() {
            if (todoList == null || todoList.Count == 0) {
                Console.WriteLine("No hay tareas por realizar");
            } else {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < todoList.Count; i++) {
                    Console.WriteLine((i + 1) + ". " + todoList[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
