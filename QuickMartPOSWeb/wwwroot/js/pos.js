// Global variable to store the current transaction
let currentTransaction = { items: [], subtotal: 0, tax: 0, total: 0 };

function updateDateTime() {
    var now = new Date();
    document.getElementById('datetime').textContent = now.toLocaleString();
}

function addToCart(productId) {
    var quantity = parseInt(document.getElementById('qty-' + productId).value);
    $.post('/POS/AddToTransaction', { productId: productId, quantity: quantity }, function (data) {
        currentTransaction = data;
        updateCart(data);
    });
}

function updateCart(transaction) {
    var cartTable = document.getElementById('cart-items');
    cartTable.innerHTML = '<tr><th>Product Name</th><th>Qty</th><th>Unit Price</th><th>Total Price</th></tr>';
    transaction.items.forEach(function (item) {
        cartTable.innerHTML += `<tr>
            <td>${item.product.name}</td>
            <td>${item.quantity}</td>
            <td>$${item.product.price.toFixed(2)}</td>
            <td>$${(item.product.price * item.quantity).toFixed(2)}</td>
        </tr>`;
    });

    document.getElementById('subtotal').textContent = transaction.subtotal.toFixed(2);
    document.getElementById('tax').textContent = transaction.tax.toFixed(2);
    document.getElementById('total').textContent = transaction.total.toFixed(2);
}

function processPayment() {
    var cashAmount = parseFloat(document.getElementById('cash-payment').value);
    $.post('/POS/Checkout', { cashAmount: cashAmount }, function (data) {
        document.getElementById('change').textContent = data.change.toFixed(2);
        currentTransaction = data.transaction;
        updateCart(data.transaction);
    });
}

function clearCart() {
    $.post('/POS/ClearCart', function (data) {
        currentTransaction = data;
        updateCart(data);
    });
}

function refund() {
    // Basic refund implementation
    let refundAmount = prompt("Enter refund amount:");
    if (refundAmount !== null && !isNaN(refundAmount)) {
        alert(`Refund of $${parseFloat(refundAmount).toFixed(2)} processed.`);
    } else {
        alert("Invalid refund amount.");
    }
}

function openSettings() {
    // Basic settings implementation
    let settingsMenu = `
    <h3>Settings</h3>
    <p>Tax Rate: <input type="number" id="taxRate" value="8" min="0" max="100" step="0.1">%</p>
    <button onclick="saveSettings()">Save</button>
    `;
    document.getElementById('settingsModal').innerHTML = settingsMenu;
    document.getElementById('settingsModal').style.display = 'block';
}

function saveSettings() {
    let taxRate = document.getElementById('taxRate').value;
    alert(`Tax rate updated to ${taxRate}%`);
    document.getElementById('settingsModal').style.display = 'none';
    // In a real application, you'd send this to the server to update
}
function printReceipt() {
    console.log("printReceipt function called"); // This will log a message to the console
    let receiptWindow = window.open('', '_blank');
    receiptWindow.document.write('<html><head><title>Receipt</title></head><body>');
    receiptWindow.document.write('<h2>Receipt</h2>');
    receiptWindow.document.write(document.getElementById('cart-items').outerHTML);
    receiptWindow.document.write('<p>Subtotal: $' + currentTransaction.subtotal.toFixed(2) + '</p>');
    receiptWindow.document.write('<p>Tax: $' + currentTransaction.tax.toFixed(2) + '</p>');
    receiptWindow.document.write('<p>Total: $' + currentTransaction.total.toFixed(2) + '</p>');
    receiptWindow.document.write('</body></html>');
    receiptWindow.document.close();
    receiptWindow.print();
}


function previewReceipt() {
    let previewContent = `
    <h3>Receipt Preview</h3>
    ${document.getElementById('cart-items').outerHTML}
    <p>Subtotal: $${currentTransaction.subtotal.toFixed(2)}</p>
    <p>Tax: $${currentTransaction.tax.toFixed(2)}</p>
    <p>Total: $${currentTransaction.total.toFixed(2)}</p>
    `;
    document.getElementById('receiptPreviewModal').innerHTML = previewContent;
    document.getElementById('receiptPreviewModal').style.display = 'block';
}

function closeModal(modalId) {
    document.getElementById(modalId).style.display = 'none';
}

function searchProducts() {
    let searchTerm = document.getElementById('searchBar').value.toLowerCase();
    let products = document.querySelectorAll('#productTable tr');
    products.forEach(function (product) {
        if (product.cells[0].innerText.toLowerCase().includes(searchTerm)) {
            product.style.display = '';
        } else {
            product.style.display = 'none';
        }
    });
}

// Event listeners
document.addEventListener('DOMContentLoaded', function () {
    setInterval(updateDateTime, 1000);
    document.getElementById('searchBar').addEventListener('input', searchProducts);
});

function previewReceipt() {
    $.ajax({
        url: '/POS/ReceiptPreview', // Ensure this matches your controller action
        type: 'GET',
        success: function (data) {
            $('#receiptContent').html(data);
            $('#receiptModal').modal('show');
        },
        error: function () {
            alert('Error loading receipt preview.');
        }
    });
}
