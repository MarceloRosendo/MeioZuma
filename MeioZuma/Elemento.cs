namespace MeioZuma
{
    public class Elemento
    {
        public int Num;
        public Elemento Prox;
        public Elemento Ant;

        public Elemento()                   // Construtor da Classe
        {
            Num = 0;
            Prox = null;
            Ant = null;
        }
    }
}