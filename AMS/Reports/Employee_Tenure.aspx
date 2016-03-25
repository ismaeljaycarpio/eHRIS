﻿<%@ Page Title="Employee Tenure" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee_Tenure.aspx.cs" Inherits="AMS.Reports.Employee_Tenure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h5>Employee Tenure</h5>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="input-group input-group-btn">
                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search..."></asp:TextBox>
                                    <asp:Button ID="btnSearch"
                                        runat="server"
                                        CssClass="btn btn-primary"
                                        Text="Go"
                                        OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="table-responsive">
                        <asp:Button runat="server" Text="Word" ID="btnExportToPDF" OnClick="btnExportToPDF_Click" />
                        <asp:Button runat="server" ID="btnExcel" OnClick="btnExcel_Click" Text="Excel" />
                        <asp:GridView ID="gvEmployee"
                            runat="server"
                            class="table table-striped table-hover dataTable"
                            GridLines="None"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            ShowHeaderWhenEmpty="true"
                            AllowSorting="true"
                            DataKeyNames="UserId"
                            EmptyDataText="No Record(s) found"
                            OnSorting="gvEmployee_Sorting"
                            OnPageIndexChanging="gvEmployee_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Emp_Id" HeaderText="ID" SortExpression="Emp_Id" />
                                <asp:TemplateField HeaderText="Full Name" SortExpression="FullName">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFNAME" runat="server" Text='<%# Eval("FullName") %>' CommandName="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
                                <asp:TemplateField HeaderText="Starting Date" SortExpression="Contract_SD">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblStartingDate" Text='<%# Eval("Contract_SD", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date" SortExpression="Contract_ED">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEndDate" Text='<%# Eval("Contract_ED", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Current Rendered Service" SortExpression="Years">
                                    <ItemTemplate>
                                        <asp:Label ID="lblYears" runat="server" Text='<%# Eval("Years") + " Years " %>'></asp:Label>
                                        <asp:Label ID="lblMonths" runat="server" Text='<%# Eval("Months") + " Months" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>