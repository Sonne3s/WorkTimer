class AJAX {
    static init(successFunc = null, responseType = null, element = null) {
        let xmlhttp = new XMLHttpRequest();
        xmlhttp.responseType = responseType ?? "";

        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == XMLHttpRequest.DONE) { // XMLHttpRequest.DONE == 4
                if (xmlhttp.status == 200) {
                    if (successFunc != null) {
                        successFunc(xmlhttp.response, element);
                    }
                }
                else if (xmlhttp.status == 400) {
                    alert('There was an error 400');
                }
                else {
                    alert('something else other than 200 was returned');
                }
            }
        };

        return xmlhttp;
    }

    static responseType = {
        json: "json",
        document: "document",
        text: "text",
        blob: "blob",
        arraybuffer: "arraybuffer"
    }

    static method = {
        get: "GET",
        post: "Post"
    }

    static get(url, successFunc, responseType, element) {
        let xmlhttp = AJAX.init(successFunc, responseType, element);
        xmlhttp.open(AJAX.method.get, url, true);
        xmlhttp.send();
    }

    static post(url, successFunc, responseType, element) {
        let xmlhttp = AJAX.init(successFunc, responseType, element);
        xmlhttp.open(AJAX.method.post, url, true);
        xmlhttp.send();
    }

    static form(url, form, successFunc, responseType, element) {
        let xmlhttp = AJAX.init(successFunc, responseType, element);
        let formData = new FormData(form);
        xmlhttp.open(AJAX.method.post, url, true);
        xmlhttp.send(formData);
    }

    static getJSON(url, successFunc, element) {
        AJAX.get(url, successFunc, AJAX.responseType.json, element);
    }

    static getPage(url, successFunc, element) {
        AJAX.get(url, successFunc, AJAX.responseType.document, element);
    }
}