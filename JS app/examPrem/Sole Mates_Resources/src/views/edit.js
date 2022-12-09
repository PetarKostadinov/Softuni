import { edit, getById } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const editTemplate = (shoe, onEdit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit item</h2>
        <form @submit=${onEdit} class="edit-form">
            <input type="text" name="brand" .value=${shoe.brand} id="shoe-brand" placeholder="Brand"/>
            <input type="text" name="model" .value=${shoe.model} id="shoe-model" placeholder="Model"/>
            <input type="text" name="imageUrl" .value=${shoe.imageUrl} id="shoe-img" placeholder="Image url"/>
            <input type="text" name="release" .value=${shoe.release} id="shoe-release" placeholder="Release date"/>
            <input type="text" name="designer" .value=${shoe.designer} id="shoe-designer" placeholder="Designer"/>
            <input type="text" name="value" .value=${shoe.value} id="shoe-value" placeholder="Value"/>

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function showEdit(ctx) {

    const id = ctx.params.id
    const shoe = await getById(id)

    ctx.render(editTemplate(shoe, createSubmitHandler(onEdit)));

    async function onEdit({ brand, model, imageUrl, release, designer, value}) {

        if (brand == '' || model == '' || release == '' || designer == '' || imageUrl == '' || value == '') {
            return alert('All fields are required!');
        }
        // price = Number(price);
        // year = Number(year);
        // if (year < 0 || price < 0) {
        //     return alert('Year and price should be a positive number!');
        // }

        await edit(id, { brand, model, imageUrl, release, designer, value})
        ctx.page.redirect('/catalog/' + id)
    }
}





