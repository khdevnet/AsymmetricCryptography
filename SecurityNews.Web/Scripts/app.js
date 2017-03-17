var app= (function () {

    return {
        init: function myfunction() {
            $('form').submit(function (event) {
                $.ajax({
                    type: 'POST',
                    url: $('form').attr("action"),
                    data: $('form').serialize(),
                    dataType: 'json'
                })
                    .done(function (data) {
                        $("#result").html(JSON.stringify(data));
                        console.log(data);
                    });
                event.preventDefault();
            });
        }
    };
}());