using System.Text.Json;
using ToDoModel;

namespace ToDoController
{
    public class CToDo
    {
        private List<MToDo> ListaDeTarefas = new List<MToDo>();

        public void Create(string titulo)
        {
            int registro = this.ListaDeTarefas.Count + 1;
            this.ListaDeTarefas.Add(new MToDo { Registro = registro,Titulo = titulo });
            Console.WriteLine($"O Numero do Registro: {registro}");
        }

        public dynamic GetOne(int registro)
        {
            dynamic resposta;

            if(registro > this.ListaDeTarefas.Count)
            {
                resposta = new { mensagem = "O Registro Informado Precisa Ainda Ser Criada." };
            }
            else
            {
                resposta = this.ListaDeTarefas[registro - 1];
            }

            return JsonSerializer.Serialize(resposta);
        }

        public dynamic Delete(int registro)
        {
            dynamic resposta;

            if(registro > this.ListaDeTarefas.Count)
            {
                resposta = new { mensagem = "O Registro Informado Precisa Ainda Ser Criada." };
            }
            else
            {
                this.ListaDeTarefas.RemoveRange(registro - 1,1);
                resposta = new { mensagem = "Tarefa Deletada Com Sucesso" };
            }
            return JsonSerializer.Serialize(resposta);
        }
        public dynamic GetAll()
        {
            dynamic resposta;
            if(this.ListaDeTarefas.Count == 0)
            {
                resposta = new { mensagem = "Crie Tarefas para Listar..." };
            }
            else
            {
                resposta = new { quantidadeTotal = this.ListaDeTarefas.Count,Tarefas = this.ListaDeTarefas.ToArray() };
            }

            return JsonSerializer.Serialize(resposta);
        }
    }
}
