using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanchonete.BusinessEntity
{
    /// <summary>
    /// Classe que representa a entidade de ingrediente.
    /// </summary>
    public class IngredienteBE
    {
        /// <summary>
        /// Descrição do ingrediente.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor do ingrediente.
        /// </summary>
        public decimal Valor { get; set; }
    }
}