using System;
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
                    removeTodo();
                } else if (option == 3) {
                    showTodoList();
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
                string newTodo = Console.ReadLine();
                todoList.Add(newTodo);
                Console.WriteLine("Tarea registrada");
            } catch (Exception) {
                throw new Exception("Error al ingresar la tarea");
            }
        }

        public static void removeTodo() {
            try {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < todoList.Count; i++) {
                    Console.WriteLine((i + 1) + ". " + todoList[i]);
                }
                Console.WriteLine("----------------------------------------");

                string todoToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(todoToRemove) - 1;
                if (indexToRemove > -1) {
                    if (todoList.Count > 0) {
                        string removedTodo = todoList[indexToRemove];
                        todoList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + removedTodo + " eliminada");
                    }
                }
            } catch (Exception) {
                throw new Exception("Error al remover la tarea");
            }
        }

        public static void showTodoList() {
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
