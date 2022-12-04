import { html, nothing } from "../lib.js";
import { get, post } from "../api/api.js";
import { getSearched } from "../api/data.js";


const searchTemplate = (onSearch, result, click, user) => html`<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${onSearch} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    ${resultTemplate(result, click, user)}

</section>`;

const resultTemplate = (result, click, user) => html`
<!--Show after click Search button-->
${click ? html`
<div class="search-result">
    <!--If have matches-->
    ${result.length > 0 ? result.map(album => albumsTemplate(album, user))
            : html`
    <!--If there are no matches-->
    <p class="no-result">No result.</p>`}
</div>` : nothing}`;


const albumsTemplate = (album, user) => html`
        <div class="card-box">
            <img src=${album.imgUrl}>
            <div>
                <div class="text-center">
                    <p class="name">Name: ${album.name}</p>
                    <p class="artist">Artist: ${album.artist}</p>
                    <p class="genre">Genre: ${album.genre}</p>
                    <p class="price">Price: ${album.price}</p>
                    <p class="date">Release Date: ${album.releaseDate}</p>
                </div>
                ${user ? html`
                <div class="btn-group">
                    <a href="/catalog/${album._id}" id="details">Details</a>
                </div>` : nothing}
                
            </div>
        </div>`;


export async function showSearch(ctx) {

    let click = false;
    let result = '';

    ctx.render(searchTemplate(onSearch, result, click))

    async function onSearch() {

        click = true;
        const data = document.getElementById('search-input');
        const query = data.value;

        if (query) {
            result = await getSearched(query);

        } else {
            return alert('Enter desired product');
        }
        const user = Boolean(ctx.user)
        ctx.render(searchTemplate(onSearch, result, click, user), resultTemplate(result, click, user))
    }
}







// export async function donate(petId) {

//     return post('/data/donation', {
//         petId
//     });
// }

// export async function getDonation(petId) {
//     return get(`/data/donation?where=petId%3D%22$${petId}%22&distinct=_ownerId&count`)
// }

// export async function getOwnDonation(petId, userId) {
//     return get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
// }