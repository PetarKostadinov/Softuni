function addItem() {
    
    let input = document.getElementById('newItemText').value;

    let elements = document.getElementById('items');

    const liElement = document.createElement('li');

    liElement.textContent = input;

    elements.appendChild(liElement);

    document.getElementById('newItemText').value = '';


}