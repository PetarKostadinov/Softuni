function search() {
   
   let townsArr = [...document.querySelectorAll('ul li')];
   let searchText = document.getElementById('searchText').value;
   let count = 0;

   for (let item of townsArr){

      let townName = item.textContent;

      if (townName.includes(searchText)){

         item.style.textDecoration = 'underline';
         item.style.fontWeight = 'bold';

         count++;
      }else {

         item.style.textDecoration = 'none';
         item.style.fontWeight = 'normal';
      };

   };

   document.getElementById('result').innerText = `${count} matches found`;
}
