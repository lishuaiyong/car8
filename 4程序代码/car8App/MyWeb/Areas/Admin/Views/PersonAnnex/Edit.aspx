﻿<%@ Page Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="MyCon.MyMvcPage<DbEnt.PersonAnnexRule.Entity>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    PersonAnnex Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="~/Res/MyJs_Admin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            jv.SetDetail();
            
            //$('#txtCreateDate').datepicker();
            //$("#txtStatus").TextHelper("array", "在岗,离岗");
            //$("#txtChannelManager").TextHelper("change", "~/C3_Shop/LoadStaff/?post=渠道经理", 500);

        });
        function Edit_OK(ev) {
            
            $.post("~/Admin/PersonAnnex/" + jv.page()["action"] + "/" + (jv.page()["uid"] || "0") + ".aspx", $(".MyCard").GetDivJson("Edit_") , function (res) {
                //客户端返回的是Json
                if (res.msg ) alert(res.msg);
                jv.Hide(function () { $(".flexigrid", jv.boxdy()).getFlexi().populate(); });
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divCard">
        <table width="100%">
            <tr>
                <td class='tdEdit'>
                    ID:
                </td>
                <td class='tdVal'>
                    <%=Html.TextBox("Edit_Id", (Model.Id))%>
                </td>
                <td class='tdSplit'>
                </td>
                <td class='tdEdit'>
                    UserID:
                </td>
                <td class='tdVal'>
                    <%=Html.TextBox("Edit_UserID", (Model.UserID))%>
                </td>
            </tr>
            <tr>
                <td class='tdEdit'>
                    Key:
                </td>
                <td class='tdVal'>
                    <%=Html.TextBox("Edit_Key", (Model.Key))%>
                </td>
                <td class='tdSplit'>
                </td>
                <td class='tdEdit'>
                    AnnexID:
                </td>
                <td class='tdVal'>
                    <%=Html.TextBox("Edit_AnnexID", (Model.AnnexID))%>
                </td>
            </tr>
            <tr>
                <td class='tdEdit'>
                    SortID:
                </td>
                <td class='tdVal'>
                    <%=Html.TextBox("Edit_SortID", (Model.SortID))%>
                </td>
                <td class='tdSplit'>
                </td>
                <td class='tdVal'>
                </td>
            </tr>
        </table>
        <input class="submit" type="button" value="保存" onclick="Edit_OK(event)" />
    </div>
</asp:Content>
