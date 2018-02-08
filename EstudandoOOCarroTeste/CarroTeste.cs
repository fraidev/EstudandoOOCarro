using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudandoOOCarro;
using FluentAssertions;
using NUnit.Framework;

namespace EstudandoOOCarroTeste
{
    public class CarroTeste
    {
        [TestCase(0, 0, Direcao.Frente)]
        [TestCase(1, 0, Direcao.Esquerda)]
        [TestCase(0, 1, Direcao.Direita)]
        [TestCase(2, 1, Direcao.Esquerda)]
        [TestCase(1, 2, Direcao.Direita)]
        [TestCase(2, 2, Direcao.Frente)]
        public void Teste_da_barra_de_direcao_do_carro(int voltasParaEsquerda, int voltasParaDireita, Direcao esperado)
        {
            //Get
            var carro = new Carro();

            // When 
            for (var i = 0; i < voltasParaEsquerda; i++)
            {
                carro.VirarParaEsquerda();
            }

            for (var i = 0; i < voltasParaDireita; i++)
            {
                carro.VirarParaDireita();
            }

            // Then
            carro.Direcao.Should().Be(esperado);
        }
    }
}
