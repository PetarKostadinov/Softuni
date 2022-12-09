import { deleteById, getById } from "../api/data.js";
import { donate } from "../api/donations.js";
import { html, nothing } from "../lib.js";

const detailsTemplate = (car, isUser, isOwner, onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${car.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}</li>
        </ul>

        <p class="description-para">${car.description}</p>
        ${isUser && isOwner ? html`<div class="listings-buttons">
            <a href="/edit/${car._id}" class="button-list">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>
        </div>` : nothing}

    </div>
</section>`;
//#####################################################################################################
export async function showDetails(ctx) {

    const id = ctx.params.id;
    const car = await getById(id);

    const isUser = Boolean(ctx.user)
    const isOwner = isUser && ctx.user._id == car._ownerId;

    ctx.render(detailsTemplate(car, isUser, isOwner, onDelete));

    async function onDelete() {

        const choise = confirm('Are you sure you want to delete this car?');

        if (choise) {

            await deleteById(id);

            ctx.page.redirect('/catalog')
        }
    }
}