function solve() {

    let obj = {

        task: document.getElementById('task'),
        description: document.getElementById('description'),
        date: document.getElementById('date')
    }

    let addBtn = document.getElementById('add')
    addBtn.addEventListener('click', onAdd);

    function onAdd(ev) {
        ev.preventDefault();

        let task = obj.task.value;
        let description = obj.description.value;
        let date = obj.date.value;

        if (task == '' || description == '' || date == '') {
            return;
        }

        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        let p1Descr = document.createElement('p');
        let p2Date = document.createElement('p');
        let div = document.createElement('div');
        let startBtn = document.createElement('button');
        let deleteBtn = document.createElement('button');

        h3.textContent = `${task}`;
        p1Descr.textContent = `Description: ${description}`;
        p2Date.textContent = `Due Date: ${date}`;
        div.classList.add('flex')
        startBtn.classList = 'green'
        startBtn.textContent = 'Start'
        deleteBtn.classList = 'red'
        deleteBtn.textContent = 'Delete'

        let divToAdd = document.querySelector("body > main > div > section:nth-child(2) > div:nth-child(2)")

        article.appendChild(h3);
        article.appendChild(p1Descr);
        article.appendChild(p2Date);
        article.appendChild(div);
        div.appendChild(startBtn);
        div.appendChild(deleteBtn);
        divToAdd.appendChild(article);

        startBtn.addEventListener('click', onStart);

        function onStart(ev) {

            if(ev.currentTarget.textContent == 'Delete'){
                article.remove()
            }

            if(ev.currentTarget.textContent == 'Start'){

                let divInProg = document.getElementById('in-progress')
                startBtn.classList = 'red'
                startBtn.textContent = 'Delete'
                deleteBtn.classList = 'orange'
                deleteBtn.textContent = 'Finish'
    
                divInProg.appendChild(article)
            }
             
        }

        deleteBtn.addEventListener('click', onDelete)
        
        function onDelete(ev) {

            if(deleteBtn.textContent == 'Delete'){
                article.remove();
            }
            if(deleteBtn.textContent == 'Finish'){
                let divComlete = document.querySelector("body > main > div > section:nth-child(4) > div:nth-child(2)")

                divComlete.appendChild(article);
                div.remove();
            } 
        }
    }
}