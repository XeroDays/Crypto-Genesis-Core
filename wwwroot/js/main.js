$(document).ready(function() {

});
 
$('#txtEnter,#txtClose,#txtInvested').on('input', function(e) {
    calculateProfit();
});


$('.server-buttons p').click(function () {
    var coin = $(this).text();
    $.getJSON("../Coin/" + coin, function (dataa) {
        $('#txtEnter').val(dataa.currentPrice);
        $('#txtClose').val(dataa.currentPrice);
    });
});


var calculateProfit = function() {

    var enter = $("#txtEnter").val();
    var close = $("#txtClose").val();
    var invested = $("#txtInvested").val();


    var check1 = $.isNumeric(enter);
    var check2 = $.isNumeric(close);
    var check3 = $.isNumeric(invested);

    if (check1 && check2 && check3) {
        var purchaseCoin = invested / enter;
        var closingOrder = purchaseCoin * close;
        var PL = closingOrder - invested;

        $('#lblCoins').text('Total Coins : ' + purchaseCoin.toFixed(5));
        $('#lblInvested').text('Total Invest : ' + invested);
        var PLText = "Total Profit/Loss : ";
        if (PL > 0) {
            PLText = PLText + '+'
            $("#lblProfit").css("color", "green");
        } else {
            PLText = PLText + '-'
            $("#lblProfit").css("color", "red");
        }

        $('#lblProfit').text(PLText + PL.toFixed(2));
    }

};

function validate(evt) {

    var charCode = (evt.which) ? evt.which : evt.keyCode; 
    if ((charCode >= 48 && charCode <= 57) || charCode == 46 || charCode == 0)
        return true;
    return false;
}