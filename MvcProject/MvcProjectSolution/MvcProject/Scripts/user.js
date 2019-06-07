var LoadLoginParial = function () {

    $.ajax({
        url: '/UserAuthentication/Login',
        method: 'GET'
    }).done(function (data) {
        $('#ModalLogin .modal-content').html(data);
        $('#ModalLogin').modal('show');

    });

}

var openLoginModal = function () { LoadLoginParial(); }


//function logoutAction() {

//    $.ajax({
//        url: '/UserAuthentication/Logout',
//        method: "GET"
//    }).done(() => {
//        //location.reload();
//    })

//}
//var logout = () => {
//    logoutAction();
//}

var LoadEditUserParial = function () {

    $.ajax({
        url: '/UserAuthentication/EditUser',
        method: 'GET'
    }).done(function (data) {
        $('#ModalLogin .modal-content').html(data);
        $('#ModalLogin').modal('show');

    });

}

var openEditUserModal = function () { LoadEditUserParial(); }

var LoadChangePasswordParial = function () {

    $.ajax({
        url: '/UserAuthentication/ChangePassword',
        method: 'GET'
    }).done(function (data) {
        $('#ModalLogin .modal-content').html(data);
        $('#ModalLogin').modal('show');

    });

}

var openChangePasswordModal = function () { LoadChangePasswordParial(); }

