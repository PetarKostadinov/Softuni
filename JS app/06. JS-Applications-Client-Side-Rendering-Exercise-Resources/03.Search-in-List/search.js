import {render, html} from '../node_modules/lit-html/lit-html.js';
import {towns as townNames} from './towns.js';

const listTemplate = (towns) => html`
<ul>
   ${towns.map(x => html`<li class="${x.match ? 'active' : ''}">${x.name}</li>`)}
</ul>`

const towns = townNames.map(x => ({name: x, match: false}));
const root = document.getElementById('towns');
const input = document.getElementById('searchText');
const output = document.getElementById('result');
document.querySelector('button').addEventListener('click', onSearch)

update();

function update(){
   const result = listTemplate(towns);
   render(result, root);
}

function onSearch(){
   const match = input.value.trim();
   let matches = 0;
   for (let town of towns) {

      if(match && town.name.includes(match)){
         town.match = true;
         matches++;
      }else{
         town.match = false;
      } 
   }
   
   output.textContent = `${matches} matches found` ;
   update();
}



