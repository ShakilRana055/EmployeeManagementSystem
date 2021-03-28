class AjaxOperation {
    constructor() { }

    SaveAjaxWithPhoto(destination, jsonData) {
        let data;
        $.ajax({
            url: destination,
            type: "post",
            data: jsonData,
            async: false,
            processData: false,
            contentType: false,
            success: function (response) {
                data = response;
            }
        });
        return data;
    }

    SaveAjax(destination, jsonData) {
        let data;
        $.ajax({
            url: destination,
            type: "POST",
            data: jsonData,
            async: false,
            success: function (response) {
                data = response;
            }
        });
        return data;
    }

    DeleteAjaxById(destination, jsonData) {
        let data;
        $.ajax({
            url: destination,
            data: ({ "id": jsonData }),
            async: false,
            success: function (response) {
                data = response;
            }
        });
        return data;
    }

    GetAjax(destination) {
        let getAjax;
        $.ajax({
            url: destination,
            method: "GET",
            dataType: "JSON",
            async: false,
            success: function (response) {
                getAjax = response;
            }
        });
        return getAjax;
    }

    GetAjaxByValue(destination, value) {
        let getAjaxByValue;
        $.ajax({
            url: destination,
            method: "GET",
            data: ({ "search": value }),
            async: false,
            success: function (response) {
                getAjaxByValue = response;
            }
        });
        return getAjaxByValue;
    }

    GetAjaxHtml(destination) {
        let getAjaxHtml;
        $.ajax({
            url: destination,
            method: "GET",
            dataType: "html",
            async: false,
            success: function (response) {
                getAjaxHtml = response;
            }
        });
        return getAjaxHtml;
    }

    GetAjaxHtmlByValue(destination, value) {
        let getAjaxHtmlByValue;
        $.ajax({
            url: destination,
            method: "GET",
            data: ({ "search": value }),
            dataType: "html",
            async: false,
            success: function (response) {
                getAjaxHtmlByValue = response;
            }
        });
        return getAjaxHtmlByValue;
    }

    GetAjaxHtmlByJson(destination, jsonData) {
        let getAjaxHtmlByValue;
        $.ajax({
            url: destination,
            method: "GET",
            data: jsonData,
            dataType: "html",
            async: false,
            success: function (response) {
                getAjaxHtmlByValue = response;
            }
        });
        return getAjaxHtmlByValue;
    }
}


class ModalOperation {
    constructor() { }

    ModalOpen(modalId) {
        $(modalId).modal("show");
    }

    ModalOpenWithHtml(modalId, modalDiv, htmlData) {
        $(modalId).modal("show");
        $(modalDiv).html(htmlData);
    }

    ModalClose(modalId, modalDiv) {
        $(modalId).modal("hide");
        $(modalDiv).html("");
    }

    ModalStatic(modalId) {
        $(modalId).modal({
            backdrop: 'static',
            keyboard: false
        });
    }
}

class TostrMessage {
    SavedMessage(response) {
        response === true ? toastr.success("Successfully Saved", "Success!") :
            toastr.error("Something Went Wrong!", "Error!");
    }

    DeletedMessage(response) {
        response === true ? toastr.success("Successfully Deleted", "Success!") :
            toastr.error("Something Went Wrong!", "Error!");
    }
    EditedMessage(response) {
        response === true ? toastr.success("Successfully Updated", "Success!") :
            toastr.error("Something Went Wrong!", "Error!");
    }

    CustomMessage(message) {
        toastr.success(message, "Success!")
    }
}