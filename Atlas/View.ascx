﻿<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="View.ascx.cs"  Inherits="Christoc.Modules.Atlas.View" %>
<%@ Register Assembly="DotNetNuke.Web.Client" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" TagPrefix="cc1" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%--<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>--%>

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />


    <script type="text/javascript" src="DesktopModules/Atlas/JS/imgscale.jquery.min.js"></script>

<div class="MainBodyStyle" id="MainForm" runat="server">
<table style="width: 100%; height: 100%; font-size: small; font-family: Tahoma;"
            id="tblMaster_MainForm">
            <tr runat="server" style="height: 40px;">
                <td style="height: 100%" valign="top" colspan="3">
                    <table style="width: 100%; height: 40px;margin-top:-5px;">
                     <%--   <tr style="height: 95%">
                            <td colspan="3" style="height: 80px">
                                
                                <img runat="server" id="imgHeaderLogo" alt="" style="width: 100%; height: 80px;" src="about:blank" />
                            </td>
                        </tr>--%>
                        <tr style="height: 5%">
                            <td>
                                <table style="width: 100%" class="MainHeaderStyle">
                                    <tr>
                                        <td style="width: 21%">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 5%;visibility:hidden;">
                                                        <asp:ImageButton ID="ImgbtnPersian" runat="server" OnClientClick="imgbtnPersian_onClick();"
                                                            OnClick="imgbtnPersian_onClick" PostBackUrl="~/MainPage.aspx" ImageUrl="~/DesktopModules/Atlas/Images/TopToolBar/Iran_flag.png" />
                                                    </td>
                                                    <td style="width: 5%;visibility:hidden;" >
                                                        <asp:ImageButton ID="ImgbtnEnglish" runat="server" OnClientClick="ImgbtnEnglish_onClick();"
                                                            OnClick="ImgbtnEnglish_onClick" PostBackUrl="~/MainPage.aspx" ImageUrl="~/DesktopModules/Atlas/Images/TopToolBar/uk-flag.png" />
                                                    </td>
                                                    <td style="width: 90%"></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 77%">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 50%">
                                                        <asp:Label ID="lblCurrentVersion" runat="server" CssClass="HeaderLabel"></asp:Label>
                                                    </td>
                                                    <td style="width: 50%" align="center">
                                                        <asp:Label ID="lblCurrentUser" runat="server" CssClass="WelcomeLabel"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td id="TdImageButtonLogOut" runat="server"  style="width: 2%;visibility:hidden;">
                                            <asp:ImageButton ID="imgbtnLogOut" runat="server" OnClientClick="imgbtnLogOut_onClick();"
                                                OnClick="imgbtnLogOut_onClick" PostBackUrl="~/MainPage.aspx" ImageUrl="~/DesktopModules/Atlas/Images/TopToolBar/exit.png" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div class="bottomDockMenu" id="bottomDockMenu">
                        <div class="bottomDockMenu-container">
                            <a id="dmItemWelcome_DockMenu" class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemWelcome_DockMenu')">
                                <span></span>
                                <img id="qlItemHome" src="DesktopModules/Atlas/Images/DockMenu/home.png" alt="" /></a><a id="dmItemWorkFlowsView_DockMenu"
                                    class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemWorkFlowsView_DockMenu')">
                                    <span></span>
                                    <img id="qlItemWorkFlowsView" src="DesktopModules/Atlas/images/DockMenu/email.png" alt="" /></a>
                            <a id="dmItemTrafficsControl_DockMenu" class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemTrafficsControl_DockMenu')">
                                <span></span>
                                <img id="qlItemTrafficsControl" src="DesktopModules/Atlas/images/DockMenu/portfolio.png" alt="" /></a><a
                                    id="dmItemRegisteredRequests_DockMenu" class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemRegisteredRequests_DockMenu')">
                                    <span></span>
                                    <img id="qlItemRegisteredRequests" src="DesktopModules/Atlas/images/DockMenu/video.png" alt="" /></a>
                            <a id="dmItemSurveyedRequests_DockMenu" class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemSurveyedRequests_DockMenu')">
                                <span></span>
                                <img id="qlItemSurveyedRequests" src="DesktopModules/Atlas/images/DockMenu/music.png" alt="" /></a>
                            <a id="dmItemKartable_DockMenu" class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemKartable_DockMenu')">
                                <span></span>
                                <img id="qlItemKartable" src="DesktopModules/Atlas/images/DockMenu/history.png" alt="" /></a><a id="dmItemReportsIntroduction_DockMenu"
                                    class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemReportsIntroduction_DockMenu')">
                                    <span></span>
                                    <img id="qlItemReportsIntroduction" src="DesktopModules/Atlas/images/DockMenu/calendar.png" alt="" /></a>
                            <a id="dmItemPersonnelIntroduction_DockMenu" class="bottomDockMenu-item" href="#"
                                onclick="DockMenuItem_onClick('dmItemPersonnelIntroduction_DockMenu')"><span></span>
                                <img id="qlItemPersonnelIntroduction" src="DesktopModules/Atlas/images/DockMenu/link.png" alt="" /></a> <a id="dmItemManagerMasterMonthlyOperationReport_DockMenu"
                                    class="bottomDockMenu-item" href="#" onclick="DockMenuItem_onClick('dmItemManagerMasterMonthlyOperationReport_DockMenu')">
                                    <span></span>
                                    <img id="qlItemManagerMasterMonthlyOperationReport" src="DesktopModules/Atlas/images/DockMenu/rss.png" alt="" /></a>
                            <a id="dmItemPersonnelMasterMonthlyOperationReport_DockMenu" class="bottomDockMenu-item"
                                href="#" onclick="DockMenuItem_onClick('dmItemPersonnelMasterMonthlyOperationReport_DockMenu')">
                                <span></span>
                                <img id="qlItemPersonnelMasterMonthlyOperationReport" src="DesktopModules/Atlas/images/DockMenu/rss2.png" alt="" /></a>
                        </div>
                    </div>
                </td>
            </tr>
            <tr runat="server" id="NavBarMain_tr" style="height: 370px;">
                <td style="width: 21%; height: 100%;" valign="top">
                    <div id="NavBarMain_div">
                        <ComponentArt:NavBar ID="NavBarMain" Width="95%" Height="100%" CssClass="NavBar"
                            FillContainer="false" DefaultItemLookId="TopItemLook" ExpandSinglePath="true"
                            ImagesBaseUrl="DesktopModules/Atlas/images/NavBar" DefaultSelectedItemLookId="Level2SelectedItemLook"
                            runat="server" DefaultItemTextAlign="Right" >
                            <ItemLooks>
                                <ComponentArt:ItemLook LookId="TopItemLook" RightIconUrl="arrow.gif" ExpandedRightIconUrl="arrow_expanded.gif"
                                    LabelPaddingLeft="15"   />
                                <ComponentArt:ItemLook LookId="Level2ItemLook"  LabelPaddingLeft="15"   />
                                <ComponentArt:ItemLook LookId="Level2SelectedItemLook" LabelPaddingLeft="15"   />
                            </ItemLooks>
                            <Items>
                                <ComponentArt:NavBarItem Text="تعاریف پایه" DefaultSubItemLookId="Level2ItemLook"
                                    Expanded="false" ID="nvbItemBasicDefinitions_NavBarMain" SelectedLookId="TopItemLook"
                                    SubGroupCssClass="Level2Group">
                                    <ComponentArt:NavBarItem Text="معرفی پرسنل" 
                                        ID="nvbItemPersonnelIntroduction_NavBarMain" >
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی انواع استخدام" 
                                        ID="nvbItemEmployTypesIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی شرکت ها" 
                                        ID="nvbItemCorporationsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی بخش ها" 
                                        ID="nvbItemDepartmentsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی پست های سازمانی" 
                                        ID="nvbItemPostsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی گروه قوانین" 
                                        ID="nvbItemRulesGroupIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی گروه های کاری" 
                                        ID="nvbItemWorkGroupsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی انواع بازه شیفت" 
                                        ID="nvbItemShiftPairTypesIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی شیفت ها" 
                                        ID="nvbItemShiftIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی نوبت کاری" 
                                        ID="nvbItemWorkHeatIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی پیش کارت" 
                                        ID="nvbItemPreCardIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی پزشک" 
                                        ID="nvbItemPhysicianIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی بیماری" 
                                        ID="nvbItemIllnessIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی رتبه" 
                                        ID="nvbItemGradeIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی مرکز هزینه" 
                                        ID="nvbItemCostCenterIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی گروه جریان" 
                                        ID="nvbItemFlowGroupIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی محل های ماموریت" 
                                        ID="nvbItemMissionLocationsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی ایستگاه کنترل" 
                                        ID="nvbItemControlStationIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی دستگاه" 
                                        ID="nvbItemMachineIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی تعطیلات سالیانه" 
                                        ID="nvbItemYearlyHolidaysIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی قراردادها" 
                                        ID="nvbItemContractIntroduction_NavBarMain">
                                     </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی پیمانکار" 
                                        ID="nvbItemContractorsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                </ComponentArt:NavBarItem>
                                <ComponentArt:NavBarItem Text="عملیات مجوز" DefaultSubItemLookId="Level2ItemLook"
                                    Expanded="true" ID="nvbItemJustificationOperation_NavBarMain" SelectedLookId="TopItemLook"
                                    SubGroupCssClass="Level2Group" >
                                    <ComponentArt:NavBarItem Text="درخواست های ثبت شده" 
                                        ID="nvbItemRegisteredRequests_NavBarMain" >
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="کارتابل"  Value="UsingBySubstitiute"
                                        ID="nvbItemKartable_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تاریخچه کارتابل"  Value="UsingBySubstitiute"
                                        ID="nvbItemSurveyedRequests_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="کارتابل ویژه"  Value="UsingBySubstitiute"
                                        ID="nvbItemSpecialRequests_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="کارتابل جانشین درخواست" 
                                        ID="nvbItemRequestSubstituteKartable_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="گزارش مدیریتی کارکرد ماهیانه"  Value="UsingBySubstitiute"
                                        ID="nvbItemManagerMasterMonthlyOperationReport_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="گزارش کارکرد ماهیانه" 
                                        ID="nvbItemPersonnelMasterMonthlyOperationReport_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی جریان های کاری" 
                                        ID="nvbItemWorkFlowsView_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                     <ComponentArt:NavBarItem Text=" جزئیات جریان های کاری " 
                                        ID="nvbItemWorkFlowDetail_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="مشاهده مدیران" 
                                        ID="nvbItemMasterManagersIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی جانشین" 
                                        ID="nvbItemSubstituteIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                     <componentArt:NavBarItem Text="تایید اضافه کار تشویقی-مدیران و معاونین"
                                        ID="nvbItemOvertimePersonlist_NavBarMain">
                                    </componentArt:NavBarItem>
                                </ComponentArt:NavBarItem>
                                <ComponentArt:NavBarItem Text="عملیات حضور و غیاب" DefaultSubItemLookId="Level2ItemLook"
                                    Expanded="false" ID="nvbItemPresenceAndAbsenceOperation_NavBarMain" SelectedLookId="TopItemLook"
                                    SubGroupCssClass="Level2Group" >
                                    <ComponentArt:NavBarItem Text="تعریف محدوده محاسبات" 
                                        ID="nvbItemCalculationRangeDefinition_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تنظیمات واسط کاربری" 
                                        ID="nvbItemUiValidation_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی شیفت های استثناء" 
                                        ID="nvbItemExceptionShiftsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="مانده مرخصی" 
                                        ID="nvbItemMasterLeaveRemains_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="کنترل ترددها" 
                                        ID="nvbItemTrafficsControl_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="نگهبانی" 
                                        ID="nvbItemSentry_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="ویرایش نتایج محاسبات" 
                                        ID="nvbItemCalculationsResultsUpdate_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <componentArt:NavBarItem Text="بودجه بندی اضافه کاری تشویقی"
                                        ID="nvbItemOvertime_NavBarMain">
                                    </componentArt:NavBarItem>
                                    <componentArt:NavBarItem Text="زمان بندی تایید کارتابل"
                                        ID="nvbItemApprovalSchedulelist_NavBarMain">
                                    </componentArt:NavBarItem>
                                    <componentArt:NavBarItem Text="تایید اضافه کار تشویقی-اداری"
                                        ID="nvbItemOvertimeEdarilist_NavBarMain">
                                    </componentArt:NavBarItem>
                                    <componentArt:NavBarItem Text="ارسال کارکرد به سیستم حقوق و دستمزد"
                                        ID="nvbItemOvertimeSendFunctionlist_NavBarMain">
                                    </componentArt:NavBarItem>
                                </ComponentArt:NavBarItem>
                                <ComponentArt:NavBarItem Text="عملیات جانبی" DefaultSubItemLookId="Level2ItemLook"
                                    Expanded="false" ID="nvbItemLateralOperations_NavBarMain" SelectedLookId="TopItemLook"
                                    SubGroupCssClass="Level2Group" >
                                    <ComponentArt:NavBarItem Text="معرفی نقش ها" 
                                        ID="nvbItemRolesIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="معرفی کاربران" 
                                        ID="nvbItemUsersIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تغییر کلمه عبور" 
                                        ID="nvbItemPasswordChange_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تغییر مشخصات سازمانی پرسنل" 
                                        ID="nvbItemPersonnelOrganizationFeaturesChange_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="مدیریت اخبار عمومی" 
                                        ID="nvbItemMasterPublicNews_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="پیام های خصوصی" 
                                        ID="nvbItemPrivateMessage_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="انجام محاسبات" 
                                        ID="nvbItemCalculations_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تنظیمات کاربری شخصی" 
                                        ID="nvbItemPersonalUserSettings_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="تنظیمات کاربری مدیریتی" 
                                        ID="nvbItemManagementUserSettings_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="ترددهای آنلاین" 
                                        ID="nvbItemOnlineTraffics_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="رستوران" 
                                        ID="nvbItemWebRest_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                </ComponentArt:NavBarItem>
                                <ComponentArt:NavBarItem Text="گزارش ها" DefaultSubItemLookId="Level2ItemLook" Expanded="false"
                                    ID="nvbItemReports_NavBarMain" SelectedLookId="TopItemLook" SubGroupCssClass="Level2Group"
                                    >
                                    <ComponentArt:NavBarItem Text="معرفی گزارش ها" 
                                        ID="nvbItemReportsIntroduction_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="گزارش های سیستمی" 
                                        ID="nvbItemSystemReports_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <ComponentArt:NavBarItem Text="گزارش های طراحی شده " 
                                        ID="nvbItemDesignedReports_NavBarMain">
                                    </ComponentArt:NavBarItem>                                    
                                </ComponentArt:NavBarItem>
                                <ComponentArt:NavBarItem Text="قانون ساز" DefaultSubItemLookId="Level2ItemLook" Expanded="false"
                                    ID="nvbItemRuleGenerator_NavBarMain" SelectedLookId="TopItemLook" SubGroupCssClass="Level2Group">
                                   <%-- <ComponentArt:NavBarItem Text="مدیریت مفاهیم" 
                                        ID="nvbItemConceptsManagement_NavBarMain">
                                    </ComponentArt:NavBarItem>--%>
                                    <ComponentArt:NavBarItem Text="مدیریت قوانین" 
                                        ID="nvbItemRulesManagement_NavBarMain">
                                    </ComponentArt:NavBarItem>
                                    <%--<ComponentArt:NavBarItem Text="مدیريت مولفه هاي ساخت مفاهيم و قوانين" 
                                        ID="nvbItemExpressionsOperation_NavBarMain">
                                    </ComponentArt:NavBarItem>--%>
                                </ComponentArt:NavBarItem>
                            </Items>
                            <ClientEvents>
                                <ItemSelect EventHandler="NavBarMain_onItemSelect" />
                                <Load EventHandler="NavBarMain_onItemLoad" />
                            </ClientEvents>
                        </ComponentArt:NavBar>
                    </div>
                </td>
                <td style="width: 78%; height: 100%;" valign="top">
                    <div>
                        <ComponentArt:TabStrip ID="TabStripMenus" runat="server" DefaultGroupTabSpacing="1"
                            DefaultItemLookId="DefaultTabLook" DefaultSelectedItemLookId="SelectedTabLook"
                            ScrollingEnabled="true" ImagesBaseUrl="images/TabStrip" MultiPageId="MultiPageMenus"
                            ScrollLeftLookId="ScrollItem" ScrollRightLookId="ScrollItem" Width="100%">
                            <ItemLooks>
                                <ComponentArt:ItemLook LookId="DefaultTabLook" CssClass="DefaultTab" HoverCssClass="DefaultTabHover"
                                    LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4"
                                    LeftIconUrl="tab_left_icon.gif" RightIconUrl="tab_right_icon.gif" LeftIconWidth="13"
                                    LeftIconHeight="25" RightIconWidth="13" RightIconHeight="25" meta:resourcekey="DefaultTabLook" />
                                <ComponentArt:ItemLook LookId="SelectedTabLook" CssClass="SelectedTab" LabelPaddingLeft="15"
                                    LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" LeftIconUrl="selected_tab_left_icon.gif"
                                    RightIconUrl="selected_tab_right_icon.gif" LeftIconWidth="13" LeftIconHeight="25"
                                    RightIconWidth="13" RightIconHeight="25" meta:resourcekey="SelectedTabLook" />
                                <ComponentArt:ItemLook LookId="ScrollItem" CssClass="ScrollItem" HoverCssClass="ScrollItemHover"
                                    LabelPaddingLeft="5" LabelPaddingRight="5" LabelPaddingTop="0" LabelPaddingBottom="0" />
                            </ItemLooks>
                            <Tabs>
                                <ComponentArt:TabStripTab ID="tbWelcome_TabStripMenus" Text="صفحه اصلی">
                                </ComponentArt:TabStripTab>
                            </Tabs>
                            <ClientEvents>
                                <TabSelect EventHandler="TabStripMenus_onTabSelect" />
                            </ClientEvents>
                        </ComponentArt:TabStrip>
                    </div>
                    <ComponentArt:MultiPage ID="MultiPageMenus" runat="server" CssClass="MultiPage" SelectedIndex="0"
                        Width="100%">
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvWelcome">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvWelcome_iFrame" src="DesktopModules/Atlas/MainView.aspx?(new Date()).getDate()"
                                    class="pgvWelcome_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvShiftIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvShiftIntroduction_iFrame"
                                    src="about:blank" class="pgvShiftIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvDepartmentsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvDepartmentsIntroduction_iFrame"
                                    src="about:blank" class="pgvDepartmentsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPostsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPostsIntroduction_iFrame"
                                    src="about:blank" class="pgvPostsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvEmployTypesIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvEmployTypesIntroduction_iFrame"
                                    src="about:blank" class="pgvEmployTypesIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvMissionLocationsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvMissionLocationsIntroduction_iFrame"
                                    src="about:blank" class="pgvMissionLocationsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvExceptionShiftsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvExceptionShiftsIntroduction_iFrame"
                                    src="about:blank" class="pgvExceptionShiftsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvWorkGroupsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvWorkGroupsIntroduction_iFrame"
                                    src="about:blank" class="pgvWorkGroupsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPersonnelIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPersonnelIntroduction_iFrame"
                                    src="about:blank" class="pgvPersonnelIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvWorkHeatIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvWorkHeatIntroduction_iFrame"
                                    src="about:blank" class="pgvWorkHeatIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvControlStationIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvControlStationIntroduction_iFrame"
                                    src="about:blank" class="pgvControlStationIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvMachineIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvMachineIntroduction_iFrame"
                                    src="about:blank" class="pgvMachineIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvMasterLeaveRemains">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvMasterLeaveRemains_iFrame"
                                    src="about:blank" class="pgvMasterLeaveRemains_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPersonnelOrganizationFeaturesChange">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPersonnelOrganizationFeaturesChange_iFrame"
                                    src="about:blank" class="pgvPersonnelOrganizationFeaturesChange_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvUsersIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvUsersIntroduction_iFrame"
                                    src="about:blank" class="pgvUsersIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPreCardIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPreCardIntroduction_iFrame"
                                    src="about:blank" class="pgvPreCardIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPasswordChange">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPasswordChange_iFrame" src="about:blank"
                                    class="pgvPasswordChange_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvRolesIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvRolesIntroduction_iFrame"
                                    src="about:blank" class="pgvRolesIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvManagerMasterMonthlyOperationReport">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvManagerMasterMonthlyOperationReport_iFrame"
                                    src="about:blank" class="pgvManagerMasterMonthlyOperationReport_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPersonnelMasterMonthlyOperationReport">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPersonnelMasterMonthlyOperationReport_iFrame"
                                    src="about:blank" class="pgvPersonnelMasterMonthlyOperationReport_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvMasterManagersIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvMasterManagersIntroduction_iFrame"
                                    src="about:blank" class="pgvMasterManagersIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvWorkFlowsView">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvWorkFlowsView_iFrame" src="about:blank"
                                    class="pgvWorkFlowsView_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvSubstituteIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvSubstituteIntroduction_iFrame"
                                    src="about:blank" class="pgvSubstituteIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPhysicianIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPhysicianIntroduction_iFrame"
                                    src="about:blank" class="pgvPhysicianIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvIllnessIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvIllnessIntroduction_iFrame"
                                    src="about:blank" class="pgvIllnessIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvGradeIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvGradeIntroduction_iFrame"
                                    src="about:blank" class="pgvGradeIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                         <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvCostCenterIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvCostCenterIntroduction_iFrame"
                                    src="about:blank" class="pgvCostCenterIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvFlowGroupIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvFlowGroupIntroduction_iFrame"
                                    src="about:blank" class="pgvFlowGroupIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvCalculationRangeDefinition">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvCalculationRangeDefinition_iFrame"
                                    src="about:blank" class="pgvCalculationRangeDefinition_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvYearlyHolidaysIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvYearlyHolidaysIntroduction_iFrame"
                                    src="about:blank" class="pgvYearlyHolidaysIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvContractorsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true" id="pgvContractorsIntroduction_iFrame"
                                    src="about:blank" class="pgvContractorsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvRulesGroupIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvRulesGroupIntroduction_iFrame"
                                    src="about:blank" class="pgvRulesGroupIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvReportsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true" id="pgvReportsIntroduction_iFrame"
                                    src="about:blank" class="pgvReportsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvDesignedReports">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvDesignedReports_iFrame"
                                    src="about:blank" class="pgvDesignedReports_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvTrafficsControl">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvTrafficsControl_iFrame" src="about:blank"
                                    class="pgvTrafficsControl_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvMasterPublicNews">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvMasterPublicNews_iFrame" src="about:blank"
                                    class="pgvMasterPublicNews_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvPrivateMessage">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvPrivateMessage_iFrame" src="about:blank"
                                    class="pgvPrivateMessage_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvUiValidation">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvUiValidation_iFrame" src="about:blank"
                                    class="pgvUiValidation_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvCalculations">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvCalculations_iFrame" src="about:blank"
                                    class="pgvCalculations_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvCorporationsIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvCorporationsIntroduction_iFrame" src="about:blank"
                                    class="pgvCorporationsIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvShiftPairTypesIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvShiftPairTypesIntroduction_iFrame" src="about:blank"
                                    class="pgvShiftPairTypesIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvConceptRuleMasterOperation">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true"  id="pgvConceptRuleMasterOperation_iFrame"
                                    src="about:blank" class="pgvConceptRuleMasterOperation_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                         <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvWorkFlowDetail">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true" id="pgvWorkFlowDetail_iFrame"
                                    src="about:blank" class="pgvWorkFlowDetail_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                        <ComponentArt:PageView CssClass="PageContent" runat="server" ID="pgvContractIntroduction">
                            <div style="width: 100%; margin: 0 auto;">
                                <iframe allowtransparency="true" id="pgvContractIntroduction_iFrame"
                                    src="about:blank" class="pgvContractIntroduction_iFrame" frameborder="0"></iframe>
                            </div>
                        </ComponentArt:PageView>
                    </ComponentArt:MultiPage>


                </td>
                <td style="width: 1%; height: 100%" valign="top"></td>
            </tr>
        </table>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogLeaveBudgetheader" FooterClientTemplateId="DialogLeaveBudgetfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogLeaveBudget"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/LeaveBudget.aspx" IFrameCssClass="LeaveBudget_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogLeaveBudgetheader">
                    <table style="width: 523px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogLeaveBudget.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogLeaveBudget_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogLeaveBudget" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogLeaveBudget" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogLeaveBudget_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogLeaveBudget').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogLeaveBudget_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogLeaveBudgetfooter">
                    <table id="tbl_DialogLeaveBudgetfooter" style="width: 523px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogLeaveBudget_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogLeaveBudget_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogLeaveBudget_onShow" />
                <OnClose EventHandler="DialogLeaveBudget_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogUserInterfaceAccessLevelsheader" FooterClientTemplateId="DialogUserInterfaceAccessLevelsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogUserInterfaceAccessLevels"
            runat="server" PreloadContentUrl="false" IFrameCssClass="UserInterfaceAccessLevels_iFrame"
            ContentUrl="DesktopModules/Atlas/UserInterfaceAccessLevels.aspx">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogUserInterfaceAccessLevelsheader">
                    <table style="width: 603px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogUserInterfaceAccessLevels.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogUserInterfaceAccessLevels_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogUserInterfaceAccessLevels" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogUserInterfaceAccessLevels" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogUserInterfaceAccessLevels_IFrame').src=parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogUserInterfaceAccessLevels').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogUserInterfaceAccessLevels_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogUserInterfaceAccessLevelsfooter">
                    <table id="tbl_DialogUserInterfaceAccessLevelsfooter" style="width: 603px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogUserInterfaceAccessLevels_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogUserInterfaceAccessLevels_downRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogUserInterfaceAccessLevels_onShow" />
                <OnClose EventHandler="DialogUserInterfaceAccessLevels_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogPersonnelMainInformationheader" FooterClientTemplateId="DialogPersonnelMainInformationfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogPersonnelMainInformation"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/PersonnelMainInformation.aspx"
            IFrameCssClass="PersonnelMainInformation_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogPersonnelMainInformationheader">
                    <table id="tbl_DialogPersonnelMainInformationheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogPersonnelMainInformation.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogPersonnelMainInformation_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogPersonnelMainInformation" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogPersonnelMainInformation" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogPersonnelMainInformation_IFrame').contentWindow.DialogPersonnelMainInformation_onClose();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogPersonnelMainInformation_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogPersonnelMainInformationfooter">
                    <table id="tbl_DialogPersonnelMainInformationfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogPersonnelMainInformation_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogPersonnelMainInformation_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogPersonnelMainInformation_onShow" />
                <OnClose EventHandler="DialogPersonnelMainInformation_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogPersonnelSearchheader" FooterClientTemplateId="DialogPersonnelSearchfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogPersonnelSearch"
            PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/PersonnelSearch.aspx" IFrameCssClass="PersonnelSearch_iFrame"
            runat="server" Style="width: 50%;">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogPersonnelSearchheader">
                    <table id="tbl_DialogPersonnelSearchheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogPersonnelSearch.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogPersonnelSearch_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogPersonnelSearch" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogPersonnelSearch" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogPersonnelSearch_IFrame').src =parent.ModulePath + 'WhitePage.aspx' ;DialogPersonnelSearch.Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogPersonnelSearch_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogPersonnelSearchfooter">
                    <table id="tbl_DialogPersonnelSearchfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogPersonnelSearch_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogPersonnelSearch_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogPersonnelSearch_onShow" />
                <OnClose EventHandler="DialogPersonnelSearch_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogCalendarheader" FooterClientTemplateId="DialogCalendarfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogCalendar"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/Calendar.aspx" IFrameCssClass="Calendar_iFrame"
            Style="width: 50%;">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogCalendarheader">
                    <table style="width: 633px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogCalendar.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogCalendar_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogCalendar" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td valign="middle" id="CloseButton_DialogCalendar">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogCalendar_IFrame').src =parent.ModulePath + 'WhitePage.aspx' ;eval(ClientPerfixId + 'DialogCalendar').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogCalendar_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogCalendarfooter">
                    <table id="tbl_DialogCalendarfooter" style="width: 633px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogCalendar_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogCalendar_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogCalendar_onShow" />
                <OnClose EventHandler="DialogCalendar_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogExceptionShiftsheader" FooterClientTemplateId="DialogExceptionShiftsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogExceptionShifts"
            PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ExceptionShifts.aspx" IFrameCssClass="ExceptionShifts_tbDetails_iFrame"
            runat="server">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogExceptionShiftsheader">
                    <table style="width: 737px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogExceptionShifts.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogExceptionShifts_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogExceptionShifts" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogExceptionShifts" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogExceptionShifts_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogExceptionShifts').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogExceptionShifts_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogExceptionShiftsfooter">
                    <table id="tbl_DialogExceptionShiftsfooter" style="width: 737px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogExceptionShifts_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogExceptionShifts_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogExceptionShifts_onShow" />
                <OnClose EventHandler="DialogExceptionShifts_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" Modal="true" AllowResize="false"
            runat="server" AllowDrag="false" Alignment="MiddleCentre" ID="DialogLoading">
            <Content>
                <table>
                    <tr>
                        <td>
                            <img runat="server" alt="" src="~/DesktopModules/Atlas/Images/Dialog/loading2.gif" />
                        </td>
                    </tr>
                </table>
            </Content>
            <ClientEvents>
                <OnShow EventHandler="DialogLoading_onShow" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogMonthlyOperationGridSchemaheader" FooterClientTemplateId="DialogMonthlyOperationGridSchemafooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogMonthlyOperationGridSchema"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/MonthlyOperationGridSchema.aspx"
            IFrameCssClass="MonthlyOperationGridSchema_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogMonthlyOperationGridSchemaheader">
                    <table id="tbl_DialogMonthlyOperationGridSchemaheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogMonthlyOperationGridSchema.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyOperationGridSchema_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogMonthlyOperationGridSchema" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogMonthlyOperationGridSchema" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogMonthlyOperationGridSchema_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogMonthlyOperationGridSchema').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogMonthlyOperationGridSchema_topRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/top_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogMonthlyOperationGridSchemafooter">
                    <table id="tbl_DialogMonthlyOperationGridSchemafooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyOperationGridSchema_downLeftImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_left.gif" alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogMonthlyOperationGridSchema_downRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogMonthlyOperationGridSchema_onShow" />
                <OnClose EventHandler="DialogMonthlyOperationGridSchema_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogMonthlyOperationGanttChartSchemaheader" FooterClientTemplateId="DialogMonthlyOperationGanttChartSchemafooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogMonthlyOperationGanttChartSchema"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/MonthlyOperationGanttChartSchema.aspx"
            IFrameCssClass="MonthlyOperationGanttChartSchema_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogMonthlyOperationGanttChartSchemaheader">
                    <table id="tbl_DialogMonthlyOperationGanttChartSchemaheader" style="width: 993px"
                        cellpadding="0" cellspacing="0" border="0" onmousedown="DialogMonthlyOperationGanttChartSchema.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyOperationGanttChartSchema_topLeftImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/top_left.gif" alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogMonthlyOperationGanttChartSchema" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogMonthlyOperationGanttChartSchema" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogMonthlyOperationGanttChartSchema_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogMonthlyOperationGanttChartSchema').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogMonthlyOperationGanttChartSchema_topRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/top_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogMonthlyOperationGanttChartSchemafooter">
                    <table id="tbl_DialogMonthlyOperationGanttChartSchemafooter" style="width: 993px"
                        cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyOperationGanttChartSchema_downLeftImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_left.gif" alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogMonthlyOperationGanttChartSchema_downRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogMonthlyOperationGanttChartSchema_onShow" />
                <OnClose EventHandler="DialogMonthlyOperationGanttChartSchema_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogUnderManagementPersonnelheader" FooterClientTemplateId="DialogUnderManagementPersonnelfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogUnderManagementPersonnel"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/UnderManagementPersonnel.aspx"
            IFrameCssClass="UnderManagementPersonnel_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogUnderManagementPersonnelheader">
                    <table style="width: 953px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogUnderManagementPersonnel.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogUnderManagementPersonnel_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogUnderManagementPersonnel" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogUnderManagementPersonnel" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogUnderManagementPersonnel_IFrame').src =parent.ModulePath + 'WhitePage.aspx',eval(ClientPerfixId + 'DialogUnderManagementPersonnel').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogUnderManagementPersonnel_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogUnderManagementPersonnelfooter">
                    <table id="tbl_DialogUnderManagementPersonnelfooter" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogUnderManagementPersonnel_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogUnderManagementPersonnel_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogUnderManagementPersonnel_onShow" />
                <OnClose EventHandler="DialogUnderManagementPersonnel_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogKartableheader" FooterClientTemplateId="DialogKartablefooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogKartable"
            runat="server" PreloadContentUrl="false" ContentUrl="about:blank" IFrameCssClass="Kartable_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogKartableheader">
                    <table id="tbl_DialogKartableheader" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogKartable.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogKartable_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogKartable" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogKartable" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogKartable_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogKartable').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogKartable_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogKartablefooter">
                    <table id="tbl_DialogKartablefooter" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogKartable_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogKartable_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogKartable_onShow" />
                <OnClose EventHandler="DialogKartable_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogEndorsementFlowStateheader" FooterClientTemplateId="DialogEndorsementFlowStatefooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogEndorsementFlowState"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/EndorsementFlowState.aspx"
            IFrameCssClass="EndorsementFlowState_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogEndorsementFlowStateheader">
                    <table style="width: 802px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogEndorsementFlowState.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogEndorsementFlowState_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogEndorsementFlowState" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogEndorsementFlowState" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogEndorsementFlowState_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogEndorsementFlowState').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogEndorsementFlowState_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogEndorsementFlowStatefooter">
                    <table id="tbl_DialogEndorsementFlowStatefooter" style="width: 802px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogEndorsementFlowState_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogEndorsementFlowState_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogEndorsementFlowState_onShow" />
                <OnClose EventHandler="DialogEndorsementFlowState_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogRegisteredRequestsheader" FooterClientTemplateId="DialogRegisteredRequestsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" ID="DialogRegisteredRequests"
            Alignment="Default" runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/RegisteredRequests.aspx"
            IFrameCssClass="RegisteredRequests_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRegisteredRequestsheader">
                    <table id="tbl_DialogRegisteredRequestsheader" style="width: 978px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogRegisteredRequests.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRegisteredRequests_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRegisteredRequests" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogRegisteredRequests" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogRegisteredRequests_IFrame').src = 'DesktopModules/Atlas/WhitePage.aspx';eval(ClientPerfixId + 'DialogRegisteredRequests').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRegisteredRequests_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRegisteredRequestsfooter">
                    <table id="tbl_DialogRegisteredRequestsfooter" style="width: 978px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRegisteredRequests_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRegisteredRequests_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRegisteredRequests_onShow" />
                <OnClose EventHandler="DialogRegisteredRequests_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogCalculationRange"
            HeaderClientTemplateId="DialogCalculationRangeheader" FooterClientTemplateId="DialogCalculationRangefooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/CalculationRange.aspx" IFrameCssClass="CalculationRange_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogCalculationRangeheader">
                    <table id="tbl_DialogCalculationRangeheader" style="width: 903px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogCalculationRange.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogCalculationRange_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogCalculationRange" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogCalculationRange" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogCalculationRange_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogCalculationRange').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogCalculationRange_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogCalculationRangefooter">
                    <table id="tbl_DialogCalculationRangefooter" style="width: 903px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogCalculationRange_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogCalculationRange_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogCalculationRange_onShow" />
                <OnClose EventHandler="DialogCalculationRange_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogRulesGroupUpdate"
            HeaderClientTemplateId="DialogRulesGroupUpdateheader" FooterClientTemplateId="DialogRulesGroupUpdatefooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/OvertimeJustificationRequest.aspx"
            IFrameCssClass="RulesGroupUpdate_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRulesGroupUpdateheader">
                    <table id="tbl_DialogRulesGroupUpdateheader" style="width: 993px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogRulesGroupUpdate.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRulesGroupUpdate_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRulesGroupUpdate" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogRulesGroupUpdate" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogRulesGroupUpdate_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogRulesGroupUpdate').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRulesGroupUpdate_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRulesGroupUpdatefooter">
                    <table id="tbl_DialogRulesGroupUpdatefooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRulesGroupUpdate_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRulesGroupUpdate_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRulesGroupUpdate_onShow" />
                <OnClose EventHandler="DialogRulesGroupUpdate_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogReportParametersheader" FooterClientTemplateId="DialogReportParametersfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogReportParameters"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ReportParameters.aspx" IFrameCssClass="ReportParameters_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogReportParametersheader">
                    <table id="tbl_DialogReportParametersheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogReportParameters.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogReportParameters_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogReportParameters" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogReportParameters" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogReportParameters_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogReportParameters').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogReportParameters_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogReportParametersfooter">
                    <table id="tbl_DialogReportParametersfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogReportParameters_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogReportParameters_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogReportParameters_onShow" />
                <OnClose EventHandler="DialogReportParameters_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogSubstituteSettingsheader" FooterClientTemplateId="DialogSubstituteSettingsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogSubstituteSettings"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/SubstituteSettings.aspx"
            IFrameCssClass="SubstituteSettings_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogSubstituteSettingsheader">
                    <table style="width: 753px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogSubstituteSettings.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogSubstituteSettings_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogSubstituteSettings" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogSubstituteSettings" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogSubstituteSettings_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogSubstituteSettings').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogSubstituteSettings_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogSubstituteSettingsfooter">
                    <table id="tbl_DialogSubstituteSettingsfooter" style="width: 753px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogSubstituteSettings_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogSubstituteSettings_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogSubstituteSettings_onShow" />
                <OnClose EventHandler="DialogSubstituteSettings_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogOperatorsheader" FooterClientTemplateId="DialogOperatorsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogOperators"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/Operators.aspx" IFrameCssClass="Operators_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogOperatorsheader">
                    <table id="tbl_DialogOperatorsheader" style="width: 802px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogOperators.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogOperators_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogOperators" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogOperators" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogOperators_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogOperators').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogOperators_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogOperatorsfooter">
                    <table id="tbl_DialogOperatorsfooter" style="width: 802px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogOperators_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogOperators_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogOperators_onShow" />
                <OnClose EventHandler="DialogOperators_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogLeaveReserve"
            HeaderClientTemplateId="DialogLeaveReserveheader" FooterClientTemplateId="DialogLeaveReservefooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/LeaveReserve.aspx" IFrameCssClass="LeaveReserve_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogLeaveReserveheader">
                    <table id="tbl_DialogLeaveReserveheader" style="width: 803px;" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogLeaveReserve.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogLeaveReserve_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogLeaveReserve" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogLeaveReserve" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogLeaveReserve_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogLeaveReserve').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogLeaveReserve_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogLeaveReservefooter">
                    <table id="tbl_DialogLeaveReservefooter" style="width: 803px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogLeaveReserve_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogLeaveReserve_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogLeaveReserve_onShow" />
                <OnClose EventHandler="DialogLeaveReserve_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogMasterRulesViewheader" FooterClientTemplateId="DialogMasterRulesViewfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogMasterRulesView"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/MasterRulesView.aspx" IFrameCssClass="MasterRulesView_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogMasterRulesViewheader">
                    <table id="tbl_DialogMasterRulesViewheader" style="width: 723px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogMasterRulesView.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogMasterRulesView_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogMasterRulesView" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogMasterRulesView" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogMasterRulesView_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogMasterRulesView').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogMasterRulesView_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogMasterRulesViewfooter">
                    <table id="tbl_DialogMasterRulesViewfooter" style="width: 723px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogMasterRulesView_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogMasterRulesView_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogMasterRulesView_onShow" />
                <OnClose EventHandler="DialogMasterRulesView_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogMasterDataAccessLevelsheader" FooterClientTemplateId="DialogMasterDataAccessLevelsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogMasterDataAccessLevels"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/MonthlyExceptionShifts.aspx" IFrameCssClass="MasterDataAccessLevels_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogMasterDataAccessLevelsheader">
                    <table id="tbl_DialogMasterDataAccessLevelsheader" style="width: 903px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogMasterDataAccessLevels.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogMasterDataAccessLevels_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogMasterDataAccessLevels" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogMasterDataAccessLevels" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogMasterDataAccessLevels_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogMasterDataAccessLevels').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogMasterDataAccessLevels_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogMasterDataAccessLevelsfooter">
                    <table id="tbl_DialogMasterDataAccessLevelsfooter" style="width: 903px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogMasterDataAccessLevels_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogMasterDataAccessLevels_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogMasterDataAccessLevels_onShow" />
                <OnClose EventHandler="DialogMasterDataAccessLevels_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogSendPrivateMessageheader" FooterClientTemplateId="DialogSendPrivateMessagefooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogSendPrivateMessage"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/SendPrivateMessage.aspx"
            IFrameCssClass="SendPrivateMessage_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogSendPrivateMessageheader">
                    <table style="width: 903px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogSendPrivateMessage.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogSendPrivateMessage_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogSendPrivateMessage" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogSendPrivateMessage" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogSendPrivateMessage_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogSendPrivateMessage').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogSendPrivateMessage_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogSendPrivateMessagefooter">
                    <table id="tbl_DialogSendPrivateMessagefooter" style="width: 903px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogSendPrivateMessage_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogSendPrivateMessage_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogSendPrivateMessage_onShow" />
                <OnClose EventHandler="DialogSendPrivateMessage_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogUiValidationRulesheader" FooterClientTemplateId="DialogUiValidationRulesfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogUiValidationRules"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/UiValidationRules.aspx"
            IFrameCssClass="UiValidationRules_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogUiValidationRulesheader">
                    <table style="width: 903px" cellpadding="0" cellspacing="0" border="0" onmousedown="DialogUiValidationRules.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogUiValidationRules_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogUiValidationRules" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogUiValidationRules" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogUiValidationRules_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogUiValidationRules').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogUiValidationRules_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogUiValidationRulesfooter">
                    <table id="tbl_DialogUiValidationRulesfooter" style="width: 903px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogUiValidationRules_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogUiValidationRules_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogUiValidationRules_onShow" />
                <OnClose EventHandler="DialogUiValidationRules_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogUserSettings"
            HeaderClientTemplateId="DialogUserSettingsheader" FooterClientTemplateId="DialogUserSettingsfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/UserSettings.aspx" IFrameCssClass="UserSettings_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogUserSettingsheader">
                    <table id="tbl_DialogUserSettingsheader" style="width: 703px;" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogUserSettings.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogUserSettings_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogUserSettings" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogUserSettings" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogUserSettings_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogUserSettings').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogUserSettings_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogUserSettingsfooter">
                    <table id="tbl_DialogUserSettingsfooter" style="width: 703px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogUserSettings_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogUserSettings_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogUserSettings_onShow" />
                <OnClose EventHandler="DialogUserSettings_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogTrafficsTransfer"
            HeaderClientTemplateId="DialogTrafficsTransferheader" FooterClientTemplateId="DialogTrafficsTransferfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/TrafficsTransfer.aspx" IFrameCssClass="TrafficsTransfer_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogTrafficsTransferheader">
                    <table id="tbl_DialogTrafficsTransferheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogTrafficsTransfer.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogTrafficsTransfer_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogTrafficsTransfer" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogTrafficsTransfer" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogTrafficsTransfer_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogTrafficsTransfer').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogTrafficsTransfer_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogTrafficsTransferfooter">
                    <table id="tbl_DialogTrafficsTransferfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogTrafficsTransfer_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogTrafficsTransfer_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogTrafficsTransfer_onShow" />
                <OnClose EventHandler="DialogTrafficsTransfer_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogSystemReportsheader" FooterClientTemplateId="DialogSystemReportsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogSystemReports"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/SystemReports.aspx"
            IFrameCssClass="SystemReports_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogSystemReportsheader">
                    <table id="tbl_DialogSystemReportsheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogSystemReports.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogSystemReports_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogSystemReports" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogSystemReports" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogSystemReports_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogSystemReports').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogSystemReports_topRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/top_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogSystemReportsfooter">
                    <table id="tbl_DialogSystemReportsfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogSystemReports_downLeftImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_left.gif" alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogSystemReports_downRightImage" style="display: block;"
                                    src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogSystemReports_onShow" />
                <OnClose EventHandler="DialogSystemReports_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogMonthlyExceptionShiftsheader" FooterClientTemplateId="DialogMonthlyExceptionShiftsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogMonthlyExceptionShifts"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/MonthlyExceptionShifts.aspx" IFrameCssClass="MonthlyExceptionShifts_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogMonthlyExceptionShiftsheader">
                    <table id="tbl_DialogMonthlyExceptionShiftsheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogMonthlyExceptionShifts.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyExceptionShifts_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogMonthlyExceptionShifts" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogMonthlyExceptionShifts" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogMonthlyExceptionShifts_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogMonthlyExceptionShifts').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogMonthlyExceptionShifts_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogMonthlyExceptionShiftsfooter">
                    <table id="tbl_DialogMonthlyExceptionShiftsfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogMonthlyExceptionShifts_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogMonthlyExceptionShifts_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogMonthlyExceptionShifts_onShow" />
                <OnClose EventHandler="DialogMonthlyExceptionShifts_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogUpdateCalculationResultheader" FooterClientTemplateId="DialogUpdateCalculationResultfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogUpdateCalculationResult"
            runat="server" PreloadContentUrl="false" ContentUrl="about:blank" IFrameCssClass="UpdateCalculationResult_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogUpdateCalculationResultheader">
                    <table id="tbl_DialogUpdateCalculationResultheader" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogUpdateCalculationResult.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogUpdateCalculationResult_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogUpdateCalculationResult" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogUpdateCalculationResult" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogUpdateCalculationResult_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogUpdateCalculationResult').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogUpdateCalculationResult_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogUpdateCalculationResultfooter">
                    <table id="tbl_DialogUpdateCalculationResultfooter" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogUpdateCalculationResult_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogUpdateCalculationResult_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogUpdateCalculationResult_onShow" />
                <OnClose EventHandler="DialogUpdateCalculationResult_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogDesignedReportsSelectColumnsheader" FooterClientTemplateId="DialogDesignedReportsSelectColumnfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogDesignedReportsSelectColumn"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/DesignedReportsSelectColumn.aspx" IFrameCssClass="DesignedReportsSelectColumn_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogDesignedReportsSelectColumnsheader">
                    <table id="tbl_DialogDesignedReportsSelectColumnsheader" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogUpdateCalculationResult.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogDesignedReportsSelectColumn_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogDesignedReportsSelectColumn" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogDesignedReportsSelectColumn" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogDesignedReportsSelectColumn_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogDesignedReportsSelectColumn').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogDesignedReportsSelectColumn_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogDesignedReportsSelectColumnfooter">
                    <table id="Table2" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogDesignedReportsSelectColumn_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogDesignedReportsSelectColumn_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogDesignedReportsSelectColumn_onShow" />
                <OnClose EventHandler="DialogDesignedReportsSelectColumn_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogReportParametersConditionsheader" FooterClientTemplateId="DialogReportParametersConditionsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogReportParametersConditions"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ReportParametersConditions.aspx" IFrameCssClass="ReportParametersConditions_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogReportParametersConditionsheader">
                    <table id="Table3" style="width: 993px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogUpdateCalculationResult.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogReportParametersConditions_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogReportParametersConditions" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogReportParametersConditions" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogReportParametersConditions_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogReportParametersConditions').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogReportParametersConditions_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogReportParametersConditionsfooter">
                    <table id="Table4" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogReportParametersConditions_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogReportParametersConditions_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogReportParametersConditions_onShow" />
                <OnClose EventHandler="DialogReportParametersConditions_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogDefinePhysiciansheader" FooterClientTemplateId="DialogDefinePhysiciansfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogDefinePhysicians"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/DefinePhysicians.aspx" IFrameCssClass="DefinePhysicians_IFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogDefinePhysiciansheader">
                    <table id="tbl_DialogDefinePhysiciansheader" style="width: 453px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogDefinePhysicians.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogDefinePhysicians_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogDefinePhysicians" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogDefinePhysicians" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogDefinePhysicians_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogDefinePhysicians').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogDefinePhysicians_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogDefinePhysiciansfooter">
                    <table id="tbl_DialogDefinePhysiciansfooter" style="width: 453px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogDefinePhysicians_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogDefinePhysicians_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogDefinePhysicians_onShow" />
                <OnClose EventHandler="DialogDefinePhysicians_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogDefineIllnessheader" FooterClientTemplateId="DialogDefineIllnessfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogDefineIllness"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/DefineIllness.aspx" IFrameCssClass="DefineIllness_IFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogDefineIllnessheader">
                    <table id="tbl_DialogDefineIllnessheader" style="width: 453px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogDefineIllness.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogDefineIllness_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogDefineIllness" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogDefineIllness" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogDefineIllness_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogDefineIllness').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogDefineIllness_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogDefineIllnessfooter">
                    <table id="tbl_DialogDefineIllnessfooter" style="width: 453px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogDefineIllness_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogDefineIllness_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogDefineIllness_onShow" />
                <OnClose EventHandler="DialogDefineIllness_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogConceptsManagement"
            HeaderClientTemplateId="DialogConceptsManagementheader" FooterClientTemplateId="DialogConceptsManagementfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ConceptsManagement.aspx" IFrameCssClass="ConceptsManagement_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogConceptsManagementheader">
                    <table id="tbl_DialogConceptsManagementheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogConceptsManagement.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogConceptsManagement_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogConceptsManagement" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogConceptsManagement" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogConceptsManagement_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogConceptsManagement').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogConceptsManagement_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogConceptsManagementfooter">
                    <table id="tbl_DialogConceptsManagementfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogConceptsManagement_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogConceptsManagement_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogConceptsManagement_onShow" />
                <OnClose EventHandler="DialogConceptsManagement_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogRuleGenerator"
            HeaderClientTemplateId="DialogRuleGeneratorheader" FooterClientTemplateId="DialogRuleGeneratorfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="RuleGenerator.aspx" IFrameCssClass="RuleGenerator_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRuleGeneratorheader">
                    <table id="tbl_DialogRuleGeneratorheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogRuleGenerator.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRuleGenerator_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRuleGenerator" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogRuleGenerator" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById('DialogRuleGenerator_IFrame').src = 'WhitePage.aspx'; DialogRuleGenerator.Close('cancelled');RefreshGridInParentForm();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRuleGenerator_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRuleGeneratorfooter">
                    <table id="tbl_DialogRuleGeneratorfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRuleGenerator_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRuleGenerator_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRuleGenerator_onShow" />
                <OnClose EventHandler="DialogRuleGenerator_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogRulesManagement"
            HeaderClientTemplateId="DialogRulesManagementheader" FooterClientTemplateId="DialogRulesManagementfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/RulesManagement.aspx" IFrameCssClass="RulesManagement_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRulesManagementheader">
                    <table id="tbl_DialogRulesManagementheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogRulesManagement.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRulesManagement_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRulesManagement" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogRulesManagement" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogRulesManagement_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogRulesManagement').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRulesManagement_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRulesManagementfooter">
                    <table id="tbl_DialogRulesManagementfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRulesManagement_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRulesManagement_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRulesManagement_onShow" />
                <OnClose EventHandler="DialogRulesManagement_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="True" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogConceptRuleEditor"
            HeaderClientTemplateId="DialogConceptRuleEditorheader" FooterClientTemplateId="DialogConceptRuleEditorfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ConceptRuleEditor.aspx" IFrameCssClass="ConceptRuleEditor_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogConceptRuleEditorheader">
                    <table id="tbl_DialogConceptRuleEditorheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogConceptRuleEditor.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogConceptRuleEditor_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogConceptRuleEditor" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogConceptRuleEditor" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogConceptRuleEditor_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogConceptRuleEditor').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogConceptRuleEditor_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogConceptRuleEditorfooter">
                    <table id="tbl_DialogConceptRuleEditorfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogConceptRuleEditor_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogConceptRuleEditor_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogConceptRuleEditor_onShow" />
                <OnClose EventHandler="DialogConceptRuleEditor_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="True" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogExpressionsManagement"
            HeaderClientTemplateId="DialogExpressionsManagementheader" FooterClientTemplateId="DialogExpressionsManagementfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/ExpressionsManagement.aspx" IFrameCssClass="ExpressionsManagement_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogExpressionsManagementheader">
                    <table id="tbl_DialogExpressionsManagementheader" style="width: 503px;" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogExpressionsManagement.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogExpressionsManagement_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogExpressionsManagement" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold;"></td>
                                        <td id="CloseButton_DialogExpressionsManagement" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogExpressionsManagement_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId +  'DialogExpressionsManagement').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogExpressionsManagement_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogExpressionsManagementfooter">
                    <table id="tbl_DialogExpressionsManagementfooter" style="width: 503px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogExpressionsManagement_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogExpressionsManagement_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif" alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogExpressionsManagement_onShow" />
                <OnClose EventHandler="DialogExpressionsManagement_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogOnlineTrafficsheader" FooterClientTemplateId="DialogOnlineTrafficsfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="Default" ID="DialogOnlineTraffics"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/OnlineTraffics.aspx"
            IFrameCssClass="OnlineTraffics_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogOnlineTrafficsheader">
                    <table id="tbl_DialogOnlineTrafficsheader" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogOnlineTraffics.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogOnlineTraffics_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogOnlineTraffics" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogOnlineTraffics" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogOnlineTraffics_IFrame').contentWindow.DialogOnlineTraffics_onClose();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogOnlineTraffics_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogOnlineTrafficsfooter">
                    <table id="tbl_DialogOnlineTrafficsfooter" style="width: 993px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogOnlineTraffics_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogOnlineTraffics_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogOnlineTraffics_onShow" />
                <OnClose EventHandler="DialogOnlineTraffics_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/mages/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogFlowConditions"
            HeaderClientTemplateId="DialogFlowConditionsheader" FooterClientTemplateId="DialogFlowConditionsfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/FlowConditions.aspx" IFrameCssClass="FlowConditions_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogFlowConditionsheader">
                    <table id="tbl_DialogFlowConditionsheader" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogFlowConditions.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogFlowConditions_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogFlowConditions" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogFlowConditions" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogFlowConditions_IFrame').src =parent.ModulePath + 'WhitePage.aspx';eval(ClientPerfixId + 'DialogFlowConditions').Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogFlowConditions_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogFlowConditionsfooter">
                    <table id="tbl_DialogFlowConditionsfooter" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogFlowConditions_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogFlowConditions_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogFlowConditions_onShow" />
                <OnClose EventHandler="DialogFlowConditions_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogRequestHistoryheader" FooterClientTemplateId="DialogRequestHistoryfooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogRequestHistory"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/RequestHistory.aspx" IFrameCssClass="RequestHistory_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRequestHistoryheader">
                    <table id="tbl_DialogRequestHistoryheader" style="width: 812px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogRequestHistory.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRequestHistory_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRequestHistory" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogRequestHistory" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="eval(ClientPerfixId + 'DialogRequestHistory').Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRequestHistory_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRequestHistoryfooter">
                    <table id="tbl_DialogRequestHistoryfooter" style="width: 812px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRequestHistory_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRequestHistory_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRequestHistory_onShow" />
                <OnClose EventHandler="DialogRequestHistory_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogRulePrecards"
            HeaderClientTemplateId="DialogRulePrecardsheader" FooterClientTemplateId="DialogRulePrecardsfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/RulePrecards.aspx" IFrameCssClass="RulePrecards_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRulePrecardsheader">
                    <table id="tbl_DialogRulePrecardsheader" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogRulePrecards.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRulePrecards_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRulePrecards" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogRulePrecards" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId  + 'DialogRulePrecards_IFrame').src = 'DesktopModules/Atlas/WhitePage.aspx'; DialogRulePrecards.Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRulePrecards_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRulePrecardsfooter">
                    <table id="tbl_DialogRulePrecardsfooter" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRulePrecards_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRulePrecards_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRulePrecards_onShow" />
                <OnClose EventHandler="DialogRulePrecards_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>  
         <ComponentArt:Dialog ModalMaskImage="DesktopModules/Atlas/Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopLeft" ID="DialogWorkFlowDetail"
            HeaderClientTemplateId="DialogWorkFlowDetailheader" FooterClientTemplateId="DialogWorkFlowDetailfooter"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/WorkFlowDetail.aspx" IFrameCssClass="WorkFlowDetail_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogWorkFlowDetailheader">
                    <table id="tbl_DialogWorkFlowDetailheader" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0" onmousedown="DialogWorkFlowDetail.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogWorkFlowDetail_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogWorkFlowDetail" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogWorkFlowDetail" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').src = 'DesktopModules/Atlas/WhitePage.aspx'; DialogWorkFlowDetail.Close('cancelled');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogWorkFlowDetail_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogWorkFlowDetailfooter">
                    <table id="tbl_DialogWorkFlowDetailfooter" style="width: 953px" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogWorkFlowDetail_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogWorkFlowDetail_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogWorkFlowDetail_onShow" />
                <OnClose EventHandler="DialogWorkFlowDetail_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>
        
        <ComponentArt:Dialog ModalMaskImage="Images/Dialog/alpha.png" HeaderCssClass="headerCss"
            HeaderClientTemplateId="DialogRequestRefrenceheader" FooterClientTemplateId="DialogRequestRefrencefooter"
            Modal="true" AllowResize="false" AllowDrag="false" Alignment="TopCentre" ID="DialogRequestRefrence"
            runat="server" PreloadContentUrl="false" ContentUrl="DesktopModules/Atlas/RequestRefrence.aspx" IFrameCssClass="RequestRefrence_iFrame">
            <ClientTemplates>
                <ComponentArt:ClientTemplate ID="DialogRequestRefrenceheader">
                    <table id="tbl_DialogRequestRefrenceheader" style="width: 903px" cellpadding="0" cellspacing="0"
                        border="0" onmousedown="DialogRequestRefrence.StartDrag(event);">
                        <tr>
                            <td width="6">
                                <img id="DialogRequestRefrence_topLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/top.gif); padding: 3px">
                                <table style="width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td id="Title_DialogRequestRefrence" valign="bottom" style="color: White; font-size: 13px; font-family: Arial; font-weight: bold"></td>
                                        <td id="CloseButton_DialogRequestRefrence" valign="middle">
                                            <img alt="" src="DesktopModules/Atlas/Images/Dialog/close-down.png" onclick="document.getElementById(ClientPerfixId  + 'DialogRequestRefrence_IFrame').src = 'DesktopModules/Atlas/WhitePage.aspx'; DialogRequestRefrence.Close('cancelled')" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                <img id="DialogRequestRefrence_topRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/top_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
                <ComponentArt:ClientTemplate ID="DialogRequestRefrencefooter">
                    <table id="tbl_DialogRequestRefrencefooter" style="width: 903px" cellpadding="0" cellspacing="0"
                        border="0">
                        <tr>
                            <td width="6">
                                <img id="DialogRequestRefrence_downLeftImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_left.gif"
                                    alt="" />
                            </td>
                            <td style="background-image: url(DesktopModules/Atlas/Images/Dialog/down.gif); background-repeat: repeat; padding: 3px"></td>
                            <td width="6">
                                <img id="DialogRequestRefrence_downRightImage" style="display: block;" src="DesktopModules/Atlas/Images/Dialog/down_right.gif"
                                    alt="" />
                            </td>
                        </tr>
                    </table>
                </ComponentArt:ClientTemplate>
            </ClientTemplates>
            <ClientEvents>
                <OnShow EventHandler="DialogRequestRefrence_onShow" />
                <OnClose EventHandler="DialogRequestRefrence_onClose" />
            </ClientEvents>
        </ComponentArt:Dialog>

        <asp:HiddenField runat="server" ID="hfdmItemPersonnelMasterMonthlyOperationReport_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemManagerMasterMonthlyOperationReport_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemPersonnelIntroduction_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemReportsIntroduction_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemKartable_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemSurveyedRequests_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemRegisteredRequests_DockMenu" />
        <asp:HiddenField runat="server" ID="hfdmItemTrafficOperationByOperator_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemWorkFlowsView_DockMenu"  />
        <asp:HiddenField runat="server" ID="hfdmItemWelcome_DockMenu" />
        <asp:HiddenField runat="server" ID="hfErrorType_MainForm"  />
        <asp:HiddenField runat="server" ID="hfConnectionError_MainForm"  />
        <asp:HiddenField runat="server" ID="hfCurrentUILangID" />
        <asp:HiddenField runat="server" ID="hfCurrentSysLangID" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemHome" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemWorkFlowsView"  />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemTrafficsControl"  />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemRegisteredRequests"  />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemSurveyedRequests"  />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemKartable" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemReportsIntroduction" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemPersonnelIntroduction" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemManagerMasterMonthlyOperationReport" />
        <asp:HiddenField runat="server" ID="hfTitle_qlItemPersonnelMasterMonthlyOperationReport" />
        <asp:HiddenField runat="server" ID="hfAccessNoAllowdNavBarItemsList" />
        <asp:HiddenField runat="server" ID="hfMonthlyOperationSchema_MainForm" />
    </div>
