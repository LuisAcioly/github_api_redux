public class App {
    public static void main(String[] args) {
        //Simulação de um código procedural
        System.out.println("Iniciando os trabalhos do resturante");

        //Trabalhando com orientação objetos
        int numeroPratos = 10;
        int tempoPreparo = 30;
        int numeroCozinheiros = 5;
        Cozinha cozMin = new Mineira(numeroPratos, numeroCozinheiros, tempoPreparo);
        
        System.out.println("----------------Cozinha Mineira----------------");
        System.out.printf("Numero de Pratos: %d \n", cozMin.getNumPratos());
        System.out.printf("Numero de Cozinheiros: %d\n", cozMin.getNumCozinheiros());
        System.out.printf("Tempo de Preparo: %d\n", cozMin.getTempoPreparo());
        System.out.printf("Abre as: %d\n", cozMin.getHoraAbertura());
        System.out.printf("Fecha as: %d\n", cozMin.getHoraFechamento());
        System.out.printf("Abre as: %d\n", cozMin.getHoraAbertura());
        System.out.printf("Prato Principal: %s\n", cozMin.getPratoPrincipal());
        cozMin.prepararPratos();
        cozMin.lavarLouca();

        numeroPratos = 8;
        tempoPreparo = 15;
        numeroCozinheiros = 3;
        Cozinha cozChin = new Chinesa(numeroPratos, numeroCozinheiros, tempoPreparo);
        System.out.println("\n----------------Cozinha Chinesa----------------");
        System.out.printf("Numero de Pratos: %d \n", cozChin.getNumPratos());
        System.out.printf("Numero de Cozinheiros: %d\n", cozChin.getNumCozinheiros());
        System.out.printf("Tempo de Preparo: %d\n", cozChin.getTempoPreparo());
        System.out.printf("Abre as: %d\n", cozChin.getHoraAbertura());
        System.out.printf("Fecha as: %d\n", cozChin.getHoraFechamento());
        System.out.printf("Abre as: %d\n", cozChin.getHoraAbertura());
        System.out.printf("Prato Principal: %s\n", cozChin.getPratoPrincipal());
        cozChin.prepararPratos();
        cozChin.lavarLouca();

        numeroPratos = 5;
        tempoPreparo = 10;
        numeroCozinheiros = 2;
        Cozinha cozIta = new Italiana(numeroPratos, numeroCozinheiros, tempoPreparo);
        System.out.println("\n----------------Cozinha Italiana----------------");
        System.out.printf("Numero de Pratos: %d \n", cozIta.getNumPratos());
        System.out.printf("Numero de Cozinheiros: %d\n", cozIta.getNumCozinheiros());
        System.out.printf("Tempo de Preparo: %d\n", cozIta.getTempoPreparo());
        System.out.printf("Abre as: %d\n", cozIta.getHoraAbertura());
        System.out.printf("Fecha as: %d\n", cozIta.getHoraFechamento());
        System.out.printf("Abre as: %d\n", cozIta.getHoraAbertura());
        System.out.printf("Prato Principal: %s\n", cozIta.getPratoPrincipal());
        cozIta.prepararPratos();
        cozIta.lavarLouca();
    }
}
