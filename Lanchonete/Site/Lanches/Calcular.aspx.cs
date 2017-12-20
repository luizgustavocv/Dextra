using Lanchonete.BusinessEntity;
using Constantes = Lanchonete.BusinessEntity.Constantes;
using Lanchonete.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site.Lanches
{
    public partial class Calcular : System.Web.UI.Page
    {
        private readonly CalculoBO _calculoBO = new CalculoBO();
        private bool _executarCalculo = true;

        protected void SelecionarIngrediente(object sender, EventArgs e)
        {
            try
            {
                var botao = (Button)sender;

                lstIngredientes.Items.Add(new ListItem
                {
                    Value = botao.Text,
                    Text = botao.Text
                });

                if (_executarCalculo)
                {
                    CalcularTotal();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void SelecionarLanche(object sender, EventArgs e)
        {
            try
            {
                var botao = (Button)sender;
                _executarCalculo = false;

                switch (botao.Text)
                {
                    case Constantes.Lanches.XBacon:
                        SelecionarIngrediente(btnBacon, e);
                        SelecionarIngrediente(btnHamburguer, e);
                        SelecionarIngrediente(btnQueijo, e);
                        break;
                    case Constantes.Lanches.XBurger:
                        SelecionarIngrediente(btnHamburguer, e);
                        SelecionarIngrediente(btnQueijo, e);
                        break;
                    case Constantes.Lanches.XEgg:
                        SelecionarIngrediente(btnOvo, e);
                        SelecionarIngrediente(btnHamburguer, e);
                        SelecionarIngrediente(btnQueijo, e);
                        break;
                    case Constantes.Lanches.XEggBacon:
                        SelecionarIngrediente(btnOvo, e);
                        SelecionarIngrediente(btnBacon, e);
                        SelecionarIngrediente(btnHamburguer, e);
                        SelecionarIngrediente(btnQueijo, e);
                        break;
                }

                CalcularTotal();

                _executarCalculo = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void LimparCampos(object sender, EventArgs e)
        {
            try
            {
                lstIngredientes.Items.Clear();
                lblTotal.Text = "R$0,00";
                lblPromocao.Text = Constantes.Promocao.SemPromocao;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CalcularTotal()
        {
            try
            {
                var ingredientes = new List<string>();

                foreach (var item in lstIngredientes.Items)
                {
                    ingredientes.Add(item.ToString());
                }

                var calculoBE = _calculoBO.CalcularLanche(ingredientes);

                lblTotal.Text = calculoBE.Valor.ToString("C");
                lblPromocao.Text = calculoBE.Promocao;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}