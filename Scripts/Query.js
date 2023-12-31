﻿$(document).ready(function () {
    $("#getSpedizioniToday").click(function () {
        $("#contentContainer").empty();
        $.ajax({
            method: 'GET',
            url: "getSpedizioniToday",
            success: function (data) {
                $.each(data, function (i, v) {
                    var licurrent = "<li>" + "<span class='fw-bold'>Destinazione:</span> " + v.Destination + " <span class='fw-bold'>Indirizzo:</span> " + v.Address + "<span class='fw-bold'> Destinatario:</span> " + v.Destinatario + "</li>"
                    $("#contentContainer").append(licurrent);
                })
            }
        })
    })

    $("#getSpedizioniInAttesa").click(function () {
        $("#contentContainer").empty();
        $.ajax({
            method: 'GET',
            url: "getTotSNonConsegnate",
            success: function (data) {
                var licurrent = "<li>" + "Spedizioni Totali Da Consegnare = " + data.TotSpedizioni + "</li>"
                $("#contentContainer").append(licurrent);
            }
        })
    })

    $("#getSpedizioniGroupByCity").click(function () {
        $("#contentContainer").empty();
        $.ajax({
            method: 'GET',
            url: "getTotSpedizioniByCity",
            success: function (data) {
                $.each(data, function (i, v) {
                    var licurrent = "<li>" + v.Citta + " - Spedizioni Totali = " + v.TotSpedizioni + "</li>"
                    $("#contentContainer").append(licurrent);
                })
            }
        })
    })

})