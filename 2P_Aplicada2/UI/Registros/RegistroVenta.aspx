<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroVenta.aspx.cs" Inherits="_2P_Aplicada2.UI.Registros.RegistroVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">

    <div class="row">
			<div class="col-lg-10 col-xl-9 mx-auto">
				<div class="card  flex-row my-5">
					<div class="card-img-left d-none d-md-flex">
					</div>
					<div class="card-body">
						<div class="card-header text-white h5" style="background-color: rgb(234, 82, 82)">
							<div class="card-title text-center text-uppercase">
						     Registro de Ventas
						    <asp:Label CssClass="float-right" runat="server" ID="LabelFecha" Text="18/12/2019"></asp:Label>
							</div>
						</div>

						<asp:Panel ID="formRegistro" runat="server">							
							<hr />
							<div class="form-group">
								<div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ID="textboxId" class="form-control" placeholder="ID" />
									<div class="input-group-append">
										<asp:Button runat="server" ID="BuscarButton" OnClick="BuscarButton_Click" Text="Buscar"  CssClass="btn btn-primary"  type="button" />
									</div>
								</div>
							  </div>
 
                                <div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ID="textboxIdCliente" class="form-control" placeholder="ID Cliente" />
								</div>
							   </div>
                                
                                <div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="Date" ID="Fecha" class="form-control"/>
								</div>
							   </div>

                                <div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ID="textboxMonto" class="form-control" placeholder="Monto" />
								</div>
							  </div>

                               <div class="form-group">
								<div class="input-group">								
									<asp:TextBox runat="server" type="number" ID="textboxBalance" class="form-control" placeholder="Balance" />
								</div>
							  </div>
                             
                            </div>
	
							<hr />
							<div class="row ">
                            <div class="col-3"></div>
                            <div class="col-6">
                            <asp:Button Text="Nuevo" ID="NuevoButton" OnClick="NuevoButton_Click" runat="server" class="btn btn-lg btn-primary text-uppercase" type="submit" />
							<asp:Button Text="Guardar" ID="GuardarButton" OnClick="GuardarButton_Click" runat="server" class="btn btn-lg btn-success text-uppercase" type="submit" />
							<asp:Button Text="Eliminar" ID="EliminarButton" OnClick="EliminarButton_Click" runat="server" class="btn btn-lg btn-danger text-uppercase" type="submit" />
			
							<hr class="my-4" />
                            </div>
                            <div class="col-3"></div>	
                            </div>

						</asp:Panel>
					</div>
				</div>
			</div>
		</div>

</asp:Content>
