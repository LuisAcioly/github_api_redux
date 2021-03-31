import java.util.ArrayList;

abstract class Cozinha {
    protected int numeroPratos;
    protected int numeroCozinheiros;
    protected int tempoPreparo;
    protected int horaAbertura;
    protected int horaFechamento;
    protected String pratoPrincipal;
    protected ArrayList<Ingrediente> ingredientes;
    protected ArrayList<Funcionario> funcionarios;
    
    public Cozinha(int numeroPratos, int numeroCozinheiros, int tempoPreparo) {
        this.numeroPratos = numeroPratos;
        this.numeroCozinheiros = numeroCozinheiros;
        this.tempoPreparo = tempoPreparo;
        this.horaAbertura = 0;
        this.horaFechamento = 0;
        this.pratoPrincipal = null;
        this.ingredientes = new  ArrayList<Ingrediente>();
        this.funcionarios = new ArrayList<Funcionario>();
    }

    public int getNumPratos(){
        return this.numeroPratos;
    }

    public int getNumCozinheiros(){
        return this.numeroCozinheiros;
    }

    public int getTempoPreparo(){
        return this.tempoPreparo;
    }

    public int getHoraAbertura() {
        return this.horaAbertura;
    }

    protected void setHoraAbertura(int horaAbertura) {
        this.horaAbertura = horaAbertura;
    }

    public int getHoraFechamento() {
        return this.horaFechamento;
    }

    protected void setHoraFechamento(int horaFechamento) {
        this.horaFechamento = horaFechamento;
    }

    public String getPratoPrincipal() {
        return this.pratoPrincipal;
    }

    protected void setPratoPrincipal(String pratoPrincipal) {
        this.pratoPrincipal = pratoPrincipal;
    }

    public ArrayList<Ingrediente> getIngredientes() {
        return this.ingredientes;
    }

    protected void setIngredientes(ArrayList<Ingrediente> ingredientes) {
        this.ingredientes = ingredientes;
    }

    public ArrayList<Funcionario> getFuncionarios() {
        return this.funcionarios;
    }

    protected void setFuncionarios(ArrayList<Funcionario> funcionarios) {
        this.funcionarios = funcionarios;
    }

    public void prepararPratos(){
        System.out.printf("\nIgredientes para a %s:\n", getPratoPrincipal());
        
        ingredientes.forEach((ingrediente) -> System.out.printf("%s - Validade: %s\n",ingrediente.getNome(), ingrediente.getDataValidade()));

    }

    public void lavarLouca(){
        System.out.println("\nOs que vão lavar a louça são:");
        
        funcionarios.forEach((funcionario) -> System.out.printf("%s - Atividade: %s\n",funcionario.getNome(), funcionario.getAtividade()));
    }
    
    abstract void criaIngredientes();
    
    abstract void criaFuncionarios();
    
}
