namespace MeioZuma
{
    public class Elemento
    {
        public int Num;
        public Elemento Prox;
        public Elemento Ant;

        public Elemento()
        {
            Num = 0;
            Prox = null;
            Ant = null;
        }
        
        public Elemento(int color)
        {
            Num = color;
            Prox = null;
            Ant = null;
        }
    }
}