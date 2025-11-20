export function initCheckout() {
    const toggleBtn = document.getElementById('toggleShipping');
    const formContainer = document.getElementById('shippingForm');
    const chevronIcon = document.getElementById('chevronIcon');

    if (!toggleBtn || !formContainer || !chevronIcon) return;

    toggleBtn.addEventListener('click', () => {
        if (formContainer.classList.contains('hidden')) {
            // Open the form
            formContainer.classList.remove('hidden');
            formContainer.style.maxHeight = '0px';

            setTimeout(() => {
                formContainer.style.maxHeight = formContainer.scrollHeight + 'px';
            }, 10);

            // Rotate chevron
            chevronIcon.style.transform = 'rotate(180deg)';
        } else {
            // Close the form
            formContainer.style.maxHeight = '0px';

            // Rotate chevron back
            chevronIcon.style.transform = 'rotate(0deg)';

            setTimeout(() => {
                formContainer.classList.add('hidden');
            }, 300);
        }
    });

    // Donation toggle functionality
    const toggleDonation = document.getElementById('toggleDonation');
    const donationFormContainer = document.getElementById('donationForm');
    const chevronDonation = document.getElementById('chevronDonation');

    if (toggleDonation && donationFormContainer && chevronDonation) {
        toggleDonation.addEventListener('click', () => {
            if (donationFormContainer.classList.contains('hidden')) {
                // Open the form
                donationFormContainer.classList.remove('hidden');
                donationFormContainer.style.maxHeight = '0px';

                setTimeout(() => {
                    donationFormContainer.style.maxHeight = donationFormContainer.scrollHeight + 'px';
                }, 10);

                // Rotate chevron
                chevronDonation.style.transform = 'rotate(180deg)';
            } else {
                // Close the form
                donationFormContainer.style.maxHeight = '0px';

                // Rotate chevron back
                chevronDonation.style.transform = 'rotate(0deg)';

                setTimeout(() => {
                    donationFormContainer.classList.add('hidden');
                }, 300);
            }
        });
    }

    // Get amount from shop page
    const ballAmount = parseInt(localStorage.getItem('ballAmount')) || 1;
    const pricePerItem = parseFloat(localStorage.getItem('pricePerItem')) || 12.50;

    // Calculate prices
    const totalBallPrice = ballAmount * pricePerItem;
    const btwPercentage = 0.09;
    const btwAmount = (pricePerItem * btwPercentage) * ballAmount;

    // Update amount and price displays
    const ammountBalElement = document.getElementById('ammountBal');
    const priceBalElement = document.getElementById('priceBal');
    const btwElement = document.getElementById('BTW');

    if (ammountBalElement) {
        ammountBalElement.textContent = ballAmount;
    }

    if (priceBalElement) {
        priceBalElement.textContent = `€${totalBallPrice.toFixed(2).replace('.', ',')}`;
    }

    if (btwElement) {
        btwElement.textContent = `€${btwAmount.toFixed(2).replace('.', ',')}`;
    }

    // Donation input functionality
    const donationInput = document.getElementById('donationInput');
    const donatieBedrag = document.getElementById('donatieBedrag');
    const totaalBedragElement = document.getElementById('totaalBedrag');

    let donationAmount = 0;

    // Function to update total
    function updateTotal() {
        const total = totalBallPrice + donationAmount;
        if (totaalBedragElement) {
            totaalBedragElement.textContent = `€${total.toFixed(2).replace('.', ',')}`;
        }
    }

    // Initialize donation display
    if (donatieBedrag) {
        donatieBedrag.textContent = `€${donationAmount.toFixed(2).replace('.', ',')}`;
    }

    // Initialize total
    updateTotal();

    if (donationInput) {
        donationInput.addEventListener('input', (e) => {
            let value = parseFloat(e.target.value) || 0;

            // Validate minimum (can't be negative)
            if (value < 0) {
                value = 0;
                e.target.value = 0;
            }

            donationAmount = value;

            if (donatieBedrag) {
                donatieBedrag.textContent = `€${value.toFixed(2).replace('.', ',')}`;
            }
            updateTotal();
        });

        // Handle blur to format the value properly
        donationInput.addEventListener('blur', (e) => {
            const value = parseFloat(e.target.value) || 0;
            e.target.value = value.toFixed(2);
        });
    }
}
