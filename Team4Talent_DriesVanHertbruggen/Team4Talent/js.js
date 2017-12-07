//lijst met de bestelling die zal worden doorgegeven aan c#
var orderlist = [];

//Verwissel de food lijst met de huidige bestelling
function switchView() {
    console.log("Switchview clicked");
        var x = document.getElementById("confirmorder");
        var y = document.getElementById("store");
        var z = document.getElementById("switchorder")
        if (x.style.display === "none")
        {
            x.style.display= "block";
            y.style.display= "none";
            z.textContent = "Ga naar winkel";
            
            showOrderlist();
        }
        else
        {
            x.style.display = "none";
            y.style.display = "block";
            z.textContent = "Ga naar winkelwagen";

            var tmp = document.getElementById("cOrder");
            tmp.removeChild(document.getElementById("orderlist"));
        }
    }

$(document).ready(function () {
    //aantal broodjes met 1 incrementeren
    $(".itemincrease").click(function () {
        var a = $(this).closest(".itemselection").children(".itemamount");
        var amount = a.text();
        var b = parseInt(amount) + 1;
        a.text(b.toString());
    });

    //aantal broodjes met 1 laten zakken
    $(".itemdecrease").click(function () {
        var a = $(this).closest(".itemselection").children(".itemamount");
        var amount = a.text();
        if (parseInt(amount) > 0)
        {
            var b = parseInt(amount) - 1;
        }
        a.text(b);
    });

    //object voor een fooditem
    var food = function (name, price, amount) {
        this.price = price;
        this.name = name;
        this.amount = amount;

        this.total = price * amount;
    }

    //Toevoegen aan winkelwagen.click()
    $(".itembutton").click(function () {
        //Lees naam in
        var a = $(this).closest(".itemcontainer").children("h3");
        //lees prijs in
        var b = $(this).siblings(".itemprice").children(".price");
        //lees aantal in
        var c = $(this).siblings(".itemselection").children(".itemamount");

        //als er meer dan 1 wordt besteld, worden de volgende functies uitgevoerd
        //om lege fooditems te vermijden
        if (c.text() > 0)
        {
            //maak fooditem aan met de ingeleven gegevens
            var tmp = new food(a.text(), b.text(), c.text());
            console.log(parseFloat(b.text()) * parseFloat(c.text()));

            console.log(tmp.name);
            console.log(tmp.price);
            console.log(tmp.amount);

            //voeg fooditem toe aan huidige bestelling
            orderlist.push(tmp);
            for (var i = 0; i < orderlist.length; i++)
            {
                console.log(orderlist[i]);
            }
        }

    });

    //Uitproberen verwijderen item uit bestelling
    //Werkt nog niet
    $(".delbutton").click(function () {
        console.log("delbutton clicked");
        var a = $(this).closest("tr").children(".tmpId");
        delete orderlist[parseInt(a.text)];
        console.log(orderlist);
        showOrderlist();
    });
});

function showOrderlist()
{
    //maak een table aan om hier later alle info van de huidige bestelling in te steken
    var t = document.createElement("table");
    //ID toegevoegd om deze later gemakkelijk te kunnen terugvinden
    t.setAttribute("id", "orderlist");

    var title = document.createElement("tr");
    //maak 5 kolommen om alle data in weg te schrijven
    var title0 = document.createElement("td");
    var title1 = document.createElement("td");
    var title2 = document.createElement("td");
    var title3 = document.createElement("td");
    var title4 = document.createElement("td");
    var title5 = document.createElement("td");

    //input titels
    $(title).append("");
    $(title1).append("Naam");
    $(title2).append("Aantal");
    $(title3).append("Prijs");
    $(title4).append("Totaal");
    $(title5).append("Actie");

    title.appendChild(title0);
    title.appendChild(title1);
    title.appendChild(title2);
    title.appendChild(title3);
    title.appendChild(title4);
    title.appendChild(title5);

    //voeg tr toe aan table
    t.appendChild(title);

    for (var i = 0; i < orderlist.length; i++) {
        var a = document.createElement("tr");
        //maak 5 kolommen om alle data in weg te schrijven
        var b = document.createElement("td");
        $(b).addClass("tmpId");
        var c = document.createElement("td");
        var d = document.createElement("td");
        var e = document.createElement("td");
        var f = document.createElement("td");
        var g = document.createElement("td");

        //Steek de data van de huidige bestelling in de kolommen
        $(g).append(i);
        $(b).append(orderlist[i].name);
        $(c).append(orderlist[i].amount);
        $(d).append("€" + (Math.round(orderlist[i].price * 100) / 100).toFixed(2));
        $(e).append("€" + (Math.round(orderlist[i].total * 100) / 100).toFixed(2));

        //maak een button die zal worden gebruikt om een optie uit de bestelling te verwijderen
        var btnDel = $('<button/>',
            {
                text: 'Verwijder',
                class: 'delbutton',
                type: 'button',
            });
        $(f).append(btnDel);


        //voeg alle kolommen toe aan de huidige rij
        a.appendChild(g);
        a.appendChild(b);
        a.appendChild(c);
        a.appendChild(d);
        a.appendChild(e);
        a.appendChild(f);

        //voeg de rij toe aan de tabel
        t.appendChild(a);
    }

    //variabele om totaal uit te komen
    var ordertotal = 0;
    //totaal euro optellen
    for (var i = 0; i < orderlist.length; i++) {
        ordertotal = ordertotal + orderlist[i].total;
    }

    var totaltr = document.createElement("tr");
    //maak 5 kolommen om alle data in weg te schrijven
    var totaltd1 = document.createElement("td");
    var totaltd2 = document.createElement("td");
    var totaltd3 = document.createElement("td");
    var totaltd4 = document.createElement("td");
    var totaltd5 = document.createElement("td");
    var totaltd6 = document.createElement("td");

    //tr opvullen
    $(totaltd1).append("Totaal");
    $(totaltd2).append("");
    $(totaltd3).append("");
    $(totaltd4).append("");
    $(totaltd5).append("€" + (Math.round(ordertotal * 100) / 100).toFixed(2));
    $(totaltd6).append("");

    totaltr.appendChild(totaltd1);
    totaltr.appendChild(totaltd2);
    totaltr.appendChild(totaltd3);
    totaltr.appendChild(totaltd4);
    totaltr.appendChild(totaltd5);
    totaltr.appendChild(totaltd6);

    t.appendChild(totaltr);


    //voeg de tabel toe aan de div voor het te collaten zien
    var o = document.getElementById("cOrder");
    o.appendChild(t);



    var tmpstring = "";
    for (var i = 0; i < orderlist.length; i++) {
        tmpstring = tmpstring + orderlist[i].name;
        tmpstring = tmpstring + "|";
        tmpstring = tmpstring + orderlist[i].amount;
        tmpstring = tmpstring + "|";
        tmpstring = tmpstring + orderlist[i].price;
        tmpstring = tmpstring + "|";
        tmpstring = tmpstring + orderlist[i].total;
        tmpstring = tmpstring + "%";
    }
    $("#hiddeninput").val(tmpstring);
    console.log(tmpstring);
}