import { deleteById, getById } from "../api/data.js";
import { html, nothing } from "../lib.js";

const detailsTemplate = (album, isOwner, onDelete) => html`
<section id="detailsPage">
<div class="wrapper">
    <div class="albumCover">
        <img src=${album.imgUrl}>
    </div>
    <div class="albumInfo">
        <div class="albumText">

            <h1>Name: ${album.name}</h1>
            <h3>Artist: ${album.artist}</h3>
            <h4>Genre: ${album.genre}</h4>
            <h4>Price: ${album.price}</h4>
            <h4>Date: ${album.releaseDate}</h4>
            <p>Description: ${album.description}</p>
        </div>

        <!-- Only for registered user and creator of the album-->
        ${isOwner ? html`
        <div class="actionBtn">
            <a href="/edit/${album._id}" class="edit">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
        </div>` : nothing}
       
    </div>
</div>
</section>`;
//#####################################################################################################
export async function showDetails(ctx) {
    const id = ctx.params.id;
    const album = await getById(id);

      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user._id == album._ownerId;

    ctx.render(detailsTemplate(album, isOwner, onDelete));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this album?');

        if(choise){

            await deleteById(id);
            ctx.page.redirect('/catalog')
        }
    } 

   
}





// const detailsTemplate = (album, isUser, isOwner, onDelete, onDonate) => html`<section id="detailsPage">
//     <div class="details">
//         <div class="animalPic">
//             <img src=${album.image}>
//         </div>
//         <div>
//             <div class="animalInfo">
//                 <h1>Name: ${album.name}</h1>
//                 <h3>Breed: ${album.breed}</h3>
//                 <h4>Age: ${album.age}</h4>
//                 <h4>Weight: ${album.weight}</h4>
//                 <h4 class="donation">Donation: 0$</h4>
//             </div>
//             <!-- if there is no registered isUser, do not display div-->
//             ${isUser ? html`<div class="actionBtn">
//                 <!-- Only for registered isUser and creator of the albums-->
//                 ${isOwner ? html`
//                  <a href="/edit/${album._id}" class="edit">Edit</a>
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
//     const album = await getById(id);

      
//       const isUser = Boolean(ctx.user)
//       const isOwner = isUser && ctx.user._id == album._ownerId;

//     ctx.render(detailsTemplate(album, isUser, isOwner, onDelete, onDonate));

//     async function onDelete(){
        
//         const choise = confirm('Are you sure you want to delete this album?');

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