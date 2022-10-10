function deleteByEmail() {

    let input = document.querySelector('input[name="email"]').value;

    const rows = document.querySelectorAll('tbody tr');

    const result = document.getElementById('result');

    for (const row of rows) {
        
        if(row.children[1].textContent === input){

            row.remove();

            result.textContent = 'Deleted';
        }else{

            result.textContent = 'Not found.';
        };

      
    }

    
    document.querySelector('input[name="email"]').value = '';
    
}