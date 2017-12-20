using Lanchonete.BusinessEntity;
using Lanchonete.BusinessEntity.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace Lanchonete.BusinessObject
{
    /// <summary>
    /// Classe que representa as regras de negócio para o cálculo de lanches.
    /// </summary>
    public class CalculoBO
    {
        /// <summary>
        /// Lista de ingredientes cadastrados (simulando banco de dados).
        /// </summary>
        public List<IngredienteBE> _listaIngredientes = new List<IngredienteBE>
        {
            new IngredienteBE
            {
                Descricao = Ingredientes.Alface,
                Valor = Ingredientes.VlrAlface
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Bacon,
                Valor = Ingredientes.VlrBacon
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Hamburguer,
                Valor = Ingredientes.VlrHamburguer
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Ovo,
                Valor = Ingredientes.VlrOvo
            },
            new IngredienteBE
            {
                Descricao = Ingredientes.Queijo,
                Valor = Ingredientes.VlrQueijo
            }
        };

        /// <summary>
        /// Calcula o valor total do lanche de acordo com os ingredientes selecionados e a promoção pertencente se houver.
        /// </summary>
        /// <param name="ingredientes">Lista de ingredientes selecionados.</param>
        /// <returns>Valor total do lanche e promoção se houver.</returns>
        public CalculoBE CalcularLanche(List<string> ingredientes)
        {
            try
            {
                var calculoBE = new CalculoBE();
                var ingredientesSelecionados = new List<IngredienteBE>();

                foreach (var ingrediente in ingredientes)
                {
                    ingredientesSelecionados.Add(_listaIngredientes.FirstOrDefault(i => i.Descricao == ingrediente));
                }

                calculoBE.Promocao = VerificarPromocao(ingredientesSelecionados);

                calculoBE.Valor = CalcularValor(ingredientesSelecionados, calculoBE.Promocao);

                return calculoBE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica as promoções pertencentes de acordo com os ingredientes selecionados.
        /// </summary>
        /// <param name="ingredientes">Lista de ingredientes selecionados.</param>
        /// <returns>Descrição das promoções pertencentes.</returns>
        public string VerificarPromocao(List<IngredienteBE> ingredientes)
        {
            try
            {
                var promocoes = string.Empty;

                if (ingredientes.Any(i => i.Descricao == Ingredientes.Alface) && !ingredientes.Any(i => i.Descricao == Ingredientes.Bacon))
                {
                    promocoes = Promocao.Light;
                }

                if (ingredientes.Count(i => i.Descricao == Ingredientes.Hamburguer) > 2)
                {
                    promocoes = string.IsNullOrEmpty(promocoes) ? Promocao.MuitaCarne : string.Concat(promocoes, " + ", Promocao.MuitaCarne);
                }

                if (ingredientes.Count(i => i.Descricao == Ingredientes.Queijo) > 2)
                {
                    promocoes = string.IsNullOrEmpty(promocoes) ? Promocao.MuitoQueijo : string.Concat(promocoes, " + ", Promocao.MuitoQueijo);
                }

                if (string.IsNullOrEmpty(promocoes))
                {
                    promocoes = Promocao.SemPromocao;
                }

                return promocoes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Calcula o valor total do lanche de acordo com os ingredientes selecionados e as promoções pertencentes.
        /// </summary>
        /// <param name="ingredientes">Lista de ingredientes selecionados.</param>
        /// <param name="promocao">Promoções pertencentes.</param>
        /// <returns>Valor total do lanche.</returns>
        public decimal CalcularValor(List<IngredienteBE> ingredientes, string promocao)
        {
            try
            {
                var valorLanche = 0.0M;
                var quantidadeCarne = 0;
                var quantidadeQueijo = 0;

                if (promocao.Contains(Promocao.SemPromocao))
                {
                    ingredientes.ForEach(i => valorLanche += i.Valor);
                }
                else
                {
                    foreach (var ingrediente in ingredientes)
                    {
                        if (ingrediente.Descricao == Ingredientes.Hamburguer && promocao.Contains(Promocao.MuitaCarne))
                        {
                            quantidadeCarne++;
                        }

                        if (ingrediente.Descricao == Ingredientes.Queijo && promocao.Contains(Promocao.MuitoQueijo))
                        {
                            quantidadeQueijo++;
                        }

                        if (quantidadeCarne == 3)
                        {
                            quantidadeCarne = 0;
                        }
                        else if (quantidadeQueijo == 3)
                        {
                            quantidadeQueijo = 0;
                        }
                        else
                        {
                            valorLanche += ingrediente.Valor;
                        }
                    }

                    if (promocao.Contains(Promocao.Light))
                    {
                        valorLanche = valorLanche * 0.9M;
                    }
                }

                return valorLanche;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}