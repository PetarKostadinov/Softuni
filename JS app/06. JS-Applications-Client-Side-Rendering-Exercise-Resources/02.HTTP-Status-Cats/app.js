import { html, render } from "../node_modules/lit-html/lit-html.js";
import { cats as catData} from "./catSeeder.js";

// const root = document.getElementById('allCats');

// const listCats = (cat) => html`
// <li>
// <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
// <div class="info">
//     <button class="showBtn">Show status code</button>
//     <div class="status" style="display: none" ${cat.id}">
//         <h4>Status Code: ${cat.statusCode}</h4>
//         <p>${cat.statusMessage}</p>
//     </div>
// </div>
// </li>`;

// render(html`<ul>${catData.map(listCats)}</ul>`, root);

// root.addEventListener('click', onClick);

// function onClick(ev){

//     if(ev.target.tagName == 'BUTTON'){

//         let el = ev.target.parentNode.querySelector('.status');

//         if(el.style.display == 'none'){
//             el.style.display = 'block';
//             ev.target.textContent = 'Hide status code';
//         }else{
//             el.style.display ='none';
//             ev.target.textContent = 'Show status code';
//         }

//     }
// }

//alternative:

const root = document.getElementById('allCats');

const listCats = (cat) => html`
<ul>
    ${cat.map(x => html`
    <li>
    <img src="./images/${x.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id=${x.id}">
            <h4>Status Code: ${x.statusCode}</h4>
            <p>${x.statusMessage}</p>
        </div>
    </div>
    </li>`)}
</ul>`;

update()

function update(){

    const result =  listCats(catData)
    render(result, root);
}
root.addEventListener('click', onClick);
function onClick(ev){

    if(ev.target.tagName == 'BUTTON'){

        let el = ev.target.parentNode.querySelector('.status');

        if(el.style.display == 'none'){
            el.style.display = 'block';
            ev.target.textContent = 'Hide status code';
        }else{
            el.style.display ='none';
            ev.target.textContent = 'Show status code';
        }
    }
}