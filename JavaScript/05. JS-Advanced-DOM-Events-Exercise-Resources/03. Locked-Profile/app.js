function lockedProfile() {

    Array.from(document.querySelectorAll('.profile button')).forEach(e => e.addEventListener('click', onToggle));

    function onToggle (event) {

        const profile = event.target.parentElement;

        const isUnLocked = profile.querySelector('input[type="radio"][value="unlock"]').checked;

        if(isUnLocked){

            const infoDiv = profile.querySelector('div');

            if(event.target.textContent == 'Show more'){

                infoDiv.style.display = 'block';

                event.target.textContent = 'Hide it';
            
            }else{

                infoDiv.style.display = '';

                event.target.textContent = 'Show more';

            };
        };
    };

    /////////////////////ADDITIONAL FUNCTIONALITY - NOT INCLUDE IN THE EXERSICE/////////

    const radio = Array.from(document.querySelectorAll('input[type="radio"]'));

    for (let element of radio) {
     
        element.addEventListener('click', onTick);

        if(element.value == 'lock'){

            element.parentElement.querySelector('button').disabled = true;

        };
    };

    function onTick(e){

        const button = e.target.parentElement.querySelector('button')

        if(e.target.value == 'lock'){

            button.disabled = true;

        }else{

            button.disabled = false;
        };
    };
    
}