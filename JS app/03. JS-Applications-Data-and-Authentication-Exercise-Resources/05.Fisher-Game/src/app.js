let userDta = null;

window.addEventListener('DOMContentLoaded', () => {
    userDta = JSON.parse(sessionStorage.getItem('userData'));
    if (userDta != null) {
        document.getElementById('guest').style.display = 'none'
        document.querySelector('#addForm .add').disabled = false;
    } else {
        document.getElementById('user').style.display = 'none'
    }

    document.querySelector('.load').addEventListener('click', loadData);

    document.getElementById('addForm').addEventListener('submit', onCreateSubmit);
    document

    const email = JSON.parse(sessionStorage.getItem('userData'))?.email;
    document.querySelector('.email span').textContent = email || document.querySelector('.email span').textContent;

    const main = document.getElementById('main');
    main.style.display = 'none'
})

const catches = document.getElementById('catches');
catches.addEventListener('click', onTableClick);


const token = JSON.parse(sessionStorage.getItem('userData')).token;

function onTableClick(ev) {

    if (ev.target.className == 'delete') {
        onDelete(ev.target);
    } else if (ev.target.className == 'update') {
        onUpdate(ev, ev.target);
    }
}

async function onUpdate(ev, button) {
    ev.preventDefault();

    const currCetch = button.parentElement;
    const id = button.dataset.id;

    const anglerIn = currCetch.querySelector('.angler')
    const weightIn = currCetch.querySelector('.weight')
    const speciesIn = currCetch.querySelector('.species')
    const locationIn = currCetch.querySelector('.location')
    const baitIn = currCetch.querySelector('.bait')
    const captureTimeIn = currCetch.querySelector('.angler')

    let updatedCatch = {
        angler: anglerIn.value,
        weight: Number(weightIn.value),
        species: speciesIn.value,
        location: locationIn.value,
        bait: baitIn.value,
        captureTime: Number(captureTimeIn.value)
    }

    const res = await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'put',
        headers: { 'X-Authorization': token },
        body: JSON.stringify(updatedCatch)
    })

   
    loadData();

}

async function onDelete(button) {

    const id = button.dataset.id;
    await deleteCatch(id);
    button.parentElement.remove();
}

async function deleteCatch(id) {

    const res = await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'delete',
        headers: { 'X-Authorization': token }
    });
    return res;
}

async function onCreateSubmit(ev) {

    ev.preventDefault();

    if (!userDta) {
        window.location = '/login.html';
        return;
    }

    const formData = new FormData(ev.target);

    const data = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, { [k]: v }), {});

    try {
        if (Object.values(data).some(x => x == '')) {
            throw new Error('All fields are required!')
        }

        const res = await fetch('http://localhost:3030/data/catches', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userDta.token
            },
            body: JSON.stringify(data)
        })

        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message);
        }

        ev.target.reset();
        loadData();

    } catch (err) {
        alert(err.message)
    }
}

async function loadData() {

    const res = await fetch('http://localhost:3030/data/catches');
    const data = await res.json();
    document.getElementById('catches').replaceChildren(...data.map(createPreview));
    main.style.display = ''
}

function createPreview(item) {
    const isOwner = (userDta && item._ownerId == userDta.id);
    const element = document.createElement('div');
    element.className = 'catch';
    element.innerHTML =
        `<label>Angler</label>
    <input type="text" class="angler" value="${item.angler}" ${!isOwner ? 'disabled' : ''}>
    <label>Weight</label>
    <input type="text" class="weight" value="${item.weight}" ${!isOwner ? 'disabled' : ''}>
    <label>Species</label>
    <input type="text" class="species" value="${item.species}" ${!isOwner ? 'disabled' : ''}>
    <label>Location</label>
    <input type="text" class="location" value="${item.location}" ${!isOwner ? 'disabled' : ''}>
    <label>Bait</label>
    <input type="text" class="bait" value="${item.bait}" ${!isOwner ? 'disabled' : ''}>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${item.captureTime}" ${!isOwner ? 'disabled' : ''}>
    <button class="update" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Update</button>
    <button class="delete" data-id="${item._id}" ${!isOwner ? 'disabled' : ''}>Delete</button>`;

    return element;
}