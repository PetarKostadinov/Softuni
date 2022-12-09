import { edit, getById } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const editTemplate = (car, onEdit) => html`
<section id="edit-listing">
    <div class="container">

        <form @submit=${onEdit} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value=${car.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value=${car.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value=${car.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value=${car.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value=${car.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value=${car.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

export async function showEdit(ctx) {

    const id = ctx.params.id
    const car = await getById(id)

    ctx.render(editTemplate(car, createSubmitHandler(onEdit)));

    async function onEdit({ brand, model, description, year, imageUrl, price}) {

        if (brand == '' || model == '' || description == '' || year == '' || imageUrl == '' || price == '') {
            return alert('All fields are required!');
        }
        price = Number(price);
        year = Number(year);
        if (year < 0 || price < 0 ) {
            return alert('Year and price should be a positive number!');
        }

        await edit(id, { brand, model, description, year, imageUrl, price })
        ctx.page.redirect('/catalog/' + id)
    }
}





