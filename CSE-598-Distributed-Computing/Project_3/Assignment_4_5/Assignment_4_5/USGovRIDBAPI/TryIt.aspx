<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4_5.USGovRIDBAPI.TryIt" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>US Government Recreation Service</h3>
    <h5>Enter keywords and state for recreation area.</h5>
    <div>
        <asp:Label id="label" AssociatedControlId="QueryTextBox" Text="Query:" runat="server" />
        <asp:TextBox ID="QueryTextBox" runat="server" placeholder="Keywords, e.g. Pool, Road, etc."></asp:TextBox>
    </div>
    <div>
        <asp:Label id="label2" AssociatedControlId="StateTextBox" Text="State:" runat="server" />
        <asp:TextBox ID="StateTextBox" runat="server" placeholder="State, e.g. CA, NV, AZ, etc"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div class="box">
        <code>
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
        </code>
    </div>
</asp:Content>