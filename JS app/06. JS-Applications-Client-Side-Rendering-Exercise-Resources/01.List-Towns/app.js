import { html, render } from "../node_modules/lit-html/lit-html.js";

document.getElementById('btnLoadTowns').addEventListener('click', getTowns);

const listTemplate = (data) => html`
<ul>
    ${data.map(town => html`<li>${town}</li>`)}
</ul>
`
const root = document.getElementById('root');

function getTowns(ev) {

    const towns = document.getElementById('towns').value.split(',').map(x => x.trim());

    towns.forEach(x => {
        if(x == ''){
            towns.pop(x)
        }
    })

    if (towns != ''){
        ev.preventDefault();
     
        const result = listTemplate(towns);
    
        render(result, root)
    
        document.getElementById('towns').value = '';
    }
}

//alternative :
// const form =  document.querySelector('form');
// form.addEventListener('submit', onSubmit);

// function onSubmit(ev){

//     ev.preventDefault();
//     let towns = document.getElementById('towns');
//     towns = towns.value.split(',').map(x => x.trim());

//     const result = listTemplate(towns);
//     render(result, root)
// }

// const listTemplate = (towns) => html`
// <ul>
//     ${towns.map(x => html`<li>${x}</li>`)}
// </ul>
// `