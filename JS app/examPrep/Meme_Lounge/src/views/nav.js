import { logout } from "../api/users.js";
import { html, render, page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.getElementById('nav');

const navTemplate = (hasUser) => html`

    <a href="/catalog">All Memes</a>
    <!-- Logged users -->
    ${hasUser ? html`
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, {email}</span>
            <a href="/myProfile">My Profile</a>
            <a @click=${onLogout} href="javascript:void(0)">Logout</a>
        </div>
    </div>` 
    : html`
    <!-- Guest users -->
    <div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/">Home Page</a>
    </div>`}
`;

export function updateNav() {

    
    const user = getUserData();
    render(navTemplate(user), nav);

}
function onLogout() {
    logout();
    updateNav();
    
    page.redirect('/');
}


