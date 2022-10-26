function encodeAndDecodeMessages() {

    let textArea = document.querySelectorAll('textarea');
    let temp = '';
    
    const encodeBtn = document.querySelectorAll('button')[0];
    encodeBtn.addEventListener('click', encode);
    const decodeBgtn = document.querySelectorAll('button')[1];
    decodeBgtn.addEventListener('click', decode);
    /**
     * 
     * @param {event} e 
     */
    function encode(e){

        let newText = '';

        let firstText = e.target.parentElement.children[1].value;

        document.querySelectorAll('textarea')[0].value = '';
        document.querySelectorAll('textarea')[1].value = '';

        for (let index = 0; index < firstText.length; index++) {
            
            let currChar = firstText[index].charCodeAt();

            newText += String.fromCharCode(currChar + 1);
        }
       
        document.querySelectorAll('textarea')[1].value = newText;

        temp = firstText;

    }

    function decode (e){

        e.target.parentElement.children[1].value = temp;

    }

}