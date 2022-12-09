import { getByYear, getMyCars } from "../api/data.js";
import { html, nothing } from "../lib.js";


const searchTemplate = (onSearch, onChange, result) => html`
<section id="search-cars">
<h1>Filter by year</h1>

    <div  class="container">
        <input  id="search-input" type="text" name="search" placeholder="Enter desired production year" @input=${onChange}>
        <button @click=${onSearch} type="submit" class="button-list">Search</button>
    </div>



<h2>Results:</h2>
<div class="listings">

    <!-- Display all records -->
   
    ${result.map(car => carTemplate(car))}
   
   ${result.length == 0 ? html`<p class="no-cars"> No results.</p>` : nothing}
    

   
</div>
</section>`;

const carTemplate = (car) => html`
<div class="listing">
<div class="preview">
    <img src=${car.imageUrl}>
</div>
<h2>${car.brand } ${car.model}</h2>
<div class="info">
    <div class="data-info">
        <h3>Year: ${car.year}</h3>
        <h3>Price: ${car.price} $</h3>
    </div>
    <div class="data-buttons">
        <a href="/catalog/${car._id}" class="button-carDetails">Details</a>
    </div>
</div>
</div>`;


export async function showSearch(ctx) {
    
    let input = '';
  
    let result = [];

    function onChange (ev) {
        input = ev.target.value;
    }
    
    async function onSearch(){
        
       result = await getByYear(input);

       if(result.length > 0){
        
       }
        
       ctx.render(searchTemplate(onSearch, onChange, result));
    }

    ctx.render(searchTemplate(onSearch, onChange, result));
}
