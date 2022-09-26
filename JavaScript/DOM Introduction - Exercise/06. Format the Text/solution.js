function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');
  output.innerHTML = '';
  let arrText = input.split('.').filter(x => x.length > 0);

  for (let i = 0; i < arrText.length; i+= 3) {

    let result = [];

    for (let x = 0; x < 3; x++) {

      if (arrText[i + x]){

        result.push(arrText[i + x]);
      };
    };

    let resultText = result.join('. ') + '.'.trim();

    output.innerHTML += `<p>${resultText}</p>`
  };
}