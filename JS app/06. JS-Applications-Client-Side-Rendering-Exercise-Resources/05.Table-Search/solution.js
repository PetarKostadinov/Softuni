import { render, html } from "../node_modules/lit-html/lit-html.js";

const url = 'http://localhost:3030/jsonstore/advanced/table';
const root = document.querySelector('tbody');
const input = document.getElementById('searchField');
const btn = document.getElementById('searchBtn');
let students;

const listTemplate = (student) => html`
   <tr class=${student.match ? 'select' : ''}>
      <td>${student.item.firstName} ${student.item.lastName}</td>
      <td>${student.item.email}</td>
      <td>${student.item.course}</td>
   </tr>`;

getData();

async function getData(){

   const res = await fetch(url);
   const data = await res.json();
   students = Object.values(data).map(x => ({item: x, match: false}));
 
   update();
}

function update(){
   const result = students.map(listTemplate);
   render(result, root)
}

btn.addEventListener('click', onClick);

 function onClick(ev) {

   console.log(input.value)
   const text = input.value.toLocaleLowerCase().trim();

   for(let el of students){

      if(input.value != ''){
         el.match = Object.values(el.item).some(x => x.toLocaleLowerCase().includes(text))
      }
   }

   input.value = ''
   update();
}
