import { logout } from "../api/users.js";
import { html, render, page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('#site-header');

const navTemplate = (hasUser) => html`
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/">Dashboard</a>
        <!-- Guest users -->
        ${!hasUser ? html`
        <div id="guest">
            <a class="button" href="/login">Login</a>
            <a class="button" href="/register">Register</a>
        </div>` 
        : html`
        <!-- Logged-in users -->
        <div id="user">
            <span>Welcome, ${hasUser.email}</span>
            <a class="button" href="/myBook">My Books</a>
            <a class="button" href="/create">Add Book</a>
            <a @click=${onLogout} class="button" href="/">Logout</a>
        </div>`}
    </section>
</nav>`;

export function updateNav() {

    const user = getUserData();
    render(navTemplate(user), nav);

}
function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}


