function solve() {
    const obj = {
        name: document.getElementById('container').children[0],
        age: document.getElementById('container').children[1],
        kind: document.getElementById('container').children[2],
        currOwner: document.getElementById('container').children[3],
    }

    const addBtn = document.getElementById('container').children[4];

    addBtn.addEventListener('click', onAdd);

    function onAdd(ev) {
        ev.preventDefault()

        let name = obj.name.value
        let age = Number(obj.age.value)
        let kind = obj.kind.value
        let currOwner = obj.currOwner.value

        if (name == '' || isNaN(age) || age == '' || kind == '' || currOwner == '' || age < 0) {
            return
        }

        let li = document.createElement('li')
        let p = document.createElement('p')
        p.innerHTML = `<strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong>`

        let span = document.createElement('span')
        span.textContent = `Owner: ${currOwner}`

        let contactBTN = document.createElement('button')
        contactBTN.textContent = `Contact with owner`

        li.appendChild(p)
        li.appendChild(span)
        li.appendChild(contactBTN)

        let idAdoption = document.getElementById('adoption').children[1]

        idAdoption.appendChild(li)

        let div = document.createElement('div')
        let input = document.createElement('input')
        input.placeholder = `Enter your names`        

        obj.name.value = ''
        obj.age.value = ''
        obj.kind.value = ''
        obj.currOwner.value = ''

        contactBTN.addEventListener('click', onContact)

        function onContact(ev) {

            if (ev.currentTarget.textContent == `Contact with owner`) {

                li.appendChild(div)
                div.appendChild(input)
                div.appendChild(contactBTN)
                contactBTN.textContent =  'Yes! I take it!';
               
            } else if (ev.currentTarget.textContent == 'Yes! I take it!') {

                if (input.value.trim() == '') return;

                li.appendChild(contactBTN);
                document.querySelector('#adopted ul').appendChild(li);
                contactBTN.textContent =  'Checked';
                span.textContent = `New Owner: ${input.value}`;
                div.remove();

            } else if (ev.currentTarget.textContent == 'Checked') {
                li.remove();
            }
        }
    }
}


