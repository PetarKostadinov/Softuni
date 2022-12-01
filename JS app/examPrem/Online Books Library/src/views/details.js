import { deleteById, getById, getLikesForSpecUser, getTotatlLikes, postLike } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (book, isOwner, isUser, onDelete, shoLikeButton, onLike, likes) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            ${isOwner ? html`
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            <a class="button" href="/edit/${book._id}">Edit</a>
                <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>` : nothing}
            

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${shoLikeButton ? html`
            <a @click=${onLike} class="button" href="javascript:void(0)">Like</a>` 
            : nothing}
            

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>`;    
//#####################################################################################################

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const userData = getUserData();

    let [book, likes, hasLike] = await Promise.all([
                getById(id),
                getTotatlLikes(id),
                userData ? getLikesForSpecUser(id, userData._id) : 0
            ])

      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user._id == book._ownerId;
      let shoLikeButton = isOwner == false && hasLike == false && userData != null;
    ctx.render(detailsTemplate(book, isOwner, isUser, onDelete, shoLikeButton, onLike, likes));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this book?');

        if(choise){

            await deleteById(id);
            ctx.page.redirect('/')
        }
    } 

    async function onLike(){
        await postLike(id)
        ctx.page.redirect('/catalog/' + id)
    } 
}




// export async function showDetails(ctx) {

//     const userData = getUserData();

//     const [book, likes, hasLike] = await Promise.all([
//         getById(ctx.params.id),
//         getTotatlLikes(ctx.params.id),
//         userData ? getLikesForSpecUser(ctx.params.id, userData.id) : 0
//     ])

//     let isOwner = userData && userData.id == book.ownerId;
//     let shoLikeButton = isOwner == false && hasLike == false && userData != null;
//     ctx.render(detailsTemplate(book, isOwner, onDelete, likes, shoLikeButton, onLike));

//     async function onDelete(){
        
//         const choise = confirm('Are you sure you want to delete this book?');

//         if(choise){

//             await deleteById(ctx.params.id);
//             ctx.page.redirect('/')
//         }
//     }

//     async function onLike(){
//         await postLike(ctx.params.id);
//         ctx.page.redirect('/catalog/' + ctx.params.id)
//     }
// }

















// const detailsTemplate = (book, isUser, isOwner, onDelete, onDonate) => html`<section id="detailsPage">
//     <div class="details">
//         <div class="animalPic">
//             <img src=${book.image}>
//         </div>
//         <div>
//             <div class="animalInfo">
//                 <h1>Name: ${book.name}</h1>
//                 <h3>Breed: ${book.breed}</h3>
//                 <h4>Age: ${book.age}</h4>
//                 <h4>Weight: ${book.weight}</h4>
//                 <h4 class="donation">Donation: 0$</h4>
//             </div>
//             <!-- if there is no registered isUser, do not display div-->
//             ${isUser ? html`<div class="actionBtn">
//                 <!-- Only for registered isUser and creator of the books-->
//                 ${isOwner ? html`
//                  <a href="/edit/${book._id}" class="edit">Edit</a>
//                 <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`
//                  : html`
//                   <!--(Bonus Part) Only for no creator and isUser-->
//                 <a @click=${onDonate} href="javascript:void(0)" class="donate">Donate</a>`}
//             </div>` : nothing}

//         </div>
//     </div>
// </section>`;
// //#####################################################################################################
// export async function showDetails(ctx) {

  
//     const id = ctx.params.id;
//     const book = await getById(id);

      
//       const isUser = Boolean(ctx.user)
//       const isOwner = isUser && ctx.user._id == book._ownerId;

//     ctx.render(detailsTemplate(book, isUser, isOwner, onDelete, onDonate));

//     async function onDelete(){
        
//         const choise = confirm('Are you sure you want to delete this book?');

//         if(choise){

//             await deleteById(id);

//             ctx.page.redirect('/')
//         }
//     } 

//     async function onDonate(){

//         await donate(id);
//         ctx.page.redirect('/catalog/' + id);
//     }
// }