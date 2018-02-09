using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoOOCarro
{
    //Interface

    public class Carro : IAutomovel
    {
        private readonly IBarraDirecao _barraDirecao;

        //Construtor
        public Carro(IBarraDirecao barraDirecao)
        {
            _barraDirecao = barraDirecao;
            LeftOrRight = 0;
        }

        //Declaracao
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

        //Metodo
        public void VirarParaDireita()
        {
            if (_barraDirecao.Estado == Estado.Funcionando)
            {
                _barraDirecao.Usar();
                LeftOrRight++;
            }
        }

        public void VirarParaEsquerda()
        {
            if (_barraDirecao.Estado == Estado.Funcionando)
            {
                _barraDirecao.Usar();
                LeftOrRight--;
            }
        }

    }
}
