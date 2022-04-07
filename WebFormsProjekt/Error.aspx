<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebFormsProjekt.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="error-template">
                <h1 style="color:red">
                    Greška!
                </h1>
                <h3>
                    Više detalja o greški: <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                </h3>
                <div class="error-actions">
                    <a href="/PrikazPodatakaWF.aspx" class="link-primary">< Povratak na početnu stranicu</a>
                </div>
            </div>
        </div>
    </div>

            </div>
    </form>
</body>
</html>
