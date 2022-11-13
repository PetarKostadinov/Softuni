window.addEventListener('DOMContentLoaded', load)

const tbody = document.getElementById('results').children[1];
const form = document.getElementById('form');
form.addEventListener('submit', onSubmit);

function create(data) {
    const tr = document.createElement('tr');
    tr.innerHTML = `<td>${data.firstName}</td>
    <td>${data.lastName}</td>
    <td>${data.facultyNumber}</td>
    <td>${Number(data.grade)}</td>`

    return tr;
}

async function onSubmit(ev) {
   
    const formData = new FormData(ev.target);
    const firstName = formData.get('firstName');
    const lastName = formData.get('lastName');
    const facultyNumber = formData.get('facultyNumber');
    const grade = formData.get('grade');

    const result = await createStudent({ firstName, lastName, facultyNumber, grade });
    tbody.appendChild(create(result))
}

async function createStudent(student) {

    try {

        const res = await fetch('http://localhost:3030/jsonstore/collections/students', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(student)
        });

        if (!res.ok || res.status != 200) {
            throw new Error(data.message)
        }
        return res

    } catch (error) {
        alert(error.message)
    }
}

async function load(ev) {

    ev.preventDefault()

    try {

        const url = 'http://localhost:3030/jsonstore/collections/students';
        const res = await fetch(url);
        const data = await res.json();

        if (!res.ok || res.status != 200) {
            throw new Error(data.message)
        }

        Object.values(data).forEach(x => tbody.appendChild(create(x)));

    } catch (error) {
        alert(error.message)
    }
}
