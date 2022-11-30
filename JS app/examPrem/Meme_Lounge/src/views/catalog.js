import { getAll } from '../api/data.js';
import {html, nothing} from '../lib.js';


const catalogTemplate = (memes) => html`<section id="meme-feed">
<h1>All Memes</h1>
<div id="memes">
    <!-- Display : All memes in database ( If any ) -->
    ${memes.length > 0 ? memes.map(meme => memeCardTemplate(meme)) 
    : html`
    <!-- Display : If there are no memes in database -->
    <p class="no-memes">No memes in database.</p>`}
</div>
</section>`;

const memeCardTemplate = (meme) => html`
<div class="meme">
<div class="card">
    <div class="info">
        <p class="meme-title">${meme.title}</p>
        <img class="meme-image" alt="meme-img" src=${meme.imageUrl}>
    </div>
    <div id="data-buttons">
        <a class="button" href="/catalog/${meme._id}">Details</a>
    </div> 
</div>
</div>`;

export async function showCatalog(ctx){
    const memes = await getAll();
    //const isUser = Boolean(ctx.user);
    ctx.render(catalogTemplate(memes));
}



// const catalogTemplate = (albums, isUser) => html`
// <section id="catalogPage">
//         <h1>All Albums</h1>
//     ${albums.length == 0 ? html`
//     <p class="no-albums">No Albums in Catalog!</p>` 
//     : albums.map(album => albumCardTemplate(album, isUser))}
//     </div>
// </section>`;
 
// const albumCardTemplate = (album, isUser) => html`
// <div class="card-box">
//     <img src=${album.imgUrl}>
//     <div>
//         <div class="text-center">
//             <p class="name">Name: ${album.name}</p>
//             <p class="artist">Artist: ${album.artist}</p>
//             <p class="genre">Genre: ${album.genre}</p>
//             <p class="price">Price: $${album.price}</p>
//             <p class="date">Release Date: ${album.releaseDate}</p>
//         </div>
//         ${isUser ? html`<div class="btn-group">
//             <a href="/catalog/${album._id}" id="details">Details</a>
//         </div>` : nothing}
       
//     </div>
// </div>`;
