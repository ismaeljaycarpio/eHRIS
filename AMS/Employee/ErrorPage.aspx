﻿<%@ Page Title="Error Page" Language="C#" MasterPageFile="~/ProfileNested.master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="AMS.Employee.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlNoAgency" runat="server" CssClass="alert alert-warning">
        <strong>No Agency specified!</strong> Configure agency for this user and try again. If error persist, the Agency has no specified Performance Evaluation sheet.
    </asp:Panel>
</asp:Content>