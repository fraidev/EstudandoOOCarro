using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoOOCarro
{
    public interface IAutomovel
    {
        Direcao Direcao { get; }
        void VirarParaDireita();
        void VirarParaEsquerda();
    }

    public class Carro : IAutomovel
    {
        public Carro()
        {
            LeftOrRight = 0;
        }

        public Direcao Direcao
        {
            get
            {
                if (LeftOrRight > 0)
                {
                    return Direcao.Direita;
                }

                if (LeftOrRight < 0)
                {
                    return Direcao.Esquerda;
                }

                return Direcao.Frente;
            }
        }

        private int LeftOrRight { get; set; }

        public void VirarParaDireita()
        {
            LeftOrRight++;
        }

        public void VirarParaEsquerda()
        {
            LeftOrRight--;
        }

    }

    public class BarraDirecao
    {
        private readonly int _maxUso;

        public BarraDirecao(int maxUso)
        {
            _maxUso = maxUso;
        }
        
        public Estado Estado
        {
            get
            {
                if (CountUso < _maxUso)
                {
                    return Estado.Funcionando;
                }
                else
                {
                    return Estado.Quebrado;
                }
            }
        }

        
        private int CountUso;

        public void Usar()
        {
            CountUso++;
        }
    


    }

    public enum Estado
    {
        Funcionando,
        Quebrado
    }

    public enum Direcao
    {
        Frente,
        Esquerda,
        Direita
    }
}
