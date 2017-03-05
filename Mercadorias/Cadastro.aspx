<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Mercadorias.Cadastro1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">

        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#home">Cadastro</a></li>
            <li><a data-toggle="tab" href="#menu1">Lista de Mercadorias</a></li>
        </ul>

        <div class="tab-content">



            <div id="home" class="tab-pane fade in active">


                <div class="container">
                    <h2>Cadastro de novas mercadorias</h2>

       
                    <div class="form-group">
                        <label for="textNome" class="control-label">Nome :</label>
                        <asp:TextBox runat="server" ID="textNome" class="form-control" placeholder="Digite o nome do produto"
                            data-error="Por favor, informe um nome correto." required />
                    </div>

                    <div class="form-group">
                        <label for="tpMercadoria" class="control-label">Tipo :</label>
                        <asp:TextBox runat="server" ID="tpMercadoria" class="form-control" placeholder="Digite o tipo do produto"
                            data-error="Por favor, informe um tipo correto." required />
                        <div class="help-block with-errors"></div>
                    </div>

                    <div class="form-group">
                        <label for="txtquantidade" class="control-label">Quantidade :</label>
                        <asp:TextBox runat="server" TextMode="Number" class="form-control" ID="txtquantidade" placeholder="Digite a quantidad de produtos"
                            required />

                    </div>

                    <div class="row">
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="txtpreco" class="control-label">Preço :</label>
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <asp:TextBox runat="server" TextMode="Number" step="0.01" data-number-to-fixed="2" data-number-stepfactor="100" class="form-control currency" ID="txtpreco" Width="200px" placeholder="00,00"  required/>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4">

                            <div class="form-group">
                                <label for="ddlTpNegocio" class="control-label">Tipo de Negócio :</label>
                                <asp:DropDownList runat="server" TextMode="Number" class="form-control" ID="ddlTpNegocio" placeholder="Digite a quantidad de produtos"
                                    required Width="200px" />

                            </div>

                        </div>

                        <div class="col-md-10">
                            <span></span>
                        </div>

                        <div class="col-md-2">

                            <div class="form-row">

                                <div class="input-group">
                                    <asp:Button runat="server" ID="btnSalvar" Text="Cadastrar" OnClick="btnEnviar_Click" type="submit" class="btn btn-primary" />
                                </div>
                            </div>

                        </div>

                    </div>



                </div>


            </div>


            <div id="menu1" class="tab-pane fade">


                <div class="container">
                    <h2>Mercadorias cadastradas</h2>
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
                </div>

            </div>

        </div>
    </div>
</asp:Content>
