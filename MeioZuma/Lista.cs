using System;
using System.ComponentModel;
using System.Configuration;
using MeioZuma;

namespace ListaDuplamenteEncadeada
{
    public class Lista
    {
        private Elemento Início;            // Primeiro elemento da lista
        private Elemento Fim;               // Último elemento da lista
        private Elemento Aux;               // Objeto auxiliar

        public int Tamanho;                 // Número de Elementos da Lista

        public Lista()                      // Construtor da Classe
        {
            Início = null;
            Fim = null;
            Tamanho = 0;
        }

        // Função para inserir um elemento no início da lista
        public void InserirInício(int Valor)
        {
            Elemento Novo = new Elemento();     // Alocação Dinâmica - Novo Elemento para a Lista

            Novo.Num = Valor;                   // Insere o valor do elemento na lista

            if (Início == null)                 // A lista está vazia? Primeiro elemento...
            {
                Início = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteiro para o elemento anterior passa a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Novo.Prox = Início;             // O elemento Novo aponta para o elemento que já havia sido inserido anteriormente
                Início.Ant = Novo;              // O ponteiro anterior do elemento já existente aponta para o novo elemento
                Novo.Ant = null;                // Já que é o primeiro, o ponteiro anterior aponta para null
                Início = Novo;                  // e o Início passa a ter o endereço do elemento Novo que acabou de ser inserido
            }

            Tamanho++;                          // O elemento entrou na lista
        }

        // Função para inserir um elemento no final da lista
        public void InserirFinal(int Valor)
        {
            Elemento Novo = new Elemento();     // Alocação Dinâmica - Novo Elemento para a Lista

            Novo.Num = Valor;                   // Insere o valor do elemento na lista

            if (Início == null)                 // A lista está vazia? Primeiro elemento...
            {
                Início = Novo;                  // O elemento inserido é o primeiro e o último. Guarda o endereço dele.
                Fim = Novo;

                Novo.Prox = null;               // O ponteiro para o próximo elemento passa a ser nulo
                Novo.Ant = null;                // O ponteior para o elemento anterior para a ser nulo
            }
            else                                // A lista já possui elementos?
            {
                Fim.Prox = Novo;                // O elemento que era o último da lista aponta para o elemento inserido
                Novo.Ant = Fim;                 // O ponteiro anterior do novo elemento aponta para o que já existia
                Novo.Prox = null;               // O ponteiro próximo do novo elemento aponta para nada, já que ele é o último
                Fim = Novo;                     // Atualiza o último: o elemento final passa a ser o novo elemento inserido
            }

            Tamanho++;                          // O elemento entrou na lista
        }
        
        public void inserirNoMeio(int n, int item) {
            int index = 1;
            if (Tamanho == 0) 
            {
                Console.WriteLine("Lista vazia");
            } else if ((n > Tamanho) || (n < 1)) 
            {
                Console.WriteLine("Fora do tamanho da lista");
                return;
            } else if (n == Tamanho) 
            {
                InserirFinal(item);
                return;
            } 
            Elemento Aux = Início;
            while (index < n) {
                index++;
                Aux = Aux.Prox;
            }
            Elemento Elemento = new Elemento();
            Elemento.Num = item;
            Elemento.Prox = Aux.Prox;
            Aux.Prox.Ant = Elemento;
            Aux.Prox = Elemento;
            Elemento.Ant = Aux;
            Tamanho++;
        }

        //Função para mostrar todos os elementos da lista do Início ao Fim
        public void MostraListaINIFIM()
        {
            Console.Clear();

            if (Início == null)
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
            }
            else
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Aux = Início;

