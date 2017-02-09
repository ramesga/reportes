<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="FrmAgregar.aspx.cs" Inherits="Sistema_Principal.FrmAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 1153px;
        }
        .auto-style9 {
            height: 589px;
        width: 1173px;
    }
        .auto-style10 {
            width: 133px;
        }
        .auto-style11 {
            width: 122px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="abrigo_formulario" class="auto-style9">
        <br />
        <h1 align="center">Nuevo Reporte</h1>
    <br />
        <table>
            <tr>
                <td>
                    Tipo de reporte:
                </td>
                <td>
                    <asp:Button ID="BtnAbierto" runat="server" Text="Abierto" OnClick="BtnAbierto_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnCerrado" runat="server" Text="Cerrado" OnClick="BtnCerrado_Click" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Fecha que se genero el reporte:
                </td>
                <td>
                    <asp:TextBox ID="Txtinicial" runat="server" Enabled="False" Font-Italic="true" TabIndex="30" Width="70px" OnTextChanged="Txtinicial_TextChanged"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" OnClick="ImageButton1_Click" Width="31px" Enabled="False" />
                </td>
                <td>
                    &nbsp;

                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Height="83px" Width="20px" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" NextPrevFormat="ShortMonth">
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
                <td class="auto-style11">Usuario que reporto:&nbsp; </td>
                <td class="primeramayus">
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="160px" Enabled="False" CssClass="primeramayus"></asp:TextBox>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ubicacion:</td>
                <td>
                    <asp:DropDownList ID="Cmbubicacion" runat="server" Width="150px" Enabled="False" OnSelectedIndexChanged="Cmbubicacion_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                </td>
                <td> &nbsp;&nbsp;&nbsp; Area : </td>
                <td>
                    <asp:DropDownList ID="Cmbcentrotrabajo" runat="server" AutoPostBack="true" Width="150px" Enabled="false" OnSelectedIndexChanged="Cmbcentrotrabajo_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="auto-style10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero de maquina: </td>
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
                <td>&nbsp;&nbsp;&nbsp; Tipo de falla:</td>
                <td>
                    <asp:RadioButton ID="RdbHd" runat="server" AutoPostBack="true" OnCheckedChanged="RdbHd_CheckedChanged" Text="Hardware" Enabled="False" />
                </td>
                <td>
                    <asp:RadioButton ID="RdbSf" runat="server" AutoPostBack="true" Text="Software" OnCheckedChanged="RdbSf_CheckedChanged" Enabled="False" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Dispositivo:</td>
                <td>
                    <asp:DropDownList ID="Cmbdispositivos" runat="server" Width="140px" Enabled="False" OnSelectedIndexChanged="Cmbdispositivos_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>Solicitud:</td>
                <td>
                    <asp:TextBox ID="TxtSolicitud" runat="server" Width="644px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <br />
        <br />
        <table>
            <tr>
                <td>Observaciones:</td>
                <td>
                    <asp:TextBox ID="TxtObservaciones" runat="server" Width="450px" Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Solución:</td>
                <td>
                    <asp:TextBox ID="Txtsolucion" runat="server" Width="449px" Enabled="False" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>   
             <td>Usuario que atendio:</td>
                <td>
                    <asp:TextBox ID="TxtUsuariocerro" runat="server" Width="160px" Enabled="False" CssClass="primeramayus"></asp:TextBox>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ing. que captura reporte:</td>
                <td>
                    <asp:TextBox ID="Txtingatendio" runat="server" Width="170" Enabled="False" Font-Bold="True" Font-Italic="True"></asp:TextBox>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Ingeniero que cerro el reporte:</td>
                <td>
                    <asp:DropDownList ID="cmbatiende" runat="server" OnSelectedIndexChanged="cmbatiende_SelectedIndexChanged" Width="170px" Enabled="False">
        </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr>
                <td>Fecha de cierre del reporte:</td>
                <td>
                    <asp:TextBox ID="TxtFinal" runat="server" Enabled="False" Font-Bold="False" Font-Italic="True" Width="70px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" Width="31px" OnClick="ImageButton2_Click" Enabled="False" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="16px" NextPrevFormat="ShortMonth" Width="44px">
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
                <td align="center" class="auto-style8">
                    <asp:Label ID="LblError" runat="server" Visible="False" ForeColor="Red" Font-Italic="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Btnguardar" runat="server" Text="Guardar" Width="170px" OnClick="Btnguardar_Click" Enabled="False" />
                </td>
                
            </tr>
        </table>
    </div>
</asp:Content>
