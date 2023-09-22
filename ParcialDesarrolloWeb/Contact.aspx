<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ParcialDesarrolloWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding:15px">

        <table class="w-70" style="height: 287px; width: 1208px">
            <tr>
                <td colspan="2" style="font-size: xx-large; background-color: #333333; color: #FFFFFF; height: 46px;">Ventas&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 29px; width: 604px">&nbsp;</td>
                <td class="text-start" style="height: 29px; text-align: justify; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td class="text-end" style="height: 30px; width: 604px">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Codigo:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; text-align: justify; width: 604px">
                    <asp:TextBox ID="TxtCodigo" runat="server" Font-Size="Medium" TextMode="Number" Width="200px"></asp:TextBox>
                &nbsp;
                    <asp:Button ID="BtnBuscar" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Buscar" OnClick="BtnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Seleccione un Cliente:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:DropDownList ID="dropDownListClientes" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Serie de Factura:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtSerie" runat="server" Font-Size="Medium" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label5" runat="server" Font-Size="Medium" Text="Numero de Factura:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtNumero" runat="server" Font-Size="Medium" Width="500px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label6" runat="server" Font-Size="Medium" Text="Monto:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtMonto" runat="server" Font-Size="Medium" Width="500px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-end" style="width: 604px; height: 30px">
                    <asp:Label ID="Label7" runat="server" Font-Size="Medium" Text="Mensaje:"></asp:Label>
                </td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:TextBox ID="TxtMensaje" runat="server" Font-Size="Medium" Width="500px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td style="height: 30px; width: 604px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 604px; height: 30px">&nbsp;</td>
                <td class="text-start" style="height: 30px; width: 604px">
                    <asp:Button ID="BtnGuardar" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Guardar" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnActualizar" runat="server" BackColor="#666666" Font-Bold="True" Font-Size="Large" ForeColor="White" Text="Pagar" OnClick="BtnActualizar_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="VistaVenta" runat="server" BackColor="#666666" Font-Bold="True" ForeColor="White" Width="1208px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="True" OnCheckedChanged="chk_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

