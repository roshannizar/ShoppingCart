﻿var products = [];
var grandTotal = 0;

function CalculateTotal(quantity) {
    var quantity = document.getElementById("quantity").value;
    var unitprice = document.getElementById("unitprice").innerHTML;
    var quantityInStock = document.getElementById("quantityInStock").innerHTML;

    var total = parseFloat(unitprice) * parseInt(quantity);
    var remaining = parseInt(quantityInStock) - parseInt(quantity);

    if (parseInt(quantity) > parseInt(quantityInStock)) {
        document.getElementById("quantity").value = quantityInStock;
        alert("You are extending the limit of the stock available!");
    } else {
        document.getElementById("totalamount").innerHTML = total;
    }
}


function CreateOrderLine() {
    var temp = document.getElementById("productId");
    var productId = temp.options[temp.selectedIndex].value;
    var productName = temp.options[temp.selectedIndex].textContent;
    var description = document.getElementById("description").innerHTML;
    var unitPrice = document.getElementById("unitprice").innerHTML;
    var quantity = document.getElementById("quantity").value;

    var orderLine = {
        productId: 0,
        unitPrice: 0,
        quantity:0
    }

    if (products) {

        CreateTableRow(productName, description, unitPrice, quantity);
        orderLine.productId = parseInt(productId);
        orderLine.unitPrice = parseInt(unitPrice);
        orderLine.quantity = parseInt(quantity);

        products.push(orderLine);
        console.log(products);
    } else {
        console.log("Product is empty!");
    }
}

function CreateTableRow(productName, description, unitPrice, quantity) {

    var table = document.getElementById("tableForm");
    var editBtn = document.createElement("input");
    var deleteBtn = document.createElement("input");
    var quantityText = document.createElement("input");

    editBtn.setAttribute('type', 'button');
    editBtn.setAttribute('value', 'Edit');
    editBtn.classList.add("btn");
    editBtn.classList.add("btn-sm");
    editBtn.classList.add("btn-outline-warning");

    quantityText.setAttribute('type', 'number');
    quantityText.classList.add('form-control');
    quantityText.classList.add('col-md-6');
    quantityText.disabled = true;

    var row = table.insertRow(2);
    var productNameCell = row.insertCell(0);
    var descriptionCell = row.insertCell(1);
    descriptionCell.colSpan = 2;
    var unitpriceCell = row.insertCell(2);
    var quantityCell = row.insertCell(3);
    var totalCell = row.insertCell(4);
    var editBtnCell = row.insertCell(5);

    editBtnCell.appendChild(editBtn);
    quantityCell.appendChild(quantityText);

    productNameCell.innerHTML = productName;
    descriptionCell.innerHTML = description;
    unitpriceCell.innerHTML = "Rs: "+unitPrice;
    quantityText.value = quantity;
    totalCell.innerHTML = "Rs: "+parseInt(quantity) * parseInt(unitPrice);
    editBtnCell.appendChild(editBtn);
    
}