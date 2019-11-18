var TempProduct = [];

function EditOrders(id) {

    var orderId = document.getElementById("orderid "+id).innerHTML;
    var productId = document.getElementById("productid " + id).innerHTML;
    var productName = document.getElementById("productName " + id).innerHTML;
    var description = document.getElementById("description " + id).innerHTML;
    var unitPrice = document.getElementById("unitprice " + id).innerHTML;
    var quantity = document.getElementById("quantity " + id).innerHTML;
    var editBtn = document.getElementById("EditBtn " + id);


    if (editBtn.value === "Edit") {
        document.getElementById("productid").value = productId;
        document.getElementById("id").value = id;
        document.getElementById("orderId").value = orderId;
        document.getElementById("Name").value = productName;
        document.getElementById("description").value = description;
        document.getElementById("UnitPrice").value = unitPrice;
        document.getElementById("Quantity").value = quantity;
    }
}

function ConfirmOrderChanges() {

    var orderItems = {
        Id: 0,
        ProductId: 0,
        UnitPrice: 0,
        Quantity: 0,
        OrderId: 0
    };

    orderItems.Id = parseInt(document.getElementById("id").value);
    orderItems.ProductId = parseInt(document.getElementById("productid").value);
    orderItems.UnitPrice = parseInt(document.getElementById("UnitPrice").value);
    orderItems.Quantity = parseInt(document.getElementById("Quantity").value);
    orderItems.OrderId = parseInt(document.getElementById("orderId").value);
    document.getElementById("updatedQuantity " + orderItems.Id).textContent = "Quantity: " + orderItems.Quantity;
    document.getElementById("updateTotalAmount " + orderItems.Id)
        .textContent = "Total Amount: Rs: " + (parseInt(document.getElementById("Quantity").value) *
                                              parseInt(document.getElementById("UnitPrice").value));                                              
    TempProduct.push(orderItems);
    document.getElementById("SaveChanges").hidden = false;
}