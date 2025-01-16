
var gid;

function del(id) {
    gid = id;

    $('#del').modal('show');

}


function confirmdel1()
{
    window.location.href = "DeleteCategories?id="+gid;
}
//

//
function addtocart(id) {
    $.ajax({
        url: 'AddHoteltocart',
        type: 'POST',
        data: { id: id },
        success: function (result) {
            console.log(result.count);
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,1111111111
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "  تم الإضافة الى السلة بنحاح   "
            });
            //
            var cart = document.getElementById("cart");
            cart.innerHTML = result.count;
        }

    });

}
function AdvanceSearch(Name) {

    $.ajax({
        url: 'AdvanceSearch',
        type: 'POST',
        data: { Name: Name },
        success: function (result) {

            $('#categoreisContainer').html(result);

        }

    });
   

}
function confirmdel() {
    $.ajax({
       
        url: 'DeleteCategories',
        type:'POST',
        data: { id: gid },
        success: function (result) {
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "  تم الحذف بنجاح "
            });

            
            //window.location.href = "Home";
            $('#categoreisContainer').html(result);
        },

      
   
    });
}

