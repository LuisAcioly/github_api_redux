import java.util.ArrayList;

public class Italiana extends Cozinha{

    public Italiana(int numeroPratos, int numeroCozinheiros, int tempoPreparo) {
        super(numeroPratos, numeroCozinheiros, tempoPreparo);
        
        setHoraAbertura(13);
        setHoraAbertura(22);
        setPratoPrincipal("Yakissoba");
        criaIngredientes();
        criaFuncionarios();
    }

    @Override
    void criaIngredientes() {
        ArrayList<Ingrediente> ingredientes = new  ArrayList<Ingrediente>();
        
        Ingrediente ingrediente1 = new Ingrediente("Molho", "25/04/2021");
        ingredientes.add(ingrediente1);

        Ingrediente ingrediente2 = new Ingrediente("Macarrão", "25/05/2021");
        ingredientes.add(ingrediente2);

        Ingrediente ingrediente3 = new Ingrediente("Carne", "25/06/2021");
        ingredientes.add(ingrediente3);
        
        setIngredientes(ingredientes);
    }

    @Override
    void criaFuncionarios() {
        ArrayList<Funcionario> funcionarios = new ArrayList<Funcionario>();
        
        Funcionario funcionario1 = new Funcionario("João", "Garçom");
        funcionarios.add(funcionario1);

        Funcionario funcionario2 = new Funcionario("Maria", "Garçom");
        funcionarios.add(funcionario2);

        
        setFuncionarios(funcionarios);
        
    }
    
}
