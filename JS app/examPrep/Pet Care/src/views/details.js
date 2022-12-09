import { deleteById, getById } from "../api/data.js";
import { donate } from "../api/donations.js";
import { html, nothing } from "../lib.js";




const detailsTemplate = (pet, isUser, isOwner, onDelete, onDonate) => html`<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>
            <!-- if there is no registered isUser, do not display div-->
            ${isUser ? html`<div class="actionBtn">
                <!-- Only for registered isUser and creator of the pets-->
                ${isOwner ? html`
                 <a href="/edit/${pet._id}" class="edit">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`
                 : html`
                  <!--(Bonus Part) Only for no creator and isUser-->
                <a @click=${onDonate} href="javascript:void(0)" class="donate">Donate</a>`}
            </div>` : nothing}

        </div>
    </div>
</section>`;
//#####################################################################################################
export async function showDetails(ctx) {

  
    const id = ctx.params.id;
    const pet = await getById(id);

      
      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user._id == pet._ownerId;

    ctx.render(detailsTemplate(pet, isUser, isOwner, onDelete, onDonate));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this pet?');

        if(choise){

            await deleteById(id);

            ctx.page.redirect('/')
        }
    } 

    async function onDonate(){

        await donate(id);
        ctx.page.redirect('/catalog/' + id);
    }
}