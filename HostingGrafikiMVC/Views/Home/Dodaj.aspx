<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Dodaj
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%using (Html.BeginForm("Dodaj", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
      { %>
    <h2>Dodaj</h2>
    <p>
    <input type="file" name="FileUpload" id="FileUpload" /> Wybierz grafikę do załadowania
    </p>
    <%: Html.CheckBox("Prywatny") %> Prywatny (nie będzie wyświetlany w galerii)
    <br />

    <%= ViewData["AkcjaDodawania"] %> <br />

    <input type="submit" name="Dodaj" value="Dodaj grafikę" />

    <% if (ViewData["ŚcieżkaPobierania"] != "" && ViewData["ŚcieżkaPobierania"] != null)
       { %>
       <br />
       Link zamaskowany: <%: Html.TextBox("ŚcieżkaPobierania", ViewData["ŚcieżkaPobierania"]) %>
       <br />
       Link bezpośredni: <%: Html.TextBox("ŚcieżkaPobieraniaBezpośrednia", ViewData["ŚcieżkaPobieraniaBezpośrednia"]) %>
       <br />
       Link do usunięcia:<%: Html.TextBox("ŚcieżkaUsuwania", ViewData["ŚcieżkaUsuwania"])  %>

    <% } %>
    
    <% } %>

</asp:Content>
