function matchpass() {
    var pw0 = document.getElementById('0').value;
    var pw1 = document.getElementById('1').value;
    var pw2 = document.getElementById('2').value;
    if (pw0 == '') {
        alert("Bạn chưa nhập mật khẩu hiện tại!");
        return false;
    }
    if (pw1 == '') {
        alert("Bạn chưa nhập mật khẩu mới!");
        return false;
    }
    if (pw2 == '') {
        alert("Bạn chưa nhập lại mật khẩu mới!");
        return false;
    }
    if (pw1 != pw2) {
        alert("Mật khẩu không khớp!");
        return false;
    }

    else
        return true;

}