<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Mercadorias.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Editar cadastro</h2>

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
                        <asp:TextBox runat="server" TextMode="Number" step="0.01" data-number-to-fixed="2" data-number-stepfactor="100" class="form-control currency" ID="txtpreco" Width="200px" />
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

            <div class="col-md-8">
                <span></span>
            </div>

            <div class="col-md-1">

                <div class="form-row">

                    <div class="input-group">
                        <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click"  type="submit" class="btn btn-primary" />
                    </div>
                </div>

            </div>
            <div class="col-md-1">

                <div class="form-row">

                    <div class="input-group">
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click"  type="submit" class="btn btn-primary" />
                    </div>
                </div>

            </div>

        </div>



    </div>

</asp:Content>
