$(document).ready(function () {
    function Details(id) {
        $.get("http://localhost:57424/api/users/getuser/" + id, function (data) {

            $("#1").html(data.UserID);
            $("#2").html(data.UserName);
            $("#3").html(data.Password);
            $("#4").html(data.NamePinYin);
            $("#5").html(data.Tel);
            $("#6").html(data.Email);
            $("#7").html(data.Birthday);
            $("#8").html(data.Sex);
            $("#9").html(data.CreateTime);
            $("#10").html(data.UpdateTime);

            $("#details").modal({
                show: true
            });
        })
    };
    function Edit() {
        layer.msg("2");
        alert("2");
    };
    function Delete() {
        layer.msg("3");
        alert("3");
    };
})