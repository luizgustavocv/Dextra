using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.BusinessEntity
{
    /// <summary>
    /// Classe que representa a entidade de cálculo.
    /// </summary>
    public class CalculoBE
    {
        /// <summary>
        /// Valor total do lanche.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Promoção que o lanche pertence.
        /// </summary>
        public string Promocao { get; set; }
    }
}