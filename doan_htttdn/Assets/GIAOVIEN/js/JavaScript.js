function matchpass() {
    var pw0 = document.getElementById('0').value;
    var pw1 = document.getElementById('1').value;
    var pw2 = document.getElementById('2').value;
    if (pw0 == '') {
        alert("Bạn chưa nhập mật khẩu hiện tại!");
        return false;
    }
    else
    {
        if (pw1 == '') {
            alert("Bạn chưa nhập mật khẩu mới!"); return false;
        }
        else
        {
            if (pw2 == '') {
                alert("Bạn chưa nhập lại mật khẩu mới!");
                return false;
            }
            else {

                if (pw1 != pw2) {
                    alert("Mật khẩu không khớp!");
                    return false;

                }
                else


                    return true;
            }
            
        }
        

    }
        //alert("Đổi mật khẩu thành công!")

}
function matchinfor() {
    var name = document.getElementById('namegv').value;
    var phone = document.getElementById('phonegv').value;
    //var dt = document.getElementById('dtgv').value;
    //var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
 
    //if (name == '') {
    //    alert("Bạn chưa nhập họ và tên!");
    //}

    //if (!filter.test(email.value)) {
    //    alert('Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com');
    //    email.focus;

    //}
    
    if (phone =='' || ( phone != '' && Number.isNaN(phone)) == false) {
        alert("Bạn phải nhập số ở mục số điện thoại");
        return false;
    }
    //if (dt == '') {
    //    alert("Bạn chưa nhập trình độ!");
    //}


    else
        return true;
}