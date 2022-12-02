import { deleteById, getAllComents, getById, postComent } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const detailsTemplate = (game, isOwner, onDelete, addComent, allComents, onComent) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src=${game.imageUrl} />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">
        ${game.summary}
        </p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>

            ${allComents.length > 0 ? html`
            <ul>
                <!-- list all comments for current game (If any) -->
                ${allComents.map(comment => commentTemplate(comment))}
                
            </ul>`
             : html`
             <!-- Display paragraph: If there are no games in the database -->
            <p class="no-comment">No comments.</p>`}  
        </div>

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        ${isOwner ? html`
        <div class="buttons">
            <a href="/edit/${game._id}" class="button">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
        </div>` : nothing}
        
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    ${addComent ? html`
    <article class="create-comment">
        <label>Add new comment:</label>
        <form @submit=${onComent} class="form">
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
        </form>
    </article>` : nothing}
    

</section>`;


const commentTemplate = (comment) => html`
<li class="comment">
<p>Content: ${comment.comment}</p>
</li>`;


//#####################################################################################################
export async function showDetails(ctx) {
    const id = ctx.params.id;
    const game = await getById(id);

      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user.id == game._ownerId;
      const addComent = isUser == true && isOwner == false

      const allComents = await getAllComents(game._id)

    ctx.render(detailsTemplate(game, isOwner, onDelete, addComent, allComents, createSubmitHandler(onComent)));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this game?');

        if(choise){

            await deleteById(id);
            ctx.page.redirect('/');
        }
    } 
    async function onComent({comment}){

        const gameId = game._id
        const data = { gameId, comment };
       const result =  await postComent(data);
       console.log(result)
        ctx.page.redirect('/catalog/' + id)
    }
   
}





// const detailsTemplate = (game, isUser, isOwner, onDelete, onDonate) => html`<section id="detailsPage">
//     <div class="details">
//         <div class="animalPic">
//             <img src=${game.image}>
//         </div>
//         <div>
//             <div class="animalInfo">
//                 <h1>Name: ${game.name}</h1>
//                 <h3>Breed: ${game.breed}</h3>
//                 <h4>Age: ${game.age}</h4>
//                 <h4>Weight: ${game.weight}</h4>
//                 <h4 class="donation">Donation: 0$</h4>
//             </div>
//             <!-- if there is no registered isUser, do not display div-->
//             ${isUser ? html`<div class="actionBtn">
//                 <!-- Only for registered isUser and creator of the memes-->
//                 ${isOwner ? html`
//                  <a href="/edit/${game._id}" class="edit">Edit</a>
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
//     const game = await getById(id);

      
//       const isUser = Boolean(ctx.user)
//       const isOwner = isUser && ctx.user._id == game._ownerId;

//     ctx.render(detailsTemplate(game, isUser, isOwner, onDelete, onDonate));

//     async function onDelete(){
        
//         const choise = confirm('Are you sure you want to delete this game?');

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