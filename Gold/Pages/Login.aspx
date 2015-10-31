<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" FailureText="Nao foi possivel logar.&lt;br&gt;Tente novamente!" LoginButtonText="Logar" OnAuthenticate="Login1_Authenticate" PasswordLabelText="Senha:" PasswordRequiredErrorMessage="Senha e obrigatoria!" TitleText="" UserNameLabelText="CPF:" UserNameRequiredErrorMessage="CPF e obrigatorio!" ValidateRequestMode="Enabled">
        </asp:Login>

    <div>
    
    </div>
    </form>
</body>
</html>
