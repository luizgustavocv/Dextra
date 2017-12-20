<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calcular.aspx.cs" Inherits="Site.Lanches.Calcular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Lanchonete</title>
    <link href="../Lanches/css/calcular.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <table>
                <tr>
                    <td>
                        <p>Ingredientes:</p>
                        <p>
                            <asp:Button ID="btnAlface" Text="Alface" runat="server" OnClick="SelecionarIngrediente" />
                        </p>
                        <p>
                            <asp:Button ID="btnBacon" Text="Bacon" runat="server" OnClick="SelecionarIngrediente" />
                        </p>
                        <p>
                            <asp:Button ID="btnHamburguer" Text="Hambúrguer de carne" runat="server" OnClick="SelecionarIngrediente" />
                        </p>
                        <p>
                            <asp:Button ID="btnOvo" Text="Ovo" runat="server" OnClick="SelecionarIngrediente" />
                        </p>
                        <p>
                            <asp:Button ID="btnQueijo" Text="Queijo" runat="server" OnClick="SelecionarIngrediente" />
                        </p>
                        <p>Lanches:</p>
                        <p>
                            <asp:Button ID="btnXBacon" Text="X-Bacon" ToolTip="Bacon, hambúrguer de carne e queijo" runat="server" OnClick="SelecionarLanche" />
                        </p>
                        <p>
                            <asp:Button ID="btnXBurger" Text="X-Burger" ToolTip="Hambúrguer de carne e queijo" runat="server" OnClick="SelecionarLanche" />
                        </p>
                        <p>
                            <asp:Button ID="btnXEgg" Text="X-Egg" ToolTip="Ovo, hambúrguer de carne e queijo" runat="server" OnClick="SelecionarLanche" />
                        </p>
                        <p>
                            <asp:Button ID="btnXEggBacon" Text="X-Egg Bacon" ToolTip="Ovo, bacon, hambúrguer de carne e queijo" runat="server" OnClick="SelecionarLanche" />
                        </p>
                    </td>
                    <td>
                        <p>Ingredientes selecionados:</p>
                        <p>
                            <asp:ListBox ID="lstIngredientes" runat="server" />
                        </p>
                        <p>
                            <asp:Label ID="lblTotal" Text="R$0,00" runat="server" />
                        </p>
                        <p>
                            <asp:Label Text="Promoção:" runat="server" />
                        </p>
                        <p>
                            <asp:Label ID="lblPromocao" Text="Sem promoção" runat="server" />
                        </p>
                        <p>
                            <asp:Button ID="btnLimpar" Text="Limpar" runat="server" OnClick="LimparCampos" />
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
