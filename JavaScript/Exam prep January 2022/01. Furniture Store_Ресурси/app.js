window.addEventListener('load', solve);

function solve() {

    let obj = {

        model: document.getElementById('model'),
        year: document.getElementById('year'),
        description: document.getElementById('description'),
        price: document.getElementById('price')
    }

    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', onAdd);

    function onAdd(ev) {

        ev.preventDefault();
        let model = obj.model.value;
        let year = obj.year.value;
        let description = obj.description.value;
        let price = Number(obj.price.value);
        let check1 = Number(price) > 0 ? true : false;
        let check2 = Number(year) > 0 ? true : false;

        if (model == '' || year == '' || description == '' || check1 == false || check2 == false) {
            return
        }
        
        let furnitureList = document.getElementById('furniture-list');

        let trClassInfo = document.createElement('tr');
        trClassInfo.classList = 'info';

        let tdModel = document.createElement('td');
        tdModel.textContent = model;

        let tdPrice = document.createElement('td');
        tdPrice.textContent = price.toFixed(2);

        let tdButtons = document.createElement('td');
        
        let moreBtn = document.createElement('button');
        moreBtn.textContent = 'More Info';
        moreBtn.classList.add('moreBtn');

        let buyBtn = document.createElement('button');
        buyBtn.classList.add('buyBtn');
        buyBtn.textContent = 'Buy it';

        let trClassHide = document.createElement('tr');
        trClassHide.classList = 'hide';

        let tdYear = document.createElement('td');
        tdYear.textContent = `Year: ${year}`;

        let tdDescription = document.createElement('td');
        tdDescription.setAttribute('colspan', 3);
        tdDescription.textContent = `Description: ${description}`;

        trClassInfo.appendChild(tdModel);
        trClassInfo.appendChild(tdPrice);
        tdButtons.appendChild(moreBtn);
        tdButtons.appendChild(buyBtn);
        trClassHide.appendChild(tdYear);
        trClassHide.appendChild(tdDescription);
        furnitureList.appendChild(trClassInfo);
        trClassInfo.appendChild(tdButtons);
        furnitureList.appendChild(trClassHide);

        obj.model.value = '';
        obj.year.value = '';
        obj.description.value = '';
        obj.price.value = '';

        moreBtn.addEventListener('click', onMore);
        function onMore(ev) {

            if (ev.currentTarget.textContent == 'More Info') {

                trClassHide.style.display = 'contents';
                ev.currentTarget.textContent = 'Less Info';
            } else {

                trClassHide.style.display = 'none';
                ev.currentTarget.textContent = 'More Info';
            }
        }

        buyBtn.addEventListener('click', onBuy);
        function onBuy(ev) {

            ev.currentTarget.parentElement.parentElement.remove();
            tdYear.remove();
            tdDescription.remove();
            let total = parseFloat(document.getElementsByClassName('total-price')[0].textContent);
            let currPrice = parseFloat(tdPrice.textContent);
            total += currPrice;
            document.getElementsByClassName('total-price')[0].textContent = total.toFixed(2);
        }
    }
}
