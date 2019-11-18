var TempProduct = [];

function EditOrders(id) {

    var orderId = document.getElementById("orderid "+id).innerHTML;
    var productId = document.getElementById("productid " + id).innerHTML;
    var unitPrice = document.getElementById("unitprice " + id).innerHTML;
    var quantity = document.getElementById("quantity " + id).value;
    var editBtn = document.getElementById("EditBtn "+id);
    var tempName;

    if (editBtn.value === "Edit") {
        tempName = "Save";
        editBtn.classList.add("btn-success");
        editBtn.value = "Save";
        document.getElementById("quantity " + id).hidden = false;
    } else {
        tempName = "Edit";
        editBtn.classList.add("btn-warning");
        editBtn.value = "Edit";
        document.getElementById("quantity " + id).hidden = true;
    }
}

