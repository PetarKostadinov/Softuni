import { createIdeas } from "../api/data.js";

const section = document.getElementById('createPage');

let form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx = null;

export function showCreate(context){

    ctx = context;
    context.showSection(section)
}

async function onSubmit(ev){
ev.preventDefault();
    let formData = new FormData(form);

    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('imageURL')

    await createIdeas({
        title,
        description,
        img
    })

    form.reset();

    ctx.goTo('/catalog')

}