<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_4_5.EncryptDecryptService.TryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Encrypt Service</h3>
    <h6>Enter a string below to get the encrypted string in SHA256</h6>
    <div>
        <asp:Label id="encryptorLabel" AssociatedControlId="EncryptStringTextBox" Text="String:" runat="server" />
        <asp:TextBox ID="EncryptStringTextBox" runat="server" placeholder="Enter Content..."></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
    </div>

    <h3>Decrypt Service</h3>
    <h6>Enter a string below to get the encrypted string in SHA256</h6>
    <div>
        <asp:Label id="decryptorLabel" AssociatedControlId="DecryptStringTextBox" Text="String:" runat="server" />
        <asp:TextBox ID="DecryptStringTextBox" runat="server" placeholder="Enter Content..."></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="SubmitButton2" runat="server" Text="Submit" OnClick="SubmitButtonDecryptor_Click" />
    </div>
    <div>
        <asp:Literal ID="ResultLiteralDecryptor" runat="server"></asp:Literal>
    </div>

</asp:Content>