function addItem() {
    let input = document.getElementById('newItemText').value;

    let liElement = document.createElement('li');

    liElement.textContent = input;

    let deleteButton = document.createElement('a');

    deleteButton.textContent = '[Delete]'

    deleteButton.href = '#'

    liElement.appendChild(deleteButton)

    document.getElementById('items').appendChild(liElement)

    deleteButton.addEventListener('click', onDelete);

    function onDelete (event){

        event.target.parentElement.remove();

    };
}