function validate() {
    let input = document.getElementById('email')
    input.addEventListener('change', (e) => {

        let regex = /^[a-z]+@[a-z]+.[a-z]+$/;
        !regex.test(e.target.value) ? e.target.classList.add('error') : e.target.classList.remove('error');

    });
}