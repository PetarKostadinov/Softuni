import { deleteById, getById } from "../api/data.js";
import { html, nothing } from "../lib.js";

const detailsTemplate = (meme, isOwner, onDelete) => html`
<section id="meme-details">
            <h1>Meme Title: ${meme.title}

            </h1>
            <div class="meme-details">
                <div class="meme-img">
                    <img alt="meme-alt" src=${meme.imageUrl}>
                </div>
                <div class="meme-description">
                    <h2>Meme Description</h2>
                    <p>
                      ${meme.description}
                    </p>

                    <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
                    ${isOwner ? html`
                    <a class="button warning" href="/edit/${meme._id}">Edit</a>
                    <button @click=${onDelete} class="button danger">Delete</button>` 
                    : nothing}
                    
                </div>
            </div>
        </section>`;
//#####################################################################################################
export async function showDetails(ctx) {
    const id = ctx.params.id;
    const meme = await getById(id);

      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user.id == meme._ownerId;

    ctx.render(detailsTemplate(meme, isOwner, onDelete));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this meme?');

        if(choise){

            await deleteById(id);
            ctx.page.redirect('/catalog')
        }
    } 

   
}





// const detailsTemplate = (meme, isUser, isOwner, onDelete, onDonate) => html`<section id="detailsPage">
//     <div class="details">
//         <div class="animalPic">
//             <img src=${meme.image}>
//         </div>
//         <div>
//             <div class="animalInfo">
//                 <h1>Name: ${meme.name}</h1>
//                 <h3>Breed: ${meme.breed}</h3>
//                 <h4>Age: ${meme.age}</h4>
//                 <h4>Weight: ${meme.weight}</h4>
//                 <h4 class="donation">Donation: 0$</h4>
//             </div>
//             <!-- if there is no registered isUser, do not display div-->
//             ${isUser ? html`<div class="actionBtn">
//                 <!-- Only for registered isUser and creator of the memes-->
//                 ${isOwner ? html`
//                  <a href="/edit/${meme._id}" class="edit">Edit</a>
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
//     const meme = await getById(id);

      
//       const isUser = Boolean(ctx.user)
//       const isOwner = isUser && ctx.user._id == meme._ownerId;

//     ctx.render(detailsTemplate(meme, isUser, isOwner, onDelete, onDonate));

//     async function onDelete(){
        
//         const choise = confirm('Are you sure you want to delete this meme?');

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