//$.ajax({
//    method: "GET",
//    //获取该用户的角色
//    url: "http://localhost:57424/api/User_Role/GetUser_Role?id=" + $.cookie('userID'),
//    success: function (data) {
//        //如果获取成功，则根据该用户的角色去获取该角色拥有的菜单
//        $.ajax({
//            url: "http://localhost:57424/api/Role_Menu/GetRole_MenuByRole?id=" + data.RoleID,
//            method: "GET",
//            success: function (arr) {
//                //MakeMenu(array, "00000000-0000-0000-0000-000000000000")
//                //$.get("http://localhost:57424/api/Menus/Menu" + array + "00000000-0000-0000-0000-000000000000", function (data) {
//                //    alert(data);
//                //})
//                //$.ajax({
//                //    method: "GET",
//                //    url: "http://localhost:57424/api/Menus/Menu",
//                //    data: {
//                //        array: arr,
//                //        pid: "00000000-0000-0000-0000-000000000000"
//                //    },
//                //    success: function (a) {
//                //        alert(a);
//                //    }
//                //})
//            }
//        });
//    },
//    error: function () { alert("获取菜单失败"); }
//});


////组成菜单
////array,角色拥有的菜单,第一次为根节点ID，后面为父节 点ID
////function MakeMenu(array, pid) {
////    $.get("http://localhost:57424/api/Menus/getMenu", function (data) {
////        for (var i = 0; i < data.length ; i++) {
////            //判断是否是一级菜单
////            if (data[i].ParentMenuID == pid) {
////                //如果是一级菜单，遍历该角色拥有的一级菜单，并生成一级菜单
////                for (var j = 0; j < array.length; j++) {
////                    //console.log("i:" + i + ";j:" + j);
////                    if (data[i].MenuID == array[j].MenuID) {
////                        //生成一级菜单
////                        var FirstMenu = "<li id='Menu_" + i + "'" +
////                            "><a href='" + data[i].PagePath +
////                            "'id='dropDown_"+i+"'"+
////                            "><i class='" + data[i].Icon
////                            + "'></i>" + data[i].MenuName + "</a></li>";

////                        $("#Menu_Start").append(FirstMenu);
////                        //END 一级菜单




////                        //Start 二级菜单
////                        $.get("http://localhost:57424/api/Menus/GetMenuByPM?pid=" + data[i].MenuID, function (num) {
////                            if (num != 0) {
////                                var a = '<ul class="nav child_menu"><li><a href="index.html">菜单1</a></li><li><a href="#">菜单2</a></li><li><a href="#">菜单2</a></li><li><a href="#">菜单2</a></li><li><a href="#">菜单2</a></li><li><a href="index3.html">菜单3</a></li></ul>';
////                                var b = '<span class="fa fa-chevron-down"></span>';
////                                $("#dropDown_" + i).append(b);
////                                $("#dropDown_" + i).after(a);
////                            }
////                        });

////                        //二级菜单
////                        //for (var k = 0; k < data.length; k++) {
////                        //    //判断是否是二级菜单
////                        //    if (data[k].ParentMenuID == data[i].MenuID) {
////                        //        //判断用户是否拥有权限
////                        //        for (m = 0; m < array.length; m++) {
////                        //            if (data[k].MenuID == array[m].MenuID) {
////                        //                $("#MenuDrop_" + i).append('<a href="' + data[k].PagePath + '">' + data[k].MenuName + '</a>');
////                        //            }
////                        //        }
////                        //    }
////                        //}


////                    }
////                }
////            }
////        }
////    })
////}

$.ajax({
    method: "GET",
    url: "http://localhost:57424/api/Menus/Menu/" + $.cookie('userID') + "?pid=00000000-0000-0000-0000-000000000000",
    success: function (data) { $("#Menu_Start").append(data); },
    error: function () { alert("获取菜单失败");}
})