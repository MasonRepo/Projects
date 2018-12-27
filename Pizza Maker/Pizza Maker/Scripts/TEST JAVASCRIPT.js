
//========== VARIABLES ===========

// These are going to need AJAX gets to grab, setting up for now.

var TotalPizzas = 0;
var Modifier = 0;
//================================

var num = $('#TOTALPIZZAS');

var pps = $("#PPS").data("pps");
var PPS = pps / 30;
Modifier = $("#PPS").data("Modifier");

//$("#PPS").innerText = PPS;

var i = num.data("total");
var PizzaPerSecond = 1;
var realNum = document.getElementById('TOTALPIZZAS');

var BrickOven = 0;

// i wish this worked...
BrickOven.Pizza = 10;
BrickOven.Cost = 10;
var BrickOvenCost = 10;

var button = document.getElementById('showButton');


//$("button").click(function () {
//    var fired_button = $(this).data("id");
//    alert(fired_button);
//});

$("#bigPizza").click(function () {
    i += 1;
    save();
});


//this is going to be any button...
$("button").click(function () {
    var base = "http://localhost:61279/Test/";
    var id = $(this).data("id");
    var increase = $(this).find("#PizzaIncrease");
    if (id != null && increase != null) {
        var play = $(this).data("player");
        var currentButton = $(this);
        var playerAmount = currentButton.find("#playerAmount");
        // var show = currentButton.getElementById('pizzaPrice').innerText;
        var pizzaPrice = currentButton.find("#pizzaPrice");

        var complete = base + id + "/" + play
        var buildings = $("#buildings").html();

        if (pizzaPrice.text() > realNum.innerText) {

            console.log(pizzaPrice.text() + "This is how much the player has: " + realNum.innerText);
        }
        if (pizzaPrice.text() <= i) {
            $.post(complete)
                .done(function (response) {
                    pps = response.PPS;
                    PPS = response.PPS / 30;
                    i = i - pizzaPrice.text();
                    response.TotalBuildings.forEach(function (item) {
                        if (id == item.BuildingID) {
                            // increase.text("PPS Increase: " + item.PizzaIncrease * response.Modifier);
                            playerAmount.text(item.AmountPlayerHas);
                            pizzaPrice.text(item.Price);
                        };
                    })
                })
        }
    }
});

$(document).ready(function () {

    $(".btn-upgrade").click(function () {

        console.log($(this).data("purchased"));
        var base = "http://localhost:61279/PurchaseUpgrade/";

        var playerID = $(this).data("player");
        var upgradeID = $(this).data("id");
        var purchased = $(this).data("purchased");
        var price = $(this).data("price");
        console.log(price);
        var complete = base + playerID + "/" + upgradeID;
        if (i > price) {
            $.post(complete)
                .done(function (response) {
                    pps = response.PPS;
                    PPS = response.PPS / 30;
                    i = i - price;

                    response.AllUpgrades.forEach(function (item) {
                        if (upgradeID == item.UpgradeID && item.IsPurchased == true) {
                            var button = "#" + upgradeID;
                            $(button).prop("disabled", true);
                        };
                    })
                })
        }
    });
});


var PPSDisplay = document.getElementById('PPS');

//var PerSecond = document.getElementById('AmountSecond');

function start() {
    setInterval(increase, 1000 / 30);
}


function save() {
    setInterval(save, 30000);
}


function save() {

    var base = "http://localhost:61279/Save/";
    var playeramount = 0;
    playeramount = realNum.innerText;
    var playerID = $("#buildings").data("player")
    var display = i.toFixed(0);
    //var amount = playeramount.toFixed(0);
    $.post(base + playerID + "/" + display)
        .done(function (response) { });
}


function increase() {
    if (true) {
        //var PPS = $("#PPS").data("pps");

        i += PPS;
        var display = i.toFixed(0);
        PPSDisplay.innerText = ("You are currently making " + pps + " pizzas per second");
        realNum.innerText = ("You have " + display + " pizzas");

    };
};

requestAnimationFrame(start);
