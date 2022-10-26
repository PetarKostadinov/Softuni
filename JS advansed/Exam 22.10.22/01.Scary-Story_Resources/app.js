window.addEventListener("load", solve);

function solve() {

  let obj = {

    firstName: document.getElementById('first-name'),
    lastName: document.getElementById('last-name'),
    age: document.getElementById('age'),
    storyTitle: document.getElementById('story-title'),
    genre: document.getElementById('genre'),
    story: document.getElementById('story')
  }

  let publishBtn = document.getElementById('form-btn')

  publishBtn.addEventListener('click', onPublish);

  function onPublish(ev) {

    let firstName = obj.firstName.value;
    let lastName = obj.lastName.value;
    let age = obj.age.value;
    let storyTitle = obj.storyTitle.value;
    let genre = obj.genre.value;
    let story = obj.story.value;

    let firstName1 = obj.firstName.value;
    let lastName1 = obj.lastName.value;
    let age1 = obj.age.value;
    let storyTitle1 = obj.storyTitle.value;
    let genre1 = obj.genre.value;
    let story1 = obj.story.value;



    if (firstName == '' || lastName == '' || age == '' || storyTitle == '' || story == '') {
      return
    }

    let idPreview = document.getElementById('preview-list')

    let h3 = document.createElement('h3')
    h3.textContent = `Preview`
    let li = document.createElement('li')
    li.classList = `story-info`
    let article = document.createElement('article')
    let h4 = document.createElement('h4')
    h4.textContent = `Name: ${firstName} ${lastName}`
    let pAge = document.createElement('p')
    pAge.textContent = `Age: ${age}`
    let pTitle = document.createElement('p')
    pTitle.textContent = `Title: ${storyTitle}`
    let pGenre = document.createElement('p')
    pGenre.textContent = `Genre: ${genre}`
    let pStory = document.createElement('p')
    pStory.textContent = `${story}`
    let saveBtn = document.createElement('button')
    saveBtn.classList = `save-btn`
    saveBtn.textContent = `Save Story`
    let editBtn = document.createElement('button')
    editBtn.classList = `edit-btn`
    editBtn.textContent = `Edit Story`
    let deleteBtn = document.createElement('button')
    deleteBtn.classList = `delete-btn`
    deleteBtn.textContent = `Delete Story`

    //idPreview.appendChild(h3)
    idPreview.appendChild(li)
    li.appendChild(article)
    article.appendChild(h4)
    article.appendChild(pAge)
    article.appendChild(pTitle)
    article.appendChild(pGenre)
    article.appendChild(pStory)
    li.appendChild(saveBtn)
    li.appendChild(editBtn)
    li.appendChild(deleteBtn)


    obj.firstName.value = ''
    obj.lastName.value = ''
    obj.age.value = ''
    obj.storyTitle.value = ''
    obj.genre.value = ''
    obj.story.value = ''

    publishBtn.disabled = true;
    saveBtn.disabled = false;
    editBtn.disabled = false;
    deleteBtn.disabled = false;

    editBtn.addEventListener('click', onEdit)

    function onEdit(ev) {

      obj.firstName.value = firstName1;
      obj.lastName.value = lastName1;
      obj.age.value = age1;
      obj.storyTitle.value = storyTitle;
      obj.genre.value = genre1;
      obj.story.value = story1;

      li.remove()
      publishBtn.disabled = false;
    }

    saveBtn.addEventListener('click', onSave)

    function onSave(ev){
      let main = document.getElementById('main')
      main.innerHTML = ''

      let h1 = document.createElement('h1')
      h1.textContent = 'Your scary story is saved!'

      main.appendChild(h1)
    }

    deleteBtn.addEventListener('click', onDelete)

    function onDelete(ev){
      li.remove()
      publishBtn.disabled = false;
    }
  }
}
