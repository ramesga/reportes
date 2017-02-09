<%@ Page Title="" Language="C#" MasterPageFile="~/Anonimo.Master" AutoEventWireup="true" CodeBehind="FrmPrincipal.aspx.cs" Inherits="Sistema_Principal.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <br />
    <table>
        <tr>
            <td align="center">
                <asp:Label ID="Lblreporte" runat="server" Width="1160px" Font-Italic="True" Font-Size="Medium" Height="24px"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grvreportes" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" Width="1227px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" HeaderStyle-HorizontalAlign ="Left" style="margin-left: 0px" OnSelectedIndexChanged="grvreportes_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="grvreportes_PageIndexChanging" OnRowDataBound="grvreportes_RowDataBound" PageSize="15">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="folio" HeaderText="Folio" />
            <asp:BoundField DataField="fechainicio" HeaderText="Fecha registro" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="reporta" HeaderText="Reporto" />
            <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" />
            <asp:BoundField DataField="area" HeaderText="Area" />
            <asp:BoundField DataField="dispositivofalla" HeaderText="Dispositivo que falla" />
            <asp:BoundField DataField="solicitud" HeaderText="Solicitud" />
            <asp:BoundField DataField="observaciones" HeaderText="Observaciones" />
            

            <asp:BoundField DataField="solucion" HeaderText="Solución" />

            
            <asp:BoundField DataField="atendioreporte" HeaderText="Capturo reporte" />
            <asp:BoundField DataField="cerroreporte" HeaderText="Usuario que cerro" />
            <asp:BoundField DataField="ingenierocerro" HeaderText="Ing. que cerro" />
            <asp:BoundField DataField="fechaasignado" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha asignación" />
            <asp:BoundField DataField="cordinadorzona" HeaderText="Cordinador zona" />
            <asp:BoundField DataField="fechafinal" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha cierre" />
            <asp:BoundField DataField="statusreporte" HeaderText="Status de Reporte" />
            <asp:BoundField DataField="diastrancurridos" HeaderText="Dias sin resolver" FooterStyle-HorizontalAlign="Center" >
<FooterStyle HorizontalAlign="Center"></FooterStyle>
            </asp:BoundField>
            <asp:BoundField DataField="tiemporespuesta" HeaderText="Tiempo de respuesta" />
            <asp:CommandField EditText="Modificar" SelectText="Modificar reporte" ShowSelectButton="True" HeaderText="Modificar Reporte" />
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

    <table>
        <tr>
            <td align="left">
                <asp:Label ID="Lblcontador" runat="server" Width="140px" Font-Italic="True" ForeColor="#000099" Align="center"></asp:Label>
            </td>
            <td class="centrartext">
                <asp:TextBox ID="Txtcontador" runat="server" Width="30px" Enabled="False" Font-Bold="True" Font-Italic="True" Visible="False" CssClass="centrartext"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Txcord" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
