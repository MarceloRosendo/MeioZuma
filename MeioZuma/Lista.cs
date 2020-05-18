using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using MeioZuma;

namespace ListaDuplamenteEncadeada
{
    public class Lista
    {
        private Elemento Início;
        private Elemento Fim;
        private Elemento Aux;

        public int Tamanho;

        public Lista()
        {
            Início = null;
            Fim = null;
            Tamanho = 0;
        }

        public void InserirInício(int Valor)
        {
            Elemento Novo = new Elemento();

            Novo.Num = Valor;

            if (Início == null)
            {
                Início = Novo;
                Fim = Novo;

                Novo.Prox = null;
                Novo.Ant = null;
            }
            else
            {
                Novo.Prox = Início;
                Início.Ant = Novo;
                Novo.Ant = null;
                Início = Novo;
            }

            Tamanho++;
        }

        public void InserirFinal(int Valor)
        {
            Elemento Novo = new Elemento();

            Novo.Num = Valor;

            if (Início == null)
            {
                Início = Novo;
                Fim = Novo;

                Novo.Prox = null;
                Novo.Ant = null;
            }
            else
            {
                Fim.Prox = Novo;
                Novo.Ant = Fim;
                Novo.Prox = null;
                Fim = Novo;
            }

            Tamanho++;
        }
        
        public void InserirNoMeio(int n, int item) {
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
            Elemento AuxLocal = Início;
            while (index < n) {
                index++;
                AuxLocal = AuxLocal.Prox;
            }
            Elemento Elemento = new Elemento(item);
            
            Elemento.Prox = AuxLocal.Prox;
            Elemento.Ant = AuxLocal;

            if (AuxLocal.Prox != null)
            {
                AuxLocal.Prox.Ant = Elemento;
            }
            
            AuxLocal.Prox = Elemento;
            Tamanho++;
        }

        public void MostraListaINIFIM()
        {
            if (Início == null)
            {
                Console.WriteLine("Fim de jogo \n\n");
            }
            else
            {
                Aux = Início;

                while (Aux != null)
                {
                    Console.Write(Aux.Num + "  ");
                    Aux = Aux.Prox;
                }
            }
        }
        
        private Elemento RemoveElemento(Elemento item)
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
        
        public Boolean RemoveElementos(Elemento item, int qt)
        {
            Elemento Aux = item;
            Boolean flag = true;

            try
            {
                while (qt != 0)
                {
                    Aux = RemoveElemento(Aux);
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

        public Elemento GetElemento(int pos)
        {
            Console.Clear();

            int index = 0;

            if (Início == null)
            {
                Console.WriteLine("Fim de Jogo \n\n");
            }
            else
            {
                Aux = Início;

                while (Aux != null)
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

        public void VerifySequence(int pos, int color)
        {
            int index = 0;
            int pontos = 0;
            if (Início == null)
            {
                Console.WriteLine("A lista não possui nenhum elemento!!! \n\n");
            }
            else
            {
                Elemento AuxLocal = Início;
                Elemento AuxSave = Início;
                while (AuxLocal != null)
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
                                    // percorrer para tras buscando o primeiro elemento da cor escolhida
                                    while (AuxLocal != null)
                                    {
                                        if (AuxLocal.Num != color)
                                        {
                                            // salva a posição do ultimo elemento com a cor escolhida
                                            AuxSave = AuxLocal.Prox;
                                            break;
                                        }
                                        AuxLocal = AuxLocal.Ant;
                                    }

                                    AuxLocal = AuxSave;
                                }
                            }
                            
                            // percorre a lista apartir do primeiro elemento com a cor escolhida pelo jogador
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
                                RemoveElementos(AuxLocal, pontos);    
                            }
                            else
                            {
                                InserirNoMeio(pos,color);
                            }
                            break;
                        }
                        else
                        {
                            InserirNoMeio(pos,color);
                            break;
                        }
                    }
                    AuxLocal = AuxLocal.Prox;                             
                }                                               
            }
        }

        public int[] pickTwoRandomColors()
        {
            int[] res = new int[2];
            Random random = new Random();
            if (Início == null)
            {
                Console.WriteLine("Fim de jogo \n\n");
                return null;
            }
            else
            {
                int randomPos;
                if (Tamanho < 3)
                {
                    switch (Tamanho)
                    {
                        case 2:
                            res[0] = GetElemento(1).Num;
                            res[1] = GetElemento(2).Num;
                            break;
                        case 1:
                            res[0] = res[1] = GetElemento(1).Num;
                            break;
                    }

                    return res;
                }
                else
                {
                    return null;
                }
            }
        }
        
    }
}