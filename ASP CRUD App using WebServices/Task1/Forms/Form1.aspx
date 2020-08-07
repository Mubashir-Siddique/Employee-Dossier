<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="Task1.Forms.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Styles/Style.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="Form1.js"></script>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/dataTables.bootstrap.min.css" rel="stylesheet" />
    <%--    <link href="../Styles/jquery.dataTables.min.css" rel="stylesheet" />--%>
    <script src="../Scripts/jquery.dataTables.min.js"></script>
    <script src="../Scripts/dataTables.bootstrap.min.js"></script>


</head>
<body>




    <form id="form1" runat="server">
        <div>
            <h3 style="text-align: center">Employee Table data manipulation using WebService & AJAX </h3>
        </div>
        <br />
        <input id="custId" type="hidden" name="custId" value=" " />

        <br />
        <div style="display:inline-block">
            <div style="float: left; width: 212px; height: 150px; text-align: center;">
                <asp:Label Text="Employee Image" runat="server" ID="lbl1" CssClass="PictureLbl" />
            </div>

            <div id="imgdiv" style=" text-align: center; width: 155px; height: 150px; border: 2px solid black; overflow: hidden;">
                <img id="imgUpload" src="../Images/compact-camera.png" onclick="document.getElementById('File1').click()"  alt="" width="150" height="150" style="z-index:-1; max-width: 100%; max-height: 100%;" />
                <input id="File1" onchange="readURL(this)"; type="file" style=" height: 0; width: 0;" />
            </div>
        </div>
        <br /><br />
        <table id="tbl">
            <tr>
                <td class="tdLabels">
                    <asp:Label Text="Employee Name" runat="server" />
                </td>
                <td>
                    <input id="inputName" type="text" name="name" value="EmpName" required="required" />
                </td>
                <td class="errorMessage1">**Please Enter Valid Name
                </td>
            </tr>

            <tr>
                <td class="tdLabels">
                    <asp:Label Text="Employee Address" runat="server" />
                </td>
                <td>
                    <input id="inputAddress" type="text" name="name" value="EmpName" required="required" />
                </td>
                <td class="errorMessage2">**Please Enter Valid Address</td>
            </tr>

            <tr>
                <td class="tdLabels">
                    <asp:Label Text="Employee Email" runat="server" />
                </td>
                <td>
                    <input id="inputEmail" title="Email" required="required" />
                </td>
                <td class="errorMessage3">**Please Enter Valid Email Address</td>
            </tr>

<%--            <tr>
                <td class="tdLabels">
                    <asp:Label Text="Employee Picture" runat="server" />
                </td>
                <td>

                </td>
                <td class="errorMessage3">**Please</td>
            </tr>--%>
        </table>      

        <br />
        <input id="insertBtn" type="button" name="name" value="Insert" onclick="InsertData()" />
        <input id="saveButton" type="button" name="name" value="Save" onclick="SaveData()" />

        <br />
        <br />
        <br />

        <!-- The Modal -->
        <div id="myModal" class="modal">

            <!-- Modal content -->
            <div class="modal-content">
                <span id="close">&times;</span>
                <p>Data Already Exists Please Enter Unique Record !!! </p>
            </div>

        </div>

        <div id="tableDiv">
        </div>

    </form>
</body>
</html>
