<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HostingGrafikiMVC.Models.HomeModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Pobierz
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pobierz</h2>
    <%using (Html.BeginForm("Pobierz", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
      { %>

    <% } %>
</asp:Content>
