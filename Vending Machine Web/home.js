var Url = "http://localhost:50812/items";

var money = 0;

var id = "";

// var price = 0;

// var quantity = 0;

function xhrFail(xhr, status, err) {
    console.log(xhr, status, err);
}

function GrabItems() {
    $.getJSON(Url)
        .done(function (response) {

            var divitems = $("#divItems");
            divitems.empty();
            var items = $("#itemTemplate").html();

            response.forEach(function (item) {

                var html = items.replace("{{Name}}", item.name)
                    .replace("{{Price}}", item.price)
                    .replace("{{Quantity}}", item.quantity)
                    .replace(/{{Id}}/gi, item.id)
                    .replace(/{{itemprice}}/gi, item.price)
                    .replace(/{{itemname}}/gi, item.name)
                    .replace(/{{itemquan}}/gi, item.quantity);

                divitems.append(html);
            });

        }).fail(xhrFail);

};



// going to need 4 on click events for money roughly..


$("#Dollar").click(function () {

    money += 1.00;
    $("#MoneyAmmount").val(money);
    money.toFixed(2);
    console.log("hello");
});
$("#Quarter").click(function () {

    money += 0.25;
    $("#MoneyAmmount").val(money);
    money.toFixed(2);
});
$("#Dime").click(function () {

    money += 0.10;
    $("#MoneyAmmount").val(money);
    money.toFixed(2);
});
$("#Nickle").click(function () {

    money += 0.05;
    $("#MoneyAmmount").val(money);
    money.toFixed(2);
});

// this is going to be for buying.
$("#divItems").on("click", "#idk", function () {

    $("#changeValue").val($(this).data("itemname"));
    console.log($(this).data("itemname"));
    id = $(this).data("itemid");
    price = $(this).data("itemprice");
    console.log(price);
    quantity = $(this).data("itemquan");
    console.log(quantity);
});


$("#THEBUTTON").click(function () {
    var base = "http://localhost:50812/money/";

    var complete = base + money + "/item/" + id;

    // if (quantity == - 0) {
    //     $("#mess").val("OUT OF STOCK!");
    // }
    // else if( price > money) {
    //     $("#mess").val("Not Enough Funds!");

    // }
    

        $.getJSON(complete)
            .done(function (response) {
                var quarters = (0.25 * response.quarters);
                var dimes = (0.10 * response.dimes);
                var nickles = (0.05 * response.nickels);
                var pennies = (0.01 * response.pennies)

                var change = quarters + dimes + nickles + pennies;

                $("#mess").val("Thank You!");
                $("#change").val(change);
                money = change;
                $("#MoneyAmmount").val(money);

            }).fail( function(xhrFail ) {

                $("#mess").val(xhrFail.responseJSON.message);


            });
            //xhr.responseJSON.message is what I should have done!
    
    GrabItems();
});



GrabItems();