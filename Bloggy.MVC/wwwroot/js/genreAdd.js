
$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.genreAddUrl;
        var redirectUrl = app.Urls.articleAddUrl;

        var genreAddDTO = {
            Name: $("input[id=genreName]").val()
        }

        var jsonData = JSON.stringify(genreAddDTO);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType : "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir Hata Oluştu.", "Hata");
            }
        });
    });
});