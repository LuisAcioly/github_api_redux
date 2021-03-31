import java.util.ArrayList;

public class Mineira extends Cozinha{

    public Mineira(int numeroPratos, int numeroCozinheiros, int tempoPreparo) {
        
        super(numeroPratos, numeroCozinheiros, tempoPreparo);

        setHoraAbertura(14);
        setHoraAbertura(20);
        setPratoPrincipal("Feijoada");
        criaIngredientes();
        criaFuncionarios();
    }

    @Override
    void criaIngredientes() {
        ArrayList<Ingrediente> ingredientes = new  ArrayList<Ingrediente>();


        Ingrediente ingrediente1 = new Ingrediente("Feijão", "25/04/2021");
        ingredientes.add(ingrediente1);

        Ingrediente ingrediente2 = new Ingrediente("Farinha", "25/05/2021");
        ingredientes.add(ingrediente2);

        Ingrediente ingrediente3 = new Ingrediente("Arroz", "25/06/2021");
        ingredientes.add(ingrediente3);

        Ingrediente ingrediente4 = new Ingrediente("Carne de Porco", "25/07/2021");
        ingredientes.add(ingrediente4);

        Ingrediente ingrediente5 = new Ingrediente("Linguiça", "25/08/2021");
        ingredientes.add(ingrediente5);
        

        setIngredientes(ingredientes);
    }

    @Override
    void criaFuncionarios() {
        ArrayList<Funcionario> funcionarios = new ArrayList<Funcionario>();
        
        Funcionario funcionario1 = new Funcionario("João", "Garçom");
        funcionarios.add(funcionario1);

        Funcionario funcionario2 = new Funcionario("Maria", "Garçom");
        funcionarios.add(funcionario2);

        Funcionario funcionario3 = new Funcionario("José", "Garçom");
        funcionarios.add(funcionario3);

        Funcionario funcionario4 = new Funcionario("Neto", "Garçom");
        funcionarios.add(funcionario4);


        setFuncionarios(funcionarios);
    }

}
