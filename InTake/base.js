function GetTablePageFromBackend() {

    $.ajax({
        dataType: "json",
        url: "ajax.ashx",
        data: { "data": "123" },
        success: function (data) {

            alert(data.op);

        }
    });

}





//Getting the parameter name from url  only query string
function GetQueryStringParameter(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}