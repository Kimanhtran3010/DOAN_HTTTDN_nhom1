﻿function matchpass() {
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
    function test() {
        alert("ahihi");
    }

function matchinfor()
{
    var name = document.getElementById('namegv');
            var phone = document.getElementById('phonegv');
            var sex = document.getElementById('sexgv');
            var diachi = document.getElementById('diachigv');
            var trinhdo = document.getElementById('trinhdogv');
            var trangthai = document.getElementById('trangthaigv');
    var filter = /^([a-zA-Z0-9_\.\-])+\ @(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (name == null)
    {
        alert("Chưa nhập họ tên");
        //return false;
    }
                
    if (sex == null)
    {
        alert("Chưa nhập giới tính");
        //return false;
    }
        
    if (phone == null || phone != null && Number.isNaN(phone) == false)
    {
                alert("Nhập lại số điện thoại");
                //return false;
    }
    if (diachi == null)
    {
        alert("Chưa nhập địa chỉ");
        //return false;
    }
       
    if (trinhdo == null)
    {
        alert("Chưa nhập trình độ");
        //return false;
    }
       
    if (trangthai == null)
    {
        alert("Chưa nhập trạng thái");
        //return false;
    }
        
    if (!filter.test(email.value))
    {
        alert("Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com");
        email.focus;
        return false;
    }

    else
    {
        alert("dữ liệu ok");
        return true;
    }
}
     

