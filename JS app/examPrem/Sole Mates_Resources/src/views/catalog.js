import { getAll } from '../api/data.js';
import { html, render } from '../lib.js';

const catalogTemplate = (shoes) => html`
<section id="dashboard">
    <h2>Collectibles</h2>

    ${shoes.length > 0 ? html`
    <ul class="card-wrapper">
        <!-- Display a li with information about every post (if any)-->
        ${shoes.map(shoe => shoeTemplate(shoe))}

    </ul>` 
    : html`<!-- Display an h2 if there are no posts -->
    <h2>There are no items added yet.</h2>`}
    
</section>`;

const shoeTemplate = (shoe) => html`
<li class="card">
    <img src=${shoe.imageUrl} alt="eminem" />
    <p>
        <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${shoe.model}</span>
    </p>
    <p><strong>Value:</strong><span class="value">${shoe.value}</span>$</p>
    <a class="details-btn" href="/catalog/${shoe._id}">Details</a>
</li>`;


export async function showCatalog(ctx) {
    const shoes = await getAll();
    ctx.render(catalogTemplate(shoes));
}