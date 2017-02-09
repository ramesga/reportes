<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="Frmagregarusuarios.aspx.cs" Inherits="Sistema_Principal.Frmagregarusuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    

    <style type="text/css">
        .auto-style2 
        {
            height: 348px;
        }
        .auto-style3 
        {
            height: 430px;
        }
        </style>

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div align="center" class="auto-style3">
        <div id="contenido_agregarusuario" class="auto-style2">
            
            <asp:Panel ID="Pnlagregar" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" Height="319px" Width="318px">
            
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblnombre" runat="server" Text="Nombre :" Font-Bold="True" Font-Italic="True" ForeColor="#0000CC"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Txtnombre" runat="server" Font-Italic="True" ForeColor="#0000CC" CssClass="primeramayus" Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblapellido" runat="server" Text="Apellido :" Font-Bold="True" Font-Italic="True" ForeColor="#0000CC"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Txtapellido" runat="server" CssClass="primeramayus" Font-Italic="True" ForeColor="#0000CC" Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblusuario" runat="server" Text="Usuario :" Font-Bold="True" Font-Italic="True" ForeColor="#0000CC"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Txtusuario" runat="server" Font-Italic="True" ForeColor="#0000CC" Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblpass" runat="server" Text="Password :" Font-Bold="True" Font-Italic="True" ForeColor="#0000CC"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Txtpass" runat="server" Font-Italic="True" ForeColor="#0000CC" TextMode="Password" Width="130px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblperfil" runat="server" Text="Perfil :" Font-Bold="True" Font-Italic="True" ForeColor="#0000CC"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            &nbsp;<asp:DropDownList ID="cmbusuario" runat="server" Width="136px">
                                <asp:ListItem>ADMINISTRADOR</asp:ListItem>
                                <asp:ListItem>SOPORTE</asp:ListItem>
                                <asp:ListItem>CORDINADOR</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Lblerror" runat="server" Visible="False" ForeColor="Red" Font-Italic="True"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        
                        <td>
                            <asp:Button ID="Btnguardar" runat="server" Text="Guardar" ToolTip="Agrega nuevo usuario" Width="170px" OnClick="Btnguardar_Click" />
                        </td>
                    </tr>
                </table>
            
            </asp:Panel>
            
        </div>
    </div>    
    
</asp:Content>
