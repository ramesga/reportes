<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmlogin.aspx.cs" Inherits="Sistema_Principal.frmlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 88px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="abrigo_general" align="center">

        <div id="content_login">

            <table>

                <tr>
                    <td>
                        <asp:Image ID="login" runat="server" ImageUrl="~/imagenessistema/login.jpg" Width="110px" Height="110" />
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Inicio de Sesión" Font-Size="Large" Width="120px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">Nombre de Usuario:</td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:TextBox ID="Txtusuario" runat="server" Width="170px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">Password:</td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:TextBox ID="Txtpass" runat="server" Width="170px" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:Label ID="LblError" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" align="center"><asp:Button ID="BtnAceptar" runat="server" Text="Ingresar" Width="150px" OnClick="BtnAceptar_Click" /></td>
                </tr>
            </table>

        </div>
    
    </div>
    </form>
</body>
</html>
