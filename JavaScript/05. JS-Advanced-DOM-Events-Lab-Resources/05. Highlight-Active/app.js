function focused() {
    
    Array.from(document.querySelectorAll('input'))
    .forEach(x => {
        x.addEventListener('focus', onFocus)
        x.addEventListener('blur', onBlur)
    
    });

    function onFocus(event){

        event.target.parentElement.className = 'focused';

    };

    function onBlur(event){

        event.target.parentElement.className = '';

    };
  
}