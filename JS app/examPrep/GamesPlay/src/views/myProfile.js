//import { getOwnMemes } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { getUserData } from "../util.js";

const myProfileTemplate = (user, memes) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${user.gender}.png">
        <div class="user-content">
            <p>Username: ${user.username}</p>
            <p>Email: ${user.email}</p>
            <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) -->
        ${memes.length > 0 ? 
        memes.map(meme => memeTemplate(meme)) 
        : html`
        <!-- Display : If user doesn't have own memes  -->
        <p class="no-memes">No memes in database.</p>`}

    </div>
</section>`;

const memeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
    <a class="button" href="/catalog/${meme._id}">Details</a>
</div>`;


export async function showMyProfile(ctx) {

    const id = ctx.user.id;
    const user = getUserData();

    const memes = await getOwnMemes(id)

    ctx.render(myProfileTemplate(user, memes));
}