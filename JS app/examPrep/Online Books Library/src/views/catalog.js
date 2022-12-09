import { getAll } from '../api/data.js';
import { html, nothing } from '../lib.js';


const catalogTemplate = (books) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    ${books.length > 0 ? html`
    <ul class="other-books-list">
        ${books.map(book => bookTemplate(book))}
    </ul>` 
    : html`
    <!-- Display paragraph: If there are no books in the database -->
    <p class="no-books">No books in database!</p>`}
    
    
</section>`;

const bookTemplate = (book) => html`
<li class="otherBooks">
<h3>${book.title}</h3>
<p>Type: ${book.type}</p>
<p class="img"><img src=${book.imageUrl}></p>
<a class="button" href="/catalog/${book._id}">Details</a>
</li>`;

export async function showCatalog(ctx) {
    const books = await getAll();
    //const isUser = Boolean(ctx.user);
    ctx.render(catalogTemplate(books));
}
