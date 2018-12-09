function matchpass() {
    var pw0 = document.getElementById('0').value;
    var pw1 = document.getElementById('1').value;
    var pw2 = document.getElementById('2').value;
    if (pw0 == '') {
        alert("Bạn chưa nhập mật khẩu hiện tại!");
    }
    if (pw1 == '') {
        alert("Bạn chưa nhập mật khẩu mới!");
    }
    if (pw2 == '') {
        alert("Bạn chưa nhập lại mật khẩu mới!");
    }
    if (pw1 != pw2) {
        alert("Mật khẩu không khớp!");
   
    }

    else
        alert("Đổi mật khẩu thành công!")

}
function matchin4() {
    var id = document.getElementById('id').value;
    var name = document.getElementById('namegv').value;
    var phone = document.getElementById('phonegv').value;
    var dt = document.getElementById('dtgv').value;
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (id == '') {
        alert("Bạn chưa nhập mã giáo viên!");
    }
    if (name == '') {
        alert("Bạn chưa nhập họ và tên!");
    }

    if (!filter.test(email.value)) {
        alert('Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com');
        email.focus;

    }
    if (phone == '') {
        alert("Bạn chưa nhập số điện thoại!");
    }
    if (phone != '' && Number.isNaN(phone) == false) {
        alert("Bạn phải nhập số ở mục số điện thoại");
    }
    if (dt == '') {
        alert("Bạn chưa nhập trình độ!");
    }


    else
        return false;
}