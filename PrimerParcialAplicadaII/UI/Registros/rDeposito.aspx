<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rDeposito.aspx.cs" Inherits="PrimerParcialAplicadaII.UI.Registros.rDeposito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #3366FF">Registro de Deposito</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="DepositoidTextBox">Deposito ID:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="DepositoidTextBox" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary btn-sm" OnClick="BuscarButton_Click" />
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="Cuenta">Cuenta:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:DropDownList class="form-control" ID="cuentaDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="ConceptoTextBox">Concepto:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="text" class="form-control" ID="ConceptoTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="MontoTextBox">Monto:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="MontoTextBox" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" class="btn btn-primary btn-sm" OnClick="BtnAgregar_Click" />
                </div>
            </div>
            
            <div>
                <asp:GridView ID="DepositoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
                    <AlternatingRowStyle BackColor="LightGray" />
                    <Columns>
                        <asp:BoundField DataField="DepositoId" HeaderText="DepositoId" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="CuentaId" HeaderText="CuentaId" />
                        <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
                        <asp:BoundField DataField="Monto" HeaderText="Monto" />
                    </Columns>
                    <HeaderStyle BackColor="LightSkyBlue" Font-Bold="True" />
                </asp:GridView>
            </div>
            
            <div class="form-group row">
                <label class="control-label col-sm-2" for="TotalTextBox">Total:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="TotalTextBox" Text="0" runat="server"></asp:TextBox>
                </div>
            </div>
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
