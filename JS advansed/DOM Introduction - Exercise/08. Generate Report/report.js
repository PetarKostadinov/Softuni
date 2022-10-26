function generateReport() {
    let checkBoxes = Array.from(document.querySelectorAll('th')).map(h => h.children[0]);

    let rows = [...document.querySelectorAll('tbody tr')];

    let result = [];

        rows.forEach(row => {

            let currRow = Array.from(row.children).reduce((obj, prop, index) => {

                if(checkBoxes[index].checked){

                    let headerName = checkBoxes[index].name;
                    obj[headerName] = prop.innerText;
                };

                return obj;
            }, {})

            result.push(currRow);
        })

       
        document.querySelector('#output').value = JSON.stringify(result);
       
}