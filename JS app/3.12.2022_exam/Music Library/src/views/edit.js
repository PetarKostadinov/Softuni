import { edit, getById } from "../api/data.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";


const editTemplate = (album, onEdit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Album</h2>
        <form @submit=${onEdit} class="edit-form">
            <input type="text" name="singer" .value=${album.singer} id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" .value=${album.album} id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" .value=${album.imageUrl} id="album-img" placeholder="Image url" />
            <input type="text" name="release" .value=${album.release} id="album-release" placeholder="Release date" />
            <input type="text" name="label" .value=${album.label} id="album-label" placeholder="Label" />
            <input type="text" name="sales" .value=${album.sales} id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`;

export async function showEdit(ctx) {

    const id = ctx.params.id
    const album = await getById(id)

    ctx.render(editTemplate(album, createSubmitHandler(onEdit)));

    async function onEdit({singer, album, imageUrl, release, label, sales}) {

        if (singer == ''
        || album == ''
        || imageUrl == ''
        || release == ''
        || label == ''
        || sales == '') {
            return alert('All fields are required!');
        }

        await edit(id, {singer, album, imageUrl, release, label, sales})
        ctx.page.redirect('/catalog/' + id)
    }
}






