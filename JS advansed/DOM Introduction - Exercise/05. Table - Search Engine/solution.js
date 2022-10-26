function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let container = document.querySelectorAll('tbody tr');

   let input = document.getElementById('searchField');

   function onClick() {
   
      for (const row of container) {

         row.classList.remove('select')
         
         if (row.innerHTML.includes(input.value)){

            row.className = 'select'
         };
         
      }

      input.value = '';

   }
}