using Auxiliary;
using ToDoController;

namespace MenuRoot
{
    public class Menu
    {
        private string? key;
        private CToDo todo = new CToDo();
        public Menu()
        {
            while(true)
            {
                Console.Clear();
                new Copyright();
                ShowMenu();
                chooseOption();
            }

        }
        private void ShowMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|  1 - Ver Lista            |");
            Console.WriteLine("|  2 - Ver Apenas Um        |");
            Console.WriteLine("|  3 - Criar Novo Item      |");
            Console.WriteLine("|  4 - Deletar Item         |");
            Console.WriteLine("|  5 - Sair                 |");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nPara Escolher uma opção digite apenas o numero.");

            this.key = Console.ReadLine();
        }

        private void chooseOption()
        {
            switch(this.key)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(this.todo.GetAll());
                    Console.WriteLine("Para Continuar Precione Qualquer Tecla.");
                    Console.ReadKey();
                    return;
                case "2":
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Informe O Numero de Registro Para Localizar.");
                        string? key = Console.ReadLine();

                        if(!string.IsNullOrEmpty(key) && int.TryParse(key,out int keyInt))
                        {
                            dynamic response = this.todo.GetOne(keyInt);
                            Console.Clear();
                            Console.WriteLine(response);
                            break;
                        }

                    }

                    Console.WriteLine("Para Continuar Precione Qualquer Tecla.");
                    Console.ReadKey();
                    return;
                case "3":
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Qual Será o Nome Da Sua Nova Tarefa?");
                        string? title = Console.ReadLine();
                        if(!string.IsNullOrWhiteSpace(title))
                        {
                            this.todo.Create(title);
                            Console.WriteLine("Criado Com Sucesso! \nPara Continuar Precione Qualquer Tecla.");
                            Console.ReadKey();
                            break;
                        }
                    }

                    return;
                case "4":
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine("Informe O Numero de Registro Para Deletar.");
                        string? key = Console.ReadLine();

                        if(!string.IsNullOrEmpty(key) && int.TryParse(key,out int keyInt))
                        {
                            dynamic response = this.todo.Delete(keyInt);
                            Console.Clear();
                            Console.WriteLine(response);
                            break;
                        }

                    }

                    Console.WriteLine("Para Continuar Precione Qualquer Tecla.");
                    Console.ReadKey();
                    return;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Para Finalizar pressione Qualquer Tecla.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Para Continuar Pressione Qualquer Tecla Para Retornar Ao Menu e Escolher Uma Opção Valida.");
                    Console.ReadKey();
                    return;
            }
        }
    }
}