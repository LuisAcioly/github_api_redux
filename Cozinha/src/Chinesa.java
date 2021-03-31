import java.util.ArrayList;

public class Chinesa extends Cozinha{

    public Chinesa(int numeroPratos, int numeroCozinheiros, int tempoPreparo) {
        super(numeroPratos, numeroCozinheiros, tempoPreparo);

        setHoraAbertura(10);
        setHoraAbertura(21);
        setPratoPrincipal("Yakissoba");
        criaIngredientes();
        criaFuncionarios();
    }

    @Override
    void criaIngredientes() {
        ArrayList<Ingrediente> ingredientes = new  ArrayList<Ingrediente>();
        
        Ingrediente ingrediente1 = new Ingrediente("Champignon", "25/04/2021");
        ingredientes.add(ingrediente1);

        Ingrediente ingrediente2 = new Ingrediente("Brócolis", "25/05/2021");
        ingredientes.add(ingrediente2);

        Ingrediente ingrediente3 = new Ingrediente("Macarrão", "25/06/2021");
        ingredientes.add(ingrediente3);

        Ingrediente ingrediente4 = new Ingrediente("Carne", "25/07/2021");
        ingredientes.add(ingrediente4);
        
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
        
        setFuncionarios(funcionarios);
        
    }
 
}
