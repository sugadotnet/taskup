/*!
* jsvanila JavaScript Library v1.0.0
* Copyright 2017 Arin Suga
* Released under the MIT license
* Date: 30 Nov 2017
*/
var jsVanila = {};
jsVanila.getTes = function () {
    return "hasil getTes";
} //End tes method
jsVanila.getJsonTes = function (url) {
    this.ajaxGetJson(url, function (err, data) {
        if (err !== null) {
            alert('Something went wrong: ' + err);
        } else {
            alert('Your query count: ' + data.title);
        } //End if
    });
} //end tes method

/*!
* AJAX JSON
*/
/*======================
ajax json
======================*/
jsVanila.getJson = function (url, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    xhr.responseType = 'json';
    xhr.onload = function () {
        var status = xhr.status;
        if (status === 200) {
            callback(null, xhr.response);
        } else {
            callback(status, xhr.response);
        }
    };
    xhr.send();
} //end function ajaxJson

/*======================
lookUp
======================*/
jsVanila.displayLookUpResult = function (url, selector) {
    this.getJson(url, function (err, data) {
        if (err !== null) {
            alert('Ada kesalahan pada server: ' + err);
        } else {
            for (var i = 0; i < selector.length; i++) {
                document.getElementById(selector[i].target).value = data[selector[i].source];
            } //End loop
        } //End if
    });
} //end method

/*======================
Input mask and formating
======================*/
jsVanila.inputMaskInteger = function () {
    var elements = document.getElementsByClassName("data-mask-integer");
    for (var i = 0; i < elements.length; i++) {
        var element = document.getElementById(elements[i].id);
        element.oninput = function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        } //end event
    } //end loop
}        //end method
jsVanila.inputMaskIntegerPct = function () {
    var elements = document.getElementsByClassName("data-mask-integer-percentage");
    for (var i = 0; i < elements.length; i++) {
        var element = document.getElementById(elements[i].id);
        element.maxLength = 3;
        element.oninput = function () {
            this.value = this.value.replace(/[^0-9]/g, '');
            if (this.value > 100) this.value = 100;
            if (this.value < 0) this.value = 0;
        } //end event
    } //end loop
}        //end method

/*======================
Table
======================*/
jsVanila.deleteTableRow = function (index, id) {
    var tableId = id;
    if (tableId == null) tableId = "tablex";
    var table = document.getElementById(tableId);
    table.deleteRow(index);
} //End deleteTableRow

/*======================
DOM
======================*/
jsVanila.elementsToJson = function (elements) {
    vReturn = {}
    for (var i = 0; i < elements.length; i++) {
        vReturn[elements[i].getAttribute("tag-id")] = {};
        vReturn[elements[i].getAttribute("tag-id")].ID = elements[i].id;
        vReturn[elements[i].getAttribute("tag-id")].value = elements[i].value;
        vReturn[elements[i].getAttribute("tag-id")].name = elements[i].name;
    } //end loop
    //console.log(vReturn);
    return vReturn;
}       //end method

/*======================
Date
======================*/
jsVanila.addDays = function (stringShortDate, numberOfDays) {
    vReturn = stringShortDate;
    var s = this.convertStringDateShortToISO(stringShortDate);
    var d = new Date(s);
    numberOfDays = d.getDate() + parseInt(numberOfDays);
    d.setDate(numberOfDays);
    var sDate = d.toISOString().split("T")[0];
    vReturn = this.convertISOToStringDateShort(sDate);
    return vReturn;
}                         //end method
/*======================
Date Convertion
======================*/
jsVanila.convertStringDateShortToISO = function (stringDate) {
    vReturn = stringDate;
    var sTemp = vReturn.split("/");
    vReturn = sTemp[2] + "-" + sTemp[1] + "-" + sTemp[0];
    return vReturn;
}          //end method
jsVanila.convertISOToStringDateShort = function (stringDate) {
    vReturn = stringDate;
    var sTemp = vReturn.split("-");
    vReturn = sTemp[2] + "/" + sTemp[1] + "/" + sTemp[0];
    return vReturn;
}          //end method
jsVanila.convertDateToStringDateShort = function (stringDate) {
    vReturn = stringDate;
    var sTemp = vReturn.split("-");
    vReturn = sTemp[2] + "/" + sTemp[1] + "/" + sTemp[0];
    return vReturn;
}          //end method
