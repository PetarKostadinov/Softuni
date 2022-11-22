import {render, html} from '../node_modules/lit-html/lit-html.js';

const listTemplate = (items) => html`
<select id="menu">
    ${items.map(x => html`<option value=${x._id}>${x.text}</option>`)}
</select>`;

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const root = document.querySelector('div');

getData();

async function getData(){

    const res = await fetch(url);
    const data = await res.json();
    
    update(Object.values(data))
}

function update(data){

    const result = listTemplate(data);
    render(result, root)
}

const form = document.querySelector('form').addEventListener('submit', onSubmit);

async function onSubmit(ev){

    ev.preventDefault();
   
   const text = document.getElementById('itemText').value;

   const res = await fetch(url, {
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({text})
   })

   if(res.ok){
    getData();
   }
}