                while (Aux != null)
                {
                    Console.Write(Aux.Num + "  ");
                    Aux = Aux.Prox;
                }
            }
        }

        //Função para mostrar todos os elementos da lista do Fim ao Início
        public void MostraListaFIMINI()
        {
            Console.Clear();            // Limpa a tela

            if (Início == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
                Console.ReadKey();
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Aux = Fim;              // Pega o último elemento

                while (Aux != null)     // Enquanto a lista tiver elementos que apontam para algum elemento anterior da lista
                {
                    Console.WriteLine("{0,5}", Aux.Num);        // Mostra o elemento,
                    Aux = Aux.Ant;                              // aponta para o elemento anterior
                }                                               // e volta

                Console.ReadKey();
            }
        }

        private Elemento removeElemento(Elemento item)
        {
            Elemento Aux;
            if (Início == null)
            {
                return null;
            }

            if (Início.Equals(item)) 
            {
                Início = Início.Prox;
                
                if (Início != null)
                {
                    Início.Ant = null;
                }
                return Início;
            }

            Elemento el = Início;
            
            while (el != null && !el.Equals(item))
            {
                el = el.Prox;      
            }

            if (el == null)
            {
                return null;
            }

            Aux = el.Prox;
            el.Ant.Prox = el.Prox;
            
            if (el.Prox != null)
            {
                el.Prox.Ant = el.Ant;
            }
            
            return Aux;
        }
        
        public Boolean removeElementos(Elemento item, int qt)
        {
            Elemento Aux = item;
            Boolean flag = true;

            try
            {
                while (qt != 0)
                {
                    Aux = removeElemento(Aux);
                    qt--;
                    Tamanho--;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        //Função para retirar um elemento da lista
        public void RetiraElemento(int Valor)
        {
            if (Início == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
            }
            else                                    // A lista não está vazia
            {
                Aux = Início;                       // Pega o endereço do primeiro elemento

                int Achou = 0;                      // Variável para contar quantas vezes o elemento é encontrado na lista

                while (Aux != null)                 // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    if (Aux.Num == Valor)           // O número digitado foi encontrado na lista
                    {
                        Achou++;                    // Conta ocorrência

                        if (Aux == Início)                  // O número a ser removido é o primeiro da lista?
                        {
                            Início = Aux.Prox;              // O primeiro elemento foi removido e ele ganha o endereço do da frente

                            if (Início != null)             // Se o elemento existe
                            {
                                Início.Ant = null;          // O ponteiro anterior dele não aponta para nada, já que ele é o primeiro
                            }
                            
                            Aux = Início;                   // Armazena o endereço dele para o próximo uso

                            Tamanho--;                      // Diminui o tamanho da lista
                        }
                        else if (Aux == Fim)
                        {
                            Fim = Fim.Ant;
                            Fim.Prox = null;
                            Aux = null;

                            Tamanho--;
                        }
                        else
                        {
                            Aux.Ant.Prox = Aux.Prox;
                            Aux.Prox.Ant = Aux.Ant;
                            Aux = Aux.Prox;                 

                            Tamanho--;                      
                        }
                    }
                    else
                    {
                        Aux = Aux.Prox;
                    }
                }

                if (Achou == 0)
                {
                    Console.WriteLine("O valor {0} não foi encontrado na lista!!! \n", Valor);
                }
                else if (Achou == 1)                        // Achou uma ocorrência
                {
                    Console.WriteLine("O valor {0} foi encontrado na lista e removido!!! \n", Valor);
                }
                else                                        // Achou mais de uma ocorrência
                {
                    Console.WriteLine("O valor {0} foi encontrado {1} vezes na lista e removido!!! \n", Valor, Achou);
                }

                Console.WriteLine("Número de Elementos da Lista: {0}\n\n", Tamanho);
                Console.ReadKey();
            }
        }

        //Função para esvaziar toda a lista
        public void EsvaziarLista()
        {
            if (Início == null)                     // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");        // Mostra
                Console.ReadKey();
            }
            else                                    // A lista não está vazia
            {
                Início = null;                      // O Início da Lista não aponta para ninguém...
                Tamanho = 0;
            }
        }
        
        public Elemento getElemento(int pos)
        {
            Console.Clear();

            int index = 0;

            if (Início == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Aux = Início;           // Pega o primeiro elemento

                while (Aux != null)     // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    index++;
                    if (index == pos)
                    {
                        return Aux;
                    }
                    Aux = Aux.Prox;                             
                }                                               
            }

            return null;
        }

        public void verifySequence(int pos, int color)
        {
            int index = 0;
            int pontos = 0;
            if (Início == null)         // Se não tem elemento na lista...
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
            }
            else                        // Se a lista tem pelo menos um elemento
            {
                Console.WriteLine("Elementos da Lista: {0}\n", Tamanho);

                Elemento AuxLocal = Início;           // Pega o primeiro elemento
                Elemento AuxSave = Início;
                while (AuxLocal != null)     // Enquanto a lista tiver elementos que apontam para outro elemento da lista
                {
                    index++;
                    if (index == pos)
                    {
                        if (AuxLocal.Num == color)
                        {
                            AuxSave = AuxLocal;
                            if (AuxLocal.Ant != null)
                            {
                                if (AuxLocal.Ant.Num == color)
                                {
                                    // percorrer para tras removendo as cores seguidas com aquele valor
                                    // percorre primeiro contando os elementos a serem removidos
                                    while (AuxLocal != null)
                                    {
                                        if (AuxLocal.Num != color)
                                        {
                                            AuxSave = AuxLocal.Prox;
                                            break;
                                        }
                                        AuxLocal = AuxLocal.Ant;
                                    }

                                    AuxLocal = AuxSave;
                                }
                            }

                            
                            // percorrer para frente removendo as cores seguidas com aquele valor
                            // percorre primeiro contando os elementos a serem removidos
                            while (AuxLocal != null)
                            {
                                if (AuxLocal.Num == color)
                                {
                                    pontos++;
                                }
                                else
                                {
                                    break;
                                }
                                AuxLocal = AuxLocal.Prox;
                            }

                            AuxLocal = AuxSave;

                            if (pontos >= 2)
                            {
                                removeElementos(AuxLocal, pontos);    
                            }
                            else
                            {
                                inserirNoMeio(pos,color);
                            }
                            break;
                        }
                        else
                        {
                            inserirNoMeio(pos,color);
                            break;
                        }
                    }
                    AuxLocal = AuxLocal.Prox;                             
                }                                               
            }
        }
    }
}