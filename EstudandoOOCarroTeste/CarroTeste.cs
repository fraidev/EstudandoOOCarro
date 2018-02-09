using EstudandoOOCarro;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace EstudandoOOCarroTeste
{
    public class CarroTeste
    {
        [TestCase(0, 0, Direcao.Frente, Estado.Funcionando)]
        [TestCase(1, 0, Direcao.Esquerda, Estado.Funcionando)]
        [TestCase(0, 1, Direcao.Direita, Estado.Funcionando)]
        [TestCase(2, 1, Direcao.Esquerda, Estado.Funcionando)]
        [TestCase(1, 2, Direcao.Direita, Estado.Funcionando)]
        [TestCase(2, 2, Direcao.Frente, Estado.Funcionando)]
        [TestCase(0, 0, Direcao.Frente, Estado.Quebrado)]
        [TestCase(1, 0, Direcao.Frente, Estado.Quebrado)]
        [TestCase(0, 1, Direcao.Frente, Estado.Quebrado)]
        public void Teste_da_barra_de_direcao_do_carro(int voltasParaEsquerda, int voltasParaDireita, Direcao esperado, Estado estadoDaBarra)
        {
            //Given
            var mockBarraDirecao = Substitute.For<IBarraDirecao>();
            mockBarraDirecao.Estado.Returns(estadoDaBarra);

            var carro = new Carro(mockBarraDirecao);

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

            var somaDasMovimentacoesNoVolante = estadoDaBarra == Estado.Quebrado ? 0 : (voltasParaEsquerda + voltasParaDireita);
            mockBarraDirecao.Received(somaDasMovimentacoesNoVolante).Usar();
        }
    }
}
