<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Mercadorias.lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Mercadorias cadastradas</h2>

        <div class="col-md-10">
            <span></span>
        </div>

        <div class="col-md-2">

            <div class="form-row">

                <div class="input-group">
                    <asp:Button runat="server" ID="btnVoltar" OnClick="btnVoltar_Click" Text="Novo cadastro" type="submit" class="btn btn-primary" />
                </div>
            </div>

        </div>

        <table class="table table-condensed">
            <thead>
                <tr>
                    <th>Código :</th>
                    <th>Nome :</th>
                    <th>Tipo :</th>
                    <th>Negócio :</th>
                    <th>Quantidade :</th>
                    <th>Preço :</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater runat="server" ID="listRepeater">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("IdMercadoria") %></td>
                            <td><%#Eval("NomeMercadoria") %></td>
                            <td><%#Eval("TipoMercadoria") %></td>
                            <td><%#Eval("TipoNegocio") %></td>
                            <td><%#Eval("Quantidade") %></td>
                            <td><%#Eval("Preco") %></td>

                            <td>
                                <a href="Editar.aspx?id=<%# Eval("IdMercadoria") %>">
                                    <img id="imgEditar" src="Source/img/table-edit.png" />Editar</a> </td>
                            <td>

                                <a href="Excluir.aspx?id=<%# Eval("IdMercadoria") %>">
                                    <img id="imgExcluir" src="Source/img/delete-forever.png" />Excluir</a>

                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>

        <div class="col-md-10">
            <span></span>
        </div>

        <div class="col-md-2">

            <div class="form-row">

                <div class="input-group">
                    <asp:Button runat="server" ID="btnVoltar2" Text="Novo cadastro" OnClick="btnVoltar_Click" type="submit" class="btn btn-primary" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
