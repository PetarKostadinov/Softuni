function create(words) {

   const content = document.getElementById('content');

   content.addEventListener('click', reveal);

   for (const word of words) {
      
      const div = document.createElement('div');
      const para = document.createElement('p');
      para.textContent = word;
      para.style.display = 'none';
      div.appendChild(para);

      //div.addEventListener('click', reveal);
      content.appendChild(div);

   };

   function reveal(event){

      if (event.target.tagName == 'DIV' && event.target != content){

          event.target.children[0].style.display = '';
      };

   };
   
}