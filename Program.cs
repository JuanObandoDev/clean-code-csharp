namespace ToDo
{
    internal class Program
    {
        public static List<string> todoList { get; set; } = new List<string>();
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                option = ShowMainMenu();
                if ((Menu)option == Menu.AddTodo)
                {
                    addTodo();
                }
                else if ((Menu)option == Menu.RemoveTodo)
                {
                    removeTodo();
                }
                else if ((Menu)option == Menu.ShowTodoList)
                {
                    showTodoList();
                }
                else if ((Menu)option == Menu.Exit)
                {
                    Console.WriteLine("Gracias por usar la aplicación");
                }
                else
                {
                    Console.WriteLine("Opción no válida");
                }
            } while ((Menu)option != Menu.Exit);
        }

        public static int ShowMainMenu()
        {
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

        public static void addTodo()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTodo = Console.ReadLine();
                todoList.Add(newTodo);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                throw new Exception("Error al ingresar la tarea");
            }
        }

        public static void removeTodo()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                showTodoList();

                string todoToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(todoToRemove) - 1;
                if (indexToRemove > (todoList.Count - 1) || indexToRemove < 0)
                {
                    Console.WriteLine("Tarea no encontrada");
                }
                else
                {
                    if (todoList.Count > 0 && indexToRemove > -1)
                    {
                        string removedTodo = todoList[indexToRemove];
                        todoList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {removedTodo} eliminada");
                    }
                    else
                    {
                        Console.WriteLine("No hay tareas por eliminar");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al remover la tarea");
            }
        }

        public static void showTodoList()
        {
            if (todoList?.Count == 0)
            {
                Console.WriteLine("----------------------------------------");
                int todoIndex = 0;
                todoList.ForEach(todo => Console.WriteLine($"{++todoIndex}. {todo}"));
                Console.WriteLine("----------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }

    public enum Menu
    {
        AddTodo = 1,
        RemoveTodo = 2,
        ShowTodoList = 3,
        Exit = 4
    }
}
