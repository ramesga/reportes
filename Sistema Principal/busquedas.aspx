<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="busquedas.aspx.cs" Inherits="Sistema_Principal.busquedas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 97px;
        }
        .auto-style3 {
            width: 90px;
        }
        .auto-style4 {
            width: 643px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        </br>
        <table>
            <tr>
                <td>
                    
                    <asp:Label ID="Lblubicacion" runat="server" Text="Ubicacion:"></asp:Label>
                      
                </td>

                <td>
                    <asp:DropDownList ID="Cmbubicacion" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="Cmbubicacion_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Lblarea" runat="server" Text="Area"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="Cmbarea" runat="server" Width="150px" ></asp:DropDownList>
                </td>
                <td class="auto-style3">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Lblfechainicio" runat="server" Text="Fecha inicio:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txtfechainicio" runat="server" Width="70px" Enabled="False" Font-Italic="True"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" Width="31px" OnClick="ImageButton1_Click" />
                </td>
                <td>

                    &nbsp;

                </td>
                <td>
                    <asp:Calendar ID="Cldinicio" runat="server" BackColor="White" BorderColor="White" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="41px" NextPrevFormat="FullMonth" Width="86px" BorderWidth="1px" Visible="False" OnSelectionChanged="Cldinicio_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="4px" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Lblfechafinal" runat="server" Text="Fecha final:"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="Txtfechafinal" runat="server" Width="70px" Enabled="False" Font-Italic="True"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" Height="22px" ImageUrl="~/imagenessistema/calendario.jpg" Width="31px" OnClick="ImageButton2_Click" />
                </td>
                <td>

                    &nbsp;

                </td>
                <td>
                    <asp:Calendar ID="Cldfinal" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="87px" NextPrevFormat="FullMonth" Width="153px" OnSelectionChanged="Cldfinal_SelectionChanged" Visible="False">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="Chcabiertos" runat="server" AutoPostBack="true" Text="Reportes abiertos o en proceso" OnCheckedChanged="Chcabiertos_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="Chccerrados" runat="server" Text="Reportes cerrados" AutoPostBack="True" OnCheckedChanged="Chccerrados_CheckedChanged" />
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td class="auto-style4" align="center">
                    <asp:Label ID="Lbltitulo" runat="server" Font-Size="Medium" ForeColor="#000099" Width="1218px"  ></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="1212px" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="folio" HeaderText="Folio" />
                        <asp:BoundField DataField="fechainicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha registro" />
                        <asp:BoundField DataField="reporta" HeaderText="Reporto" />
                        <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" />
                        <asp:BoundField DataField="area" HeaderText="Area" />
                        <asp:BoundField DataField="dispositivofalla" HeaderText="Dispositivo que falla" />
                        <asp:BoundField DataField="solicitud" HeaderText="Solicitud" />
                        <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
                        <asp:BoundField DataField="solucion" HeaderText="Solucion" />
                        <asp:BoundField DataField="atendioreporte" HeaderText="Capturo reporte" />
                        <asp:BoundField DataField="cerroreporte" HeaderText="Usuario que cerro" />
                        <asp:BoundField DataField="ingenierocerro" HeaderText="Ing. que atendio" />
                        <asp:BoundField DataField="fechaasignado" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha asignacion" />
                        <asp:BoundField DataField="cordinadorzona" HeaderText="Coordinador zona" />
                        <asp:BoundField DataField="fechafinal" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha cierre" />
                        <asp:BoundField DataField="statusreporte" HeaderText="Status de reporte" />
                        <asp:BoundField DataField="diastrancurridos" HeaderText="Dias sin resolver" />
                        <asp:BoundField DataField="tiemporespuesta" HeaderText="Tiempo de respuesta" />
                        <asp:CommandField SelectText="Modificar Reporte" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lblcontador" runat="server" Text="" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Txtcontador" runat="server" Width="30px" Enabled="False" CssClass="centrartext" Font-Bold="True" Font-Italic="True" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Txtbandera" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            
        </table>
    </div>
    
</asp:Content>
