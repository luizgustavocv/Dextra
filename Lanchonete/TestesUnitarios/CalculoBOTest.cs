using System;
using System.Collections.Generic;
using Lanchonete.BusinessEntity;
using Lanchonete.BusinessEntity.Constantes;
using Lanchonete.BusinessObject;
using NUnit.Framework;

namespace TestesUnitarios
{
    public class CalculoBOTest
    {
        private readonly CalculoBO _calculoBO = new CalculoBO();
        private List<IngredienteBE> _listaIngredientes = new List<IngredienteBE>
        {
            new IngredienteBE
            {
                Descricao = Ingredientes.Alface,
                Valor = 0.40M
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Bacon,
                Valor = 2.00M
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Hamburguer,
                Valor = 3.00M
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Ovo,
                Valor = 0.80M
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Queijo,
                Valor = 1.50M
            }
        };

        /// <summary>
        /// Valor dos lanches de cardápio: X-Bacon.
        /// </summary>
        [Test]
        public void ValorXBacon()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var xBacon = new List<string>
            {
                Ingredientes.Bacon,
                Ingredientes.Hamburguer,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(xBacon);

            Assert.AreEqual(6.50M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor dos lanches de cardápio: X-Burger.
        /// </summary>
        [Test]
        public void ValorXBurger()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var xBacon = new List<string>
            {
                Ingredientes.Hamburguer,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(xBacon);

            Assert.AreEqual(4.50M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor dos lanches de cardápio: X-Egg.
        /// </summary>
        [Test]
        public void ValorXEgg()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var xBacon = new List<string>
            {
                Ingredientes.Ovo,
                Ingredientes.Hamburguer,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(xBacon);

            Assert.AreEqual(5.30M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor dos lanches de cardápio: X-Egg Bacon.
        /// </summary>
        [Test]
        public void ValorXEggBacon()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var xBacon = new List<string>
            {
                Ingredientes.Ovo,
                Ingredientes.Bacon,
                Ingredientes.Hamburguer,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(xBacon);

            Assert.AreEqual(7.30M, calculoBE.Valor);
        }

        /// <summary>
        /// Soma todos ingredientes.
        /// </summary>
        [Test]
        public void SomaTodosIngredientes()
        {
            var valor = _calculoBO.CalcularValor(_listaIngredientes, Promocao.SemPromocao);

            Assert.AreEqual(7.70M, valor);
        }

        /// <summary>
        /// Valor lanche promoção: Light.
        /// </summary>
        [Test]
        public void ValorLancheLight()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var light = new List<string>
            {
                Ingredientes.Alface,
                Ingredientes.Ovo,
                Ingredientes.Hamburguer,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(light);

            Assert.AreEqual(5.13M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor lanche promoção: Muita carne.
        /// </summary>
        [Test]
        public void ValorLancheMuitaCarne()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var muitaCarne = new List<string>
            {
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer
            };

            var calculoBE = _calculoBO.CalcularLanche(muitaCarne);

            Assert.AreEqual(6.00M, calculoBE.Valor);

            muitaCarne.Add(Ingredientes.Hamburguer);
            muitaCarne.Add(Ingredientes.Hamburguer);
            muitaCarne.Add(Ingredientes.Hamburguer);

            calculoBE = _calculoBO.CalcularLanche(muitaCarne);

            Assert.AreEqual(12.00M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor lanche promoção: Muito queijo.
        /// </summary>
        [Test]
        public void ValorLancheMuitoQueijo()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var muitoQueijo = new List<string>
            {
                Ingredientes.Queijo,
                Ingredientes.Queijo,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(muitoQueijo);

            Assert.AreEqual(3.00M, calculoBE.Valor);

            muitoQueijo.Add(Ingredientes.Queijo);
            muitoQueijo.Add(Ingredientes.Queijo);
            muitoQueijo.Add(Ingredientes.Queijo);

            calculoBE = _calculoBO.CalcularLanche(muitoQueijo);

            Assert.AreEqual(6.00M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor lanche promoção: Light + Muita carne.
        /// </summary>
        [Test]
        public void ValorLancheLightMuitaCarne()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var lightMuitaCarne = new List<string>
            {
                Ingredientes.Alface,
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer
            };

            var calculoBE = _calculoBO.CalcularLanche(lightMuitaCarne);

            Assert.AreEqual(5.76M, calculoBE.Valor);

            lightMuitaCarne.Add(Ingredientes.Hamburguer);
            lightMuitaCarne.Add(Ingredientes.Hamburguer);
            lightMuitaCarne.Add(Ingredientes.Hamburguer);

            calculoBE = _calculoBO.CalcularLanche(lightMuitaCarne);

            Assert.AreEqual(11.16M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor lanche promoção: Light + Muito queijo.
        /// </summary>
        [Test]
        public void ValorLancheLightMuitoQueijo()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var lightMuitoQueijo = new List<string>
            {
                Ingredientes.Alface,
                Ingredientes.Queijo,
                Ingredientes.Queijo,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(lightMuitoQueijo);

            Assert.AreEqual(3.06M, calculoBE.Valor);

            lightMuitoQueijo.Add(Ingredientes.Queijo);
            lightMuitoQueijo.Add(Ingredientes.Queijo);
            lightMuitoQueijo.Add(Ingredientes.Queijo);

            calculoBE = _calculoBO.CalcularLanche(lightMuitoQueijo);

            Assert.AreEqual(5.76M, calculoBE.Valor);
        }

        /// <summary>
        /// Valor lanche promoção: Muita carne + Muito queijo.
        /// </summary>
        [Test]
        public void ValorLancheMuitaCarneMuitoQueijo()
        {
            _calculoBO._listaIngredientes = _listaIngredientes;

            var muitaCarneMuitoQueijo = new List<string>
            {
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer,
                Ingredientes.Hamburguer,
                Ingredientes.Queijo,
                Ingredientes.Queijo,
                Ingredientes.Queijo
            };

            var calculoBE = _calculoBO.CalcularLanche(muitaCarneMuitoQueijo);

            Assert.AreEqual(9.00M, calculoBE.Valor);

            muitaCarneMuitoQueijo.Add(Ingredientes.Hamburguer);
            muitaCarneMuitoQueijo.Add(Ingredientes.Hamburguer);
            muitaCarneMuitoQueijo.Add(Ingredientes.Hamburguer);
            muitaCarneMuitoQueijo.Add(Ingredientes.Queijo);
            muitaCarneMuitoQueijo.Add(Ingredientes.Queijo);
            muitaCarneMuitoQueijo.Add(Ingredientes.Queijo);

            calculoBE = _calculoBO.CalcularLanche(muitaCarneMuitoQueijo);

            Assert.AreEqual(18.00M, calculoBE.Valor);
        }

        /// <summary>
        /// Verifica descrição promoção: Light.
        /// </summary>
        [Test]
        public void PromocaoLight()
        {
            var light = new List<IngredienteBE>
            {
                new IngredienteBE
                {
                    Descricao = Ingredientes.Alface
                }
            };

            var promocao = _calculoBO.VerificarPromocao(light);

            Assert.AreEqual(Promocao.Light, promocao);
        }

        /// <summary>
        /// Verifica descrição promoção: Muita carne.
        /// </summary>
        [Test]
        public void PromocaoMuitaCarne()
        {
            var muitaCarne = new List<IngredienteBE>
            {
                new IngredienteBE
                {
                    Descricao = Ingredientes.Hamburguer
                },
                new IngredienteBE
                {
                    Descricao = Ingredientes.Hamburguer
                },
                new IngredienteBE
                {
                    Descricao = Ingredientes.Hamburguer
                }
            };

            var promocao = _calculoBO.VerificarPromocao(muitaCarne);

            Assert.AreEqual(Promocao.MuitaCarne, promocao);
        }

        /// <summary>
        /// Verifica descrição promoção: Muito queijo.
        /// </summary>
        [Test]
        public void PromocaoMuitoQueijo()
        {
            var muitaCarne = new List<IngredienteBE>
            {
                new IngredienteBE
                {
                    Descricao = Ingredientes.Queijo
                },
                new IngredienteBE
                {
                    Descricao = Ingredientes.Queijo
                },
                new IngredienteBE
                {
                    Descricao = Ingredientes.Queijo
                }
            };

            var promocao = _calculoBO.VerificarPromocao(muitaCarne);

            Assert.AreEqual(Promocao.MuitoQueijo, promocao);
        }

        /// <summary>
        /// Verifica descrição promoção: Sem promoção.
        /// </summary>
        [Test]
        public void SemPromocao()
        {
            var promocao = _calculoBO.VerificarPromocao(_listaIngredientes);

            Assert.AreEqual(Promocao.SemPromocao, promocao);
        }
    }
}
