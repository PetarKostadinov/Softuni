function solve() {
  let inputText = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;

  let result = '';

  let splitedInputText = inputText.split(' ');

  if (convention === 'Camel Case'){

    splitedInputText.forEach((element, index) => {
      
        if (index === 0){

          return result += element.toLowerCase()

        };

        return result += element[0].toUpperCase() + element.substring(1).toLowerCase();

    });

  }else if (convention === 'Pascal Case'){

    splitedInputText.forEach((element) => {

      return result += element[0].toUpperCase() + element.substring(1).toLowerCase();

    });

  }else {

    result = 'Error!';

  };

  document.getElementById('result').textContent = result;
};