<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Proizvodi.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="id" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Naziv" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNaziv" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Opis" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtOpis" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Kategorija" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtKategorija" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Proizvodjac" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProizvodjac" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Dobavljac" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDobavljac" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Cena" runat="server"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCena" runat="server">

                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button Text="Save" ID="btnSave" runat="server" OnClick="btnSave_Click"/>
                        <asp:Button Text="Delete" ID="btnDelete" runat="server"/>
                        <asp:Button Text="Clear" ID="btnClear" runat="server" OnClick="btnClear_Click"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green">

                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red">

                        </asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvProizvod" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="naziv" HeaderText="naziv" />
                    <asp:BoundField DataField="opis" HeaderText="opis" />
                    <asp:BoundField DataField="kategorija" HeaderText="kategorija" />
                    <asp:BoundField DataField="proizvodjac" HeaderText="proizvodjac" />
                    <asp:BoundField DataField="dobavljac" HeaderText="dobavljac" />
                    <asp:BoundField DataField="cena" HeaderText="cena" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton Text="Select" ID="lbSelect" CommandArgument='<%# Eval("id") %>' runat="server" OnClick="lnkSelect_OnClick"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
