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
Table
======================*/
jsVanila.deleteTableRow = function (index, id) {
    var tableId = id;
    if (tableId == null) tableId = "tablex";
    var table = document.getElementById(tableId);
    table.deleteRow(index);
} //End deleteTableRow

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
jsVanila.inputMaskDecimal = function () {
    var elements = document.getElementsByClassName("data-mask-decimal");
    for (var i = 0; i < elements.length; i++) {
        var element = document.getElementById(elements[i].id);
        element.oninput = function () {
            this.value = this.value.replace(/[^0-9]/g, '');
            if (this.value > 100) this.value = 100;
            if (this.value < 0) this.value = 0;
        } //end event
    } //end loop
}        //end method


//jsVanila.inputMaskDecimal = function() {
//    $(".data-mask-decimal").keydown(function (event) {
//        if (event.shiftKey == true) {
//            event.preventDefault();
//        }

//        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
//            (event.keyCode >= 96 && event.keyCode <= 105) ||
//            event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
//            event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190 || event.keyCode == 110) {

//        } else {
//            event.preventDefault();
//        }

//        if (($(this).val().indexOf('.') != -1) && ((event.keyCode == 190) || (event.keyCode == 110)))
//            event.preventDefault();
//        //if ($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
//        //    event.preventDefault();
//        //if a decimal has been added, disable the "."-button
//    });
//} //end method
//jsVanila.inputMaskDecimalPct = function() {
//    $(".data-mask-decimal-percentage").keydown(function (event) {
//        if (event.shiftKey == true) {
//            event.preventDefault();
//        }

//        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
//            (event.keyCode >= 96 && event.keyCode <= 105) ||
//            event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
//            event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190 || event.keyCode == 110) {

//        } else {
//            event.preventDefault();
//        }

//        if ($(this).val().indexOf('.') != -1 && ((event.keyCode == 190) || (event.keyCode == 110)))
//            event.preventDefault();

//        //if ($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
//        //    event.preventDefault();
//        //if a decimal has been added, disable the "."-button

//        if ($(this).val() > 100) {
//            $(this).val('100');
//        }
//    });
//    $(".data-mask-decimal-percentage").focusout(function (event) {
//        if ($(this).val() > 100) {
//            $(this).val('100');
//        }
//    });
//} //end method
