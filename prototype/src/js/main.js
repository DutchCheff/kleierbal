import { loadComponent } from "./loadComponents.js";
import { initShop } from "./shop.js";
import { initCheckout } from "./checkout.js";

await loadComponent('navbar', './src/components/navbar.html');
await loadComponent('footer', './src/components/footer.html');

initShop();
initCheckout();