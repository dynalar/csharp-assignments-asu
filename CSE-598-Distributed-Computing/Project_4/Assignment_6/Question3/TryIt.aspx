<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="Assignment_6.Question3.TryIt" %>

<asp:Content ID="Question3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Question 3</h3>
    <h5>Enter the URL for both an XML and XSD to validate if they are compatible.</h5>
    <b>Links to sample XML files on this server. (Right Click > Copy Link Address and paste into the boxes)</b>
    <br />
    <a href="../xml_files/Persons.xml">Persons.xml</a>
    <a href="../xml_files/Persons.xsd">Persons.xsd</a>
    <a href="https://venus.sod.asu.edu/WSRepository/xml/Courses.xml">Courses.xml</a>
    <a href="https://venus.sod.asu.edu/WSRepository/xml/Courses.xsd">Courses.xsd</a>
    <br />
    &nbsp;
    <div>
        <asp:Label id="label4" AssociatedControlId="XmlTextBox" Text="XML URL:" runat="server" />
        <asp:TextBox ID="XmlTextBox" class="xml-url-text-box" runat="server" placeholder="Enter URL for your XML here..."></asp:TextBox>
    </div>
    &nbsp;
    <div>
        <asp:Label id="label5" AssociatedControlId="XsdTextBox" Text="XSD URL:" runat="server" />
        <asp:TextBox ID="XsdTextBox" class="xml-url-text-box" runat="server" placeholder="Enter URL for your XSD here..."></asp:TextBox>
    </div>
    &nbsp;
    <div>
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
    </div>
    <div class="box">
        <code>
            <asp:Literal ID="ResultLiteral" runat="server"></asp:Literal>
        </code>
    </div>
</asp:Content>