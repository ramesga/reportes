<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="Frmgrafica.aspx.cs" Inherits="Sistema_Principal.Frmgrafica" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 1178px;
            height: 297px;
        }
        .auto-style3 {
            width: 1228px;
            height: 318px;
        }
        .auto-style4 {
            width: 3px;
        }
        .auto-style5 {
            margin-bottom: 12px;
        }
        .auto-style6 {
            width: 1192px;
            height: 21px;
        }
        .auto-style7 {
            height: 21px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Lblmes" runat="server" Text="Seleccione el mes :" BackColor="White" BorderColor="SteelBlue" BorderWidth="1px" Font-Italic="True" Font-Size="Small" ForeColor="#000099" Width="124px" Height="19px" BorderStyle="None"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cmbmes" runat="server" Width="100px">
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Lblaño" runat="server" Text="Seleccione el año: " BackColor="White" BorderStyle="None" BorderWidth="1px" Font-Italic="True" Font-Size="Small" ForeColor="#000099" Width="117px"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cmbano" runat="server">
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Btngenerar" runat="server" Text="Generar datos" OnClick="Btngenerar_Click" />
                </td>
               
                <td>
                    <asp:TextBox ID="Txtfecha" runat="server" TextMode="Date" Visible="False"></asp:TextBox>
                </td>
                
                <td>
                    <asp:TextBox ID="Txfinal" runat="server" TextMode="Date" Visible="False"></asp:TextBox>
                </td>
                
            </tr>
        </table>
        <table>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Lblatrasados" runat="server" Text="Reportes pendientes del mes anterior:" Width="252px" Visible="False" Font-Size="Medium"></asp:Label>
                </td>
                <td class="auto-style7" align="left">
                    <asp:Label ID="Lblatrasadoss" runat="server" Width="50px" Visible="False" align="left" Font-Size="Medium"></asp:Label>
                </td>
                <td align="center" class="auto-style6">
                    <asp:Label ID="Lblsindados" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div align="center">
        <div id="contenido_hojaactividades" class="auto-style3">

            <table>
        <tr>
            <td class="auto-style2">
                <asp:Panel ID="Panel1" runat="server" BackColor="White" Height="305px" Width="1143px" CssClass="auto-style5" Visible="False">
                    
                    <table>

                        <tr>
                            
                            <td>
                                <asp:Table ID="Tblreportes" runat="server" Width="1134px" Height="33px">
                                    <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CCCCFF" ID="filadias">
                                    </asp:TableRow>
                                    <asp:TableRow runat="server" BackColor="#99CCFF" BorderColor="#99CCFF" HorizontalAlign="Center" VerticalAlign="Middle" ID="filareporteshoy">
                                                                            </asp:TableRow>
                                    <asp:TableRow runat="server">
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                    </asp:TableRow>
                                    <asp:TableRow runat="server">
                                    </asp:TableRow>
                                </asp:Table>

                            </td>
                    
                        </tr>
  
                    </table>
                                      
                </asp:Panel>
                
            </td>
        </tr>
    </table>

        </div>
    <table>
        <tr>
            <td>
                <asp:DropDownList runat="server" id="ddlChartTypes" align="Left" AutoPostBack="True" OnSelectedIndexChanged="ddlChartTypes_SelectedIndexChanged" TabIndex="2" Enabled="False" Visible="False">
                     
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
                <asp:Label ID="Lblerror" runat="server" Font-Italic="True" Font-Size="X-Large" ForeColor="Maroon" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
        
    <table>
        <tr>
            <td class="auto-style4">
                <asp:Chart ID="Chart1" runat="server" Width="1000px" TabIndex="10" Visible="False">
                    <Series>
                        <asp:Series Name="Abiertos" Legend="Legend1">
                        </asp:Series>
                        <asp:Series ChartArea="ChartArea1" Legend="Legend1" Name="Cerrados">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" Title="Reportes">
                        </asp:Legend>
                    </Legends>
                    <Titles>
                        <asp:Title Docking="Bottom" Font="Microsoft Sans Serif, 12pt, style=Bold, Italic" ForeColor="MediumBlue" Name="Title1" Text="DIAS DEL MES">
                        </asp:Title>
                        <asp:Title Alignment="MiddleLeft" Docking="Left" Font="Microsoft Sans Serif, 11pt, style=Bold, Italic" ForeColor="MediumBlue" Name="Title2" Text="CANTIDAD DE REPORTES">
                        </asp:Title>
                        <asp:Title Font="Microsoft Sans Serif, 15pt" Name="Title3" Text="Reportes Totales (Abiertos y cerrados por dia)">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </td>
        </tr>
    </table>

    </div>
    
</asp:Content>
