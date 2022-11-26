
import { egtAllIdeas } from "../api/data.js";
const section = document.getElementById('dashboard-holder');
section.addEventListener('click', onDetailsSelect)
let ctx = null;
export async function showCatalog(context){
    ctx = context;
    context.showSection(section)
    const ideas = await egtAllIdeas()

    if(ideas.length == 0){
        section.innerHTML = `<h1>No ideas yet! Be the first one :)</h1>`
    }else{
        section.replaceChildren(...ideas.map(createIdeaPreview));
    }
}

function createIdeaPreview(idea){

    const el = document.createElement('div');
    el.className = 'card overflow-hidden current-card details'
    el.style.width = '20rem'
    el.style.height = '18rem'
    el.innerHTML = `
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a data-id="${idea._id}" class="btn" href="/details">Details</a>`;

    return el;
}

function onDetailsSelect(ev){

    if(ev.target.tagName == 'A'){
        ev.preventDefault();
        const id = ev.target.dataset.id;

        if(id){
            ctx.goTo('/details', id)
        }
    }
}

