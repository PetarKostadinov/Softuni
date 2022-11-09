
async function lockedProfile() {

    const main = document.querySelector('main');
    main.innerHTML = '';

    try {

        const url = `http://localhost:3030/jsonstore/advanced/profiles`;

        const response = await fetch(url);
        const data = await response.json();

        let count = 1;

        Object.values(data).forEach(profile => {

            let div = createElement('div', 'profile', main);

            div.innerHTML += '<img src="./iconProfile2.png" class="userIcon" />';
            div.innerHTML += '<label>Lock</label>';
            div.innerHTML += `<input type="radio" name="user${count}Locked" value="lock" checked>`;
            div.innerHTML += '<label>Unlock</label>';
            div.innerHTML += `<input type="radio" name="user${count}Locked" value="unlock"><br>`;
            div.innerHTML += '<hr>';
            div.innerHTML += '<label>Username</label>';
            div.innerHTML += `<input type="text" name="user${count}Username" value="${profile.username}" disabled readonly />`;

            let hiddenFields = createElement('div', null, div);
            hiddenFields.setAttribute('id', `user${count}HiddenFields`);
            hiddenFields.style.display = 'none';

            hiddenFields.innerHTML += '<hr>';
            hiddenFields.innerHTML += '<label>Email:</label>';
            hiddenFields.innerHTML += `<input type="email" name="user${count}Email" value="${profile.email}" disabled readonly />`;
            hiddenFields.innerHTML += '<label>Age:</label>';
            hiddenFields.innerHTML += `<input type="email" name="user${count}Age" value="${profile.age}" disabled readonly />`;

            let button = createElement('button', null, div);
            button.textContent = 'Show more';

            count++;
        });

    } catch {

        throw new Error('Error with fetch');
    }

    let buttons = Array.from(document.getElementsByTagName('button'));
    buttons.forEach(btn => {
        btn.addEventListener('click', showOnClick);
    });

    function showOnClick(event) {

        let parentDiv = event.target.parentNode;
        let hiddenInfo = parentDiv.getElementsByTagName('div')[0];
        let lock = parentDiv.getElementsByTagName('input')[0];

        if (!lock.checked) {
            if (event.target.textContent === 'Show more') {

                hiddenInfo.style.display = 'inline';
                event.target.textContent = 'Hide it';

            } else {
                hiddenInfo.style.display = 'none';
                event.target.textContent = 'Show more';
            }
        }
    }

    function createElement(type, className, appender) {

        let result = document.createElement(type);

        if (className) {
            result.classList.add(className);
        }

        appender.appendChild(result);

        return result;
    }

};


//alternayive - 75/100

// function lockedProfile() {

//     let template = document.querySelector('.profile');
//         template.remove();

//     try {

//         (async () => {
//             const url = `http://localhost:3030/jsonstore/advanced/profiles`

//             let main = document.getElementById('main');

//             const res = await fetch(url)
//             const data = await res.json()

//             Object.keys(data).forEach((key, i) => {

//                 let profile = data[key];
//                 let htmlProfile = create(i + 1, profile.username, profile.email, profile.age);
//                 main.appendChild(htmlProfile);
//             })

//         })();

//         function create(ind, username, email, age) {
//             let profileDiv = document.createElement('div');
//             profileDiv.classList.add('profile');
//             let img = document.createElement('img');
//             img.src = './iconProfile2.png';
//             img.classList.add('userIcon');
//             let lockLabel = document.createElement('label');
//             lockLabel.textContent = 'Lock';
//             let inputLock = document.createElement('input');
//             inputLock.type = 'radio';
//             inputLock.value = 'lock';
//             inputLock.name = `user${ind}Locked`;
//             inputLock.checked = true;

//             let unlockLabel = document.createElement('label');
//             unlockLabel.textContent = 'Unlock';
//             let inputUnLock = document.createElement('input');
//             inputUnLock.type = 'radio';
//             inputUnLock.value = 'unlock';
//             inputUnLock.name = `user${ind}Locked`;
//             inputUnLock.checked = false;
//             let br = document.createElement('br');
//             let hr = document.createElement('hr');
//             let labelUser = document.createElement('label');
//             labelUser.textContent = `Username`;
//             let inputUser = document.createElement('input');
//             inputUser.type = 'text';
//             inputUser.name = `user${ind}Username`;
//             inputUser.value = username;
//             inputUser.readOnly = true;
//             inputUser.disabled = true;
//             let divUser = document.createElement('div');
//             divUser.style.display = 'none'
//             divUser.classList.add(`user${ind}Username`);
//             let hidenHr = document.createElement('hr');
//             let labelEmail = document.createElement('label');
//             labelEmail.textContent = `Email:`;
//             let inputEmail = document.createElement('input');
//             inputEmail.name = `user${ind}Email`;
//             inputEmail.value = email;
//             inputEmail.readOnly = true;
//             inputEmail.disabled = true;
//             inputEmail.type = 'email'
//             let labelAge = document.createElement('label');
//             labelAge.textContent = `Age:`;
//             let inputAge = document.createElement('input');
//             inputAge.name = `user${ind}Age`;
//             inputAge.value = age;
//             inputAge.readOnly = true;
//             inputAge.disabled = true;
//             inputAge.type = 'input';
//             let btn = document.createElement('button');
//             btn.textContent = `Show more`;
//             btn.addEventListener('click', onClick)

//             profileDiv.appendChild(img);
//             profileDiv.appendChild(lockLabel);
//             profileDiv.appendChild(inputLock);
//             profileDiv.appendChild(unlockLabel);
//             profileDiv.appendChild(inputUnLock);
//             profileDiv.appendChild(br);
//             profileDiv.appendChild(hr);
//             profileDiv.appendChild(labelUser);
//             profileDiv.appendChild(inputUser);
//             profileDiv.appendChild(divUser);
//             divUser.appendChild(hidenHr);
//             divUser.appendChild(labelEmail);
//             divUser.appendChild(inputEmail);
//             divUser.appendChild(labelAge);
//             divUser.appendChild(inputAge);
//             profileDiv.appendChild(btn);

//             return profileDiv;
//         }


//     } catch {

//         throw new Error('Error')
//     }

//     function onClick(ev) {

//         let profile = ev.target.parentElement;
//         let btn = ev.target;
//         let hidenFieldsDiv = ev.target.previousElementSibling;
//         let radioBtn = profile.querySelector(`input[type='radio']:checked`);

//         if (radioBtn.value !== 'unlock') {
//             return;
//         }

//         btn.textContent = btn.textContent === 'Show more'
//             ? 'Hide it'
//             : 'Show more';

//         hidenFieldsDiv.style.display = hidenFieldsDiv.style.display === 'block'
//             ? 'none'
//             : 'block';
//     }

// }