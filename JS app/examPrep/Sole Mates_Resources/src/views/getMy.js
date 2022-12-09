
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const myTemplate = (myCars) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">

        <!-- Display all records -->
        ${myCars.length > 0 ? myCars.map(car => carsTemplate(car)) 
        : html`
        <!-- Display if there are no records -->
        <p class="no-cars"> You haven't listed any cars yet.</p>`}
 
    </div>
</section>`;

const carsTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src=${car.imageUrl}>
    </div>
    <h2>${car.brand } ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/catalog/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

export async function showMy(ctx) {

    const userData = getUserData();
    const userId = userData._id;
    const myCars = await getMyCars(userId);

    ctx.render(myTemplate(myCars))
}