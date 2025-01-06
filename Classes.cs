//classe Aluno
public class Aluno{
    public string Nome {get; set; }
    public int Matricula {get; set; }
    public List<Frequencia> Frequencias {get; set; } = new List<Frequencia>();

    public Aluno(int matricula, string nome)
    {
        Matricula = matricula;
        Nome = nome;
    }
}
//classe Professor
public class Professor{
    public string Nome{get; set; }
    public int Matricula{get; set; }

    public Professor(string nome,int matricula)
    {
        Nome = nome;
        Matricula = matricula;
    }
}
//classe Disciplina
public class Disciplina{
    public string Nome {get; set; }
    public int Id {get; set; }

    public Disciplina(string nome,int id)
    {
        Nome = nome;
        Id = id;
    }
   
}
//classe Sala de Aula
public class Sala{
    public int Numero{get; set; }
    public int Capacidade{get; set; }
    public List<Disciplina> Disciplinas {get; set; } = new List<Disciplina>();

    public Sala(int numero,int capacidade)
    {
        Numero = numero;
        Capacidade = capacidade;
    }
}
//classe Frequencia
public class Frequencia{
    public int MatriculaAluno {get; set; }
    public bool Presente {get; set; }
    
    public Frequencia(int matriculaAluno, bool presente)
    {
        MatriculaAluno = matriculaAluno;
        Presente = presente;
    }
}

