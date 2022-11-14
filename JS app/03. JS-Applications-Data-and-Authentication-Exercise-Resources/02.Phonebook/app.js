function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadInfo);
    document.getElementById('btnCreate').addEventListener('click', onCreate);
    list.addEventListener('click', onDelete)
    loadInfo();
}
const list = document.getElementById('phonebook');
const personInput = document.getElementById('person');
const phoneInput = document.getElementById('phone');

attachEvents();

async function onCreate() {

    const person = personInput.value;
    const phone = phoneInput.value;
    const contact = { person, phone }

    const result = await createInfo(contact);

    list.appendChild(createItem(result))
}

async function onDelete(ev) {

    const id = ev.target.dataset.id;
    if (id != undefined) {
        await deleteInfo(id)
        ev.target.parentElement.remove()
    }
}

function createItem(contact) {

    const li = document.createElement('li');
    li.innerHTML = `${contact.person}: ${contact.phone}<button data-id='${contact._id}'>Delete</button>`
    return li;
}

async function loadInfo() {
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const res = await fetch(url);
    const data = await res.json();
    list.replaceChildren();
    Object.values(data).map(createItem).forEach(x => list.appendChild(x))

}
async function createInfo(contact) {
    const res = await fetch(`http://localhost:3030/jsonstore/phonebook`, {

        method: 'post',
        headers: { 'Content-Type': 'aplication/json' },
        body: JSON.stringify(contact)

    });


    const result = await res.json();
    return result;

}
async function deleteInfo(id) {

    const res = await fetch(`http://localhost:3030/jsonstore/phonebook/` + id, {

        method: 'delete'
    });

    const result = await res.json();
    return result;

}