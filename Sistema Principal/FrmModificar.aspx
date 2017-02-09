<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="FrmModificar.aspx.cs" Inherits="Sistema_Principal.FrmModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1154px;
        }
        .auto-style2 {
            width: 1084px;
            background-color: gainsboro;
        }
        .auto-style3 {
            background-color: black;
            width: 1084px;
        }
        .auto-style4 {
            width: 1121px;
        }
        .auto-style5 {
            width: 118px;
        }
        .auto-style6 {
            width: 30px;
        }
        .auto-style7 {
            width: 75px;
        }
        .auto-style8 {
            width: 250px;
        }
        .auto-style9 {
            width: 115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="abrigo_formulario">
        <br />
        <td>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btnasignar" runat="server" Text="Asignar" OnClick="Btnasignar_Click" />
        </td>
        <td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Btncerrar" runat="server" Text="Cerrar" Width="64px" OnClick="Btncerrar_Click" />
        </td>
        <td align="center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Lbltitulo" runat="server" Text="Modificar    Reporte" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" Width="303px" Height="33px"></asp:Label>
        </td>
        <br />
        <br />
        <br />
        <table>
            <tr>
                
                <td>
                    Fecha que se genero el reporte:
                </td>
                <td>
                    <asp:TextBox ID="Txtinicial" runat="server" Width="70px" Enabled="False" Font-Italic="True"></asp:TextBox>
                    <asp:ImageButton ID="Imginicial" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" Width="31px" OnClick="Imginicial_Click" Enabled="False" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" Height="28px" Visible="False" Width="16px" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td class="auto-style5">Usuario que reporto:</td>
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="160px" Enabled="False" CssClass="primeramayus"></asp:TextBox>
                </td>
                <td class="auto-style7"> &nbsp; Ubicación:</td>
                <td>
                    <asp:DropDownList ID="Cmbubicacion" runat="server" AutoPostBack="true" Width="150px" Enabled="False" OnSelectedIndexChanged="Cmbubicacion_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="auto-style6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Area:</td>
                <td>
                    <asp:DropDownList ID="Cmbcentrotrabajo" runat="server" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="Cmbcentrotrabajo_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Numero de maquina:</td>
                <td>
                    <asp:DropDownList ID="Cmbnumero" runat="server" Width="50px" Enabled="False">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;&nbsp;&nbsp; Tipo de Falla:</td>
                <td>
                    <asp:RadioButton ID="RdbHd" runat="server" Text="Hardware" AutoPostBack="True" Enabled="False" OnCheckedChanged="RdbHd_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="RdbSf" runat="server" Text="Software" AutoPostBack="True" Enabled="False" OnCheckedChanged="RdbSf_CheckedChanged" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Dispositivo:</td>
                <td>
                    <asp:DropDownList ID="Cmbdispositivo" runat="server" Width="140px" Enabled="False"></asp:DropDownList>
                </td>
                <td>Solicitud:</td>
                <td>
                    <asp:TextBox ID="TxtSolicitud" runat="server" Width="640px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Observaciones:</td>
                <td>
                    <asp:TextBox ID="Txtobservaciones" runat="server" Width="460" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Solución:</td>
                <td>
                    <asp:TextBox ID="Txtsolucion" runat="server" Width="449px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Usuario que cerro reporte</td>
                <td>
                    <asp:TextBox ID="Txtusuariocerro" runat="server" Width="160px" Enabled="False" CssClass="primeramayus"></asp:TextBox>
                </td>
                
                <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ingeniero que capturo reporte:</td>
               
                    <td>
                        <asp:TextBox ID="Txtingatendio" runat="server" Width="170px" Enabled="False" Font-Italic="True"></asp:TextBox>
                    </td>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ingeniero Asignado:</td>
                <td>
                    <asp:DropDownList ID="Cmbingenieros" runat="server" Width="170px" Enabled="False" OnSelectedIndexChanged="Cmbingenieros_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Fecha de cierre:</td>
                <td>
                    <asp:TextBox ID="Txtfinal" runat="server" Width="70px" Enabled="False" Font-Italic="True"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="Imgfinal" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" Width="31px" OnClick="Imgfinal_Click" Enabled="False" />
                </td>
                <td>
                    &nbsp
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server" Visible="False" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="154px" NextPrevFormat="ShortMonth" Width="79px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td>
                    <asp:TextBox ID="Txtfechaasignado" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="auto-style4">
            <tr>
                <td align="center" class="auto-style2">
                    <asp:Label ID="Lblerror" runat="server" Visible="False" ForeColor="Red" Font-Size="Large" Width="1160px" BackColor="#6699FF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style3" >
                    <asp:Button ID="Btnmodificar" runat="server" Text="Modificar"  Width="170" OnClick="Btnmodificar_Click" Enabled="False"/>
                </td>
                
            </tr>
        </table>
    </div>

</asp:Content>
