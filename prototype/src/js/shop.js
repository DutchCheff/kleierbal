export function initShop() {
    const plusBtn = document.getElementById('plus');
    const minusBtn = document.getElementById('minus');
    const amountElement = document.getElementById('ammount');
    const priceElement = document.getElementById('price');
    const addToCartBtn = document.querySelector('a[href="checkout.html"]');

    if (!plusBtn || !minusBtn || !amountElement || !priceElement) return;

    const pricePerItem = 12.50;
    let amount = parseInt(amountElement.innerHTML) || 1;

    function updatePrice() {
        const totalPrice = (pricePerItem * amount).toFixed(2);
        priceElement.innerHTML = `€${totalPrice.replace('.', ',')}`;
    }

    plusBtn.addEventListener('click', () => {
        amount += 1;
        amountElement.innerHTML = amount;
        updatePrice();
    });

    minusBtn.addEventListener('click', () => {
        if (amount > 1) {
            amount -= 1;
            amountElement.innerHTML = amount;
            updatePrice();
        }
    });

    // Store amount when clicking "Voeg toe"
    if (addToCartBtn) {
        addToCartBtn.addEventListener('click', () => {
            localStorage.setItem('ballAmount', amount);
            localStorage.setItem('pricePerItem', pricePerItem);
        });
    }
}