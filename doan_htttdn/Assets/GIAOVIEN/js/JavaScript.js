//function test() {
//    var pw1 = document.getElementById('1');
//    var pw2 = document.getElementById('2');

    
//    if (pw1 != pw2) {
//        alert("\nYou did not enter the same new password twice. Please re-enter your password.");
//        return false;
//    }
//    else return true;
//}
function matchpass() {
    var pw0 = document.getElementById('0');
    var pw1 = document.getElementById('1');
    var pw2 = document.getElementById('2');
    alert("mạhjs");
    if (pw1 != pw2) {
        alert("Mật khẩu không khớp!");
        return false;
    }
    else
        return true;
    if (pw0 == "") {
        alert("Bạn chưa nhập mật khẩu!");
        return false;
    }
    else
        return true;
     
    }
    
}
//function kiemtra() {
//    var pw0 = Document.getElementById('0');
//    var pw1 = Document.getElementById('1');
//    var pw2 = Document.getElementById('2');
//    if (pw0 == null || pw1 == null || pw2 == null) {
//        alert("Vui lòng nhập đủ thông tin:");
//        return false;
//    }
//    return true;
//}
// End -->