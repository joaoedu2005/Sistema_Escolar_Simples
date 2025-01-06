using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SistemaEscolar
{
    class Program
    {
        // Listas globais para armazenar dados
        static List<Aluno> alunos = new List<Aluno>();
        static List<Professor> professores = new List<Professor>();
        static List<Disciplina> disciplinas = new List<Disciplina>();
        static List<Frequencia> frequencias = new List<Frequencia>();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("==== Sistema Escolar ====");
                Console.WriteLine("1. Cadastrar Aluno");
                Console.WriteLine("2. Cadastrar Professor");
                Console.WriteLine("3. Cadastrar Disciplina");
                Console.WriteLine("4. Registrar Frequência");
                Console.WriteLine("5. Listar Dados");
                Console.WriteLine("6. Listar Frequencia");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                // Validação da entrada do usuário
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                    opcao = -1; // Define como inválido para continuar no loop
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;

                    case 2:
                        CadastrarProfessor();
                        break;

                    case 3:
                        CadastrarDisciplina();
                        break;

                    case 4:
                        RegistrarFrequencia();
                        break;

                    case 5:
                        ListarAlunos(alunos);
                        ListarProfessores(professores);
                        ListarDisciplinas(disciplinas);
                        break;

                    case 6:
                    ListarFrequencia(frequencias);    
                    break;

                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 0);
        }

        // Método para cadastrar aluno
        static void CadastrarAluno()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite a matrícula do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Matrícula inválida. Operação cancelada.");
                return;
            }

            Aluno novoAluno = new Aluno (matricula, nome);
            alunos.Add(novoAluno);

            Console.WriteLine($"Aluno {nome} cadastrado com sucesso!");
        }

        // Método para cadastrar professor
        static void CadastrarProfessor()
        {
            Console.Write("Digite o nome do professor: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite a matrícula do professor: ");
            if (!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Matrícula inválida. Operação cancelada.");
                return;
            }

            Professor novoProfessor = new Professor (nome, matricula);
            professores.Add(novoProfessor);

            Console.WriteLine($"Professor {nome} cadastrado com sucesso!");
        }

        // Método para cadastrar disciplina
        static void CadastrarDisciplina()
        {
            Console.Write("Digite o nome da disciplina: ");
            string nomeDisciplina = Console.ReadLine() ?? string.Empty;

            Console.Write("Digite o ID da disciplina: ");
            if(!int.TryParse(Console.ReadLine(),out int IdDisciplina))
            {
                Console.WriteLine("ID inválido. Operação cancelada.");
                return;
            }

            Disciplina novaDisciplina = new Disciplina (nomeDisciplina , IdDisciplina);
            disciplinas.Add(novaDisciplina);

            Console.WriteLine($"Disciplina '{nomeDisciplina}' cadastrada com sucesso!");
        }
        // Método para Registrar frequencia
        static void RegistrarFrequencia()
        {
            Console.Write("Digite a matrícula do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int matricula))
            {
                Console.WriteLine("Matrícula inválida. Operação cancelada.");
                return;
            }

            Console.Write("O aluno esteve presente? (s/n): ");
            string resposta = Console.ReadLine()?.ToLower();
            bool presente = resposta == "s";

            // Criando a frequência com matrícula e presença
            Frequencia novaFrequencia = new Frequencia(matricula, presente);

            frequencias.Add(novaFrequencia);

            Console.WriteLine("Frequência registrada com sucesso!");
        }

        
        // Método para Listar Dados (Alunos, Professores e Disciplinas)
        static void ListarAlunos(List<Aluno> alunos)
        {
            Console.WriteLine("=== Lista de Alunos ===");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Matricula}, Nome: {aluno.Nome})");
            }
        }
        static void ListarProfessores(List<Professor> professores)
        {
            Console.WriteLine("=== Lista de Professores ===");
            foreach (var professor in professores)
            {
                Console.WriteLine($"Matricula: {professor.Matricula}, Nome: {professor.Nome}");
            }
        }
        static void ListarDisciplinas(List<Disciplina> disciplinas)
        {
            Console.WriteLine("=== Lista de Disciplinas ===");
            foreach (var disciplina in disciplinas)
            {
                Console.WriteLine($"ID: {disciplina.Id} , Nome: {disciplina.Nome}");
            }
        }
        //Método para Listar especificamente Frequencias
        static void ListarFrequencia(List<Frequencia> frequencias)
        {
            if(frequencias.Count == 0)
            {
                Console.WriteLine("Nenhuma frequencia registrada.");
                return;
            }

            Console.WriteLine("==== Lista de Frequencias ====");
            foreach(var frequencia in frequencias)
            {
                Console.WriteLine($"Matricula: {frequencia.MatriculaAluno}, Presente: {(frequencia.Presente ? "Sim" : "Não")}");
            }
        }
    }
}
