



(function () {

    $(function () {
        // Declare a proxy to reference the hub.
        var notifications = $.connection.messagesHub;

        //debugger;
        // Create a function that the hub can call to broadcast messages.
        notifications.client.updateMessages = function () {
            getAllMessages();

        };
        // Start the connection.
        $.connection.hub.start().done(function () {
            console.log("connected!");
            getAllMessages();
        }).fail(function (e) {
            alert(e);
        });
    });

    function getAllMessages() {
        var tbl = $('#messagesTable');
        $.ajax({
            url: '/Home/GetMessages',
            contentType: 'application/html ; charset:utf-8',
            type: 'GET',
            dataType: 'html'
        }).done(function (result) {
            tbl.empty().append(result);
        }).fail(function (e) {
            alert(e);
        });
    }


    //$.connection.hub.start()
    //    .done(function () {

    //        console.log('ok');
    //        $.connection.messagesHub.server.sendMessages()
    //            .done(function (mes) {
                   
    //                WriteToPage(mes);
    //            })
    //            .fail(function () {
                    
    //            });
    //    })
    //    .fail(function () {
    //        console.log('fail');
    //    });

    //$.connection.hub.server.sendMessages()
    //    .done(function (mes) {
    //        WriteToPage(mes);
    //    })
    //    .fail(function () {

    //    });
    //$.connection.hub.start()
    //    .done(function () {
    //        console.log("success");
    //    }
    //    )
    //    .fail(function () { });
    //$.connection.hub.start()
    //    .done(function () {
    //        console.log('well done!');
    //        $.connection.myHub.server.sendMessages();
    //    })
    //    .fail(function () {

    //    });
    //$.connection.myHub.client.sendMessages = function (mes) {
    //    //alert('connected');
    //    WriteToPage(mes);
    //};
    //$('#click-me').on('click', function () {
    //    $.connection.myHub.server.getTime()
    //        .done(function (mes) {
    //            console.log('okss');
    //            WriteToPage(mes);
    //        })
    //        .fail(function () {

    //        });
    //});

    //var WriteToPage = function (mes) {
    //    $('#get-it').append(mes + "<br />");
    //};
})();
