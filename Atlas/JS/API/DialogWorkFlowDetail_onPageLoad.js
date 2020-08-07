﻿var DialogWorkFlowDetailMode = '';

function DialogWorkFlowDetail_onShow(sender, e) {
    CurrentLangID = parent.CurrentLangID;
    var ObjDialogWorkFlowDetail = parent.DialogWorkFlowDetail.get_value();
    var RequestCaller = ObjDialogWorkFlowDetail.RequestCaller;
    var Applicant = ObjDialogWorkFlowDetail.Applicant;
    var KeyApplicant = ObjDialogWorkFlowDetail.KeyApplicant;
    var LastRequestDate = ObjDialogWorkFlowDetail.LastRequestDate;
    var contentUrl_DialogWorkFlowDetail =parent.ModulePath + "WorkFlowDetail.aspx?RequestCaller=" + CharToKeyCode(RequestCaller) + "&Applicant=" + CharToKeyCode(Applicant) + "&KeyApplicant=" + CharToKeyCode(KeyApplicant) + "&LastRequestDate=" + CharToKeyCode(LastRequestDate);
    DialogWorkFlowDetail.set_contentUrl(contentUrl_DialogWorkFlowDetail);
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.display = '';
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.visibility = 'visible';

    if (CurrentLangID == 'fa-IR') {
        document.getElementById('DialogWorkFlowDetail_topLeftImage').src = parent.ModulePath + 'Images/Dialog/top_right.gif';
        document.getElementById('DialogWorkFlowDetail_topRightImage').src = parent.ModulePath + 'Images/Dialog/top_left.gif';
        document.getElementById('DialogWorkFlowDetail_downLeftImage').src = parent.ModulePath + 'Images/Dialog/down_right.gif';
        document.getElementById('DialogWorkFlowDetail_downRightImage').src = parent.ModulePath + 'Images/Dialog/down_left.gif';        
        document.getElementById('CloseButton_DialogWorkFlowDetail').align = 'left';
    }
    if (CurrentLangID == 'en-US')
        document.getElementById('CloseButton_DialogWorkFlowDetail').align = 'right';

    ChangeStyle_DialogWorkFlowDetail();
}

function DialogWorkFlowDetail_onClose(sender, e) {
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.display = 'none';
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.visibility = 'hidden';
    DialogWorkFlowDetail.set_contentUrl("about:blank");
}

function CharToKeyCode(str) {
    var OutStr = '';
    if (str != null && str != undefined) {
        for (var i = 0; i < str.length; i++) {
            var KeyCode = str.charCodeAt(i);
            var CharKeyCode = '//' + KeyCode;
            OutStr += CharKeyCode;
        }
    }
    return OutStr;
}

function ChangeStyle_DialogWorkFlowDetail() {
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.width = (screen.width - 10).toString() + 'px';
    document.getElementById(ClientPerfixId + 'DialogWorkFlowDetail_IFrame').style.height = (0.75 * screen.height).toString() + 'px';
    document.getElementById('tbl_DialogWorkFlowDetailheader').style.width = document.getElementById('tbl_DialogWorkFlowDetailfooter').style.width = (screen.width - 7).toString() + 'px';
}

