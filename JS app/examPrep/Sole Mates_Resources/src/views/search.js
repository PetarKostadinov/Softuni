import { getByBrand } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { createSubmitHandler, getUserData } from "../util.js";

const searchTemplate = (onSearch, result, user) => html`
<section id="search">
    <h2>Search by Brand</h2>

    <form @submit=${onSearch} class="search-wrapper cf">
        <input id="#search-input" type="text" name="search" placeholder="Search here..." required/>
        <button type="submit">Search</button>
    </form>

    <h3>Results:</h3>

    <div id="search-container">
        <ul class="shoed-wrapper">
            <!-- Display a li with information about every post (if any)-->
        ${result.map(shoe => shoeTemplate(shoe, user))}
        </ul>

        <!-- Display an h2 if there are no posts -->
        ${result.length == 0 ? html`<h2>There are no results found.</h2>` : nothing}
        <!--  -->
    </div>
</section>`;

const shoeTemplate = (shoe, user) => html`
<li class="card">
    <img src=${shoe.imageUrl} alt="travis" />
    <p>
        <strong>Brand: </strong><span class="brand">${shoe.brand}</span>
    </p>
    <p>
        <strong>Model: </strong><span class="model">${shoe.model}</span>
    </p>
    <p><strong>Value: </strong><span class="value">${shoe.value}</span>$</p>
    ${user != null ? html`<a class="details-btn" href="/catalog/${shoe._id}">Details</a>` : nothing}
    
</li>`;

export async function showSearch(ctx) {

    let result = [];
    let user = getUserData();

    async function onSearch({search}) {

        result = await getByBrand(search);

        ctx.render(searchTemplate(createSubmitHandler(onSearch), result, user));
    }

    ctx.render(searchTemplate(createSubmitHandler(onSearch), result, user));
}
