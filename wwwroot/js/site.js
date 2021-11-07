// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Manage Roles******************************************

$(function () {
    var placeHolderElement = $('#PlaceHolderHere');

    $('button[data-toggle="ajax-modal"').click(function (event){
        //get url action from data-url from the button tag
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);       
        $.get(decodedUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        })

    })

    placeHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');

        var actionName = form.attr('action');
        var controllerName = form.attr('controller');

        var actionUrl = "/" + controllerName + "/" + actionName;

        var sendData = form.serialize();
        var userId = document.getElementById("SelecteduserId").value;       
        

        $.post(actionUrl, sendData + "&userId=" + userId).done(function (data) {

            window.location.reload();
            placeHolderElement.find('.modal').modal('hide');
        })
    })
})

//*******************************************************

//Manage Users******************************************

$(function () {
    var placeHolderElement = $('#PlaceHolderHereUser');

    $('button[data-toggle="ajax-modal"').click(function (event) {
        //get url action from data-url from the button tag
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        })

    })

    placeHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');

        var actionName = form.attr('action');
        var controllerName = form.attr('controller');

        var actionUrl = "/" + controllerName + "/" + actionName;

        var sendData = form.serialize();
        var roleId = document.getElementById("SelectedRoleId").value;


        $.post(actionUrl, sendData + "&roleId=" + roleId).done(function (data) {
            alert("تم إضافة المستخدمين بنجاح")
            window.location.reload();
            placeHolderElement.find('.modal').modal('hide');
        })
    })
})

//*******************************************************