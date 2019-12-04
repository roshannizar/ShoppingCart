function LoadProducts(id) {
    var http = new XMLHttpRequest();

    http.open("GET", "../Product/GetProductById/" + id, true);
    http.send();

    http.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            var obj = JSON.parse(this.responseText);

            if (obj != null) {

                document.getElementById("hiddenQuantity").hidden = false;
                document.getElementById("description").innerHTML = obj.description;
                document.getElementById("unitprice").innerHTML = obj.unitPrice;
                document.getElementById("quantity").disabled = false;
                document.getElementById("quantityInStock").innerHTML = obj.quantity;

            } else {

                document.getElementById("description").innerHTML = "Product not found!";
                document.getElementById("unitprice").innerHTML = "Product not found!";
                document.getElementById("hiddenQuantity").hidden = true;
                console.log("No product found!");

            }
        }
    };
}