
// this are all just test values for now.

var i = 0;
var PizzaPerSecond = 1;

var BrickOven = 0;

// i wish this worked...
BrickOven.Pizza = 10;
BrickOven.Cost = 10;
var BrickOvenCost = 10;

var button = document.getElementById('showButton');


function BuildingPurchase() {
    button.onclick = function () {
        if (i > BrickOven.Cost) {
            i -= BrickOven.Cost;
            BrickOven.Cost *= 2.25;
            PerSecond.innerText = ('Amount Per Second:' + PizzaPerSecond);
            button.innerText = ('Price of Oven: ' + BrickOven.Cost);
            BrickOven++;
            PizzaPerSecond += BrickOven * 0.25;

        }
    };
}

var num = document.getElementById('ChangeValue');

var PerSecond = document.getElementById('AmountSecond');

function start() {
    setInterval(increase, 1000);
}

function increase() {
    if (true) {
        i += PizzaPerSecond;
        var display = i.toFixed(1)
        num.innerText = display;
        if (i < BrickOven.Cost) {
            $("#showButton").hide();
        }
        if (i > BrickOven.Cost) {
            $("#showButton").show();
        };
    };
};

start();
