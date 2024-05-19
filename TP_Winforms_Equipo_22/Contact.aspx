<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TP_Winforms_Equipo_22.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center">
        <main aria-labelledby="title">

            <h2 class="text-center">Contacto</h2>

            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Email address</label>
                <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
            </div>
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">Example textarea</label>
                <textarea class="form-control mb-4" id="exampleFormControlTextarea1" rows="3"></textarea>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="Button1_Click" class="btn btn-primary me-3 ms-2" />
                <asp:Label ID="LblMensajeEnviado" runat="server"></asp:Label>
            </div>
        </main>
    </div>

</asp:Content>
