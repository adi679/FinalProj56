function ajaxCall(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
		headers: {
			'user-key': '96bb7301850e4a85b6319b5cbe3d83a7',
        },
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}