function attachEvents() {
   
    document.getElementById('refresh').addEventListener('click', loadMess)

    document.getElementById('submit').addEventListener('click', onSubmit)
    loadMess();
}

const authorInput = document.querySelector('[name="author"]');
const contentInput = document.querySelector('[name="content"]');
const list = document.getElementById('messages');

attachEvents();

async function onSubmit(){

    const author = authorInput.value;
    const content = contentInput.value;

    const result = await createMess({author, content});

    contentInput.value = '';
    list.value += '\n' + `${author}: ${content}`;
}

async function loadMess() {

    const url = `http://localhost:3030/jsonstore/messenger`;
    const res = await fetch(url);
    const data = await res.json();

    const mess = Object.values(data)
   
    
    list.value = mess.map(x => `${x.author}: ${x.content}`).join('\n')

}

async function createMess(message) {

    const url = `http://localhost:3030/jsonstore/messenger`;
    const options = {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(message)

    };

    const res = await fetch(url, options);
    const result = await res.json();
    return result;
}