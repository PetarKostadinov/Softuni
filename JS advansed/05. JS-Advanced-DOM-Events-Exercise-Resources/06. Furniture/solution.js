function solve() {

  const table = document.querySelector('tbody')

  const [input, output] = Array.from(document.querySelectorAll('textarea'))

  const[generate, buy] = Array.from(document.querySelectorAll('button'));

  generate.addEventListener('click', onGenerate);

  buy.addEventListener('click', onBuy);

  function onGenerate (e){

    const data = JSON.parse(input.value)

    for (let item of data){

      const row = document.createElement('tr');

      const imgCell = document.createElement('td');
      const nameCell = document.createElement('td');
      const priceCell = document.createElement('td');
      const decorationCell = document.createElement('td');
      const markCell = document.createElement('td');

      const img = document.createElement('img');
      img.src = item.img;
      imgCell.appendChild(img);

      const nameP = document.createElement('p');
      nameP.textContent = item.name
      nameCell.appendChild(nameP)

      const priceP = document.createElement('p');
      priceP.textContent = item.price;
      priceCell.append(priceP);

      const decorationP = document.createElement('p');
      decorationP.textContent = item.decFactor;
      decorationCell.appendChild(decorationP);

      const check = document.createElement('input');
      check.type = 'checkbox';
      markCell.appendChild(check);

      row.appendChild(imgCell);
      row.appendChild(nameCell);
      row.appendChild(priceCell);
      row.appendChild(decorationCell);
      row.appendChild(markCell);

      table.appendChild(row);

    }
  }

  function onBuy(e){

    const furniture = Array
      .from(document.querySelectorAll('input[type="checkbox"]:checked'))
      .map(b => b.parentElement.parentElement)
      .map(r => ({
          name: r.children[1].textContent,
          price: Number(r.children[2].textContent),
          decFactor: Number(r.children[3].textContent)
        }));

    let names = [];
    let total = 0;
    let decFactor = 0;

    for (let item of furniture) {
      
      names.push(item.name);
      total += item.price;
      decFactor += item.decFactor
    }

    const result = `Bought furniture: ${names.join(', ')}\r\nTotal price: ${total.toFixed(2)}\r\nAverage decoration factor: ${decFactor / furniture.length}`;


    output.value = result;

  }
  
}
