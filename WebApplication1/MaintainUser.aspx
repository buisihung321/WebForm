<%@ Page Language="C#" %>
<%@ Import Namespace="WebApplication1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<script runat="server">

    UserInfoData data = new UserInfoData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            LoadData();
    }

    public void LoadData()
    {
        gvUserInfoList.DataSource = data.GetUserList();
        gvUserInfoList.DataBind();

    }

  

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dynamic u = new UserInfo
        {
            Username = txtUserName.Text,
            Password = txtPassword.Text,
            Address = txtAddress.Text,
            Email = txtEmail.Text,
            BirthDate = DateTime.Parse(txtBirthDate.Text)
        };
        data.InsertUserInfo(u);
        LoadData();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        dynamic u = new UserInfo {Username = txtUserName.Text};
        data.Delete(u);
        LoadData();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        dynamic u = new UserInfo
        {
            Username = txtUserName.Text,
            Password = txtPassword.Text,
            Address = txtAddress.Text,
            Email = txtEmail.Text,
            BirthDate = DateTime.Parse(txtBirthDate.Text)
        };
        data.UpdateUserInfo(u);
        LoadData();
    }

    protected void gvUserInfoList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow gv = gvUserInfoList.Rows[e.NewSelectedIndex];
        txtUserName.Text = gv.Cells[1].Text;
        txtPassword.Text = gv.Cells[2].Text;
        txtBirthDate.Text = gv.Cells[3].Text;
        txtAddress.Text = gv.Cells[4].Text;
        txtEmail.Text = gv.Cells[5].Text;
    }
</script><title>Title</title>
</head>
<body>
<form id="HtmlForm" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="BirthDate"></asp:Label>
        <asp:TextBox ID="txtBirthDate" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Addresss"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <asp:GridView ID="gvUserInfoList" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvUserInfoList_SelectedIndexChanging">
    </asp:GridView>
</form>
</body>
</html>