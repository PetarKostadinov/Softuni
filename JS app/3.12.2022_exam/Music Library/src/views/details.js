import { deleteById, getById, getLikesForSpecUser, getTotatlLikes, postLike } from "../api/data.js";
import { html, nothing } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (album, isOwner, isUser, onDelete, onLike, likes, shoLikeButton) => html`
<section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src=${album.imageUrl} alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${album.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">${likes}</span></div>

          <!--Edit and Delete are only for creator-->
          
          <div id="action-buttons">
          ${shoLikeButton ? html`
          <a @click=${onLike} href="" id="like-btn">Like</a>` : nothing}
            
            ${isOwner && isUser ? html`
            <a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : nothing}
          </div>
          
        </div>
      </section>`;    
//#####################################################################################################

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const userData = getUserData();
    const album =  await getById(id)
    let [likes, hasLike] = await Promise.all([
               
                getTotatlLikes(id),
                userData ? getLikesForSpecUser(id, userData._id) : 0
            ])

      const isUser = Boolean(ctx.user)
      const isOwner = isUser && ctx.user._id == album._ownerId;
      let shoLikeButton = isOwner == false && hasLike == false && userData != null;
    ctx.render(detailsTemplate(album, isOwner, isUser, onDelete, onLike, likes, shoLikeButton));

    async function onDelete(){
        
        const choise = confirm('Are you sure you want to delete this album?');

        if(choise){

            await deleteById(id);
            ctx.page.redirect('/catalog')
        }
    } 

    async function onLike(){
        await postLike(id)
        ctx.page.redirect('/catalog/' + id)
    } 
}













