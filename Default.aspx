<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="envioEMail._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        &nbsp;</h2>
<h2>
        <asp:Label ID="lbl_status" runat="server"></asp:Label>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </h2>
<h2>
        &nbsp;</h2>
</asp:Content>
