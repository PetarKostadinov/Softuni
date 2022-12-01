import { getSearched } from "../api/data.js";
import { html } from "../lib.js";

const ownBooksTemplate = (books) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <!-- Display ul: with list-items for every user's books (if any) -->
    ${books.length > 0 ? html`
    <ul class="my-books-list">
    ${books.map(book => bookTemplate(book))}
    </ul>` 
    : html`
    <!-- Display paragraph: If the user doesn't have his own books  -->
    <p class="no-books">No books in database!</p>`}
</section>`;

const bookTemplate = (book) => html`
<li class="otherBooks">
<h3>${book.title}</h3>
<p>Type: ${book.type}</p>
<p class="img"><img src=${book.imageUrl}></p>
<a class="button" href="/catalog/${book._id}">Details</a>
</li>`;


export async function showMyBooks (ctx) {

    const id = ctx.user._id;

    const books = await getSearched(id);

    ctx.render(ownBooksTemplate(books));
}